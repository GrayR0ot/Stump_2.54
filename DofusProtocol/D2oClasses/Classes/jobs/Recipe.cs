using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Recipe", "com.ankamagames.dofus.datacenter.jobs")]
    [Serializable]
    public class Recipe : IDataObject, IIndexedData
    {
        public const string MODULE = "Recipes";
        public List<int> ingredientIds;
        public int jobId;
        public List<uint> quantities;
        public int resultId;
        public uint resultLevel;

        [I18NField] public uint resultNameId;

        public uint resultTypeId;
        public int skillId;

        [D2OIgnore]
        public int ResultId
        {
            get => resultId;
            set => resultId = value;
        }

        [D2OIgnore]
        public uint ResultNameId
        {
            get => resultNameId;
            set => resultNameId = value;
        }

        [D2OIgnore]
        public uint ResultTypeId
        {
            get => resultTypeId;
            set => resultTypeId = value;
        }

        [D2OIgnore]
        public uint ResultLevel
        {
            get => resultLevel;
            set => resultLevel = value;
        }

        [D2OIgnore]
        public List<int> IngredientIds
        {
            get => ingredientIds;
            set => ingredientIds = value;
        }

        [D2OIgnore]
        public List<uint> Quantities
        {
            get => quantities;
            set => quantities = value;
        }

        [D2OIgnore]
        public int JobId
        {
            get => jobId;
            set => jobId = value;
        }

        [D2OIgnore]
        public int SkillId
        {
            get => skillId;
            set => skillId = value;
        }

        int IIndexedData.Id => resultId;
    }
}