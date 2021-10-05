using System;
using System.Drawing;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class TpLiderTeamCommand : CommandBase
    {
        public TpLiderTeamCommand()
        {
            Aliases = new[] { "tpchef", "tpleader" };
            RequiredRole = RoleEnum.Player;
            Description = "Teleporte au chef de groupe";
            //AddParameter("to", "to", "The character to rejoin", converter: ParametersConverter.CharacterConverter);
            AddParameter("from", "from", "The character that teleport", isOptional: true, converter: ParametersConverter.CharacterConverter);
        }

        public override void Execute(TriggerBase trigger)
        {
            Character from = null;

            if (!(trigger as GameTrigger).Character.IsInParty())
            {
                switch ((trigger as GameTrigger).Character.Account.Lang)
                {
                    case "es":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous ne faites pas partie d'un groupe.");
                        break;

                    case "fr":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous ne faites pas partie d'un groupe.");
                        break;

                    case "pt":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous ne faites pas partie d'un groupe");
                        break;
                    default:
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous ne faites pas partie d'un groupe.");
                        break;
                }

                return;
            }

            if ((trigger as GameTrigger).Character.IsPartyLeader())
            {
                switch ((trigger as GameTrigger).Character.Account.Lang)
                {
                    case "es":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous êtes le chef du groupe.");
                        break;

                    case "fr":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous êtes le chef du groupe.");
                        break;

                    case "pt":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous êtes le chef du groupe.");
                        break;
                    default:
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car vous êtes le chef du groupe.");
                        break;
                }
                return;
            }

            if ((trigger as GameTrigger).Character.Party.Leader.Map.IsDungeon())
            {
                switch ((trigger as GameTrigger).Character.Account.Lang)
                {
                    case "es":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car votre chef est dans un donjon.");
                        break;

                    case "fr":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car votre chef est dans un donjon.");
                        break;

                    case "pt":
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car votre chef est dans un donjon.");
                        break;
                    default:
                        (trigger as GameTrigger).Character.DisplayNotification(
                            "Vous ne pouvez pas utiliser cette commande car votre chef est dans un donjon.");
                        break;
                }
                return;
            }

            var to = (trigger as GameTrigger).Character.Party.Leader;

            if (trigger is GameTrigger)
                from = (trigger as GameTrigger).Character;

            from.Teleport(to.Position);
            switch ((trigger as GameTrigger).Character.Account.Lang)
            {
                case "es":
                    (trigger as GameTrigger).Character.DisplayNotification(
                        "Vous avez été téléporté avec votre chef de groupe pour faciliter le jeu. Profitez-en!");
                    break;

                case "fr":
                    (trigger as GameTrigger).Character.DisplayNotification(
                        "Vous avez été téléporté avec votre chef de groupe pour faciliter le jeu. Profitez-en!");
                    break;

                case "pt":
                    (trigger as GameTrigger).Character.DisplayNotification(
                        "Vous avez été téléporté avec votre chef de groupe pour faciliter le jeu. Profitez-en!");
                    break;
                default:
                    (trigger as GameTrigger).Character.DisplayNotification(
                        "Vous avez été téléporté avec votre chef de groupe pour faciliter le jeu. Profitez-en!");
                    break;
            }
        }
    }
}