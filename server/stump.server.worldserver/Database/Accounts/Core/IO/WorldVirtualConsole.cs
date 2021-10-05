using System;
using System.Collections.Generic;
using Stump.Core.IO;
using Stump.Server.BaseServer;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Stump.Server.WorldServer.Core.IO
{
    public class WorldVirtualConsole : ConsoleBase, ICommandsUser
    {
        public List<string> Commands { get; } = new List<string>();

        public List<KeyValuePair<string, Exception>> CommandsErrors { get; } =
            new List<KeyValuePair<string, Exception>>();

        public void EnterCommand(string Cmd, Action<bool, string> callback)
        {
            if (!WorldServer.Instance.Running)
                return;

            if (Cmd == "")
                return;

            WorldServer.Instance.CommandManager.HandleCommand(
                new WorldVirtualConsoleTrigger(new StringStream(Cmd), callback));
        }
    }
}