using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeHandleMountsMessage : Message
    {
        public const uint Id = 6752;

        public ExchangeHandleMountsMessage(sbyte actionType, uint[] ridesId)
        {
            ActionType = actionType;
            RidesId = ridesId;
        }

        public ExchangeHandleMountsMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ActionType { get; set; }
        public uint[] RidesId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ActionType);
            writer.WriteShort((short) RidesId.Count());
            for (var ridesIdIndex = 0; ridesIdIndex < RidesId.Count(); ridesIdIndex++)
                writer.WriteVarUInt(RidesId[ridesIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionType = reader.ReadSByte();
            var ridesIdCount = reader.ReadUShort();
            RidesId = new uint[ridesIdCount];
            for (var ridesIdIndex = 0; ridesIdIndex < ridesIdCount; ridesIdIndex++)
                RidesId[ridesIdIndex] = reader.ReadVarUInt();
        }
    }
}