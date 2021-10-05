using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Game.HavenBags;

namespace Stump.Server.WorldServer.Commands.PlayerCommands
{
    public class AddHavenBagCommand : TargetCommand
    {
        public AddHavenBagCommand()
        {
            Aliases = new[] {"addhavenbag"};
            RequiredRole = RoleEnum.Administrator;
            Description = "Ajoute le thème de l'havre sac.";
            AddTargetParameter();
            AddParameter<int>("id", "id", "Emote id");
        }

        public override void Execute(TriggerBase trigger)
        {
            var ThemeId = (sbyte) trigger.Get<int>("id");
            var Character = GetTargets(trigger).FirstOrDefault();
            HavenBagManager.Instance.AddHavenBag(Character, ThemeId);
        }
    }

    public class DeleteHavenBagCommand : TargetCommand
    {
        public DeleteHavenBagCommand()
        {
            Aliases = new[] {"deletehavenbag"};
            RequiredRole = RoleEnum.Administrator;
            Description = "Supprime un thème de l'havre sac.";
            AddTargetParameter();
            AddParameter<int>("id", "id", "Emote id");
        }

        public override void Execute(TriggerBase trigger)
        {
            var ThemeId = (sbyte) trigger.Get<int>("id");
            var Character = GetTargets(trigger).FirstOrDefault();
            HavenBagManager.Instance.DeleteHavenBag(Character, ThemeId);
        }
    }
}