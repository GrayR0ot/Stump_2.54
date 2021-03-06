using Stump.DofusProtocol.Types;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.Characters;

namespace Stump.Server.WorldServer.Database.Shortcuts
{
    public class SpellShortcutRelator
    {
        public static string FetchQuery = "SELECT * FROM characters_shortcuts_spells";

        /// <summary>
        ///     Use string.Format
        /// </summary>
        public static string FetchByOwner = "SELECT * FROM characters_shortcuts_spells WHERE OwnerId={0}";
    }

    [TableName("characters_shortcuts_spells")]
    public class SpellShortcut : Shortcut, IAutoGeneratedRecord
    {
        private short m_spellId;

        public SpellShortcut()
        {
        }

        public SpellShortcut(CharacterRecord owner, int slot, short spellId) : base(owner, slot)
        {
            SpellId = spellId;
        }

        public short SpellId
        {
            get => m_spellId;
            set
            {
                m_spellId = value;
                IsDirty = true;
            }
        }

        public override DofusProtocol.Types.Shortcut GetNetworkShortcut()
        {
            return new ShortcutSpell((sbyte) Slot, (ushort) SpellId);
        }
    }
}