using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StartupActionsAllAttributionMessage : Message
    {
        public const uint Id = 6537;

        public StartupActionsAllAttributionMessage(ulong characterId)
        {
            CharacterId = characterId;
        }

        public StartupActionsAllAttributionMessage()
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