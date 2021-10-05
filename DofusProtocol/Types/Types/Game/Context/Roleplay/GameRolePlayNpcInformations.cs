using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public new const short Id = 156;

        public GameRolePlayNpcInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, ushort npcId, bool sex, ushort specialArtworkId)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            NpcId = npcId;
            Sex = sex;
            SpecialArtworkId = specialArtworkId;
        }

        public GameRolePlayNpcInformations()
        {
        }

        public override short TypeId => Id;

        public ushort NpcId { get; set; }
        public bool Sex { get; set; }
        public ushort SpecialArtworkId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(NpcId);
            writer.WriteBoolean(Sex);
            writer.WriteVarUShort(SpecialArtworkId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarUShort();
            Sex = reader.ReadBoolean();
            SpecialArtworkId = reader.ReadVarUShort();
        }
    }
}