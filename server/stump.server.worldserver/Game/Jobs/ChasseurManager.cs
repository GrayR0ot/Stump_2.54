using System.Collections.Generic;
using System.Linq;
using Stump.Server.BaseServer.Database;
using Stump.Server.BaseServer.Initialization;
using Stump.Server.WorldServer.Database.Zaap;

namespace Stump.Server.WorldServer.Game.Zaap
{
    internal class ChasseurManager : DataManager<ChasseurManager>
    {
        private Dictionary<int, ChasseurRecord> m_chasseurInfos;

        [Initialization(InitializationPass.Fourth)]
        public override void Initialize()
        {
            m_chasseurInfos = Database.Query<ChasseurRecord>(ChasseurRelator.FetchQuery)
                .ToDictionary(entry => entry.MonsterId);
        }

        public bool DropExist(int MonsterTemplate)
        {
            ChasseurRecord drop_exist;
            m_chasseurInfos.TryGetValue(MonsterTemplate, out drop_exist);

            if (drop_exist != null)
                return true;
            return false;
        }

        public int ItemId(int MonsterTemplate)
        {
            return m_chasseurInfos[MonsterTemplate].DropId;
        }

        public int Level(int MonsterTemplate)
        {
            return m_chasseurInfos[MonsterTemplate].Level;
        }
    }
}