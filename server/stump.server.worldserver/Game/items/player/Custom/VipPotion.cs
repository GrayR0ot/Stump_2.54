using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Accounts;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Effects.Instances;
using System.Drawing;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.TICKET_VIP)]
    public class VipPotion : BasePlayerItem
    {
        public VipPotion(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {
            if(Owner.WorldAccount.Vip >= 1)
            {
                Owner.SendServerMessage("Vous êtes déjà VIP, vous ne pouvez pas l'être deux fois ...", Color.OrangeRed);
                return 0;
            }
            Owner.WorldAccount.Vip = 1;
            AccountManager.Instance.UpdateVip(Owner.WorldAccount);

            Owner.Account.UserGroupId = 2;
            Owner.AddOrnament(368);
            Owner.AddTitle(3);
            var item = Owner.Inventory.TryGetItem(ItemManager.Instance.TryGetTemplate(10861));
            if (Owner.WorldAccount.Vip >= 1 && !Owner.Inventory.HasItem(ItemManager.Instance.TryGetTemplate(10861)))
            {
                item = Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(10861), 1);
                item.Effects.Add(new EffectInteger(EffectsEnum.Effect_NonExchangeable_981, 1));
                item.Invalidate();
                Owner.Inventory.RefreshItem(item);
                item = Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(10861), 1);
            }

            if (item != null)
                Owner.Shortcuts.AddItemShortcut(19, item);

            if (Owner.WorldAccount.Vip >= 1 && !Owner.Inventory.HasItem(ItemManager.Instance.TryGetTemplate(30836)))
            {
                item = Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30836), 1);
                item.Effects.Add(new EffectInteger(EffectsEnum.Effect_NonExchangeable_981, 1));
                item.Invalidate();
                Owner.Inventory.RefreshItem(item);
            }

            if (item != null)
                Owner.Shortcuts.AddItemShortcut(18, item);

            if (Owner.WorldAccount.Vip >= 1 && !Owner.Inventory.HasItem(ItemManager.Instance.TryGetTemplate(30110)))
            {
                item = Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30110), 1);
                item.Effects.Add(new EffectInteger(EffectsEnum.Effect_NonExchangeable_981, 1));
                item.Invalidate();
                Owner.Inventory.RefreshItem(item);
            }

            if (item != null)
                Owner.Shortcuts.AddItemShortcut(17, item);

            Owner.DisplayNotification("Vous venez de devenir VIP, veuillez vous deco/reco pour avoir les bonus actifs sur votre compte!", NotificationEnum.INFORMATION);
            World.Instance.SendAnnounce("<b>" + Owner.Name + "</b> vient de devenir VIP, félicitez le !", Color.GreenYellow);

            return 1;
        }
    }
}
