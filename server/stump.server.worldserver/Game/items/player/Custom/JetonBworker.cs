using Stump.Core.Extensions;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.JETON_DU_BWORKER_6885)]
    public class JetonBworker : BasePlayerItem
    {
        public JetonBworker(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
        {

            Dictionary<int, double> Items = new Dictionary<int, double>();

            //AJOUT DES ITEMS ID / Chance/100
            //Items Chacha
            Items.Add(6799, 5);
            Items.Add(6804, 5);
            Items.Add(6805, 5);
            Items.Add(6807, 5);
            Items.Add(6811, 5);
            Items.Add(6812, 5);
            Items.Add(6813, 5);
            Items.Add(14400, 10);
            Items.Add(14401, 10);
            Items.Add(14402, 10);
            Items.Add(14403, 10);
            Items.Add(14404, 10);
            Items.Add(14405, 10);
            Items.Add(14406, 10);
            Items.Add(14407, 10);
            Items.Add(14408, 10);
            Items.Add(14449, 10);


            Random rnd = new Random();
            var randomfinded = rnd.Next(0, 1000) / 100d;

            var Sort = Items.Where(x => x.Value >= randomfinded);

            if (Sort != null)
            {
                Owner.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key), 1);
                Owner.OpenPopup("Vous avez remporté un nouvel objet ! Allez le découvrir tout de suite dans votre inventaire !");
            }
            else
            {
                Owner.OpenPopup("Vous avez perdu !");
            }
            return 1;
        }


    }

}
