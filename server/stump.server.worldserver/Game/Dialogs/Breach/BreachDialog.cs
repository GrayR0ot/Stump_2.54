using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Dialogs;
using Stump.Server.WorldServer.Handlers.Dialogs;

namespace Stump.Server.WorldServer.game.Dialogs.Breach
{
    public class BreachDialog : IDialog
    {
        public BreachDialog(Character character)
        {
            Character = character;
        }

        public Character Character { get; }

        public DialogTypeEnum DialogType => DialogTypeEnum.DIALOG_DIALOG;

        public void Close()
        {
            Character.CloseDialog(this);
            DialogHandler.SendLeaveDialogMessage(Character.Client, DialogType);
        }

        public void Open()
        {
            /*var m_boss = new List<MonsterInGroupLightInformations>();

            MonsterInGroupLightInformations boss = new MonsterInGroupLightInformations();
            boss.Grade = 5;
            boss.Level = 200;
            boss.GenericId = 126;
            m_boss.Add(boss);
            
            var m_mob = new List<MonsterInGroupLightInformations>();

            MonsterInGroupLightInformations mob = new MonsterInGroupLightInformations();
            boss.Grade = 5;
            boss.Level = 200;
            boss.GenericId = 34;
            m_mob.Add(mob);
            
            var branches = new List<ExtendedBreachBranch>();
            var branche = new ExtendedBreachBranch();
            branche.Bosses = m_boss.ToArray();
            branche.Map = 182193153;
            branche.Room = 1;
            branche.Element = 71396;

            branche.Monsters = m_mob.ToArray();
            branche.Modifier = 1;
            branche.Prize = 5000;
            branche.Rewards = new BreachReward[0];
            branches.Add(branche);

            Character.SetDialog (this);
            Character.Client.Send (new BreachBranchesMessage(new ExtendedBreachBranch[0]));*/

            Character.ResetDialog();
            var random = new Random();
            var maps = new List<int> {191104002};
            var map = World.Instance.GetMap(maps[new Random().Next(maps.Count())]);
            var branchMonsters = new List<List<int>>();
            var branchBosses = new List<int>();
            if (Character.songesStep < 201)
            {
                for (var branches = 0; branches < 3; branches++)
                    if (Character.songesStep < 51)
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
                Character.SetAscensionStair(0);
                //return true;
            }

            //ROOM: I // II // III etc dans le menu
            //MODIFIER: Modificateur de combat (Paradoxe/Rêve/Cauchemard)
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
                new BreachReward(7, new byte[0], "", false, 100), //CHANCE
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
            Character.Client.Send(new BreachBranchesMessage(extendedBreachBranchs));
        }
    }
}