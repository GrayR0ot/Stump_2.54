using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlaySpellAnimMessage : Message
    {
        public const uint Id = 6114;

        public GameRolePlaySpellAnimMessage(ulong casterId, ushort targetCellId, ushort spellId, short spellLevel)
        {
            CasterId = casterId;
            TargetCellId = targetCellId;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public GameRolePlaySpellAnimMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong CasterId { get; set; }
        public ushort TargetCellId { get; set; }
        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(CasterId);
            writer.WriteVarUShort(TargetCellId);
            writer.WriteVarUShort(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            CasterId = reader.ReadVarULong();
            TargetCellId = reader.ReadVarUShort();
            SpellId = reader.ReadVarUShort();
            SpellLevel = reader.ReadShort();
        }
    }
}