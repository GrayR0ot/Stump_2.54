using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using D2pReader.GeneralInformations;
using Stump.Core.IO;

namespace D2pReader.MapInformations
{
    public class Map
    {
        public Map(CompressedMap compressedMap, MapManager map)
        {
            InitializeReader(compressedMap);

            _encryptionKey = Encoding.UTF8.GetBytes(DefaultEncryptionKeyString);
            InitializeMap(_encryptionKey, map);

            _reader.Dispose();
        }


        private void InitializeReader(CompressedMap compressedMap)
        {
            var compressedMapStream = new FileStream(compressedMap.D2pFilePath, FileMode.Open, FileAccess.Read);
            var compressedMapReader = new BinaryReader(compressedMapStream);
            compressedMapReader.BaseStream.Position = compressedMap.Offset;

            var compressedMapBuffer = compressedMapReader.ReadBytes((int) compressedMap.BytesCount);
            var compressedMapBufferWithoutHeader = new byte[compressedMapBuffer.Length - 2];
            Array.Copy(compressedMapBuffer, 2, compressedMapBufferWithoutHeader, 0, compressedMapBuffer.Length - 2);

            var mapHashCodeBuilder = new StringBuilder();
            var compressedMapMd5Buffer = MD5.Create().ComputeHash(compressedMapBufferWithoutHeader);

            for (var i = 0; i < compressedMapMd5Buffer.Length; i++)
                mapHashCodeBuilder.Append(compressedMapMd5Buffer[i].ToString("X2"));

            HashCode = mapHashCodeBuilder.ToString();


            var decompressMapStream = new MemoryStream(compressedMapBufferWithoutHeader);
            var mapDeflateStream = new DeflateStream(decompressMapStream, CompressionMode.Decompress);

            _reader = new BigEndianReader(mapDeflateStream);
            compressedMapStream.Close();
        }

        private void InitializeMap(byte[] encryptionKey, MapManager map)
        {
            var readColor = 0;
            long gridAlpha = 0;
            var gridRed = 0;
            var gridGreen = 0;
            var gridBlue = 0;
            this.map = map;
            int header = _reader.ReadSByte();
            var dataLen = 0;
            var i = 0;
            var decryptionKey = encryptionKey;

            if (header != 77)
                throw new FormatException("Unknown file header, first byte must be 77");


            MapVersion = _reader.ReadSByte();
            Id = _reader.ReadUInt();

            if (MapVersion >= 7)
            {
                Encrypted = _reader.ReadBoolean();
                EncryptionVersion = (uint) _reader.ReadSByte();
                dataLen = _reader.ReadInt();

                if (Encrypted)
                {
                    var encryptedData = _reader.ReadBytes(dataLen);

                    for (i = 0; i < encryptedData.Length; i++)
                        encryptedData[i] = (byte) (encryptedData[i] ^ decryptionKey[i % decryptionKey.Length]);

                    _reader = new BigEndianReader(new MemoryStream(encryptedData));
                }
            }

            RelativeId = _reader.ReadUInt();
            Position = new WorldPoint(RelativeId);

            MapType = _reader.ReadSByte();
            SubareaId = _reader.ReadInt();
            TopNeighbourId = _reader.ReadInt();
            BottomNeighbourId = _reader.ReadInt();
            LeftNeighbourId = _reader.ReadInt();
            RightNeighbourId = _reader.ReadInt();
            ShadowBonusOnEntities = _reader.ReadUInt();

            if (MapVersion >= 9)
            {
                readColor = _reader.ReadInt();
                _backgroundAlpha = (readColor & 4278190080) >> 32;
                BackgroundRed = (readColor & 16711680) >> 16;
                BackgroundGreen = (readColor & 65280) >> 8;
                BackgroundBlue = readColor & 255;
                readColor = (int) _reader.ReadUInt();
                gridAlpha = (readColor & 4278190080) >> 32;
                gridRed = (readColor & 16711680) >> 16;
                gridGreen = (readColor & 65280) >> 8;
                gridBlue = readColor & 255;
                _gridColor = (((int) gridAlpha & 255) << 32) | ((gridRed & 255) << 16) | ((gridGreen & 255) << 8) |
                             (gridBlue & 255);
            }
            else if (MapVersion >= 3)
            {
                BackgroundRed = _reader.ReadSByte();
                BackgroundGreen = _reader.ReadSByte();
                BackgroundBlue = _reader.ReadSByte();
            }

            BackgroundColor = (uint) (((BackgroundRed & 255) << 16) | ((BackgroundGreen & 255) << 8) |
                                      (BackgroundBlue & 255));
            if (MapVersion >= 4)
            {
                ZoomScale = (ushort) (_reader.ReadUShort() / 100);
                ZoomOffsetX = _reader.ReadShort();
                ZoomOffsetY = _reader.ReadShort();
                if (ZoomScale < 1)
                {
                    ZoomScale = 1;
                    ZoomOffsetX = ZoomOffsetY = 0;
                }
            }

            if (MapVersion > 10) TacticalModeTemplateId = _reader.ReadInt();

            UseLowPassFilter = _reader.ReadSByte() == 1;
            UseReverb = _reader.ReadSByte() == 1;

            if (UseReverb)
                PresetId = _reader.ReadInt();
            else
                PresetId = -1;


            BackgroundsCount = _reader.ReadSByte();

            BackgroundFixtures = new List<Fixture>();

            for (i = 0; i < BackgroundsCount; i++)
            {
                var backgroundFixture = new Fixture(_reader);
                BackgroundFixtures.Add(backgroundFixture);
            }


            ForegroundsCount = _reader.ReadSByte();

            ForegroundFixtures = new List<Fixture>();

            for (i = 0; i < ForegroundsCount; i++)
            {
                var foregroundFixture = new Fixture(_reader);
                ForegroundFixtures.Add(foregroundFixture);
            }


            _reader.ReadInt();

            GroundCRC = _reader.ReadInt();
            LayersCount = _reader.ReadSByte();
            Layers = new List<Layer>();
            map.m_compressedElements = new List<byte>();
            for (i = 0; i < LayersCount; i++)
            {
                var layer = new Layer(_reader, (sbyte) MapVersion, map);
                Layers.Add(layer);
            }

            CellsCount = MAP_CELLS_COUNT;
            Cells = new CellData[CellsCount].ToList();
            m_compressedCells = new byte[Cells.ToArray().Length * 11];
            for (i = 0; i < CellsCount; i++)
            {
                var cell = new CellData(_reader, (sbyte) MapVersion, i);
                Cells[i] = cell;
                //System.Array.Copy(_cells[i].Serialize(), 0, m_compressedCells, i * 11, 11);
                // _cells.Add(cell);
            }
            /* for (i = 0; i < _cellsCount; i++)
             {
                 this.m_compressedCells = _cells.ToArray()[i].Serialize();
             }*/
            // this.map.m_compressedCells = ZipHelper.Compress(this.m_compressedCells);
        }

        #region Vars

        private BigEndianReader _reader;

        public const string DefaultEncryptionKeyString = "649ae451ca33ec53bbcbcc33becf15f4";
        private readonly byte[] _encryptionKey;
        private byte[] m_compressedCells;


        public const int MAP_CELLS_COUNT = 560;

        public MapManager map { get; set; }

        private long _backgroundAlpha;
        private long _gridColor;

        #endregion

        #region Properties

        public int MapVersion { get; private set; }

        public bool Encrypted { get; private set; }

        public uint EncryptionVersion { get; private set; }

        public int GroundCRC { get; private set; }

        public int ZoomScale { get; private set; } = 1;

        public int ZoomOffsetX { get; private set; }

        public int ZoomOffsetY { get; private set; }

        public int GroundCacheCurrentlyUsed { get; } = 0;

        public uint Id { get; private set; }

        public uint RelativeId { get; private set; }

        public int MapType { get; private set; }

        public int BackgroundsCount { get; private set; }

        public List<Fixture> BackgroundFixtures { get; private set; }

        public int ForegroundsCount { get; private set; }

        public List<Fixture> ForegroundFixtures { get; private set; }

        public int SubareaId { get; private set; }

        public uint ShadowBonusOnEntities { get; private set; }

        public uint BackgroundColor { get; private set; }

        public int BackgroundRed { get; private set; }

        public int BackgroundGreen { get; private set; }

        public int BackgroundBlue { get; private set; }

        public int TopNeighbourId { get; private set; }

        public int BottomNeighbourId { get; private set; }

        public int LeftNeighbourId { get; private set; }

        public int RightNeighbourId { get; private set; }

        public bool UseLowPassFilter { get; private set; }

        public bool UseReverb { get; private set; }

        public int PresetId { get; private set; }

        public int CellsCount { get; private set; }

        public int LayersCount { get; private set; }

        public bool IsUsingNewMovementSystem { get; } = false;

        public List<Layer> Layers { get; private set; }

        public List<CellData> Cells { get; private set; }

        public WorldPoint Position { get; private set; }

        public string HashCode { get; private set; }

        public int TacticalModeTemplateId { get; private set; }

        #endregion
    }
}