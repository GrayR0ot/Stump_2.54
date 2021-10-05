using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CheckIntegrityMessage : Message
    {
        public const uint Id = 6372;

        public CheckIntegrityMessage(sbyte[] data)
        {
            Data = data;
        }

        public CheckIntegrityMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte[] Data { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(Data.Count());
            for (var dataIndex = 0; dataIndex < Data.Count(); dataIndex++) writer.WriteSByte(Data[dataIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var dataCount = reader.ReadVarInt();
            Data = new sbyte[dataCount];
            for (var dataIndex = 0; dataIndex < dataCount; dataIndex++) Data[dataIndex] = reader.ReadSByte();
        }
    }
}