using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Core.IO;

namespace Stump.Server.WorldServer.Commands.Trigger
{
    public class WorldConsoleTrigger : TriggerBase
    {
        public WorldConsoleTrigger(StringStream args)
            : base(args, RoleEnum.Administrator)
        {
        }

        public WorldConsoleTrigger(string args)
            : base(args, RoleEnum.Administrator)
        {
        }

        public override bool CanFormat => false;

        public override ICommandsUser User => WorldServer.Instance.ConsoleInterface as WorldConsole;

        public override void Reply(string text)
        {
            Console.WriteLine(" " + text);
        }

        public override BaseClient GetSource()
        {
            return null;
        }

        public override void Log()
        {
        }
    }
}