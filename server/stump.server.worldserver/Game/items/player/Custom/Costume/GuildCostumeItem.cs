using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Game.Actors.Look;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.COSTUME_DE_GUILDE_18525)]
    public class GuildCostumeItem : BasePlayerItem
    {
        public GuildCostumeItem(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public SexTypeEnum Sex { get; private set; }

        public override ActorLook UpdateItemSkin(ActorLook characterLook)
        {
            if (IsEquiped())
            {
                if (Owner.Guild != null)
                {
                    if (Sex == SexTypeEnum.SEX_MALE)
                    {
                        characterLook.AddSkin(3492); //New ApparenceId
                        characterLook.AddSkin((short)Owner.Guild.Emblem.Template.SkinId);
                        characterLook.AddColor(8, Owner.Guild.Emblem.SymbolColor);
                        characterLook.AddColor(7, Owner.Guild.Emblem.BackgroundColor);
                    }
                    else
                    {
                        characterLook.AddSkin(3493); //New ApparenceId
                        characterLook.AddSkin((short)Owner.Guild.Emblem.Template.SkinId);
                        characterLook.AddColor(8, Owner.Guild.Emblem.SymbolColor);
                        characterLook.AddColor(7, Owner.Guild.Emblem.BackgroundColor);
                    }
                }
            }
            else
            {
                if (Owner.Guild != null)
                {
                    if (Sex == SexTypeEnum.SEX_MALE)
                    {
                        characterLook.RemoveSkin(3492); //New ApparenceId
                        characterLook.RemoveSkin((short)Owner.Guild.Emblem.Template.SkinId);
                        characterLook.RemoveColor(7);
                        characterLook.RemoveColor(8);
                    }
                    else
                    {
                        characterLook.RemoveSkin(3493); //New ApparenceId
                        characterLook.RemoveSkin((short)Owner.Guild.Emblem.Template.SkinId);
                        characterLook.RemoveColor(7);
                        characterLook.RemoveColor(8);
                    }
                }
            }
            return base.UpdateItemSkin(characterLook);
        }
    }
}