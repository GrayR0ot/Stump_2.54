//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Database.Items;
//using Stump.Server.WorldServer.Game.Actors.Look;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using System.Drawing;

//namespace Stump.Server.WorldServer.Game.Items.Player.Custom
//{
//    [ItemId(ItemIdEnum.COSTUME_CAME)]
//    public class CostumeCameleon : BasePlayerItem
//    {
//        public CostumeCameleon(Character owner, PlayerItemRecord record)
//            : base(owner, record)
//        {
//        }

//        public override ActorLook UpdateItemSkin(ActorLook characterLook)
//        {
//            if (IsEquiped())
//            {
//                characterLook.AddSkin(7409); //New ApparenceId
//                characterLook.AddColor(8, Owner.Guild.Emblem.SymbolColor);
//                characterLook.AddColor(6, Owner.Guild.Emblem.BackgroundColor);
//                characterLook.AddColor(7, Owner.Guild.Emblem.SymbolColor);
//            }
//            else
//            {
//                characterLook.RemoveSkin(7409); //New ApparenceId
//            }

//            return base.UpdateItemSkin(characterLook);
//        }
//    }
//}
