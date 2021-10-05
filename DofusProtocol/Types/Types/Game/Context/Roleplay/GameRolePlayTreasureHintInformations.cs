using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
    {
        public new const short Id = 471;

        public GameRolePlayTreasureHintInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, ushort npcId)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            NpcId = npcId;
        }

        public GameRolePlayTreasureHintInformations()
        {
        }

        public override short TypeId => Id;

        public ushort NpcId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarUShort();
        }
    }
}