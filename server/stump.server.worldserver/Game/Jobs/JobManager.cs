using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.Collections;
using Stump.Server.BaseServer.Database;
using Stump.Server.BaseServer.Initialization;
using Stump.Server.WorldServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Database.Items.Craft;
using Stump.Server.WorldServer.Database.Jobs;
using Stump.Server.WorldServer.Game.Interactives;

namespace Stump.Server.WorldServer.Game.Jobs
{
    public class JobManager : DataManager<JobManager>, ISaveable
    {
        private readonly object m_lock = new object();
        public const int MAX_JOB_LEVEL_GAP = 100;
        public const int WEIGHT_BONUS_PER_LEVEL = 12;
        public const double WEIGHT_BONUS_DECREASE = 1 / 200d;
        private List<CraftItemRecord> m_historyRecords = new List<CraftItemRecord>();

        private Dictionary<int, JobTemplate> m_jobTemplates;
        private Dictionary<int, RecipeRecord> m_recipeRecords;

        public IReadOnlyDictionary<int, RecipeRecord> Recipes => m_recipeRecords;

        public void Save()
        {
            Database.BeginTransaction();
            lock (m_lock)
            {
                var dbIds = new List<CraftItemRecord>(m_historyRecords);

                foreach (var id in dbIds.Distinct())
                {
                    var record = GetCraftItemById(id.ItemId, id.OwnerId);
                    if (record != null)
                    {
                        record.Amount = id.Amount;
                        Database.Save(record);
                    }
                    else
                    {
                        record = new CraftItemRecord
                        {
                            ItemId = id.ItemId,
                            Amount = id.Amount,
                            OwnerId = id.OwnerId
                        };
                        Database.Insert(record);
                    }
                }
            }

            Database.CompleteTransaction();
        }

        [Initialization(InitializationPass.Fifth)]
        public void Initialize()
        {
            m_jobTemplates = Database.Query<JobTemplate>(JobTemplateRelator.FetchQuery).ToDictionary(x => x.Id);

            m_recipeRecords = Database.Query<RecipeRecord>(RecipeRelator.FetchQuery).ToDictionary(x => x.Id);

            m_historyRecords = Database.Query<CraftItemRecord>(CraftItemRelator.FetchQuery).ToList();


            World.Instance.RegisterSaveableInstance(this);
        }

        public CraftItemRecord GetCraftItemById(int id, int ownerId)
        {
            WorldServer.Instance.IOTaskPool.EnsureContext();
            return Database.Query<CraftItemRecord>(string.Format(CraftItemRelator.FetchById, id, ownerId))
                .FirstOrDefault();
        }

        public void RegisterCraft(int itemId, int amount, int ownerId)
        {
            CraftItemRecord record;
            var existant = m_historyRecords.FirstOrDefault(x => x.ItemId == itemId && x.OwnerId == ownerId);
            if (existant != null)
            {
                if (existant.Amount + amount > 1000000)
                    m_historyRecords.FirstOrDefault(x => x.ItemId == itemId && x.OwnerId == ownerId).Amount = 1000000;
                else
                    m_historyRecords.FirstOrDefault(x => x.ItemId == itemId && x.OwnerId == ownerId).Amount += amount;
            }
            else
            {
                record = new CraftItemRecord
                {
                    ItemId = itemId,
                    Amount = amount,
                    OwnerId = ownerId
                };
                m_historyRecords.Add(record);
            }
        }

        public int GetAmountOfCraft(int ownerId, int itemId)
        {
            var amount = 0;
            if (itemId == 0)
                foreach (var item in m_historyRecords.Where(x => x.OwnerId == ownerId))
                    amount += item.Amount;
            else if (m_historyRecords.FirstOrDefault(x => x.ItemId == itemId && x.OwnerId == ownerId) != null)
                amount = m_historyRecords.FirstOrDefault(x => x.ItemId == itemId && x.OwnerId == ownerId).Amount;

            return amount;
        }

        public JobTemplate GetJobTemplate(int id)
        {
            return m_jobTemplates.TryGetValue(id, out var job) ? job : null;
        }

        public JobRecord[] GetCharacterJobs(int characterId)
        {
            return Database.Query<JobRecord>(string.Format(JobRecordRelator.FetchByOwner, characterId)).ToArray();
        }

        public InteractiveSkillTemplate[] GetJobSkills(int jobId)
        {
            return InteractiveManager.Instance.SkillsTemplates.Values.Where(x => x.ParentJobId == jobId).ToArray();
        }

        public JobTemplate[] GetJobTemplates()
        {
            return m_jobTemplates.Values.ToArray();
        }

        public IEnumerable<JobTemplate> EnumerateJobTemplates()
        {
            return m_jobTemplates.Values;
        }


        public int GetHarvestJobXp(int minLevel)
        {
            return (int) (Math.Floor(5 + minLevel / 10d) * Rates.JobXpRate);
        }

        public Pair<int, int> GetHarvestItemMinMax(JobTemplate job, int jobLevel,
            InteractiveSkillTemplate skillTemplate)
        {
            var min = (int) ((jobLevel / 15 + 5) * Rates.DropsRate);
            var max = (int) (jobLevel / 8 * Rates.DropsRate);
            if (skillTemplate.LevelMin > jobLevel)
                return new Pair<int, int>(0, 0);

            if (jobLevel <= 50)
                return new Pair<int, int>(min, (int) (max + 5 * Rates.DropsRate));
            if (jobLevel == 200)
                return new Pair<int, int>(min, (int) (max * (5 * Rates.DropsRate)));
            if (skillTemplate.LevelMin == 200 || job.HarvestedCountMax == 0)
                return new Pair<int, int>(min, max);

            return new Pair<int, int>(Math.Max(min, max),
                (int) (job.HarvestedCountMax + (jobLevel - skillTemplate.LevelMin) / 7));
        }


        public int GetWeightBonus(int lastLevel, int newLevel)
        {
            // sum(WEIGHT_BONUS_PER_LEVEL - WEIGHT_BONUS_DECREASE*newLevel) from lastLevel + 1 to newLevel
            // approx WEIGHT_BONUS_PER_LEVEL*diff - WEIGHT_BONUS_DECREASE * (diff*(diff+1) / 2 + lastLevel*diff) + diff/2

            var diff = newLevel - lastLevel;
            var sum = 0;
            for (var i = lastLevel + 1; i < newLevel + 1; i++)
                sum += Math.Max(1, (int) Math.Ceiling(WEIGHT_BONUS_PER_LEVEL - WEIGHT_BONUS_DECREASE * i));
            return sum;

            // return (int)(WEIGHT_BONUS_PER_LEVEL * diff - WEIGHT_BONUS_DECREASE * (diff * (diff + 1) / 2 + lastLevel * diff));
        }
    }
}