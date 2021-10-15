using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Handlers.Context;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("Ascension", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class SongesReply : NpcReply
    {
        public SongesReply(NpcReplyRecord record)
            : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            var random = new Random();
            var maps = new List<int>
            {
                152834048, 190318592, 193729536, 121374211, 163582464, 94115840, 87033346, 96209922, 146670592,
                17565953, 104596995, 87296515, 5242886, 64753664, 96998917, 66589184, 98567687, 157552640, 116392450,
                106960896, 176951296, 22284290, 116654595, 79434241, 174330368, 149688320, 149165056, 157028352,
                181669888, 155718656, 107227136, 101189632, 118231040, 157290496, 66850816, 22809602, 27000836,
                40110085, 27789316, 17309696, 107485184, 96209926, 55053312, 18087940, 132911104, 174070272, 149427200,
                89392130, 56102912, 102760963, 56365056, 21497858, 57155841, 125831683, 59514880, 175902208, 104333827,
                182193153, 26740736, 66326528, 62919680, 182455296, 61868036, 62135816, 57938689, 123212800, 179572736,
                110101506, 110363650, 109840899, 109576707, 112203523, 119277059, 140776448, 169873408, 169349120,
                169611264, 176164864, 182718464, 184686337, 187437056, 187957512, 195039232, 72361984
            };
            var map = Game.World.Instance.GetMap(maps[new Random().Next(maps.Count())]);
            var branchMonsters = new List<List<int>>();
            var branchBosses = new List<int>();
            if (character.songesStep < 201)
            {
                for (var branches = 0; branches < 3; branches++)
                    if (character.songesStep < 51)
                    {
                        var monsters = new List<int>();
                        branchBosses.Add(
                            MonsterManager.Instance.GetMonsterGrades().Where(x => x.GradeId == 21)
                                .Where(x => MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss).ToArray()[
                                    random.Next(MonsterManager.Instance.GetMonsterGrades().Where(x => x.GradeId == 21)
                                        .Where(x => MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss).Count())]
                                .Id);
                        for (var i = 0; i < 3; i++)
                            monsters.Add(
                                MonsterManager.Instance.GetMonsterGrades().Where(x => x.GradeId == 21)
                                    .Where(x => !MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss).ToArray()[
                                        random.Next(MonsterManager.Instance.GetMonsterGrades()
                                            .Where(x => x.GradeId == 21).Where(x =>
                                                !MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss).Count())].Id);
                        branchMonsters.Add(monsters);
                    }
                /*StartFight(character, map, 200, monsters);
                return true;*/
            }
            else
            {
                character.SetAscensionStair(0);
                //return true;
            }

            //ROOM: I // II // III etc dans le menu
            //MODIFIER: Modificateur de combat (Paradoxe/Rêve/Cauchemard)

            character.Client.Send(new BreachEnterMessage());
            var monsterBranches = new List<MonsterInGroupLightInformations[]>();
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                monsterBranches.Add(new[]
                {
                    new MonsterInGroupLightInformations(
                        MonsterManager.Instance.GetMonsterGrade(branchMonsters[i][j]).Template.Id, 1, 1)
                });

            var bossBranches = new List<MonsterInGroupLightInformations[]>();
            bossBranches.Add(new[]
            {
                new MonsterInGroupLightInformations(
                    MonsterManager.Instance.GetMonsterGrade(branchBosses[0]).Template.Id, 1, 1)
            });
            bossBranches.Add(new[]
            {
                new MonsterInGroupLightInformations(
                    MonsterManager.Instance.GetMonsterGrade(branchBosses[1]).Template.Id, 1, 1)
            });
            bossBranches.Add(new[]
            {
                new MonsterInGroupLightInformations(
                    MonsterManager.Instance.GetMonsterGrade(branchBosses[2]).Template.Id, 1, 1)
            });

            BreachReward[] breachRewards =
            {
                new BreachReward(93, new byte[0], "", false, 100), //VITALITY
                new BreachReward(94, new byte[0], "", false, 100), //POWER
                new BreachReward(92, new byte[0], "", false, 100), //STRENGH
                new BreachReward(6, new byte[0], "", false, 100), //INTELLIGENCY
                new BreachReward(91, new byte[0], "", false, 100), //AGILITY
                new BreachReward(7, new byte[0], "", false, 100) //CHANCE
            };
            ExtendedBreachBranch[] extendedBreachBranchs =
            {
                new ExtendedBreachBranch(1, 1, bossBranches[0], 188486931, monsterBranches[0], breachRewards,
                    (uint) random.Next(155, 547), 100),
                new ExtendedBreachBranch(2, 2, bossBranches[1], 188486931, monsterBranches[1], breachRewards,
                    (uint) random.Next(155, 547), 100),
                new ExtendedBreachBranch(3, 3, bossBranches[2], 188486931, monsterBranches[2], breachRewards,
                    (uint) random.Next(155, 547), 100)
            };
            character.Client.Send(new BreachBranchesMessage(extendedBreachBranchs));

            return true;
        }


        public void StartFight(Character character, Map map, int cell, List<int> monsters)
        {
            if (!Game.World.Instance.GetMap(map.Id).Area.IsRunning) Game.World.Instance.GetMap(map.Id).Area.Start();
            character.Teleport(map, map.GetCell(cell));
            Task.Delay(1000).ContinueWith(t =>
            {
                character.SendServerMessage(
                    "Vous avez été téléporté a l'étage " + character.songesStep + " des songes !");

                var fight = Singleton<FightManager>.Instance.CreateSongesFight(character.Map, character);
                fight.ChallengersTeam.AddFighter(character.CreateFighter(fight.ChallengersTeam));

                foreach (var monsterGrade in monsters)
                {
                    var grade = Singleton<MonsterManager>.Instance.GetMonsterGrade(monsterGrade).DeepCopy();
                    grade.Level += (uint) character.songesStep;
                    var position = new ObjectPosition(map, map.GetCell(cell), (DirectionsEnum) 5);
                    var monster = new Monster(grade, new MonsterGroup(0, position));

                    fight.DefendersTeam.AddFighter(new MonsterFighter(fight.DefendersTeam, monster));
                }

                character.Client.Send(new AreaFightModificatorUpdateMessage(10825));
                fight.StartPlacement();

                ContextHandler.HandleGameFightJoinRequestMessage(character.Client,
                    new GameFightJoinRequestMessage(character.Fighter.Id, (ushort) fight.Id));
                character.SaveLater();
                return true;
            });
        }
    }
}