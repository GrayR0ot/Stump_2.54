using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachCharactersMessage : Message
    {
        public const uint Id = 6811;
        public IEnumerable<ulong> characters;

        public BreachCharactersMessage(IEnumerable<ulong> characters)
        {
            this.characters = characters;
        }

        public BreachCharactersMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) characters.Count());
            foreach (var objectToSend in characters) writer.WriteVarULong(objectToSend);
        }

        public override void Deserialize(IDataReader reader)
        {
            var charactersCount = reader.ReadUShort();
            var characters_ = new ulong[charactersCount];
            for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
                characters_[charactersIndex] = reader.ReadVarULong();
            characters = characters_;
        }
    }
}