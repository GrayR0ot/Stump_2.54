using System.Collections.Generic;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;

namespace Stump.Server.WorldServer.Game.Idols.Effects
{
    public class Hoskar
    {
        private readonly List<HoskarBonus> m_bonus;
        private readonly IFight m_fight;
        private readonly CharacterFighter m_fighter;

        public Hoskar(CharacterFighter fighter, IFight fight)
        {
            m_bonus = new List<HoskarBonus>();
            m_fight = fight;
            m_fighter = fighter;
            fighter.TurnPassed += Fighter_TurnPassed;
        }

        private void Fighter_TurnPassed(FightActor obj)
        {
            UpdateEffect();
        }

        public void AddEffect(int healthLost, int regainRoundNumber)
        {
            m_fighter.Stats[PlayerFields.Health].Context -= healthLost;
            m_bonus.Add(new HoskarBonus(healthLost, regainRoundNumber));
        }


        public void UpdateEffect()
        {
            for (var i = 0; i < m_bonus.Count; i++)
                if (m_fight.TimeLine.RoundNumber == m_bonus[i].RoundHealthRegain)
                {
                    m_fighter.Stats[PlayerFields.Health].Context += m_bonus[i].HealthLost;
                    m_bonus.RemoveAt(i);
                }
        }

        private class HoskarBonus
        {
            public HoskarBonus(int healthLost, int roundHealthRegain)
            {
                HealthLost = healthLost;
                RoundHealthRegain = roundHealthRegain;
            }

            public int HealthLost { get; }

            public int RoundHealthRegain { get; }
        }
    }
}