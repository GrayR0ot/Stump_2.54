using Stump.DofusProtocol.Types;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.Characters;

namespace Stump.Server.WorldServer.Database.Shortcuts
{
    public class ItemShortcutRelator
    {
        public static string FetchQuery = "SELECT * FROM characters_shortcuts_items";

        /// <summary>
        ///     Use string.Format
        /// </summary>
        public static string FetchByOwner = "SELECT * FROM characters_shortcuts_items WHERE OwnerId={0}";
    }

    [TableName("characters_shortcuts_items")]
    public class ItemShortcut : Shortcut, IAutoGeneratedRecord
    {
        private int m_itemGuid;

        private int m_itemTemplateId;

        public ItemShortcut()
        {
        }

        public ItemShortcut(CharacterRecord owner, int slot, int itemTemplateId, int itemGuid)
            : base(owner, slot)
        {
            ItemTemplateId = itemTemplateId;
            ItemGuid = itemGuid;
        }

        public int ItemTemplateId
        {
            get => m_itemTemplateId;
            set
            {
                m_itemTemplateId = value;
                IsDirty = true;
            }
        }

        public int ItemGuid
        {
            get => m_itemGuid;
            set
            {
                m_itemGuid = value;
                IsDirty = true;
            }
        }

        public override DofusProtocol.Types.Shortcut GetNetworkShortcut()
        {
            return new ShortcutObjectItem((sbyte) Slot, ItemGuid, ItemTemplateId);
        }
    }
}