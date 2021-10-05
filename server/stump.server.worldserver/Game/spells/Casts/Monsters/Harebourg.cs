using Stump.Server.WorldServer.Game.Fights;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(3657)]
    public class Harebourg : DefaultSpellCastHandler
    {
        public Harebourg(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {

            foreach (var handlers in Handlers)
            {


                handlers.Apply();

            }
        }
    }
}
