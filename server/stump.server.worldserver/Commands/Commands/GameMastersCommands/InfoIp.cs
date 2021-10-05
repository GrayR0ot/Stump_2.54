using System.Collections.Generic;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Game;

namespace Stump.Server.WorldServer.Commands.Commands.Info
{
    public class InfoIP : TargetCommand
    {
        public InfoIP()
        {
            Aliases = new[]
            {
                "infoip"
            };
            RequiredRole = RoleEnum.GameMaster;
            Description = "Number of connected player by IP";
        }

        public override void Execute(TriggerBase trigger)
        {
            var IPAlreadySeen = new List<string>();
            foreach (var chr in Singleton<World>.Instance.GetCharacters())
                if (!IPAlreadySeen.Contains(chr.Account.LastConnectionIp))
                    IPAlreadySeen.Add(chr.Account.LastConnectionIp);
            trigger.Reply("Ip connectés: " + IPAlreadySeen.Count);
        }
    }
}