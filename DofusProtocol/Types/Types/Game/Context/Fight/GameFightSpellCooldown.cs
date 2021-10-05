using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightSpellCooldown
    {
        public const short Id = 205;

        public GameFightSpellCooldown(int spellId, sbyte cooldown)
        {
            SpellId = spellId;
            Cooldown = cooldown;
        }

        public GameFightSpellCooldown()
        {
        }

        public virtual short TypeId => Id;

        public int SpellId { get; set; }
        public sbyte Cooldown { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
            writer.WriteSByte(Cooldown);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
            Cooldown = reader.ReadSByte();
        }
    }
}