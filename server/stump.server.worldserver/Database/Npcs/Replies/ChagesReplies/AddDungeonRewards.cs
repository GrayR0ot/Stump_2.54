﻿using System.Collections.Generic;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Dungeon;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Items.Player;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("AddDungeonRewards", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class AddDungeonRewards : NpcReply
    {
        public AddDungeonRewards(NpcReplyRecord record)
            : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            if (!base.Execute(npc, character)) return false;

            var _itensToSee = new List<BasePlayerItem>();
            var m_items = DungeonItemsManager.Instance.GetItems();

            foreach (var item in m_items)
            {
                var finditem = character.Inventory.TryGetItem(item);

                if (finditem == null)
                {
                    character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 252);
                    return false;
                }

                _itensToSee.Add(finditem);
            }

            foreach (var item in _itensToSee)
                character.Inventory.RemoveItem(item, 1);

            var coin = ItemManager.Instance.CreatePlayerItem(character, (int) ItemIdEnum.BOWLTON_DOR_13026, 3);
            character.Inventory.AddItem(coin);
            character.Inventory.AddKamas(20000000);
            //character.SendServerMessage("Você adquiriu uma Moeda de Calabouço e 20MK.", Color.YellowGreen);
            return true;
        }
    }
}