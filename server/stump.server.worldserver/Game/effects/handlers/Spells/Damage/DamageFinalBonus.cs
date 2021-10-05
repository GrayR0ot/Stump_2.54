using System.Collections.Generic;
using System.Linq;
using Stump.Server.WorldServer.Game.Fights;

namespace Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage
{
    public enum Trigger
    {
        None,
        Pourpre,
        Turquoise,
        Vulbis,
        Yoche_Magistral = 4,
        Yoche_Majeur = 3,
        Yoche = 2,
        Yoche_Mineur = 1
    }

    public class DamageFinalBonus
    {
        private readonly IFight m_fight;
        private readonly List<DofusBonus> m_damageBonus;

        public DamageFinalBonus(IFight fight)
        {
            m_damageBonus = new List<DofusBonus>();
            m_fight = fight;
        }


        public bool Add(int lostRoundNumber, Trigger trigger)
        {
            if (trigger == Trigger.Pourpre && m_damageBonus.Where(x => x.Trigger == Trigger.Pourpre).Count() >= 10)
                return false;
            if (trigger == Trigger.Turquoise && m_damageBonus.Where(x => x.Trigger == Trigger.Turquoise).Count() >= 10)
                return false;

            if (trigger == Trigger.Yoche_Magistral &&
                m_damageBonus.Where(x => x.Trigger == Trigger.Yoche_Magistral).Count() >= 2)
                return false;

            if (trigger == Trigger.Yoche_Majeur &&
                m_damageBonus.Where(x => x.Trigger == Trigger.Yoche_Majeur).Count() >= 3)
                return false;

            if (trigger == Trigger.Yoche && m_damageBonus.Where(x => x.Trigger == Trigger.Yoche).Count() >= 4)
                return false;

            if (trigger == Trigger.Yoche_Mineur &&
                m_damageBonus.Where(x => x.Trigger == Trigger.Yoche_Mineur).Count() >= 5)
                return false;

            m_damageBonus.Add(new DofusBonus(trigger, lostRoundNumber));
            return true;
        }

        public void Update()
        {
            for (var i = 0; i < m_damageBonus.Count; i++)
                if (m_damageBonus[i].RoundNumberLost != -1 &&
                    m_damageBonus[i].RoundNumberLost > m_fight.TimeLine.RoundNumber)
                    m_damageBonus.RemoveAt(i);
        }

        private class DofusBonus
        {
            public Trigger Trigger { get; }

            public int RoundNumberLost { get; }

            public DofusBonus(Trigger trigger, int roundNumberLost)
            {
                Trigger = trigger;
                RoundNumberLost = roundNumberLost;
            }
        }
    }
}