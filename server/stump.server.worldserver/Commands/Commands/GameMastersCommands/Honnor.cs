using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class HonorCommand : SubCommandContainer
    {
        public HonorCommand()
        {
            Aliases = new[] {"honor"};
            RequiredRole = RoleEnum.GameMaster_Padawan;
            Description = "Manage your honor.";
        }
    }

    public class HonorAddCommand : TargetSubCommand
    {
        public HonorAddCommand()
        {
            Aliases = new[] {"add"};
            RequiredRole = RoleEnum.GameMaster;
            ParentCommandType = typeof(HonorCommand);
            Description = "Add Honor to a target";
            AddParameter<ushort>("amount", "amount", "Amount of honor to add", 1);
            AddTargetParameter(true);
        }

        public override void Execute(TriggerBase trigger)
        {
            foreach (var target in GetTargets(trigger))
            {
                target.AddHonor(trigger.Get<ushort>("amount"));
                target.Map.Refresh(target);
                trigger.Reply(
                    "Félicitations ! Vous avez gagné " + trigger.Get<ushort>("amount") + " points d'honneur !",
                    Color.OrangeRed);
            }
        }
    }
}