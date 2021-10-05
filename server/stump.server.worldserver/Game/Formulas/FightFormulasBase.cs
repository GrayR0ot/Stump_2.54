using Stump.Server.WorldServer.Game.Fights.Results;
using System;

namespace Stump.Server.WorldServer.Game.Formulas
{
    public class FightFormulasBase
    {
        public static event Func<IFightResult, double, double> WinXpModifier;

        public static double CalculateWinExp(IFightResult fighter, IEnumerable<FightActor> alliesResults, IEnumerable<FightActor> droppersResults/*, int WaveNumber = 0*/)
        {
            var hoy = dayOfWeek(DateTime.Now);
            var hora = DateTime.Now.ToString("HH");

            var droppers = droppersResults as MonsterFighter[] ?? droppersResults.ToArray();
            var allies = alliesResults as FightActor[] ?? alliesResults.ToArray();

            if (!droppers.Any() || !allies.Any())
                return 0;

            var sumPlayersLevel = allies.Sum(entry => entry.Level);
            var maxPlayerLevel = allies.Max(entry => entry.Level);
            var sumMonstersLevel = droppers.Sum(entry => entry.Level);
            var sumMonstersHiddenLevel = droppers.OfType<MonsterFighter>().Sum(entry => entry.HiddenLevel == 0 ? entry.Level : entry.HiddenLevel);
            var maxMonsterLevel = droppers.Max(entry => entry.Level);
            var sumMonsterXp = droppers.Sum(entry => entry.GetGivenExperience());

            double levelCoeff = 1;
            if (sumPlayersLevel - 5 > sumMonstersLevel)
                levelCoeff = (double)sumMonstersLevel / sumPlayersLevel;
            else if (sumPlayersLevel + 10 < sumMonstersLevel)
                levelCoeff = (sumPlayersLevel + 10) / (double)sumMonstersLevel;

            var xpRatio = Math.Min(fighter.Level, Math.Truncate(2.5d * maxMonsterLevel)) / sumPlayersLevel * 100d;

            var regularGroupRatio = allies.Where(entry => entry.Level >= maxPlayerLevel / 3).Sum(entry => 1);

            if (regularGroupRatio <= 0)
                regularGroupRatio = 1;

            var baseXp = Math.Truncate(xpRatio / 100 * Math.Truncate(sumMonsterXp * GroupCoefficients[regularGroupRatio - 1] * levelCoeff));
            var multiplicator = fighter.Fight.AgeBonus <= 0 ? 1 : 1 + fighter.Fight.AgeBonus / 100d;
            var challengeBonus = fighter.Fight.GetChallengesBonus();

            var idolsBonus = fighter.Fight.GetIdolsXPBonus();
            var idolsMalus = Math.Pow(Math.Min(4, ((double)sumMonstersHiddenLevel / droppers.Count() / maxPlayerLevel)), 2);
            var idolsWisdomBonus = Math.Truncate((100 + fighter.Level * 2.5) * Math.Truncate(idolsBonus * idolsMalus) / 100.0);
            var idolsWisdomBonus2 = idolsWisdomBonus;

            //var sabidol = fighter.Fight.GetIdolsSabBonus();
            var dropidols = fighter.Fight.GetIdolsDropBonus2();

            long xp = 0;
            //if (hora == "20")
            //{
            //    if (hoy == "sábado" || hoy == "domingo")
            //    {
            //        xp = (long)Math.Truncate(Math.Truncate(baseXp * (100 + Math.Max(fighter.Wisdom + idolsWisdomBonus, 0)) / 100d) * multiplicator * (Rates.XpRate * 8));
            //    }
            //    else
            //    {
            //        xp = (long)Math.Truncate(Math.Truncate(baseXp * (100 + Math.Max(fighter.Wisdom + idolsWisdomBonus, 0)) / 100d) * multiplicator * Rates.XpRate * 4);
            //    }
            //}
            //else
            //{
            //    if (hoy == "sábado" || hoy == "domingo")
            //    {
            //        xp = (long)Math.Truncate(Math.Truncate(baseXp * (100 + Math.Max(fighter.Wisdom + idolsWisdomBonus, 0)) / 100d) * multiplicator * (Rates.XpRate * 4));
            //    }
            //    else
            //    {
            //        xp = (long)Math.Truncate(Math.Truncate(baseXp * (100 + Math.Max(fighter.Wisdom + idolsWisdomBonus, 0)) / 100d) * multiplicator * Rates.XpRate * 2);
            //    }
            //}
            //xp += (long)Math.Truncate(xp * (challengeBonus / 100d));

            //if (fighter.Fight.Map.SuperArea.Id == 5 && fighter.Fight.Map.IsDungeonSpawn)
            //{
            //    xp = xp * 5;
            //}

            //var finalxp = xp * sabidol / 100;
            //if (WaveNumber > 0) xp = xp * WaveNumber;

            //if (fighter is FightPlayerResult)
            //    if ((RoleEnum)(fighter as FightPlayerResult).Character.Account.UserGroupId >= RoleEnum.GameMaster_Padawan)
            //        (fighter as FightPlayerResult).Character.SendServerMessage($"Xp de base = {baseXp}, Xp finale = {xp}, CACA = {sabidol}, multiplicator = {multiplicator}, challengeBonus = {challengeBonus}, idolsWisdom = {idolsWisdomBonus}, idolsbonus ={idolsBonus}, idols malus = {idolsMalus}, idolsWisdomBonus2 = {idolsWisdomBonus2}");

            //if (fighter is FightPlayerResult)
            //             if ((RoleEnum)(fighter as FightPlayerResult).Character.Account.UserGroupId >= RoleEnum.GameMaster_Padawan)
            //                 (fighter as FightPlayerResult).Character.SendServerMessage($"Xp de base = {baseXp}, DROPIDOL = {dropidols}, SABIDOL = {sabidol}");

            //         var sumatotal = finalxp + xp;

            //         if (sumatotal >= 1000000000)
            //         {
            //             sumatotal = 1000000000;
            //         }
            //         else
            //         {
            //             sumatotal = finalxp + xp;
            //         }

            //return InvokeWinXpModifier(fighter, sumatotal);

            //var xp = (double)Math.Min(double.MaxValue, Math.Truncate(Math.Truncate(baseXp * (100 + Math.Max(fighter.Wisdom + idolsWisdomBonus, 0)) / 100d) * multiplicator * Rates.XpRate));
            //xp += (double)Math.Min(double.MaxValue, Math.Truncate(xp * (challengeBonus / 100d)));
            //if (fighter is FightPlayerResult)
            //   if ((RoleEnum)(fighter as FightPlayerResult).Character.Account.UserGroupId >= RoleEnum.GameMaster_Padawan)
            //      (fighter as FightPlayerResult).Character.SendServerMessage($"Xp de base = {baseXp}, Xp finale = {xp}, multiplicator = {multiplicator}, challengeBonus = {challengeBonus}, idolsWisdom = {idolsWisdomBonus}, idolsbonus ={idolsBonus}, idols malus = {idolsMalus}, idolsWisdomBonus2 = {idolsWisdomBonus2}");

            //return InvokeWinXpModifier(fighter, xp);
        }
    }
}