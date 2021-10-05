using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseKickRequestMessage : Message
    {
        public const uint Id = 5698;

        public HouseKickRequestMessage(ulong objectId)
        {
            ObjectId = objectId;
        }

        public HouseKickRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarULong();
        }
    }
}