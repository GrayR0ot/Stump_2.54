using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.BaseServer.Network;

namespace Stump.Server.WorldServer.Commands.Trigger
{
    internal class WorldVirtualConsoleTrigger : TriggerBase
    {
        public WorldVirtualConsoleTrigger(StringStream args)
            : base(args, RoleEnum.Administrator)
        {
        }

        public WorldVirtualConsoleTrigger(string args)
            : base(args, RoleEnum.Administrator)
        {
        }

        public WorldVirtualConsoleTrigger(StringStream args, Action<bool, string> callback)
            : base(args, RoleEnum.Administrator)
        {
            Callback = callback;
        }

        public Action<bool, string> Callback { get; }

        public override bool CanFormat => false;

        public override ICommandsUser User => WorldServer.Instance.VirtualConsoleInterface;

        public override void Reply(string text)
        {
            Callback?.Invoke(true, text);
        }

        public override void ReplyError(string message)
        {
            if (Callback != null)
                Callback(false, "(Error) " + message);
            else
                Reply("(Error) " + message);
        }

        public override BaseClient GetSource()
        {
            throw new NotImplementedException();
        }

        public override void Log()
        {
        }
    }
}