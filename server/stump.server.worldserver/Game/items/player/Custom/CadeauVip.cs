//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Database.Items;
//using Stump.Server.WorldServer.Database.World;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Effects.Instances;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Stump.Server.WorldServer.Game.Items.Player.Custom
//{
//    [ItemId(ItemIdEnum.CADEAU_DE_FELICITATIONS_13144)]
//    public class CadeauVip : BasePlayerItem
//    {
//        public CadeauVip(Character owner, PlayerItemRecord record)
//        : base(owner, record)
//        {
//        }

//        public override uint UseItem(int amount = 1, Cell targetCell = null, Character target = null)
//        {
//            var item = ItemManager.Instance.TryGetTemplate(30649);
//            target.Inventory.AddItem(item, 1);
//            return 1;
//        }
//    }
//}
