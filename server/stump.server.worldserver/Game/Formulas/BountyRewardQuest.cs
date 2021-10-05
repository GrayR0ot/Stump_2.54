using Stump.Server.WorldServer.Game.Fights.Results;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Game.Formulas
{
    internal class BountyRewardQuest
    {
        private readonly int difficultyLevel;

        public BountyRewardQuest(int difficultyLevel)
        {
            this.difficultyLevel = difficultyLevel;
        }

        public uint getNuggetAmount()
        {
            return (uint) (difficultyLevel * 10 * Rates.ResourceDropRate);
        }

        public uint getSandRoseAmount()
        {
            return (uint) (difficultyLevel * 5 * Rates.ResourceDropRate);
        }

        public void addLoot(IFightResult looter)
        {
            looter.Loot.AddItem(new DroppedItem(15263, getSandRoseAmount()));
            looter.Loot.AddItem(new DroppedItem(14635, getNuggetAmount()));
        }
    }
}