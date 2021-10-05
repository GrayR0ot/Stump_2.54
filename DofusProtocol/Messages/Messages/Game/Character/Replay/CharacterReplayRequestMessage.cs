using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterReplayRequestMessage : Message
    {
        public const uint Id = 167;

        public CharacterReplayRequestMessage(ulong characterId)
        {
            CharacterId = characterId;
        }

        public CharacterReplayRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarULong();
        }
    }
}