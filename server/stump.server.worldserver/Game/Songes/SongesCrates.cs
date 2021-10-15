using System.Collections.Generic;
using Stump.Core.Mathematics;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongesCrates
    {
        public CryptoRandom cryptoRandom;
        private readonly List<ItemProbability> itemProbabilities;
        private double total;

        public SongesCrates(List<ItemProbability> itemProbabilities)
        {
            this.itemProbabilities = itemProbabilities;
            cryptoRandom = new CryptoRandom();
        }

        public ItemProbability open()
        {
            itemProbabilities.ForEach(x => total += x.probability);
            var realItems = new Dictionary<ItemProbability, double>();
            foreach (var item in itemProbabilities)
            {
                var realProbability = item.probability / total;
                realItems.Add(item, realProbability);
            }

            double currentProbability = 0;
            var finished = false;
            while (!finished)
                foreach (var realItem in realItems)
                {
                    var random = cryptoRandom.NextDouble();
                    if (random <= realItem.Value)
                    {
                        finished = true;
                        return realItem.Key;
                    }

                    currentProbability += realItem.Value;
                }

            return null;
        }
    }
}