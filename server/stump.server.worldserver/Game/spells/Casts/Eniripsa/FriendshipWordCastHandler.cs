using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.History;
using Stump.Server.WorldServer.Handlers.Actions;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(SpellIdEnum.FRIENDSHIP_WORD_129)]
    public class FriendshipWordCastHandler : DefaultSpellCastHandler
    {
        public FriendshipWordCastHandler(SpellCastInformations informations)
            : base(informations)
        {
        }

        public override void Execute()
        {
            base.Execute();

            Caster.SpellHistory.RegisterCastedSpell(new SpellHistoryEntry(Caster.SpellHistory, Spell.CurrentSpellLevel,
                Caster, Caster, Fight.TimeLine.RoundNumber, 63));
            ActionsHandler.SendGameActionFightSpellCooldownVariationMessage(Caster.Fight.Clients, Caster, Caster, Spell, 63);
        }
    }

//using Stump.DofusProtocol.Enums;
//using Stump.Server.WorldServer.Game.Actors.Fight;
//using Stump.Server.WorldServer.Game.Fights;
//using Stump.Server.WorldServer.Game.Fights.History;
//using Stump.Server.WorldServer.Handlers.Actions;

//namespace Stump.Server.WorldServer.Game.Spells.Casts.Roublard
//{
//    [SpellCastHandler(SpellIdEnum.FRIENDSHIP_WORD_129)]
//    public class FriendshipWordCastHandler : DefaultSpellCastHandler
//    {

//        public FriendshipWordCastHandler(SpellCastInformations cast )
//            : base(cast)
//        {
//        }

//        public override void Execute()
//        {
//            base.Execute();

//            var slave = Fight.GetOneFighter<SummonedFighter>(x => x.Cell == TargetedCell && x.Controller == Caster);

//            if (slave == null)
//                return;

//            slave.CastAutoSpell(new Spell((int)SpellIdEnum.INITIALISATION, 1), TargetedCell);
//            Caster.SpellHistory.RegisterCastedSpell(new SpellHistoryEntry(Caster.SpellHistory, Spell.CurrentSpellLevel,
//                Caster, Caster, Fight.TimeLine.RoundNumber, 63));
//            ActionsHandler.SendGameActionFightSpellCooldownVariationMessage(Caster.Fight.Clients, Caster, Caster, Spell, 63);
//        }
//    }
[SpellCastHandler(SpellIdEnum.AFFECTIONATE_WORD_9394)]
    public class AffectionateWordCastHandler : DefaultSpellCastHandler
    {
        public AffectionateWordCastHandler(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            base.Execute();

            Caster.SpellHistory.RegisterCastedSpell(new SpellHistoryEntry(Caster.SpellHistory, Spell.CurrentSpellLevel,
                Caster, Caster, Fight.TimeLine.RoundNumber, 63));
            ActionsHandler.SendGameActionFightSpellCooldownVariationMessage(Caster.Fight.Clients, Caster, Caster, Spell, 63);
        }
    }
}