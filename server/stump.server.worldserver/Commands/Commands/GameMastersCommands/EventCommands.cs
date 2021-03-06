using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class EventAnnounce : CommandBase
    {
        public EventAnnounce()
        {
            Aliases = new[]
            {
                "event"
            };
            Description = "Send an event message to all connected player(s)";
            RequiredRole = RoleEnum.GameMaster_Padawan;
        }

        public override void Execute(TriggerBase trigger)
        {
            {
                ServerBase<WorldServer>.Instance.IOTaskPool.AddMessage(Singleton<World>.Instance
                    .SendAnnounceAllPlayersEvent);
            }
        }
    }
}