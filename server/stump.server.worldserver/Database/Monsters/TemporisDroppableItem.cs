using System;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;

namespace Stump.Server.WorldServer.Database.Monsters
{
    public class TemporisDroppableItemRelator
    {
        public static string FetchQuery = "SELECT * FROM temporis_monsters_drops";

        /// <summary>
        ///     Use string.Format
        /// </summary>
        public static string FetchByOwner = "SELECT * FROM temporis_monsters_drops WHERE MonsterOwnerId = {0}";
    }

    [TableName("monsters_drops")]
    public class TemporisDroppableItem : IAutoGeneratedRecord
    {
        private MonsterTemplate m_template;

        public int Id { get; set; }

        public int MonsterOwnerId { get; set; }

        [Ignore]
        public MonsterTemplate MonsterOwner
        {
            get => m_template ?? (m_template = MonsterManager.Instance.GetTemplate(MonsterOwnerId));
            set
            {
                m_template = value;
                MonsterOwnerId = value.Id;
            }
        }

        /// <summary>
        ///     The id of the item to drop
        /// </summary>
        public short ItemId { get; set; }

        /// <summary>
        ///     A monster cannot drop this item more times than the drop limit. 0 to disable this limit
        /// </summary>
        [DefaultSetting(0)]
        public int DropLimit { get; set; }

        /// <summary>
        ///     Define the probability that the item drop. Between 0.00% and 100.00%
        /// </summary>
        [NumericPrecision(16, 8)]
        public double DropRateForGrade1 { get; set; }

        /// <summary>
        ///     Define the probability that the item drop. Between 0.00% and 100.00%
        /// </summary>
        [NumericPrecision(16, 8)]
        public double DropRateForGrade2 { get; set; }

        /// <summary>
        ///     Define the probability that the item drop. Between 0.00% and 100.00%
        /// </summary>
        [NumericPrecision(16, 8)]
        public double DropRateForGrade3 { get; set; }

        /// <summary>
        ///     Define the probability that the item drop. Between 0.00% and 100.00%
        /// </summary>
        [NumericPrecision(16, 8)]
        public double DropRateForGrade4 { get; set; }

        /// <summary>
        ///     Define the probability that the item drop. Between 0.00% and 100.00%
        /// </summary>
        [NumericPrecision(16, 8)]
        public double DropRateForGrade5 { get; set; }


        /// <summary>
        ///     How many times the rolls are thrown
        /// </summary>
        [DefaultSetting(5)]
        public int RollsCounter { get; set; }

        /// <summary>
        ///     Requiered team prospection to have a chance to drop the item
        /// </summary>
        [DefaultSetting(100)]
        public int ProspectingLock { get; set; }

        // todo
        [NullString] public string Condition { get; set; }

        /// <summary>
        ///     Only one item per group can be dropped (group 0 does not follow this rule)
        /// </summary>
        public int DropGroup { get; set; }

        public bool TaxCollectorCannotLoot { get; set; }

        public void SetDropRate(double rate)
        {
            DropRateForGrade1 = rate;
            DropRateForGrade2 = rate;
            DropRateForGrade3 = rate;
            DropRateForGrade4 = rate;
            DropRateForGrade5 = rate;
        }

        public void SetDropRate(double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min > max");

            var div = max - min / 4d;

            DropRateForGrade1 = min;
            DropRateForGrade2 = min + div;
            DropRateForGrade3 = min + 2 * div;
            DropRateForGrade4 = min + 3 * div;
            DropRateForGrade5 = max;
        }

        public double GetDropRate(int grade)
        {
            if (grade <= 1)
                return DropRateForGrade1;
            if (grade == 2)
                return DropRateForGrade2;
            if (grade == 3)
                return DropRateForGrade3;
            if (grade == 4)
                return DropRateForGrade4;
            return DropRateForGrade5;
        }
    }
}