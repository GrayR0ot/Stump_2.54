using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightNoSpellCastMessage : Message
    {
        public const uint Id = 6132;

        public GameActionFightNoSpellCastMessage(uint spellLevelId)
        {
            SpellLevelId = spellLevelId;
        }

        public GameActionFightNoSpellCastMessage()
        {
        }

        public override uint MessageId => Id;

        public uint SpellLevelId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(SpellLevelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellLevelId = reader.ReadVarUInt();
        }
    }
}