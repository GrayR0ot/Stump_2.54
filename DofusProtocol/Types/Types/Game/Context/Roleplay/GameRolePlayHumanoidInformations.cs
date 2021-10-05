using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public new const short Id = 159;

        public GameRolePlayHumanoidInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            Name = name;
            HumanoidInfo = humanoidInfo;
            AccountId = accountId;
        }

        public GameRolePlayHumanoidInformations()
        {
        }

        public override short TypeId => Id;

        public HumanInformations HumanoidInfo { get; set; }
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(HumanoidInfo.TypeId);
            HumanoidInfo.Serialize(writer);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HumanoidInfo = ProtocolTypeManager.GetInstance<HumanInformations>(reader.ReadShort());
            HumanoidInfo.Deserialize(reader);
            AccountId = reader.ReadInt();
        }
    }
}