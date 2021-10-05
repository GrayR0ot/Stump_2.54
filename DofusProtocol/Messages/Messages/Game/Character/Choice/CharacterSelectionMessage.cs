using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterSelectionMessage : Message
    {
        public const uint Id = 152;

        public CharacterSelectionMessage(ulong objectId)
        {
            ObjectId = objectId;
        }

        public CharacterSelectionMessage()
        {
        }

        public override uint MessageId => Id;

        public double ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong((ulong)ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarULong();
        }
    }
}