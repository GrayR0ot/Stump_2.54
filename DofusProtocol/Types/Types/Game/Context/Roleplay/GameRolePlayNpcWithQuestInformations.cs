using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
    {
        public new const short Id = 383;

        public GameRolePlayNpcWithQuestInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, ushort npcId, bool sex, ushort specialArtworkId,
            GameRolePlayNpcQuestFlag questFlag)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            NpcId = npcId;
            Sex = sex;
            SpecialArtworkId = specialArtworkId;
            QuestFlag = questFlag;
        }

        public GameRolePlayNpcWithQuestInformations()
        {
        }

        public override short TypeId => Id;

        public GameRolePlayNpcQuestFlag QuestFlag { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            QuestFlag.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            QuestFlag = new GameRolePlayNpcQuestFlag();
            QuestFlag.Deserialize(reader);
        }
    }
}