using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items.Player.Custom;

namespace Stump.Server.WorldServer.Game.Items.Player.ShopsPack
{
    [ItemId(ItemIdEnum.PACK_PANO_PP)]
    public class Packpp : BasePlayerItem
    {
        public Packpp(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {

            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30239), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30240), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30241), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30242), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30121), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30122), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30123), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30124), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30671), 1);
            return 1;
        }
    }
}