using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Stump.Core.Reflection;
using Stump.Core.Threading;
using Stump.Server.BaseServer.Initialization;
using Stump.Server.WorldServer.Game;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;

namespace Game.Vote
{
    public class MonsterStarLoop : Singleton<MonsterStarLoop>
    {
        // FIELDS
        private static Task _queueRefresherTask;
        private static readonly int _queueRefresherElapsedTime = 540000; //2H 7200000

        // METHODS
        [Initialization(InitializationPass.Any)]
        private static void Initialize()
        {
            _queueRefresherTask = Task.Factory.StartNewDelayed(_queueRefresherElapsedTime, Instance.StartLoop);
        }

        private void StartLoop()
        {
            try
            {
                foreach (var monster in World.Instance.GetMaps().SelectMany(x => x.Actors.OfType<MonsterGroup>()))
                    monster.AgeBonus = 200;
                World.Instance.SendAnnounce(
                    "<b>Serveur :</b> Tapez .help pour voir les commandes , la boutique se trouve dans le zaap (zone boutique ).",
                    Color.AliceBlue);
            }
            finally
            {
                _queueRefresherTask = Task.Factory.StartNewDelayed(_queueRefresherElapsedTime, Instance.StartLoop);
            }
        }
    }
}