using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharactersListWithRemodelingMessage : CharactersListMessage
    {
        public new const uint Id = 6550;

        public CharactersListWithRemodelingMessage(CharacterBaseInformations[] characters, bool hasStartupActions,
            CharacterToRemodelInformations[] charactersToRemodel)
        {
            Characters = characters;
            HasStartupActions = hasStartupActions;
            CharactersToRemodel = charactersToRemodel;
        }

        public CharactersListWithRemodelingMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterToRemodelInformations[] CharactersToRemodel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) CharactersToRemodel.Count());
            for (var charactersToRemodelIndex = 0;
                charactersToRemodelIndex < CharactersToRemodel.Count();
                charactersToRemodelIndex++)
            {
                var objectToSend = CharactersToRemodel[charactersToRemodelIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var charactersToRemodelCount = reader.ReadUShort();
            CharactersToRemodel = new CharacterToRemodelInformations[charactersToRemodelCount];
            for (var charactersToRemodelIndex = 0;
                charactersToRemodelIndex < charactersToRemodelCount;
                charactersToRemodelIndex++)
            {
                var objectToAdd = new CharacterToRemodelInformations();
                objectToAdd.Deserialize(reader);
                CharactersToRemodel[charactersToRemodelIndex] = objectToAdd;
            }
        }
    }
}