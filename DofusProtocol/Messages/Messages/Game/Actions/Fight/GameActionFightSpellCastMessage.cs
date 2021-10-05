using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const uint Id = 1010;

        public GameActionFightSpellCastMessage(ushort actionId, double sourceId, bool silentCast, bool verboseCast,
            double targetId, short destinationCellId, sbyte critical, ushort spellId, short spellLevel,
            short[] portalsIds)
        {
            ActionId = actionId;
            SourceId = sourceId;
            SilentCast = silentCast;
            VerboseCast = verboseCast;
            TargetId = targetId;
            DestinationCellId = destinationCellId;
            Critical = critical;
            SpellId = spellId;
            SpellLevel = spellLevel;
            PortalsIds = portalsIds;
        }

        public GameActionFightSpellCastMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }
        public short[] PortalsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(SpellId);
            writer.WriteShort(SpellLevel);
            writer.WriteShort((short) PortalsIds.Count());
            for (var portalsIdsIndex = 0; portalsIdsIndex < PortalsIds.Count(); portalsIdsIndex++)
                writer.WriteShort(PortalsIds[portalsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUShort();
            SpellLevel = reader.ReadShort();
            var portalsIdsCount = reader.ReadUShort();
            PortalsIds = new short[portalsIdsCount];
            for (var portalsIdsIndex = 0; portalsIdsIndex < portalsIdsCount; portalsIdsIndex++)
                PortalsIds[portalsIdsIndex] = reader.ReadShort();
        }
    }
}