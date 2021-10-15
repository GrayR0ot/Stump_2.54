using System;
using System.Drawing;
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
    public class Reboot : TargetCommand
    {
        public Reboot()
        {
            Aliases = new[] {"reboot"};
            Description = "Save the player";
            RequiredRole = RoleEnum.Administrator;
            AddParameter("time", "time", "Noire duration (in minutes)", 3);
        }

        public override void Execute(TriggerBase trigger)
        {
            var value = trigger.Args.PeekNextWord();
            if (string.IsNullOrEmpty(value))
                if (trigger is GameTrigger)
                {
                    var time = trigger.Get<int>("time");

                    Singleton<World>.Instance.SendAnnounce("le serveur va redémarrer dans  " + time + " minutes.",
                        Color.Orchid);
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
            Singleton<World>.Instance.SendAnnounce("Redémarrage automatique du serveur dans 1 minute.", Color.Orchid);
            Thread.Sleep(60000);
            foreach (var cr in characters)
            {
                cr.SaveLater();

                switch (cr.Account.Lang)
                {
                    case "fr":
                        cr.SendServerMessage("Votre personnage a été sauvegardé.");
                        break;
                    default:
                        cr.SendServerMessage("You character has just been saved!");
                        break;
                }


                if (time - 60000 >= 0)
                    Thread.Sleep(time - 60000);

                Singleton<World>.Instance.SendAnnounce("Redémarrage automatique du serveur dans 1 minute.",
                    Color.Orchid);
                Thread.Sleep(60000);

                ServerBase<WorldServer>.Instance.IOTaskPool.AddMessage(Singleton<World>.Instance.Save);
                Singleton<World>.Instance.SendAnnounce("Redémarrage imminent !!!", Color.Orchid);
                Singleton<World>.Instance.SendAnnounce("Redémarrage imminent !!!", Color.Orchid);
                Singleton<World>.Instance.SendAnnounce("Redémarrage imminent !!!", Color.Orchid);
                Thread.Sleep(5000);
                Environment.Exit(1);
            }
        }
    }
}