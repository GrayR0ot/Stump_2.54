using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.Interfaces;
using Stump.Server.WorldServer.Game.Actors.Stats;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Maps.Cells;
using System.Collections.Generic;
using System.Globalization;

namespace Stump.Server.WorldServer.Game.Actors.Fight
{
    public class SummonedMonster : SummonedFighter, ICreature
    {
        readonly StatsFields m_stats;

        public SummonedMonster(int id, FightTeam team, FightActor summoner, MonsterGrade template, Cell cell)
            : base(id, team, template.Spells.ToArray(), summoner, cell, template.MonsterId, template)
        {
            Monster = template;
            Look = Monster.Template.EntityLook.Clone();
            m_stats = new StatsFields(this);
            m_stats.Initialize(template);

            if (Monster.Template.Race.SuperRaceId == 28) //Invocations
            {
                AdjustStats();
            }
        }

        void AdjustStats()
        {
            double boost;
            double boostint;
            double boostchan;
            double boostfor;
            double boostagi;
            double boostwis;

            if (Summoner.Level <= 200)
            {
                boost = (short) (((1 * Summoner.Level) / 2.55) / 3 + 1) * (Summoner.Level / 127.5d) +
                        (((Summoner.Stats.Intelligence.Total + Summoner.Stats.Agility.Total +
                           Summoner.Stats.Chance.Total + Summoner.Stats.Strength.Total) / 4) / 10);
                boostint = (short) (((1 * Summoner.Level) / 2.55) / 3 + 1) * (Summoner.Level / 127.5d) +
                           (Summoner.Stats.Intelligence.Total / 10);
                boostchan = (short) (((1 * Summoner.Level) / 2.55) / 3 + 1) * (Summoner.Level / 127.5d) +
                            (Summoner.Stats.Chance.Total / 10);
                boostfor = (short) (((1 * Summoner.Level) / 2.55) / 3 + 1) * (Summoner.Level / 127.5d) +
                           (Summoner.Stats.Strength.Total / 10);
                boostagi = (short) (((1 * Summoner.Level) / 2.55) / 3 + 1) * (Summoner.Level / 127.5d) +
                           (Summoner.Stats.Agility.Total / 10);
                boostwis = (short) (((1 * Summoner.Level) / 2.55) / 3 + 1) * (Summoner.Level / 127.5d) +
                           (Summoner.Stats.Wisdom.Total / 10);
            }
            else
            {
                boost = (short) (((1 * 200) / 2.55) / 3 + 1) * (200 / 127.5d) + (((Summoner.Stats.Intelligence.Total +
                        Summoner.Stats.Agility.Total + Summoner.Stats.Chance.Total + Summoner.Stats.Strength.Total) /
                    4) /
                    10);
                boostint = (short) (((1 * 200) / 2.55) / 3 + 1) * (200 / 127.5d) +
                           (Summoner.Stats.Intelligence.Total / 10);
                boostchan = (short) (((1 * 200) / 2.55) / 3 + 1) * (200 / 127.5d) + (Summoner.Stats.Chance.Total / 10);
                boostfor = (short) (((1 * 200) / 2.55) / 3 + 1) * (200 / 127.5d) + (Summoner.Stats.Strength.Total / 10);
                boostagi = (short) (((1 * 200) / 2.55) / 3 + 1) * (200 / 127.5d) + (Summoner.Stats.Agility.Total / 10);
                boostwis = (short) (((1 * 200) / 2.55) / 3 + 1) * (200 / 127.5d) + (Summoner.Stats.Wisdom.Total / 10);
            }

            if (Summoner.Level > 200)
            {
                m_stats.Health.Base = (short) (Monster.LifePoints * (1 + (200 / 100d)));
            }
            else
            {
                m_stats.Health.Base = (short) (Monster.LifePoints * (1 + ((Summoner.Level) / 100d)));
            }


            switch (this.Monster.Template.Id)
            {
                case 4565: // Dragon Rouge
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.FireDamageBonus].Base =
                        Summoner.Stats[PlayerFields.FireDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 4566: // Dragon Noir
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.FireDamageBonus].Base =
                        Summoner.Stats[PlayerFields.FireDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 5133: // Dragon Albinos
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.FireDamageBonus].Base =
                        Summoner.Stats[PlayerFields.FireDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 4564: // Bouftou Noir
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 2;
                    m_stats[PlayerFields.EarthDamageBonus].Base =
                        Summoner.Stats[PlayerFields.EarthDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 4563: // Boufton
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 2;
                    m_stats[PlayerFields.NeutralDamageBonus].Base =
                        Summoner.Stats[PlayerFields.NeutralDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 5132: // Bouftou
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 5 / 2;
                    m_stats[PlayerFields.NeutralDamageBonus].Base =
                        Summoner.Stats[PlayerFields.NeutralDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 4562: // tofu dodu
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.AirDamageBonus].Base = Summoner.Stats[PlayerFields.AirDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 4561: // tofu noir
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 2 / 3;
                    m_stats[PlayerFields.AirDamageBonus].Base = Summoner.Stats[PlayerFields.AirDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (4 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 5131: // tofu albinos
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 2 / 3;
                    m_stats[PlayerFields.AirDamageBonus].Base = Summoner.Stats[PlayerFields.AirDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 5134: // Crapaud noir
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.WaterDamageBonus].Base =
                        Summoner.Stats[PlayerFields.WaterDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 5135: // Crapaud Albino
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.WaterDamageBonus].Base =
                        Summoner.Stats[PlayerFields.WaterDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 5136: // Crapaud Baveux
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 3 / 2;
                    m_stats[PlayerFields.WaterDamageBonus].Base =
                        Summoner.Stats[PlayerFields.WaterDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 45: // Chaton Enrage
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 2 / 3;
                    m_stats[PlayerFields.WaterDamageBonus].Base =
                        Summoner.Stats[PlayerFields.WaterDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 117: // GONFLABLE
                    m_stats.Health.Base = Summoner.Stats.Health.Base / 2;
                    m_stats[PlayerFields.Intelligence].Base = Summoner.Stats[PlayerFields.Intelligence].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 116: // LA SACRIFIEE
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 1;
                    m_stats[PlayerFields.AirDamageBonus].Base = Summoner.Stats[PlayerFields.AirDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
                case 282: //Arvore                  
                    m_stats.Agility.Base = 0;
                    break;
                case 4010:
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total * 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total * 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total * 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total * 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total * 2))) +
                                          (short) boostwis;
                    m_stats[PlayerFields.PushDamageBonus].Base =
                        Summoner.Stats[PlayerFields.PushDamageBonus].Equiped * 1;
                    break;
                case 4776:
                    m_stats.Health.Base = Summoner.Stats.Health.Base * 1;
                    m_stats[PlayerFields.NeutralDamageBonus].Base =
                        Summoner.Stats[PlayerFields.NeutralDamageBonus].Equiped / 2;
                    m_stats.Intelligence.Base =
                        (short) (Monster.Intelligence + (1 + (Summoner.Stats.Intelligence.Total / 2))) +
                        (short) boostint;
                    m_stats.Chance.Base = (short) (Monster.Chance + (1 + (Summoner.Stats.Chance.Total / 2))) +
                                          (short) boostchan;
                    m_stats.Agility.Base = (short) (Monster.Agility + (1 + (Summoner.Stats.Agility.Total / 2))) +
                                           (short) boostagi;
                    m_stats.Strength.Base = (short) (Monster.Strength + (1 + (Summoner.Stats.Strength.Total / 2))) +
                                            (short) boostfor;
                    m_stats.Wisdom.Base = (short) (Monster.Wisdom + (1 + (Summoner.Stats.Wisdom.Total / 2))) +
                                          (short) boostwis;
                    break;
            }

            ;
            List<StatsData> stat = new List<StatsData>
            {
                m_stats.Health,
                m_stats.Intelligence,
                m_stats.Chance,
                m_stats.Strength,
                m_stats.Agility,
                m_stats.Wisdom
            };
            stat.AddRange(stat);
        }

        public override int CalculateArmorValue(int reduction)
        {
            if (Summoner.Level <= 200)
            {
                return (int) (reduction * (100 + 5 * (Summoner.Level)) / 100d);
            }
            else
            {
                return (int) (reduction * (100 + 5 * 200) / 100d);
            }
        }

        public override bool CanPlay() => base.CanPlay() && Monster.Template.CanPlay;

        public override bool CanMove() => base.CanMove() && MonsterGrade.MovementPoints > 0;

        public override bool CanTackle(FightActor fighter) => base.CanTackle(fighter) && Monster.Template.CanTackle;

        public MonsterGrade Monster { get; }

        public override ObjectPosition MapPosition
        {
            get { return Position; }
        }

        public override ushort Level
        {
            get { return (ushort) Monster.Level; }
        }

        public MonsterGrade MonsterGrade
        {
            get { return Monster; }
        }

        public override StatsFields Stats
        {
            get { return m_stats; }
        }

        public override string GetMapRunningFighterName()
        {
            return Monster.Id.ToString(CultureInfo.InvariantCulture);
        }

        public override string Name
        {
            get { return Monster.Template.Name; }
        }

        public override bool CanBePushed()
        {
            return base.CanBePushed() && Monster.Template.CanBePushed;
        }

        public override bool CanSwitchPos()
        {
            return base.CanSwitchPos() && Monster.Template.CanSwitchPos;
        }

        public override FightTeamMemberInformations GetFightTeamMemberInformations()
        {
            return new FightTeamMemberMonsterInformations(Id, Monster.Template.Id, (sbyte) Monster.GradeId);
        }

        public override GameFightFighterInformations GetGameFightFighterInformations(WorldClient client = null)
        {
            return new GameFightMonsterInformations(
                Id,
                GetEntityDispositionInformations(client),
                Look.GetEntityLook(),
                new GameContextBasicSpawnInformation((sbyte) Team.Id, IsAlive(),
                    new GameContextActorPositionInformations((double) Id, GetEntityDispositionInformations(client))),
                0,
                GetGameFightMinimalStats(client),
                new uint[0],
                (ushort) Monster.Template.Id,
                (sbyte) Monster.GradeId, (short) Monster.Level);
        }

        public override GameFightFighterLightInformations GetGameFightFighterLightInformations(
            WorldClient client = null)
        {
            return new GameFightFighterMonsterLightInformations(
                true,
                IsAlive(),
                Id,
                0,
                Level,
                (sbyte) BreedEnum.MONSTER,
                (ushort) Monster.Template.Id);
        }

        public override GameFightMinimalStats GetGameFightMinimalStats(WorldClient client = null)
        {
            return new GameFightMinimalStats(
                (uint) Stats.Health.Total,
                (uint) Stats.Health.TotalMax,
                (uint) Stats.Health.TotalMaxWithoutPermanentDamages,
                (uint) Stats[PlayerFields.PermanentDamagePercent].Total,
                (uint) Stats.Shield.TotalSafe,
                (short) Stats.AP.Total,
                (short) Stats.AP.TotalMax,
                (short) Stats.MP.Total,
                (short) Stats.MP.TotalMax,
                Summoner.Id,
                true,
                (short) Stats[PlayerFields.NeutralResistPercent].Total,
                (short) Stats[PlayerFields.EarthResistPercent].Total,
                (short) Stats[PlayerFields.WaterResistPercent].Total,
                (short) Stats[PlayerFields.AirResistPercent].Total,
                (short) Stats[PlayerFields.FireResistPercent].Total,
                (short) Stats[PlayerFields.NeutralElementReduction].Total,
                (short) Stats[PlayerFields.EarthElementReduction].Total,
                (short) Stats[PlayerFields.WaterElementReduction].Total,
                (short) Stats[PlayerFields.AirElementReduction].Total,
                (short) Stats[PlayerFields.FireElementReduction].Total,
                (short) Stats[PlayerFields.CriticalDamageReduction].Total,
                (short) Stats[PlayerFields.PushDamageReduction].Total,
                (short) Stats[PlayerFields.PvpNeutralResistPercent].Total,
                (short) Stats[PlayerFields.PvpEarthResistPercent].Total,
                (short) Stats[PlayerFields.PvpWaterResistPercent].Total,
                (short) Stats[PlayerFields.PvpAirResistPercent].Total,
                (short) Stats[PlayerFields.PvpFireResistPercent].Total,
                (short) Stats[PlayerFields.PvpNeutralElementReduction].Total,
                (short) Stats[PlayerFields.PvpEarthElementReduction].Total,
                (short) Stats[PlayerFields.PvpWaterElementReduction].Total,
                (short) Stats[PlayerFields.PvpAirElementReduction].Total,
                (short) Stats[PlayerFields.PvpFireElementReduction].Total,
                (ushort) Stats[PlayerFields.DodgeAPProbability].Total,
                (ushort) Stats[PlayerFields.DodgeMPProbability].Total,
                (short) Stats[PlayerFields.TackleBlock].Total,
                (short) Stats[PlayerFields.TackleEvade].Total,
                0,
                (sbyte) (client == null ? VisibleState : GetVisibleStateFor(client.Character)), // invisibility state
                (ushort) (100 + Stats[PlayerFields.MeeleDamageReceivedPercent].Total),
                (ushort) (100 + Stats[PlayerFields.RangedDamageReceivedPercent].Total),
                (ushort) (100 + Stats[PlayerFields.WeaponDamageReceivedPercent].Total),
                (ushort) (100 + Stats[PlayerFields.SpellDamageReceivedPercent].Total)
            );
        }
    }
}