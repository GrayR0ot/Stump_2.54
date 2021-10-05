using System;
using System.Linq;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Commands.Matching.Characters
{
    public class MapCriteria : BaseCriteria<Character>
    {
        public MapCriteria(BaseMatching<Character> matching, string pattern)
            : base(matching, pattern)
        {
        }

        public override Character[] GetMatchings()
        {
            var position = 0;
            if (Pattern[position + 1] == ':')
            {
                position++;
                var idStr = Pattern.Substring(position, Pattern.IndexOf("}", position) - position);
                int id;
                if (int.TryParse(idStr, out id))
                    throw new Exception("Invalid token. Did you mean {map} or {map:#} ? (# is a map id)");

                var map = World.Instance.GetMap(id);

                if (map == null)
                    throw new Exception(string.Format("Map {0} not found", id));

                return map.GetAllCharacters().ToArray();
            }

            if (!Pattern.Equals("map", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("Invalid token. Did you mean {map} or {map:#} ? (# is a map id)");

            if (Matching.Caller == null)
                throw new Exception("Caller not specified, cannot retrieve current map");

            return Matching.Caller.Map.GetAllCharacters().ToArray();
        }
    }
}