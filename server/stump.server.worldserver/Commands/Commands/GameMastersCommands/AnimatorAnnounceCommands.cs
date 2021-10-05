using System.Drawing;
using Stump.Core.Attributes;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class AnnounceCommand2 : CommandBase
    {
        [Variable(true)] public static string AnnounceColor = ColorTranslator.ToHtml(Color.GreenYellow);

        public AnnounceCommand2()
        {
            Aliases = new[] {"b"};
            Description = "Display an announce to all players";
            RequiredRole = RoleEnum.GameMaster_Padawan;
            AddParameter<string>("message", "msg", "The announce");
        }

        public override void Execute(TriggerBase trigger)
        {
            var color = ColorTranslator.FromHtml(AnnounceColor);

            var msg = trigger.Get<string>("msg");
            var formatMsg = trigger is GameTrigger
                ? string.Format("★{0} : (Animateur) {1}", ((GameTrigger) trigger).Character.Name, msg)
                : string.Format("★{0} : (Animateur)", msg);


            World.Instance.SendAnnounce(formatMsg, color);
        }
    }
}