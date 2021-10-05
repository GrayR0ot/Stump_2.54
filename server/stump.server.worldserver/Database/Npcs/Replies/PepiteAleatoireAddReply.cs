using System.Drawing;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Npcs;
using Stump.Server.WorldServer.Database.Npcs.Replies;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Items;

namespace Database.Npcs.Replies
{
    [Discriminator("Nebu", typeof(NpcReply), typeof(NpcReplyRecord))]
    internal class PepiteAddReply : NpcReply
    {
        public PepiteAddReply(NpcReplyRecord record)
            : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            if (character.Record.NumberOfPnjFound == 0)
            {
                var annonce = character.Name + " a trouvé le pnj, félicitations à lui !";
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }
            else if (character.Record.NumberOfPnjFound == 1)
            {
                var annonce = character.Name +
                              " a trouvé le pnj, félicitations à lui ! C'est la deuxième fois qu'il le trouve";
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }
            else if (character.Record.NumberOfPnjFound == 2)
            {
                var annonce = character.Name +
                              " a trouvé le pnj, félicitations à lui ! C'est la troisième fois qu'il le trouve";
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }
            else if (character.Record.NumberOfPnjFound == 3)
            {
                var annonce = character.Name +
                              " a trouvé le pnj, félicitations à lui ! C'est la quatrième fois qu'il le trouve";
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }
            else if (character.Record.NumberOfPnjFound == 4)
            {
                var annonce = character.Name +
                              " a trouvé le pnj, félicitations à lui ! C'est la cinquième fois qu'il le trouve";
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }
            else if (character.Record.NumberOfPnjFound == 5)
            {
                var annonce = character.Name +
                              " a trouvé le pnj, félicitations à lui ! C'est la sixième fois qu'il le trouve";
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }
            else if (character.Record.NumberOfPnjFound == 6)
            {
                var annonce = character.Name +
                              " a trouvé le pnj, félicitations à lui ! C'est la septième fois qu'il le trouve";
                var jeton = ItemManager.Instance.TryGetTemplate(12124);
                var token = character.Inventory.TryGetItem(jeton);
                var coiffe = ItemManager.Instance.TryGetTemplate(20415);
                character.Inventory.AddItem(coiffe);
                var cape = ItemManager.Instance.TryGetTemplate(20417);
                character.Inventory.AddItem(cape);
                character.PlayEmote(EmotesEnum.EMOTE_GONFLER_SES_MUSCLES);
                npc.Delete();
                character.AddTitle(27);
                character.AddOrnament(57);
                character.Inventory.AddItem(jeton, 50);
                npc.Refresh();
                character.RefreshActor();
                Singleton<World>.Instance.SendAnnounce(annonce, Color.Red);
                character.Record.NumberOfPnjFound++;
            }

            return true;
        }
    }
}