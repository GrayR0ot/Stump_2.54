using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.Extensions;
using Stump.Core.Mathematics;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class BreachBranches
    {
        public static ExtendedBreachBranch[] generateSongeBranches(Character character)
        {
            var random = new CryptoRandom();
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
            var map = World.Instance.GetMap(maps[new Random().Next(maps.Count())]);
            var branchMonsters = new List<List<int>>();
            var branchBosses = new List<int>();
            if (character.breachStep < 201)
            {
                for (var index = 0; index < 3; index++)
                {
                    var monsterGrades = new List<int>();
                    branchBosses.Add(getRandomMonster(character, true, random));
                    for (var i = 0; i < 3; i++)
                    {
                        var monsterGrade = getRandomMonster(character, false, random);
                        monsterGrades.Add(monsterGrade);
                    }

                    branchMonsters.Add(monsterGrades);
                }

                //ROOM: I // II // III etc dans le menu
                //MODIFIER: Modificateur de combat (Paradoxe/Rêve/Cauchemard)
                var monsterBranches = new List<MonsterInGroupLightInformations[]>();
                for (var i = 0; i < 3; i++)
                {
                    var monsterBranch =
                        new List<MonsterInGroupLightInformations>();
                    for (var j = 0; j < 3; j++)
                    {
                        var monsterGrade = MonsterManager.Instance.GetMonsterGrade(branchMonsters[i][j]);

                        monsterBranch.Add(new MonsterInGroupLightInformations(
                            monsterGrade.Template.Id, (sbyte) monsterGrade.GradeId,
                            (short) monsterGrade.Level)
                        );
                    }

                    monsterBranches.Add(monsterBranch.ToArray());
                }

                var bossBranches = new List<MonsterInGroupLightInformations[]>();
                for (var i = 0; i < 3; i++)
                {
                    var bossBranch = new List<MonsterInGroupLightInformations>();
                    var monsterGrade = MonsterManager.Instance.GetMonsterGrade(branchBosses[i]);

                    bossBranch.Add(new MonsterInGroupLightInformations(
                        monsterGrade.Template.Id, (sbyte) monsterGrade.GradeId,
                        (short) monsterGrade.Level)
                    );
                    bossBranches.Add(bossBranch.ToArray());
                }


                ExtendedBreachBranch[] extendedBreachBranchs =
                {
                    new ExtendedBreachBranch(1, 1, bossBranches[0], map.Id, monsterBranches[0], getRandomReward(random),
                        155, 100),
                    new ExtendedBreachBranch(2, 2, bossBranches[1], map.Id, monsterBranches[1], getRandomReward(random),
                        155, 100),
                    new ExtendedBreachBranch(3, 3, bossBranches[2], map.Id, monsterBranches[2], getRandomReward(random),
                        155, 100)
                };
                return extendedBreachBranchs;
            }

            return null;
        }

        private static BreachReward[] getRandomReward(CryptoRandom cryptoRandom)
        {
            BreachReward[] breachRewards = { };
            var range = new List<BreachBoost>
            {
                new BreachBoost(100, 300), new BreachBoost(114, 600), new BreachBoost(128, 900),
                new BreachBoost(93,
                    300), //TACKLE, VITALITY, INTELLIGENCY, CHANCE, AGILITY, STRENGTH, POWER, RET PA, RET PM, FUITE
                new BreachBoost(107, 600), new BreachBoost(121, 900), new BreachBoost(6, 300), new BreachBoost(103, 600),
                new BreachBoost(117, 900), new BreachBoost(7, 300), new BreachBoost(104, 600), new BreachBoost(118, 900),
                new BreachBoost(91, 300), new BreachBoost(105, 600), new BreachBoost(119, 900), new BreachBoost(92, 300),
                new BreachBoost(106, 600), new BreachBoost(120, 900), new BreachBoost(94, 300), new BreachBoost(108, 600),
                new BreachBoost(122, 900), new BreachBoost(95, 300), new BreachBoost(109, 600), new BreachBoost(123, 900),
                new BreachBoost(96, 300), new BreachBoost(110, 600), new BreachBoost(124, 900), new BreachBoost(99, 300),
                new BreachBoost(113, 600), new BreachBoost(127, 900)
            };
            for (var i = 0; i < 3; i++)
            {
                var breachReward = range[cryptoRandom.Next(range.Count)];
                breachRewards =
                    breachRewards.Add(new BreachReward(breachReward.Id, new byte[0], "", false, breachReward.Price));
            }

            return breachRewards;
        }

        private static int getRandomMonster(Character character, bool isBoss, CryptoRandom random)
        {
            var levelGroup = 0;
            if (character.breachStep <= 50)
                levelGroup = 21;
            else if (character.breachStep <= 100)
                levelGroup = 22;
            else if (character.breachStep <= 150)
                levelGroup = 23;
            else
                levelGroup = 24;

            if (isBoss)
                return MonsterManager.Instance.GetMonsterGrades().Where(x => x.GradeId == levelGroup)
                    .Where(x => MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss)
                    .OrderBy(x => random.Next())
                    .ToArray()[
                        random.Next(MonsterManager.Instance.GetMonsterGrades()
                            .Where(x => x.GradeId == levelGroup)
                            .Where(x => MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss)
                            .Count())].Id;
            return MonsterManager.Instance.GetMonsterGrades().Where(x => x.GradeId == levelGroup)
                .Where(x => !MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss)
                .OrderBy(x => random.Next())
                .ToArray()[
                    random.Next(MonsterManager.Instance.GetMonsterGrades()
                        .Where(x => x.GradeId == levelGroup)
                        .Where(x => !MonsterManager.Instance.GetTemplate(x.MonsterId).IsBoss)
                        .Count())].Id;
        }
    }
}