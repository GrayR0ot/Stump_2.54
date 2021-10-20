using System.Collections.Generic;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Songes;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.NARKASSETH_ONIRIQUE_21950)]
    public class NarkassethOnirique : BasePlayerItem
    {
        public NarkassethOnirique(Character owner, PlayerItemRecord record)
        : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {
            List<ItemProbability> itemProbabilities = new List<ItemProbability>();
            itemProbabilities.Add(new ItemProbability(ItemManager.Instance.TryGetTemplate(0), 1, 43)); //Prsymaradite Ambrée
            itemProbabilities.Add(new ItemProbability(ItemManager.Instance.TryGetTemplate(20292), 2, 30)); //Prsymaradite Ambrée
            itemProbabilities.Add(new ItemProbability(ItemManager.Instance.TryGetTemplate(20292), 4, 15)); //Reflet Onirique
            itemProbabilities.Add(new ItemProbability(ItemManager.Instance.TryGetTemplate(20292), 4, 7)); //Reflet Onirique
            itemProbabilities.Add(new ItemProbability(ItemManager.Instance.TryGetTemplate(0), 1, 5)); //Rune astrale mineure
            itemProbabilities.Add(new ItemProbability(ItemManager.Instance.TryGetTemplate(20292), 20, 5)); //Reflet onirique
            BreachCrates songesCrates = new BreachCrates(itemProbabilities);
            ItemProbability itemProbability = songesCrates.open();
            target.Inventory.AddItem(itemProbability.itemTemplate, itemProbability.amount);
            return 1;
        }
    }
}
