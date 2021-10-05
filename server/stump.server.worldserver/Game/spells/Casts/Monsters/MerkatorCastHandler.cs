using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Fights;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(4009)]
    public class MerkatorCastHandler : DefaultSpellCastHandler
    {
        public MerkatorCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            foreach (var handlers in Handlers)
            {
                handlers.DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
            }
        }
    }
}