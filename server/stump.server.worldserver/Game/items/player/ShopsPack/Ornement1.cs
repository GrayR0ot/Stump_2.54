using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items.Player.Custom;

namespace Stump.Server.WorldServer.Game.Items.Player.ShopsPack
{
    [ItemId(ItemIdEnum.PACK_ORNEMENT1)]
    public class Ornement1 : BasePlayerItem
    {
        public Ornement1(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {

            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30963), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30964), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30965), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30966), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30967), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30968), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30945), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(30962), 1);

            return 1;
        }
    }
}
