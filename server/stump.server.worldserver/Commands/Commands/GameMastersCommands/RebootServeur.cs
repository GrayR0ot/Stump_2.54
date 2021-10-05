using System;
using System.Threading;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class TimeREboot : TargetCommand
    {
        public TimeREboot()
        {
            Aliases = new[]
            {
                "reboot"
            };
            Description = "Save the player";
            RequiredRole = RoleEnum.GameMaster;
            AddParameter("time", "time", "Noire duration (in minutes)", 3);
        }

        public override void Execute(TriggerBase trigger)
        {
            var value = trigger.Args.PeekNextWord();
            if (string.IsNullOrEmpty(value))
                if (trigger is GameTrigger)
                {
                    var time = trigger.Get<int>("time");

                    var Restart =
                        new Thread(
                            unused => SaveMinuteBefore(time * 60000)
                        );
                    Restart.Start();
                }
        }

        public void SaveMinuteBefore(int time)
        {
            if (time - 60000 >= 0)
                Thread.Sleep(time - 60000);
            Predicate<Character> predicate = x => true;
            var characters = Singleton<World>.Instance.GetCharacters(predicate);
            Thread.Sleep(60000);
            foreach (var cr in characters)
            {
                cr.SaveLater();

                switch (cr.Account.Lang)
                {
                    case "fr":
                        cr.SendServerMessage("Votre personnage à était sauvegardé.");
                        break;
                    case "es":
                        cr.SendServerMessage("Su carácter se salvó.");
                        break;
                    case "en":
                        cr.SendServerMessage("Your character was saved.");
                        break;
                    default:
                        cr.SendServerMessage("Seu personagem foi salvo.");
                        break;
                }
            }

            ServerBase<WorldServer>.Instance.IOTaskPool.AddMessage(Singleton<World>.Instance.Save);
            Thread.Sleep(5000);
            Environment.Exit(1);
        }
    }
}