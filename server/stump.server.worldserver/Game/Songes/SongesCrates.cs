using System.Collections.Generic;
using Stump.Core.Mathematics;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongesCrates
    {
        private double total = 0;
        private List<ItemProbability> itemProbabilities;
        public CryptoRandom cryptoRandom;
        
        public SongesCrates(List<ItemProbability> itemProbabilities)
        {
            this.itemProbabilities = itemProbabilities;
            this.cryptoRandom = new CryptoRandom();
        }

        public ItemProbability open()
        {
            itemProbabilities.ForEach(x => total+= x.probability);
            Dictionary<ItemProbability, double> realItems = new Dictionary<ItemProbability, double>();
            foreach (var item in itemProbabilities)
            {
                double realProbability = item.probability / total;
                realItems.Add(item, realProbability);
            }

            double currentProbability = 0;
            bool finished = false;
            while (!finished)
            {
                foreach (var realItem in realItems)
                {
                    double random = cryptoRandom.NextDouble();
                    if (random <= realItem.Value)
                    {
                        finished = true;
                        return realItem.Key;
                    }
                    currentProbability += realItem.Value;
                }
            }

            return null;
        }
    }
}