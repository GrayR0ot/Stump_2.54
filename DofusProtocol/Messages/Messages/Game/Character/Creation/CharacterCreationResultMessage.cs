using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterCreationResultMessage : Message
    {
        public const uint Id = 161;

        public CharacterCreationResultMessage(sbyte result)
        {
            Result = result;
        }

        public CharacterCreationResultMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadSByte();
        }
    }
}