using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionAcknowledgementMessage : Message
    {
        public const uint Id = 957;

        public GameActionAcknowledgementMessage(bool valid, sbyte actionId)
        {
            Valid = valid;
            ActionId = actionId;
        }

        public GameActionAcknowledgementMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Valid { get; set; }
        public sbyte ActionId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Valid);
            writer.WriteSByte(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Valid = reader.ReadBoolean();
            ActionId = reader.ReadSByte();
        }
    }
}