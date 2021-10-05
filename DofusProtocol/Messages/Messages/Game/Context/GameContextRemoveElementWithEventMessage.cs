using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
    {
        public new const uint Id = 6412;

        public GameContextRemoveElementWithEventMessage(double objectId, sbyte elementEventId)
        {
            ObjectId = objectId;
            ElementEventId = elementEventId;
        }

        public GameContextRemoveElementWithEventMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ElementEventId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ElementEventId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ElementEventId = reader.ReadSByte();
        }
    }
}