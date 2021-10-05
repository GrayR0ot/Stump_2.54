using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AbstractGameActionMessage : Message
    {
        public const uint Id = 1000;

        public AbstractGameActionMessage(uint actionId, double sourceId)
        {
            ActionId = actionId;
            SourceId = sourceId;
        }

        public AbstractGameActionMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ActionId { get; set; }
        public double SourceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ActionId);
            writer.WriteDouble(SourceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUShort();
            SourceId = reader.ReadDouble();
        }
    }
}