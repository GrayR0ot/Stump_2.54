using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public new const short Id = 3;

        public GameRolePlayMutantInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId,
            ushort monsterId, sbyte powerLevel)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            Name = name;
            HumanoidInfo = humanoidInfo;
            AccountId = accountId;
            MonsterId = monsterId;
            PowerLevel = powerLevel;
        }

        public GameRolePlayMutantInformations()
        {
        }

        public override short TypeId => Id;

        public ushort MonsterId { get; set; }
        public sbyte PowerLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(MonsterId);
            writer.WriteSByte(PowerLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadVarUShort();
            PowerLevel = reader.ReadSByte();
        }
    }
}