using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Fights.Results;

namespace Stump.Server.WorldServer.Game.Formulas
{
    public class FightFormulas
    {
        public static readonly double[] GroupCoefficients =
        {
            1,
            1.1,
            1.5,
            2.3,
            3.1,
            3.6,
            4.2,
            4.7
        };

        public static event Func<IFightResult, long, long> WinXpModifier;

        public static long InvokeWinXpModifier(IFightResult looter, long xp)
        {
            var handler = WinXpModifier;
            return handler != null ? handler(looter, xp) : xp;
        }

        public static event Func<IFightResult, int, int> WinKamasModifier;

        public static int InvokeWinKamasModifier(IFightResult looter, int kamas)
        {
            var handler = WinKamasModifier;
            return handler != null ? handler(looter, kamas) : kamas;
        }

        public static event Func<IFightResult, DroppableItem, double, double> DropRateModifier;

        public static double InvokeDropRateModifier(IFightResult looter, DroppableItem item, double rate)
        {
            var handler = DropRateModifier;
            return handler != null ? handler(looter, item, rate) : rate;
        }

        public static string dayOfWeek(DateTime? date)
        {
            return date.Value.ToString("dddd", new CultureInfo("en-EN"));
        }

        public static long CalculateWinExp(IFightResult fighter, IEnumerable<FightActor> alliesResults,
            IEnumerable<FightActor> droppersResults, int WaveNumber = 0)
        {
            if (WaveNumber > 0) droppersResults = droppersResults.Take(alliesResults.Count());
            var droppers = droppersResults as MonsterFighter[] ?? droppersResults.ToArray();
            var allies = alliesResults as FightActor[] ?? alliesResults.ToArray();

            if (!droppers.Any() || !allies.Any())
                return 0;

            var sumPlayersLevel = allies.Sum(entry => entry.Level > 200 ? 200 : entry.Level);
            var maxPlayerLevel = allies.Max(entry => entry.Level > 200 ? 200 : entry.Level);
            var sumMonstersLevel = droppers.Sum(entry => entry.Level);
            var sumMonstersHiddenLevel = droppers.OfType<MonsterFighter>()
                .Sum(entry => entry.HiddenLevel == 0 ? entry.Level : entry.HiddenLevel);
            var maxMonsterLevel = droppers.Max(entry => entry.Level);
            var sumMonsterXp = droppers.Sum(entry => entry.GetGivenExperience());

            double levelCoeff = 1;
            if (sumPlayersLevel - 5 > sumMonstersLevel)
                levelCoeff = (double) sumMonstersLevel / sumPlayersLevel;
            else if (sumPlayersLevel + 10 < sumMonstersLevel)
                levelCoeff = (sumPlayersLevel + 10) / (double) sumMonstersLevel;

            var xpRatio = Math.Min(fighter.Level, Math.Truncate(2.5d * maxMonsterLevel)) / sumPlayersLevel * 100d;
            if (fighter.Level > 200)
                xpRatio = Math.Min(200, Math.Truncate(2.5d * maxMonsterLevel)) / sumPlayersLevel * 100d;

            var regularGroupRatio = allies.Where(entry => entry.Level >= maxPlayerLevel / 3).Sum(entry => 1);

            if (regularGroupRatio <= 0)
                regularGroupRatio = 1;

            var baseXp = Math.Truncate(xpRatio / 100 *
                                       Math.Truncate(sumMonsterXp * GroupCoefficients[regularGroupRatio - 1] *
                                                     levelCoeff));
            var challengeBonus = fighter.Fight.GetChallengesBonus();

            var idolsBonus = fighter.Fight.GetIdolsXPBonus();
            var idolsMalus = Math.Pow(Math.Min(4, (double) sumMonstersHiddenLevel / droppers.Count() / maxPlayerLevel),
                2);
            var idolsWisdomBonus =
                Math.Truncate((100 + fighter.Level * 2.5) * Math.Truncate(idolsBonus * idolsMalus) / 100.0);

            long xp = 0;
            xp = (long) Math.Truncate(
                Math.Truncate(baseXp * (100 + Math.Max(fighter.Wisdom + challengeBonus + idolsWisdomBonus, 0)) / 100d) *
                Rates.XpRate);

            if (WaveNumber > 0) xp = xp * WaveNumber;

            return InvokeWinXpModifier(fighter, xp);
        }


        public static int AdjustDroppedKamas(IFightResult looter, int teamPP, long baseKamas, bool kamasRate = true)
        {
            var challengeBonus = looter.Fight.GetChallengesBonus();
            var idolsBonus = looter.Fight.GetIdolsDropBonus();

            var looterPP = looter.Prospecting + looter.Prospecting * (challengeBonus + idolsBonus) / 250d;

            var multiplicator = looter.Fight.AgeBonus <= 0 ? 1 : 1 + looter.Fight.AgeBonus / 5 / 200d;
            var kamas = (int) (baseKamas * (looterPP / teamPP) * multiplicator * (kamasRate ? Rates.KamasRate : 2));

            return InvokeWinKamasModifier(looter, kamas);
        }

        public static int CalculateEarnedKamas(IFightResult fighter, IEnumerable<FightActor> alliesResults,
            IEnumerable<FightActor> droppersResults)
        {
            var initialRate = 0.5;
            var result = 0;
            var maxLootNumber = 0;
            var multiplicateur = 0;
            var totalMobGroupLevel = 0;
            foreach (MonsterFighter mnstr in droppersResults.Where(x => !(x is SummonedMonster))
                .Where(x => !(x is SummonedImage)).Where(x => !(x is SummonedClone)))
                if (mnstr.Monster.Template.Id != 494)
                    /*if (mnstr.Level >= 200)
                            multiplicateur = 200;
                        else if (mnstr.Level <= 199 && mnstr.Level > 150)
                            multiplicateur = 150;
                        else if (mnstr.Level <= 150 && mnstr.Level > 100)
                            multiplicateur = 120;
                        else if (mnstr.Level <= 100 && mnstr.Level > 50)
                            multiplicateur = 80;
                        else if (mnstr.Level <= 50)
                            multiplicateur = 50;
                        maxLootNumber = mnstr.Level * multiplicateur;
                        result += maxLootNumber; /// fighter.Fight.ChallengersTeam.GetAllFighters().Count();*/
                    totalMobGroupLevel += mnstr.Level;
            result = (int) (totalMobGroupLevel * initialRate * Rates.KamasRate);
            return result;
        }

        //public static double AdjustDropChance(IFightResult looter, DroppableItem item, Monster dropper, int monsterAgeBonus)
        //{
        //    var challengeBonus = looter.Fight.GetChallengesBonus();
        //    var idolsBonus = looter.Fight.GetIdolsDropBonus();


        //    //if (World.Instance.GetCharacters(x => x.Client.IP == character.Client.IP).ToList().Exists(x => x.WorldAccount.Vip))
        //    //{
        //    //    multiplicator = 1.15f;
        //    //}

        //    var looterPP = looter.Prospecting * (1 + ((challengeBonus + idolsBonus) / 85d));

        //    var rate = item.GetDropRate((int)dropper.Grade.GradeId) * (looterPP / 75d) * ((monsterAgeBonus / 100d) + 1) * Rates.DropsRate;
        //    return InvokeDropRateModifier(looter, item, rate);
        //}

        public static double AdjustDropChance(IFightResult looter, DroppableItem item, Monster dropper,
            int monsterAgeBonus)
        {
            var challengeBonus = looter.Fight.GetChallengesBonus();
            var idolsBonus = looter.Fight.GetIdolsDropBonus();

            var looterPP = looter.Prospecting / 100d * (1 + (challengeBonus + idolsBonus) / 75d);

            var rate = item.GetDropRate((int) dropper.Grade.GradeId) * looterPP * Rates.DropsRate;
            if (looter is FightPlayerResult)
                if ((looter as FightPlayerResult).Character.WorldAccount.Vip >= 1)
                    rate = rate * Rates.VipBonusDrop;
            return InvokeDropRateModifier(looter, item, rate);
        }

        public static bool HasMinSize(SpellShapeEnum zone)
        {
            return zone == SpellShapeEnum.C || zone == SpellShapeEnum.X || zone == SpellShapeEnum.Q ||
                   zone == SpellShapeEnum.plus || zone == SpellShapeEnum.sharp;
        }

        public static int CalculatePushBackDamages(FightActor source, FightActor target, int range,
            int targets)
        {
            var level = source.Level;

            if (level > 200)
                level = 200;

            var summon = source as SummonedMonster;
            if (summon != null)
                level = summon.Summoner.Level;

            return (int) ((level / 2 + (source.Stats[PlayerFields.PushDamageBonus] -
                                        target.Stats[PlayerFields.PushDamageReduction]) + 32) * range /
                          (4 * Math.Pow(2, targets)));
        }

        private enum Dia
        {
            Lunes = 1,
            Martes = 2,
            Miercoles = 3,
            Jueves = 4,
            Viernes = 5,
            Sabado = 6,
            Domingo = 0
        }
        
        public static double getRandomFinalBonus() {
            double finalBonus = 1;
            double randomBonus = new Random().Next(9);
            switch (randomBonus)
            {
                case 1:
                    finalBonus = 1.25;
                    break;
                case 2:
                    finalBonus = 1.5;
                    break;
                case 3:
                    finalBonus = 1.75;
                    break;
                case 4:
                    finalBonus = 2;
                    break;
                case 5:
                    finalBonus = 2.25;
                    break;
                case 6:
                    finalBonus = 2.5;
                    break;
                case 7:
                    finalBonus = 2.75;
                    break;
                case 8:
                    finalBonus = 3;
                    break;
                default:
                    finalBonus = 1;
                    break;
            }
            return finalBonus;
        }
    }
}