using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Commands.Trigger;
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
    [ItemId(ItemIdEnum.POTION_DEBUGMAP)]
    public class DebugMap : BasePlayerItem
    {
        public DebugMap(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }
        Cell DebugCell { get; set; }


        public override uint UseItem(int amount = 0, Cell targetCell = null, Character target = null)
        {
            if (Owner != null)
            {
                if (!Owner.IsFighting())
                {
                    var cells = Owner.Map.Cells;
                    foreach (var item in cells)
                    {
                        if (item.Walkable == true)
                            DebugCell = item;
                    }
                    Owner.Teleport(new ObjectPosition(Owner.Map, DebugCell));
                }   
            }

            return 0;
        }
    }
}
