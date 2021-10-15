using System.Linq;
using System.Threading.Tasks;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Maps.Cells;
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
            if (character.breachOwner == null)
            {
                if (character.Level > 200)
                {
                    if (character.breachStep < 201)
                    {
                        if (character.breachBranches != null)
                        {
                            var extendedBreachBranch = character.breachBranches[0];
                            switch (Id)
                            {
                                case 105623:
                                    extendedBreachBranch = character.breachBranches[2];
                                    break;
                                case 105624:
                                    extendedBreachBranch = character.breachBranches[1];
                                    break;
                                case 105625:
                                    extendedBreachBranch = character.breachBranches[0];
                                    break;
                            }

                            var map = World.Instance.GetMap((int) extendedBreachBranch.Map);
                            character.Teleport(map, character.Cell);
                            if (character.breachGroup != null)
                                foreach (var guest in character.breachGroup)
                                    World.Instance.GetCharacter((int) guest).Teleport(character.Position);

                            character.currentBreachRoom = extendedBreachBranch;

                            Task.Delay(1000).ContinueWith(t =>
                            {
                                var group = new MonsterGroup(map.GetNextContextualId(),
                                    new ObjectPosition(map, map.GetRandomFreeCell(), map.GetRandomDirection()));
                                foreach (var monster in extendedBreachBranch.Monsters)
                                {
                                    var monsterGrade = MonsterManager.Instance.GetMonsterGrades()
                                        .Where(x => x.MonsterId == monster.GenericId)
                                        .Where(x => x.GradeId == monster.Grade)
                                        .First();
                                    group.AddMonster(new Monster(monsterGrade, group));
                                }

                                var bossGrade = MonsterManager.Instance.GetMonsterGrades()
                                    .Where(x => x.MonsterId == extendedBreachBranch.Bosses[0].GenericId)
                                    .Where(x => x.GradeId == extendedBreachBranch.Bosses[0].Grade).First();
                                group.AddMonster(new Monster(bossGrade, group));
                                var breachFight =
                                    Singleton<FightManager>.Instance.CreateSongesFight(character.Map, character);
                                breachFight.ChallengersTeam.AddFighter(
                                    character.CreateFighter(breachFight.ChallengersTeam));
                                if (character.breachGroup != null)
                                    foreach (var guest in character.breachGroup)
                                        breachFight.ChallengersTeam.AddFighter(
                                            World.Instance.GetCharacter((int) guest)
                                                .CreateFighter(breachFight.ChallengersTeam));

                                foreach (var monster in group.GetMonsters())
                                    breachFight.DefendersTeam.AddFighter(
                                        monster.CreateFighter(breachFight.DefendersTeam));

                                breachFight.StartPlacement();

                                ContextHandler.HandleGameFightJoinRequestMessage(character.Client,
                                    new GameFightJoinRequestMessage(character.Fighter.Id, (ushort) breachFight.Id));
                                character.SaveLater();
                                if (character.breachGroup != null)
                                    foreach (var guest in character.breachGroup)
                                    {
                                        var guestCharacter = World.Instance.GetCharacter((int) guest);
                                        ContextHandler.HandleGameFightJoinRequestMessage(guestCharacter.Client,
                                            new GameFightJoinRequestMessage(guestCharacter.Fighter.Id,
                                                (ushort) breachFight.Id));
                                        guestCharacter.SaveLater();
                                    }
                            });
                        }
                        else
                        {
                            character.SendServerMessage(
                                "Veuillez ouvrir le globe des breach afin de débloquer votre étage !");
                        }
                    }
                    else
                    {
                        character.SendServerMessage(
                            "Vous avez terminé votre run breach, veuillez en recommencer une !");
                    }
                }
            }
            else
            {
                character.SendServerMessage("Vous devez être niveau 200 pour accéder aux breach !");
            }

            return base.StartExecute(character);
        }
    }
}