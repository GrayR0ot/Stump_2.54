using System.Linq;
using Stump.Core.Extensions;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Extensions;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Debuffs;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Move;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Handlers.Actions;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(SpellIdEnum.HUNTING_TROPHY)]
    public class Razof : DefaultSpellCastHandler
    {
        public Razof(SpellCastInformations cast)
            : base(cast)
        {

            var oneFighter = Fight.GetOneFighter(TargetedCell);
            if (oneFighter is SummonedFighter)
            {
                Initialize();
            }
        }
    }
}

