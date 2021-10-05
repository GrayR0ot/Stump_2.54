using Stump.Core.IO;

namespace D2pReader.GeneralInformations
{
    public class CompressedMap
    {
        #region Vars

        private readonly BigEndianReader _reader;

        #endregion

        public CompressedMap(BigEndianReader reader, string d2pFilePath)
        {
            _reader = reader;
            D2pFilePath = d2pFilePath;

            ReadMapInformation();
        }


        public uint GetMapId()
        {
            return uint.Parse(IndexName.Substring(IndexName.IndexOf('/') + 1).Replace(".dlm", ""));
        }

        private void ReadMapInformation()
        {
            IndexName = _reader.ReadUTF();

            if (IndexName == "link" || IndexName == "")
            {
                IsInvalidMap = true;
                return;
            }

            Offset = _reader.ReadUInt() + 2;
            BytesCount = _reader.ReadUInt();
        }

        #region Properties

        public string D2pFilePath { get; }

        public string IndexName { get; private set; }

        public uint Offset { get; private set; }

        public uint BytesCount { get; private set; }

        public bool IsInvalidMap { get; private set; }

        #endregion
    }
}