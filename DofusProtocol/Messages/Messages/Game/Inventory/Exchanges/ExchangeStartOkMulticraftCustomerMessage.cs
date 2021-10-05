using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeStartOkMulticraftCustomerMessage : Message
    {
        public const uint Id = 5817;

        public ExchangeStartOkMulticraftCustomerMessage(uint skillId, byte crafterJobLevel)
        {
            SkillId = skillId;
            CrafterJobLevel = crafterJobLevel;
        }

        public ExchangeStartOkMulticraftCustomerMessage()
        {
        }

        public override uint MessageId => Id;

        public uint SkillId { get; set; }
        public byte CrafterJobLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(SkillId);
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUInt();
            CrafterJobLevel = reader.ReadByte();
        }
    }
}