using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.I18n;
using Stump.Server.WorldServer.Game.Actors.Look;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Monster = Stump.DofusProtocol.D2oClasses.Monster;

namespace Stump.Server.WorldServer.Database.Monsters
{
    public class MonsterTemplateRelator
    {
        public static string FetchQuery = "SELECT * FROM monsters_templates";
    }

    [TableName("monsters_templates")]
    [D2OClass("Monster", "com.ankamagames.dofus.datacenter.monsters")]
    public sealed class MonsterTemplate : IAssignedByD2O, IAutoGeneratedRecord
    {
        private List<DroppableItem> m_droppableItems;
        private ActorLook m_entityLook;
        private List<MonsterGrade> m_grades;
        private List<uint> m_incompatibleChallenges = new List<uint>();
        private string m_incompatibleChallengesCSV;
        private string m_lookAsString;
        private MonsterRace m_monsterRace;
        private string m_name;
        private List<uint> m_spells = new List<uint>();
        private string m_spellsCSV;

        [PrimaryKey("Id", false)] public int Id { get; set; }

        public uint NameId { get; set; }

        public string Name => m_name ?? (m_name = TextManager.Instance.GetText(NameId));

        public uint GfxId { get; set; }

        public MonsterRace Race => m_monsterRace ?? (m_monsterRace = MonsterManager.Instance.GetMonsterRace(RaceId));

        public int RaceId { get; set; }

        public int MinDroppedKamas { get; set; }

        public int MaxDroppedKamas { get; set; }

        [Ignore]
        public List<DroppableItem> DroppableItems => m_droppableItems ??
                                                     (m_droppableItems =
                                                         MonsterManager.Instance.GetMonsterDroppableItems(Id));

        [Ignore]
        public List<MonsterGrade> Grades => m_grades ?? (m_grades = MonsterManager.Instance.GetMonsterGrades(Id));

        public string LookAsString
        {
            get
            {
                if (EntityLook == null)
                    return string.Empty;

                if (string.IsNullOrEmpty(m_lookAsString))
                    m_lookAsString = EntityLook.ToString();

                return m_lookAsString;
            }
            set
            {
                m_lookAsString = value;

                if (!string.IsNullOrEmpty(value) && value != "null")
                    m_entityLook = ActorLook.Parse(m_lookAsString);
                else
                    m_entityLook = null;
            }
        }

        [Ignore]
        public ActorLook EntityLook
        {
            get => m_entityLook;
            set
            {
                m_entityLook = value;

                if (value != null)
                    m_lookAsString = value.ToString();
            }
        }

        public bool UseSummonSlot { get; set; }

        public bool UseBombSlot { get; set; }

        public bool CanPlay { get; set; }

        public bool CanTackle { get; set; }

        public bool CanSwitchPos { get; set; }

        public bool CanBePushed { get; set; }

        public bool IsBoss { get; set; }

        public bool IsMiniBoss { get; set; }

        public bool IsActive { get; set; }

        public bool AllIdolsDisabled { get; set; }

        [NullString]
        public string SpellsCSV
        {
            get => m_spellsCSV;
            set
            {
                m_spellsCSV = value;
                m_spells = !string.IsNullOrEmpty(m_spellsCSV)
                    ? m_spellsCSV.FromCSV<uint>(",").ToList()
                    : new List<uint>();
            }
        }

        [Ignore]
        public List<uint> Spells
        {
            get => m_spells;
            set
            {
                m_spells = value;
                m_spellsCSV = m_spells.ToCSV(",");
            }
        }

        [Ignore]
        public List<uint> IncompatibleChallenges
        {
            get => m_incompatibleChallenges;
            set
            {
                m_incompatibleChallenges = value;
                m_incompatibleChallengesCSV = m_incompatibleChallenges.ToCSV(",");
            }
        }

        [NullString]
        public string IncompatibleChallengesCSV
        {
            get => m_incompatibleChallengesCSV;
            set
            {
                m_incompatibleChallengesCSV = value;
                m_incompatibleChallenges = !string.IsNullOrEmpty(m_incompatibleChallengesCSV)
                    ? m_incompatibleChallengesCSV.FromCSV<uint>(",").ToList()
                    : new List<uint>();
            }
        }

        #region IAssignedByD2O Members

        public void AssignFields(object d2oObject)
        {
            var monster = (Monster) d2oObject;
            Id = monster.id;
            NameId = monster.nameId;
            GfxId = monster.gfxId;
            RaceId = monster.race;
            LookAsString = monster.look;
            UseSummonSlot = monster.useSummonSlot;
            UseBombSlot = monster.useBombSlot;
            CanPlay = monster.canPlay;
            CanTackle = monster.canTackle;
            CanSwitchPos = monster.canSwitchPos;
            CanBePushed = monster.canBePushed;
            IsBoss = monster.isBoss;
            IsMiniBoss = monster.isMiniBoss;
            AllIdolsDisabled = monster.allIdolsDisabled;
            IncompatibleChallenges = monster.incompatibleChallenges;
            Spells = monster.spells;
            IsActive = true;
        }

        #endregion

        public void BeforeSave(bool insert)
        {
            m_incompatibleChallengesCSV = m_incompatibleChallenges.ToCSV(",");
            m_spellsCSV = m_spells.ToCSV(",");
        }
    }
}