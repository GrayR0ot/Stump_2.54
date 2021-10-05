using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterSelectedForceMessage : Message
    {
        public const uint Id = 6068;

        public CharacterSelectedForceMessage(int objectId)
        {
            ObjectId = objectId;
        }

        public CharacterSelectedForceMessage()
        {
        }

        public override uint MessageId => Id;

        public int ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadInt();
        }
    }
}