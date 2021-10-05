using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public new const short Id = 154;

        public GameRolePlayNamedActorInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, string name)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            Name = name;
        }

        public GameRolePlayNamedActorInformations()
        {
        }

        public override short TypeId => Id;

        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}