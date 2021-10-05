using System;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions.Data
{
    public class DefaultCriterionData : CriterionData
    {
        // FIELDS
        private readonly int[] m_params;

        // CONSTRUCTORS
        public DefaultCriterionData(ComparaisonOperatorEnum @operator, params string[] parameters)
            : base(@operator, parameters)
        {
            m_params = new int[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
                if (int.TryParse(base[i], out m_params[i]))
                {
                }
                else if (base[i] == "d")
                {
                }
                else
                {
                    throw new Exception();
                }
        }

        // PROPERTIES
        public int this[int offset] => m_params[offset];

        // METHODS
    }
}