using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public new const short Id = 36;

        public GameRolePlayCharacterInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId,
            ActorAlignmentInformations alignmentInfos)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            Name = name;
            HumanoidInfo = humanoidInfo;
            AccountId = accountId;
            AlignmentInfos = alignmentInfos;
        }

        public GameRolePlayCharacterInformations()
        {
        }

        public override short TypeId => Id;

        public ActorAlignmentInformations AlignmentInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }
    }
}