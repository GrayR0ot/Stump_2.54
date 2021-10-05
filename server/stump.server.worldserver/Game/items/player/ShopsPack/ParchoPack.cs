using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items.Player.Custom;

namespace Stump.Server.WorldServer.Game.Items.Player.ShopsPack
{
    [ItemId(ItemIdEnum.PARCHO_PACK)]
    public class ParchoPack : BasePlayerItem
    {
        public ParchoPack(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {

            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(797), 50);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(801), 50);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(805), 50);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(810), 50);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(814), 50);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(817), 50);

            return 1;
        }
    }
}
