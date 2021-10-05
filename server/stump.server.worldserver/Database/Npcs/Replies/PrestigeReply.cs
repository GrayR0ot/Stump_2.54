using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("Prestige", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class PrestigeReply : NpcReply
    {
        public PrestigeReply(NpcReplyRecord record)
            : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            if (character.Level < 200) character.OpenPopup("vous devez être niveau 200 pour passer de prestige");

            return character.IncrementPrestige();
        }
    }
}