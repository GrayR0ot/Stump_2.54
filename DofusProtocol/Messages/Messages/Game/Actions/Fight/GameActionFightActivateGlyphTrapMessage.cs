using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const uint Id = 6545;

        public GameActionFightActivateGlyphTrapMessage(ushort actionId, double sourceId, short markId, bool active)
        {
            ActionId = actionId;
            SourceId = sourceId;
            MarkId = markId;
            Active = active;
        }

        public GameActionFightActivateGlyphTrapMessage()
        {
        }

        public override uint MessageId => Id;

        public short MarkId { get; set; }
        public bool Active { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            Active = reader.ReadBoolean();
        }
    }
}