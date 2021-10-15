namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongeBoost
    {
        public SongeBoost(uint id, uint price)
        {
            this.Id = id;
            this.Price = price;
        }

        public uint Id { get; set; }

        public uint Price { get; set; }
    }
}