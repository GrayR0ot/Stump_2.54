using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("AddItem", typeof(NpcReply), typeof(NpcReplyRecord))]
    [Discriminator("Additem", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class AddItemReply : NpcReply
    {
        private ItemTemplate m_itemTemplate;

        public AddItemReply(NpcReplyRecord record)
            : base(record)
        {
        }

        public int ItemId
        {
            get => Record.GetParameter<int>(0U);
            set => Record.SetParameter(0U, value);
        }

        public ItemTemplate Item
        {
            get
            {
                ItemTemplate itemTemplate;
                if ((itemTemplate = m_itemTemplate) == null)
                    itemTemplate = m_itemTemplate = Singleton<ItemManager>.Instance.TryGetTemplate(ItemId);
                return itemTemplate;
            }
            set
            {
                m_itemTemplate = value;
                ItemId = value.Id;
            }
        }

        public uint Amount
        {
            get => Record.GetParameter<uint>(1U);
            set => Record.SetParameter(1U, value);
        }

        public override bool Execute(Npc npc, Character character)
        {
            bool flag;
            if (!base.Execute(npc, character))
            {
                flag = false;
            }
            else
            {
                var item = ItemManager.Instance.CreatePlayerItem(character, ItemId, (int) Amount, true);
                //BasePlayerItem playerItem = Singleton<ItemManager>.Instance.CreatePlayerItem(character, , false);
                character.Inventory.AddItem(item);
                character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE, 21, Amount, ItemId);
                flag = true;
            }

            return flag;
        }
    }
}