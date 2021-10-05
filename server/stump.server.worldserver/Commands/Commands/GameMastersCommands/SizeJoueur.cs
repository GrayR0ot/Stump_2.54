using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Plug.Commands
{
    internal class SizeCommand : InGameCommand
    {
        public SizeCommand()
        {
            Aliases = new[] {"size"};
            RequiredRole = RoleEnum.GameMaster;
            Description = "Augmente votre taille.";
            AddParameter<short>("taille", "taille", "définissez la taille");
        }

        public override void Execute(GameTrigger trigger)
        {
            var player = trigger.Character;
            player.Look.SetScales(trigger.Get<short>("taille"));
            player.RefreshActor();
            trigger.Reply("Votre taille est maintenant de <b>" + trigger.Get<short>("taille") + "</b> !");
        }
    }
}