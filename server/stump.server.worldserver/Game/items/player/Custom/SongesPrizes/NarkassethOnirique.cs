/*using Stump.Core.Extensions;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.NARKASSETH_1)]
    public class NarkassethOnirique : BasePlayerItem
    {
        public NarkassethOnirique(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {

            Dictionary<int, double> Items = new Dictionary<int, double>();
            
            Items.Add(6799, 5);
            Items.Add(6804, 5);
            Items.Add(6805, 5);
            Items.Add(6807, 5);


            Random rnd = new Random();
            var randomfinded = rnd.Next(0, 1000) / 100d;

            var Sort = Items.Where(x => x.Value >= randomfinded);
            if (Sort.RandomElementOrDefault().Key == 5)
            {
                Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key), 1);
            }
            else if (Sort.RandomElementOrDefault().Key == 5)
            {
                Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key), 1);
            }
            else if (Sort.RandomElementOrDefault().Key == 5)
            {
                Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key), 1);
            }
            else if (Sort.RandomElementOrDefault().Key == 5)
            {
                Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key), 1);
            }
            Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key), 1);
                Owner.SendServerMessage("Vous avez remporté un nouvel objet.");
                return 1;
        }
    }
}
*/
