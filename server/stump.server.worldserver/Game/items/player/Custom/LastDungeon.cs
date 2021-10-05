using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Accounts;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Dialogs.Interactives;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.POTION_BACK_DUNGEON)]
    public class LastDungeon : BasePlayerItem
    {
        public LastDungeon(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 0, Cell targetCell = null, Character target = null)
        {
            if(Owner != null)
            {
                if (!Owner.IsFighting())
                {
                    if (Owner.Record.BackDungeon != 0)
                    {
                        var map = Singleton<World>.Instance.GetMap(Owner.Record.BackDungeon);
                        Owner.Teleport(new ObjectPosition(map, map.GetFirstFreeCellNearMiddle()));
                    }
                    else
                    {
                        Owner.Client.Send(new PopupWarningMessage(3, "Retour en DJ", "Vous n'avez pas de position sauvegardée."));
                    }
                }
                else
                {
                    Owner.Client.Send(new PopupWarningMessage(3, "Retour en DJ", "Pour lancer cette commande, il faut être en dehors d'un combat."));
                }
            }

            return 0;
        }
    }
}
