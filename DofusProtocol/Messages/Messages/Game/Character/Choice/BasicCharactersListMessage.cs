using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicCharactersListMessage : Message
    {
        public const uint Id = 6475;

        public BasicCharactersListMessage(CharacterBaseInformations[] characters)
        {
            Characters = characters;
        }

        public BasicCharactersListMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterBaseInformations[] Characters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Characters.Count());
            for (var charactersIndex = 0; charactersIndex < Characters.Count(); charactersIndex++)
            {
                var objectToSend = Characters[charactersIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var charactersCount = reader.ReadUShort();
            Characters = new CharacterBaseInformations[charactersCount];
            for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Characters[charactersIndex] = objectToAdd;
            }
        }
    }
}