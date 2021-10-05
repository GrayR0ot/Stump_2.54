namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongeBoost
    {
        private uint id;
        private uint price;

        public SongeBoost(uint id, uint price)
        {
            this.id = id;
            this.price = price;
        }

        public uint Id
        {
            get => id;
            set => id = value;
        }

        public uint Price
        {
            get => price;
            set => price = value;
        }
    }
}