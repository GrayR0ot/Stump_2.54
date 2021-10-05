using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Maps.Cells;

namespace Stump.Server.WorldServer.AI.Fights.Spells
{
    public class SpellTarget
    {
        public double MinFire,
            MaxFire,
            MinWater,
            MaxWater,
            MinEarth,
            MaxEarth,
            MinAir,
            MaxAir,
            MinNeutral,
            MaxNeutral,
            MinHeal,
            MaxHeal;

        public double Fire => (MinFire + MaxFire) / 2;

        public double Air => (MinAir + MaxAir) / 2;

        public double Earth => (MinEarth + MaxEarth) / 2;

        public double Water => (MinWater + MaxWater) / 2;

        public double Neutral => (MinEarth + MaxEarth) / 2;

        public double Heal => (MinHeal + MaxHeal) / 2;

        public double Curse { get; set; }

        public double Boost { get; set; }

        //public string Comment { get; set; }
        // Min total damage            
        public double MinDamage => MinFire + MinAir + MinEarth + MinWater + MinNeutral + MaxHeal + Curse + Boost;

        // Max total damage            
        public double MaxDamage => MaxFire + MaxAir + MaxEarth + MaxWater + MaxNeutral + MinHeal + Curse + Boost;

        /// <summary>
        ///     Return positive values for bad effects (curses and spellImpact) and négative values for good effects (heals and
        ///     boosts)
        /// </summary>
        public double Damage => (MinDamage + MaxDamage) / 2;

        /// <summary>
        ///     Can be null
        /// </summary>
        public TargetCell Target { get; set; }

        public Cell[] AffectedCells { get; set; }

        public MapPoint TargetPoint => Target.Point;

        public Cell CastCell { get; set; }

        public void Add(SpellTarget dmg)
        {
            MinFire += dmg.MinFire;
            MaxFire += dmg.MaxFire;
            MinWater += dmg.MinWater;
            MaxWater += dmg.MaxWater;
            MinEarth += dmg.MinEarth;
            MaxEarth += dmg.MaxEarth;
            MinAir += dmg.MinAir;
            MaxAir += dmg.MaxAir;
            MinNeutral += dmg.MinNeutral;
            MaxNeutral += dmg.MaxNeutral;
            MinHeal += dmg.MinHeal;
            MaxHeal += dmg.MaxHeal;
            Curse += dmg.Curse;
            Boost += dmg.Boost;
        }

        public void Multiply(double ratio)
        {
            MinFire *= ratio;
            MaxFire *= ratio;
            MinWater *= ratio;
            MaxWater *= ratio;
            MinEarth *= ratio;
            MaxEarth *= ratio;
            MinAir *= ratio;
            MaxAir *= ratio;
            MinNeutral *= ratio;
            MaxNeutral *= ratio;
            MinHeal *= ratio;
            MaxHeal *= ratio;
            Curse *= ratio;
            Boost *= ratio;
        }
    }
}