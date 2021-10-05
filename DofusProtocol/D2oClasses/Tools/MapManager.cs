using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using D2pReader.GeneralInformations;
using D2pReader.MapInformations;
using zlib;

namespace D2pReader
{
    public class MapManager
    {
        /// <summary>
        ///     Creates a new instance of MapManager class.
        /// </summary>
        /// <param name="d2pfolder">Path to the folder containing d2p files.</param>
        public MapManager(string d2pfolder)
        {
            _d2pFolder = new D2pFolder(d2pfolder);
            _isInitialized = true;
        }

        /// <summary>
        ///     Retrieves a map from its ID.
        /// </summary>
        /// <param name="id">Map ID</param>
        /// <returns>Map object corresponding to the map with ID id. Returns NULL if no map found.</returns>
        public Map GetMap(uint id)
        {
            if (!_isInitialized)
                throw new Exception("MapManager is not initialized, please try again in a few seconds.");

            if (_parsedMaps.ContainsKey(id))
                return _parsedMaps[id];


            var compressedMap = GetCompressedMap(id);

            if (compressedMap == null)
                return null;

            var map = new Map(compressedMap, new MapManager(""));
            _parsedMaps.Add(map.Id, map);


            return _parsedMaps[id];
        }

        /// <summary>
        ///     Retrieves all maps found in the d2p files.
        /// </summary>
        /// <returns>A dictionary associating a map ID with the corresponding map object.</returns>
        public Dictionary<uint, Map> ParseAllMap(MapManager maps)
        {
            var allMaps = new Dictionary<uint, Map>();

            foreach (var d2pfile in _d2pFolder.FolderContent)
            {
                Console.WriteLine("Loading file :" + d2pfile.D2pFilePath);
                foreach (var CompressedMap in d2pfile.CompressedMaps.Values)
                {
                    var map = new Map(CompressedMap, maps);
                    allMaps.Add(map.Id, map);
                }
            }

            _parsedMaps = allMaps;


            return _parsedMaps;
        }

        /// <summary>
        ///     Retrieves a compressed map from its ID.
        /// </summary>
        /// <param name="id">Map ID</param>
        /// <returns>Compressed map object corresponding to the map with ID id. Returns NULL if no map found.</returns>
        private CompressedMap GetCompressedMap(uint id)
        {
            foreach (var d2pfile in _d2pFolder.FolderContent)
                if (d2pfile.CompressedMaps.ContainsKey(id))
                    return d2pfile.CompressedMaps[id];

            return null;
        }

        #region Vars

        private readonly D2pFolder _d2pFolder;
        private Dictionary<uint, Map> _parsedMaps = new Dictionary<uint, Map>();
        public byte[] m_compressedCells;

        public List<byte> m_compressedElements = new List<byte>();
        // public static byte[] m_compressedElements;

        private readonly bool _isInitialized;

        #endregion
    }

    public class ZipHelper
    {
        public static byte[] Compress(byte[] data)
        {
            var input = new MemoryStream(data);
            var memoryStream = new MemoryStream();
            Compress(input, memoryStream);
            return memoryStream.ToArray();
        }

        public static void Compress(Stream input, Stream output)
        {
            using (var gZipStream = new GZipStream(output, CompressionMode.Compress))
            {
                input.CopyTo(gZipStream);
            }
        }

        public static byte[] Uncompress(byte[] data)
        {
            var input = new MemoryStream(data);
            var memoryStream = new MemoryStream();
            Uncompress(input, memoryStream);
            return memoryStream.ToArray();
        }

        public static void Uncompress(Stream input, Stream output)
        {
            using (var gZipStream = new GZipStream(input, CompressionMode.Decompress, true))
            {
                gZipStream.CopyTo(output);
            }
        }

        public static void Deflate(Stream input, Stream output)
        {
            var zOutputStream = new ZOutputStream(output);
            var binaryReader = new BinaryReader(input);
            zOutputStream.Write(binaryReader.ReadBytes((int) input.Length), 0, (int) input.Length);
            zOutputStream.Flush();
        }
    }
}