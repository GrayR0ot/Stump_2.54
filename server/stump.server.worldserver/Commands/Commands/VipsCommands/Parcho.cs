//using Stump.DofusProtocol.Enums;
//using Stump.Server.BaseServer.Commands;
//using Stump.Server.WorldServer.Commands.Commands.Patterns;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using System;
//namespace Stump.Server.WorldServer.Commands.Commands
//{
//    public class Parcho : TargetCommand
//    {
//        public Parcho()
//        {
//            base.Aliases = new string[]
//            {
//                "parcho"
//            };
//            base.RequiredRole = RoleEnum.Vip;
//            base.Description = "ajoute 101 points de caractéristiques";
//            base.AddTargetParameter(true, "Defined target");
//        }
//        public override void Execute(TriggerBase trigger)
//        {
//            Character[] targets = base.GetTargets(trigger);

//            for (int i = 0; i < targets.Length; i++)
//            {
//                Character character = targets[i];

//                if (!character.IsFighting())
//                {
//                    if (character.Stats.Agility.Additional >= 101
//                    & character.Stats.Chance.Additional >= 101
//                    & character.Stats.Intelligence.Additional >= 101
//                    & character.Stats.Strength.Additional >= 101
//                    & character.Stats.Vitality.Additional >= 101
//                    & character.Stats.Wisdom.Additional >= 101)
//                    {
//                        character.SendServerMessage("[Serveur] : Vous êtes déjà parchotté dans tous les éléments.", System.Drawing.Color.Red);
//                    }
//                    else
//                    {
//                        character.Stats.Agility.Additional = character.Stats.Agility.Additional + 101;
//                        character.Stats.Chance.Additional = character.Stats.Chance.Additional + 101;
//                        character.Stats.Intelligence.Additional = character.Stats.Intelligence.Additional + 101;
//                        character.Stats.Strength.Additional = character.Stats.Strength.Additional + 101;
//                        character.Stats.Vitality.Additional = character.Stats.Vitality.Additional + 101;
//                        character.Stats.Wisdom.Additional = character.Stats.Wisdom.Additional + 101;

//                        character.SendServerMessage("[Serveur] : Vous voilà parchotté dans tous les éléments.", System.Drawing.Color.DarkBlue);
//                        character.RefreshStats();
//                    }
//                }
//                else
//                {
//                    trigger.ReplyError("Pour lancer cette commande, il faut être en dehors d'un combat. ");
//                }
//            }
//        }
//    }
//}

