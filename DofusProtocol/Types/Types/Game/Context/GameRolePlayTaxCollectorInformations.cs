using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public new const short Id = 148;

        public GameRolePlayTaxCollectorInformations(double contextualId,
            EntityDispositionInformations disposition, EntityLook look, TaxCollectorStaticInformations Identification,
            byte GuildLevel,
            int TxCollectorAttack)
        {
            Disposition = disposition;
            ContextualId = contextualId;
            Look = look;
            Identification = Identification;
            GuildLevel = GuildLevel;
            TaxCollectorAttack = TaxCollectorAttack;
        }

        public GameRolePlayTaxCollectorInformations()
        {
        }

        public override short TypeId => Id;

        public TaxCollectorStaticInformations Identification { get; set; }
        public byte GuildLevel { get; set; }
        public int TaxCollectorAttack { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Identification.TypeId);
            Identification.Serialize(writer);
            writer.WriteByte(GuildLevel);
            writer.WriteInt(TaxCollectorAttack);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Identification = ProtocolTypeManager.GetInstance<TaxCollectorStaticInformations>(reader.ReadShort());
            Identification.Deserialize(reader);
            GuildLevel = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
        }
    }
}