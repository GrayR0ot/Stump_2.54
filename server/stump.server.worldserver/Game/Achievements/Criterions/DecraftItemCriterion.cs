using System;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Achievements.Criterions.Data;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions
{
    public class DecraftCountCriterion : AbstractCriterion<DecraftCountCriterion, DefaultCriterionData>
    {
        // FIELDS
        public const string Identifier = "Eu";
        private ushort? m_maxValue;

        // CONSTRUCTORS
        public DecraftCountCriterion(AchievementObjectiveRecord objective)
            : base(objective)
        {
        }

        // PROPERTIES
        public int ItemsCount => base[0][1];

        public int ItemId => base[0][0];

        public override bool IsIncrementable => true;

        public override ushort MaxValue
        {
            get
            {
                if (m_maxValue == null)
                {
                    m_maxValue = (ushort) ItemsCount;

                    switch (base[0].Operator)
                    {
                        case ComparaisonOperatorEnum.EQUALS: break;

                        case ComparaisonOperatorEnum.INFERIOR:
                            throw new Exception();

                        case ComparaisonOperatorEnum.SUPERIOR:
                            m_maxValue++;
                            break;
                    }
                }

                return m_maxValue.Value;
            }
        }

        // METHODS
        public override DefaultCriterionData Parse(ComparaisonOperatorEnum @operator, params string[] parameters)
        {
            return new DefaultCriterionData(@operator, parameters);
        }

        public override bool Eval(Character character)
        {
            return ItemId == 0 ? ItemsCount < character.OwnedRuneAmount : false;
        }

        public override bool Lower(AbstractCriterion left)
        {
            return ItemsCount < ((DecraftCountCriterion) left).ItemsCount;
        }

        public override bool Greater(AbstractCriterion left)
        {
            return ItemsCount > ((DecraftCountCriterion) left).ItemsCount;
        }

        public override ushort GetPlayerValue(PlayerAchievement player)
        {
            return (ushort) Math.Min(MaxValue, player.Owner.OwnedRuneAmount);
        }
    }
}