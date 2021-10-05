using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdolSelectErrorMessage : Message
    {
        public const uint Id = 6584;

        public IdolSelectErrorMessage(bool activate, bool party, sbyte reason, ushort idolId)
        {
            Activate = activate;
            Party = party;
            Reason = reason;
            IdolId = idolId;
        }

        public IdolSelectErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Activate { get; set; }
        public bool Party { get; set; }
        public sbyte Reason { get; set; }
        public ushort IdolId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, Activate);
            flag = BooleanByteWrapper.SetFlag(flag, 1, Party);
            writer.WriteByte(flag);
            writer.WriteSByte(Reason);
            writer.WriteVarUShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Activate = BooleanByteWrapper.GetFlag(flag, 0);
            Party = BooleanByteWrapper.GetFlag(flag, 1);
            Reason = reader.ReadSByte();
            IdolId = reader.ReadVarUShort();
        }
    }
}