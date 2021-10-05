using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterDeletionRequestMessage : Message
    {
        public const uint Id = 165;

        public CharacterDeletionRequestMessage(ulong characterId, string secretAnswerHash)
        {
            CharacterId = characterId;
            SecretAnswerHash = secretAnswerHash;
        }

        public CharacterDeletionRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong CharacterId { get; set; }
        public string SecretAnswerHash { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(CharacterId);
            writer.WriteUTF(SecretAnswerHash);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarULong();
            SecretAnswerHash = reader.ReadUTF();
        }
    }
}