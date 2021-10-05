using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const uint Id = 151;

        public CharactersListMessage(CharacterBaseInformations[] characters, bool hasStartupActions)
        {
            Characters = characters;
            HasStartupActions = hasStartupActions;
        }

        public CharactersListMessage()
        {
        }

        public override uint MessageId => Id;

        public bool HasStartupActions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(HasStartupActions);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HasStartupActions = reader.ReadBoolean();
        }
    }
}