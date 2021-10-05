using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectUseOnCharacterMessage : ObjectUseMessage
    {
        public new const uint Id = 3003;

        public ObjectUseOnCharacterMessage(uint objectUID, ulong characterId)
        {
            ObjectUID = objectUID;
            CharacterId = characterId;
        }

        public ObjectUseOnCharacterMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CharacterId = reader.ReadVarULong();
        }
    }
}