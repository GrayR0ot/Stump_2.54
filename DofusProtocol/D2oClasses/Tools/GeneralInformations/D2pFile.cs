using System;
using System.Collections.Generic;
using System.IO;
using Stump.Core.IO;

namespace D2pReader.GeneralInformations
{
    public class D2pFile
    {
        #region Vars

        public const long START_POSITION_END_OFFSET = 16;

        #endregion

        public D2pFile(string d2pFilePath)
        {
            if (Path.GetExtension(d2pFilePath) != ".d2p")
                throw new ArgumentException("Invalid file type, " + d2pFilePath + " is not a .d2p file");

            D2pFilePath = d2pFilePath;

            using (var _reader = new BigEndianReader(File.OpenRead(D2pFilePath)))
            {
                var param1 = _reader.ReadByte();
                var param2 = _reader.ReadByte();

                if (param1 != 2 || param2 != 1)
                    throw new ArgumentException("Invalid file header, " + D2pFilePath + " is not a valid .d2p file");


                _reader.BaseStream.Position = _reader.BaseStream.Length - START_POSITION_END_OFFSET;
                var position = _reader.ReadUInt();
                var compressedMapsCount = (int) _reader.ReadUInt();
                _reader.BaseStream.Position = position;


                CompressedMap compressedMap = null;

                for (var i = 0; i <= compressedMapsCount; i++)
                {
                    compressedMap = new CompressedMap(_reader, D2pFilePath);

                    if (compressedMap.IsInvalidMap)
                        continue;

                    CompressedMaps.Add(compressedMap.GetMapId(), compressedMap);
                }
            }
        }

        #region Properties

        public string D2pFilePath { get; }

        public Dictionary<uint, CompressedMap> CompressedMaps { get; } = new Dictionary<uint, CompressedMap>();

        #endregion
    }
}