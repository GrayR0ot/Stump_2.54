using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MoodSmileyResultMessage : Message
    {
        public const uint Id = 6196;

        public MoodSmileyResultMessage(sbyte resultCode, ushort smileyId)
        {
            ResultCode = resultCode;
            SmileyId = smileyId;
        }

        public MoodSmileyResultMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ResultCode { get; set; }
        public ushort SmileyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ResultCode);
            writer.WriteVarUShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ResultCode = reader.ReadSByte();
            SmileyId = reader.ReadVarUShort();
        }
    }
}