using System.Collections.Generic;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Exchanges.Trades.Players;

namespace Stump.Server.WorldServer.Game.Exchanges.Craft.Runes
{
    public class DecraftResult
    {
        public DecraftResult(PlayerTradeItem item, int coeff)
        {
            Item = item;
            Runes = new Dictionary<ItemTemplate, int>();
            this.coeff = coeff;
        }

        public PlayerTradeItem Item { get; }

        public Dictionary<ItemTemplate, int> Runes { get; }

        public int coeff { get; set; }

        /*public double? MinCoeff
        {
            get;
            set;
        }

        public double? MaxCoeff
        {
            get;
            set;
        }*/
    }
}