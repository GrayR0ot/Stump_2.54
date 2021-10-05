namespace Stump.Server.WorldServer.Game.Exchanges.Trades
{
    public class EmptyTrader : Trader
    {
        public EmptyTrader(int id, ITrade trade)
            : base(trade)
        {
            Id = id;
        }

        public override int Id { get; }

        public override bool MoveItem(uint id, int quantity)
        {
            return false;
        }
    }
}