using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Game.Songes;
using Stump.Server.WorldServer.Handlers.Context;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("PortalBreachBranches", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class PortalBreachBranches : CustomSkill
    {
        public PortalBreachBranches(int id, InteractiveCustomSkillRecord skillTemplate,
            InteractiveObject interactiveObject) : base(id, skillTemplate, interactiveObject)
        {
        }

        public override int StartExecute(Character character)
        {
            if (character.songesOwner == null)
            {
                if (character.Level > 200)
                {
                    if (character.songesStep < 201)
                    {
                        if (character.songesBranches != null)
                        {
                            ExtendedBreachBranch extendedBreachBranch = character.songesBranches[0];
                            switch (Id)
                            {
                                case 105623:
                                    extendedBreachBranch = character.songesBranches[2];
                                    break;
                                case 105624:
                                    extendedBreachBranch = character.songesBranches[1];
                                    break;
                                case 105625:
                                    extendedBreachBranch = character.songesBranches[0];
                                    break;
                                default:
                                    break;
                            }

                            Map map = World.Instance.GetMap((int) extendedBreachBranch.Map);
                            character.Teleport(map, character.Cell);
                            if (character.songesGroup != null)
                            {
                                foreach (long guest in character.songesGroup)
                                {
                                    World.Instance.GetCharacter((int) guest).Teleport(character.Position);
                                }
                            }

                            character.currentSongeRoom = extendedBreachBranch;

                            Task.Delay(1000).ContinueWith(t =>
                            {
                                var group = new MonsterGroup(map.GetNextContextualId(),
                                    new ObjectPosition(map, map.GetRandomFreeCell(), map.GetRandomDirection()));
                                foreach (var monster in extendedBreachBranch.Monsters)
                                {
                                    MonsterGrade monsterGrade = MonsterManager.Instance.GetMonsterGrades()
                                        .Where(x => x.MonsterId == monster.GenericId)
                                        .Where(x => x.GradeId == monster.Grade)
                                        .First();
                                    group.AddMonster(new Monster(monsterGrade, group));
                                }

                                MonsterGrade bossGrade = MonsterManager.Instance.GetMonsterGrades()
                                    .Where(x => x.MonsterId == extendedBreachBranch.Bosses[0].GenericId)
                                    .Where(x => x.GradeId == extendedBreachBranch.Bosses[0].Grade).First();
                                group.AddMonster(new Monster(bossGrade, group));
                                var songesFight =
                                    Singleton<FightManager>.Instance.CreateSongesFight(character.Map, character);
                                songesFight.ChallengersTeam.AddFighter(
                                    character.CreateFighter(songesFight.ChallengersTeam));
                                if (character.songesGroup != null)
                                {
                                    foreach (long guest in character.songesGroup)
                                    {
                                        songesFight.ChallengersTeam.AddFighter(
                                            World.Instance.GetCharacter((int) guest)
                                                .CreateFighter(songesFight.ChallengersTeam));
                                    }
                                }

                                foreach (var monster in group.GetMonsters())
                                {
                                    songesFight.DefendersTeam.AddFighter(
                                        monster.CreateFighter(songesFight.DefendersTeam));
                                }

                                songesFight.StartPlacement();

                                ContextHandler.HandleGameFightJoinRequestMessage(character.Client,
                                    new GameFightJoinRequestMessage(character.Fighter.Id, (ushort) songesFight.Id));
                                character.SaveLater();
                                if (character.songesGroup != null)
                                {
                                    foreach (long guest in character.songesGroup)
                                    {
                                        Character guestCharacter = World.Instance.GetCharacter((int) guest);
                                        ContextHandler.HandleGameFightJoinRequestMessage(guestCharacter.Client,
                                            new GameFightJoinRequestMessage(guestCharacter.Fighter.Id,
                                                (ushort) songesFight.Id));
                                        guestCharacter.SaveLater();
                                    }
                                }
                            });
                        }
                        else
                        {
                            character.SendServerMessage(
                                "Veuillez ouvrir le globe des songes afin de débloquer votre étage !");
                        }
                    }
                    else
                    {
                        character.SendServerMessage(
                            "Vous avez terminé votre run songes, veuillez en recommencer une !");
                    }
                }
            }
            else
            {
                character.SendServerMessage("Vous devez être niveau 200 pour accéder aux songes !");
            }

            return base.StartExecute(character);
        }
    }
}