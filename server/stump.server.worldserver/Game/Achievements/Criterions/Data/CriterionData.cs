using System;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions.Data
{
    public class CriterionData
    {
        // FIELDS
        protected ComparaisonOperatorEnum m_operator;
        protected string[] m_parameters;

        // CONSTRUCTORS
        public CriterionData(ComparaisonOperatorEnum @operator)
        {
            m_operator = @operator;
        }

        public CriterionData(ComparaisonOperatorEnum @operator, params string[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException("parameters");
            if (parameters.Length == 0) throw new ArgumentException("parameters");

            m_operator = @operator;
            m_parameters = parameters;
        }

        // PROPERTIES
        public ComparaisonOperatorEnum Operator => m_operator;

        public string this[int index] => m_parameters[index];

        // METHODS
    }
}