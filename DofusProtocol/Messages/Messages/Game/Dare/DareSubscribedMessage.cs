using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareSubscribedMessage : Message
    {
        public const uint Id = 6660;

        public DareSubscribedMessage(bool success, bool subscribe, double dareId,
            DareVersatileInformations dareVersatilesInfos)
        {
            Success = success;
            Subscribe = subscribe;
            DareId = dareId;
            DareVersatilesInfos = dareVersatilesInfos;
        }

        public DareSubscribedMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Success { get; set; }
        public bool Subscribe { get; set; }
        public double DareId { get; set; }
        public DareVersatileInformations DareVersatilesInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, Success);
            flag = BooleanByteWrapper.SetFlag(flag, 1, Subscribe);
            writer.WriteByte(flag);
            writer.WriteDouble(DareId);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(flag, 0);
            Subscribe = BooleanByteWrapper.GetFlag(flag, 1);
            DareId = reader.ReadDouble();
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}