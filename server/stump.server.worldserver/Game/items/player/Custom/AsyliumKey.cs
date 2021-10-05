namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    public class AsyliumKey
    {

        int dungeon;
        int key;

        public AsyliumKey(int dungeon, int key)
        {
            this.dungeon = dungeon;
            this.key = key;
        }

        public int getDungeon()
        {
            return this.dungeon;
        }

        public int getKey()
        {
            return this.key;
        }
    }
    public class AsyliumDofus
    {

        int dungeon;
        int key;

        public AsyliumDofus(int dungeon, int key)
        {
            this.dungeon = dungeon;
            this.key = key;
        }

        public int getDungeon()
        {
            return this.dungeon;
        }

        public int getKey()
        {
            return this.key;
        }
    }
}