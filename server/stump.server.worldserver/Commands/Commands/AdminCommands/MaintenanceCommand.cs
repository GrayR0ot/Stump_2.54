using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class MaintenanceAnnounce : CommandBase
    {
        public MaintenanceAnnounce()
        {
            Aliases = new[]
            {
                "maintenance"
            };
            Description = "Notifier d'une maintenance tous les connectés";
            RequiredRole = RoleEnum.Administrator;
        }

        public override void Execute(TriggerBase trigger)
        {
            {
                ServerBase<WorldServer>.Instance.IOTaskPool.AddMessage(Singleton<World>.Instance
                    .SendAnnounceAllPlayersShutDown);
            }
        }
    }
}