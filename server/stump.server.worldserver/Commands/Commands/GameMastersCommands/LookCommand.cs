using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Game.Actors.Look;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class LookCommand : TargetCommand
    {
        public LookCommand()
        {
            Aliases = new[]
            {
                "look"
            };
            RequiredRole = RoleEnum.GameMaster;
            Description = "Change l'apparence de la cible";
            AddParameter<string>("look", "l", "The new look for the target", null, true);
            AddTargetParameter(true);
            AddParameter("demorph", "demorph", "Redonne l'apparence de base à la cible", false, true);
        }

        public override void Execute(TriggerBase trigger)
        {
            var targets = GetTargets(trigger);
            var i = 0;
            while (i < targets.Length)
            {
                var target = targets[i];
                if (!trigger.IsArgumentDefined("demorph"))
                {
                    if (trigger.IsArgumentDefined("look"))
                    {
                        target.CustomLook = ActorLook.Parse(trigger.Get<string>("look"));
                        target.CustomLookActivated = true;
                        target.RefreshActor();
                        i++;
                        continue;
                    }

                    trigger.ReplyError("Look not defined");
                }
                else
                {
                    target.CustomLookActivated = false;
                    target.CustomLook = null;
                    trigger.Reply("Demorphed");
                    target.Map.Area.ExecuteInContext(delegate { target.Map.Refresh(target); });
                }

                return;
            }
        }
    }
}