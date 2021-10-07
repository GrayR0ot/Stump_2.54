namespace MapGenerator
{
    public class MapUtils
    {
        private int mapId;

        private int topNeighbourId;
        private int bottomNeighbourId;
        private int leftNeighbourId;
        private int rightNeighbourId;

        public MapUtils(int mapId, int topNeighbourId, int bottomNeighbourId, int leftNeighbourId, int rightNeighbourId)
        {
            this.mapId = mapId;
            this.topNeighbourId = topNeighbourId;
            this.bottomNeighbourId = bottomNeighbourId;
            this.leftNeighbourId = leftNeighbourId;
            this.rightNeighbourId = rightNeighbourId;
        }

        public int MapId
        {
            get => mapId;
            set => mapId = value;
        }

        public int TopNeighbourId
        {
            get => topNeighbourId;
            set => topNeighbourId = value;
        }

        public int BottomNeighbourId
        {
            get => bottomNeighbourId;
            set => bottomNeighbourId = value;
        }

        public int LeftNeighbourId
        {
            get => leftNeighbourId;
            set => leftNeighbourId = value;
        }

        public int RightNeighbourId
        {
            get => rightNeighbourId;
            set => rightNeighbourId = value;
        }
    }
}