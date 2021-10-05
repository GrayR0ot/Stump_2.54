using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismFightAttackerAddMessage : Message
    {
        public const uint Id = 5893;

        public PrismFightAttackerAddMessage(ushort subAreaId, ushort fightId,
            CharacterMinimalPlusLookInformations attacker)
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            Attacker = attacker;
        }

        public PrismFightAttackerAddMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public CharacterMinimalPlusLookInformations Attacker { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SubAreaId);
            writer.WriteVarUShort(FightId);
            writer.WriteShort(Attacker.TypeId);
            Attacker.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUShort();
            FightId = reader.ReadVarUShort();
            Attacker = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
            Attacker.Deserialize(reader);
        }
    }
}