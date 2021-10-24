using System;
using Stump.Core.Attributes;

namespace Stump.Server.WorldServer
{
    [Serializable]
    public static class Rates
    {
        /// <summary>
        ///     Life regen rate (default 2 => 2hp/seconds.)
        /// </summary>
        [Variable(true)] public static float RegenRate = 2;

        [Variable(true)] public static float XpRate = 6;

        [Variable(true)] public static float KamasRate = 5;

        [Variable(true)] public static float DropsRate = 1;

        [Variable(true)] public static float ResourceDropRate = 2;

        [Variable(true)] public static float JobXpRate = 1;

        [Variable(true)] public static float VipBonusXp = 2;

        [Variable(true)] public static float VipBonusDrop = 1.50f;

        [Variable(true)] public static double KeyDropPercent = 1;

        [Variable(true)] public static float VipBonusJob = 2;
    }
}