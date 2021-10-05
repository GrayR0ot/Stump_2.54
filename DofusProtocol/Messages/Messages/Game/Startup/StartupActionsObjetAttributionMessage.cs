using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StartupActionsObjetAttributionMessage : Message
    {
        public const uint Id = 1303;

        public StartupActionsObjetAttributionMessage(int actionId, ulong characterId)
        {
            ActionId = actionId;
            CharacterId = characterId;
        }

        public StartupActionsObjetAttributionMessage()
        {
        }

        public override uint MessageId => Id;

        public int ActionId { get; set; }
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ActionId);
            writer.WriteVarULong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadInt();
            CharacterId = reader.ReadVarULong();
        }
    }
}