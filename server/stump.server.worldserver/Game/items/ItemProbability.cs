using Stump.Server.WorldServer.Database.Items.Templates;

namespace Stump.Server.WorldServer.Game.Items
{
    public class ItemProbability
    {

        public ItemTemplate itemTemplate
        {
            get => itemTemplate;
            set => itemTemplate = value;
        }

        public int amount
        {
            get => amount;
            set => amount = value;
        }

        public double probability
        {
            get => probability;
            set => probability = value;
        }

        public ItemProbability(ItemTemplate itemTemplate, int amount, double probability)
        {
            this.itemTemplate = itemTemplate;
            this.amount = amount;
            this.probability = probability;
        }
    }
}