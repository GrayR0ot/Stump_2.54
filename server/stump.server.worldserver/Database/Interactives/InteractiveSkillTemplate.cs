﻿using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.I18n;
using Stump.Server.WorldServer.Database.Jobs;
using Stump.Server.WorldServer.Game.Interactives;
using Stump.Server.WorldServer.Game.Interactives.Skills;
using Stump.Server.WorldServer.Game.Jobs;

namespace Stump.Server.WorldServer.Database.Interactives
{
    public class InteractiveSkillTemplateRelator
    {
        public static string FetchQuery = "SELECT * FROM interactives_skills_templates";
    }

    [TableName("interactives_skills_templates")]
    [D2OClass("Skill")]
    public class InteractiveSkillTemplate : IAssignedByD2O, IAutoGeneratedRecord, ISkillRecord
    {
        private int[] m_craftableItemIds;
        private string m_craftableItemIdsCSV;
        private InteractiveTemplate m_interactive;
        private int[] m_modifiableItemTypes;
        private string m_modifiableItemTypesCSV;
        private string m_name;
        private RecipeRecord[] m_recipes;

        public uint NameId { get; set; }

        public string Name => m_name ?? (m_name = TextManager.Instance.GetText(NameId));

        public int ParentJobId { get; set; }

        public bool IsForgemagus { get; set; }

        [Ignore]
        public int[] ModifiableItemTypes
        {
            get => m_modifiableItemTypes ?? (m_modifiableItemTypes = ModifiableItemTypesCSV.FromCSV<int>(","));
            set
            {
                m_modifiableItemTypes = value;
                m_modifiableItemTypesCSV = value.ToCSV(",");
            }
        }

        public string ModifiableItemTypesCSV
        {
            get => m_modifiableItemTypesCSV;
            set
            {
                m_modifiableItemTypesCSV = value;
                m_modifiableItemTypes = ModifiableItemTypesCSV.FromCSV<int>(",");
            }
        }

        public int GatheredRessourceItem { get; set; }

        public string CraftableItemIdsCSV
        {
            get => m_craftableItemIdsCSV;
            set
            {
                m_craftableItemIdsCSV = value;
                m_craftableItemIds = CraftableItemIdsCSV?.FromCSV<int>(",");
            }
        }

        [Ignore]
        public int[] CraftableItemIds
        {
            get => m_craftableItemIds ?? (m_craftableItemIds = CraftableItemIdsCSV?.FromCSV<int>(",") ?? new int[0]);
            set
            {
                m_craftableItemIds = value;
                CraftableItemIdsCSV = value.ToCSV(",");
                m_recipes = null;
            }
        }

        public RecipeRecord[] Recipes
        {
            get
            {
                return m_recipes ??
                       (m_recipes = JobManager.Instance.Recipes.Values.Where(x => x.SkillId == Id).ToArray());
            }
        }

        public int InteractiveId { get; set; }

        public string UseAnimation { get; set; }

        public int Cursor { get; set; }

        public int ElementActionId { get; set; }

        public bool AvailableInHouse { get; set; }

        public uint LevelMin { get; set; }

        public bool ClientDisplay { get; set; }

        public InteractiveTemplate Interactive =>
            m_interactive ?? (m_interactive = InteractiveManager.Instance.GetTemplate(InteractiveId));

        #region IAssignedByD2O Members

        public void AssignFields(object d2oObject)
        {
            var skill = (DofusProtocol.D2oClasses.Skill) d2oObject;

            Id = skill.id;
            NameId = skill.nameId;
            ParentJobId = skill.parentJobId;
            IsForgemagus = skill.isForgemagus;
            ModifiableItemTypes = skill.modifiableItemTypeIds.ToArray();
            GatheredRessourceItem = skill.gatheredRessourceItem;
            CraftableItemIds = skill.craftableItemIds.ToArray();
            InteractiveId = skill.interactiveId;
            UseAnimation = skill.useAnimation;
            Cursor = skill.cursor;
            ElementActionId = skill.elementActionId;
            AvailableInHouse = skill.availableInHouse;
            LevelMin = skill.levelMin;
            ClientDisplay = skill.ClientDisplay;
        }

        #endregion

        [PrimaryKey("Id", false)] public int Id { get; set; }

        public Skill GenerateSkill(int id, InteractiveObject interactiveObject)
        {
            if (GatheredRessourceItem > 0)
                return new SkillHarvest(id, this, interactiveObject);
            if (CraftableItemIds?.Length > 0)
                return new SkillCraft(id, this, interactiveObject);
            if (IsForgemagus && ModifiableItemTypes?.Length > 0)
                return new SkillRuneCraft(id, this, interactiveObject);

            return DiscriminatorManager<Skill, int>.Instance.Generate(Id, id, this, interactiveObject);
        }
    }
}