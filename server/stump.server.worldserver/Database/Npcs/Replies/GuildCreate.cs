using System.Drawing;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Dialogs.Guilds;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("GuildCreation", typeof(NpcReply), typeof(NpcReplyRecord))]
    internal class GuildCreate : NpcReply
    {
        public GuildCreate(NpcReplyRecord record) : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            if (character.Guild != null)
            {
                character.SendServerMessage("Vous devez quitter votre guilde avant d'en créer une nouvelle.",
                    Color.DarkOrange);
                return false;
            }

            try
            {
                var panel = new GuildCreationPanel(character);
                panel.Open();
                character.SendServerMessage("Vous avez perdu une guildalogemme.", Color.DarkOrange);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}