using System;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Game.Achievements.Criterions.Data;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Conditions;

namespace Stump.Server.WorldServer.Game.Achievements.Criterions
{
    public class
        ChallengeInDungeonCountCriterion : AbstractCriterion<ChallengeInDungeonCountCriterion, DefaultCriterionData>
    {
        // FIELDS
        public const string Identifier = "Ea";
        private ushort? m_maxValue;

        // CONSTRUCTORS
        public ChallengeInDungeonCountCriterion(AchievementObjectiveRecord objective)
            : base(objective)
        {
        }

        // PROPERTIES
        public int Number => base[0][0];

        public override bool IsIncrementable => true;

        public override ushort MaxValue
        {
            get
            {
                if (m_maxValue == null)
                {
                    m_maxValue = (ushort) Number;

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
            return Number < character.ChallengesInDungeonCount;
        }

        public override bool Lower(AbstractCriterion left)
        {
            return Number < ((ChallengeInDungeonCountCriterion) left).Number;
        }

        public override bool Greater(AbstractCriterion left)
        {
            return Number > ((ChallengeInDungeonCountCriterion) left).Number;
        }

        public override ushort GetPlayerValue(PlayerAchievement player)
        {
            return (ushort) Math.Min(MaxValue, player.Owner.ChallengesInDungeonCount);
        }
    }
}