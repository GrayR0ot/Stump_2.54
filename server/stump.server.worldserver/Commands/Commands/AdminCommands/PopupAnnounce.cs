using System.Drawing;
using Stump.Core.Attributes;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class PopupAnnounce : CommandBase
    {
        [Variable(true)] public static string AnnounceColor = ColorTranslator.ToHtml(Color.Red);

        public PopupAnnounce()
        {
            Aliases = new[]
            {
                "popup",
                "pop"
            };
            Description = "Display an announce to all players";
            RequiredRole = RoleEnum.Administrator;
            AddParameter<string>("message", "msg", "The announce");
        }

        public override void Execute(TriggerBase trigger)
        {
            bool predicate(Character x)
            {
                return true;
            }

            var color = ColorTranslator.FromHtml(AnnounceCommand.AnnounceColor);
            var text = trigger.Get<string>("msg");
            var characters = Singleton<World>.Instance.GetCharacters(predicate);
            var num = 0;
            foreach (var current in characters)
            {
                current.Client.Send(new PopupWarningMessage(5, "Message de l'équipe", "<br />" + text));
                num++;
            }

            trigger.Reply("Message envoyé à " + num + " joueur(s)");
        }
    }
}