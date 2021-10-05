using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Exchanges.Trades;

namespace Stump.Server.WorldServer.Game.Exchanges.Craft
{
    public class Crafter : CraftingActor
    {
        public Crafter(BaseCraftDialog exchange, Character character)
            : base(exchange, character)
        {
        }

        public override int Id => Character.Id;

        protected override void OnItemMoved(TradeItem item, bool modified, int difference)
        {
            base.OnItemMoved(item, modified, difference);
        }

        public override bool SetKamas(long amount)
        {
            return false;
        }
    }
}