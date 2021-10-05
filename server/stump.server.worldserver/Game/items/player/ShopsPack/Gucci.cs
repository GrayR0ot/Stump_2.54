using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items.Player.Custom;
using System;

namespace Stump.Server.WorldServer.Game.Items.Player.ShopsPack
{
    [ItemId(ItemIdEnum.PACK_GUCCI)]
    public class Gucci : BasePlayerItem
    {
        public Gucci(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {

            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(7220), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(31241), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(31242), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(31239), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(20988), 1);
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(31243), 1);

            Random rnd = new Random();
            int rand = rnd.Next(4);
            if (rand == 1)
            {
                Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(31240), 1);
            }
            return 1;
        }
    }
}
