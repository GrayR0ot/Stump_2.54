using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterNameSuggestionFailureMessage : Message
    {
        public const uint Id = 164;

        public CharacterNameSuggestionFailureMessage(sbyte reason)
        {
            Reason = reason;
        }

        public CharacterNameSuggestionFailureMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}