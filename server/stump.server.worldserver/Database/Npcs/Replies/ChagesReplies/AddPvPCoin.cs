﻿using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Items.Player;
using Stump.Server.WorldServer.Game.PvP;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("AddPvPCoin", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class AddPvPCoin : NpcReply
    {
        public AddPvPCoin(NpcReplyRecord record)
            : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            if (!base.Execute(npc, character)) return false;

            BasePlayerItem m_item = null;
            var m_cranios = CranioManager.Instance.GetCranios();

            foreach (var item in m_cranios)
            {
                var finditem = character.Inventory.TryGetItem(item);

                if (finditem == null)
                    continue;

                if (finditem.Stack < 10)
                    continue;

                if (finditem.Stack >= 10)
                {
                    m_item = finditem;
                    break;
                }
            }

            if (m_item == null)
            {
                character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 252);
                return false;
            }

            character.Inventory.RemoveItem(m_item, 10);
            var coin = ItemManager.Instance.CreatePlayerItem(character, (int) ItemIdEnum.KRONS_13417, 1);
            character.Inventory.AddItem(coin);
            character.SendServerMessage("Vous avez acheté un Crane.", Color.YellowGreen);
            return true;
        }
    }
}