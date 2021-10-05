using System;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Maps.Teleport;
using Stump.Server.WorldServer.Game.Parties;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("TeleportParty", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class TeleportPartyToDungeonReply : NpcReply
    {
        public TeleportPartyToDungeonReply(NpcReplyRecord record) : base(record)
        {
        }

        public short DungeonId
        {
            get => Record.GetParameter<short>(0);
            set => Record.SetParameter(0, value);
        }

        public override bool Execute(Npc npc, Character character)
        {
            var dungeon = DungeonManager.Instance.GetDungeonById(DungeonId);

            if (dungeon == null)
                return false;

            if (npc.Map.Id != dungeon.EntranceMapId)
                return false;

            if (character.IsInFight())
                return false;

            if (!character.IsInParty())
            {
                character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 312);
                return false;
            }

            if (character.LastTeleportParty >= DateTime.Now)
            {
                character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 318,
                    (character.LastTeleportParty - DateTime.Now).Minutes + 1);
                return false;
            }

            var invalidersIds = character.Party.Members.Where(x =>
                    x != character && x.Level < dungeon.OptimalPlayerLevel || x != character && x.Map == npc.Map)
                .Select(w => w.Id);

            if (invalidersIds.Count() >= character.Party.MembersCount - 1)
            {
                character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 313);
                return false;
            }

            character.Client.Send(new TeleportBuddiesMessage((ushort) DungeonId));
            character.Party.TeleportRequest = new PartyTeleport(DungeonId, character.Id, invalidersIds.ToList(),
                character.Party, character.Map, character.Cell.Id);
            return true;
        }
    }
}