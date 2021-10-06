using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public new const short Id = 180;

        public GameRolePlayMountInformations(double contextualId, 
            EntityDispositionInformations disposition, EntityLook look, string name, string ownerName, byte level)
        {
            ContextualId = contextualId;
            Disposition = disposition;
            Look = look;
            Name = name;
            OwnerName = ownerName;
            Level = level;
        }

        public GameRolePlayMountInformations()
        {
        }

        public override short TypeId => Id;

        public string OwnerName { get; set; }
        public byte Level { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(OwnerName);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OwnerName = reader.ReadUTF();
            Level = reader.ReadByte();
        }
    }
}