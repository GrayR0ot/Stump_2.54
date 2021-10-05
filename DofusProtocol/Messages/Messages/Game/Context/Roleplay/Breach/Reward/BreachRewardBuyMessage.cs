using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachRewardBuyMessage : Message
    {
        public const uint Id = 6803;

        public BreachRewardBuyMessage(uint objectId)
        {
            ObjectId = objectId;
        }

        public BreachRewardBuyMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUInt();
        }
    }
}