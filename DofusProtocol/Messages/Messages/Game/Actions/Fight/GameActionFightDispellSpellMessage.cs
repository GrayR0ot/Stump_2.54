using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
    {
        public new const uint Id = 6176;

        public GameActionFightDispellSpellMessage(ushort actionId, double sourceId, double targetId, bool verboseCast,
            ushort spellId)
        {
            ActionId = actionId;
            SourceId = sourceId;
            TargetId = targetId;
            VerboseCast = verboseCast;
            SpellId = spellId;
        }

        public GameActionFightDispellSpellMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SpellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUShort();
        }
    }
}