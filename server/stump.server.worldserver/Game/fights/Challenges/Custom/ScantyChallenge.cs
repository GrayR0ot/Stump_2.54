using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Enums.Custom;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Spells.Casts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights.Challenges.Custom
{
    [ChallengeIdentifier((int)ChallengeEnum.ECONOME)]
    [ChallengeIdentifier((int)ChallengeEnum.GOURLO_LE_TERRIBLE_CHALLENGE_2)]
    public class ScantyChallenge : DefaultChallenge
    {
        private readonly List<FightActor> m_weaponsUsed = new List<FightActor>();

        public Action<IFight, FightActor> OnTurnStopped { get; private set; }

        public ScantyChallenge(int id, IFight fight)
            : base(id, fight)
        {
            BonusMin = 20;
            BonusMax = 20;
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
            {
                fighter.SpellCasting += OnSpellCasting;
                //fighter.WeaponUsed += OnWeaponUsed;
                Fight.TurnStopped += OnTurnStopped;
            }
        }

        //void OnWeaponUsed(FightActor fighter, WeaponTemplate weapon, Cell cell, FightSpellCastCriticalEnum critical, bool silentCast)
        //{

        //    if (critical == FightSpellCastCriticalEnum.CRITICAL_FAIL)
        //        return;

        //    if (m_weaponsUsed.Contains(fighter))
        //        //UpdateStatus(ChallengeStatusEnum.FAILED);
        //        m_weaponsUsed.Add(fighter);
        //    else
        //        //m_weaponsUsed.Add(fighter);
        //    UpdateStatus(ChallengeStatusEnum.FAILED);
        //}

        void OnSpellCasting(FightActor caster, SpellCastHandler spellCastHandler)
        {
            if (spellCastHandler.Informations.Critical == FightSpellCastCriticalEnum.CRITICAL_FAIL)
                return;

            var entries = caster.SpellHistory.GetEntries(x => x.Spell.SpellId == spellCastHandler.Spell.Id);
            if (!entries.Any())
                return;
            //else
            //UpdateStatus(ChallengeStatusEnum.FAILED);
        }

        protected override void OnWinnersDetermined(IFight fight, FightTeam winners, FightTeam losers, bool draw)
        {
            base.OnWinnersDetermined(fight, winners, losers, draw);


            foreach (var fighter in Fight.GetAllFighters<CharacterFighter>())
            {
                fighter.SpellCasting -= OnSpellCasting;
                //fighter.WeaponUsed -= OnWeaponUsed;
            }
        }
    }
}
