using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Idol", "com.ankamagames.dofus.datacenter.idols")]
    [Serializable]
    public class Idol : IDataObject, IIndexedData
    {
        public const string MODULE = "Idols";
        public int categoryId;
        public string description;
        public int dropBonus;
        public int experienceBonus;
        public bool groupOnly;
        public int id;
        public List<int> incompatibleMonsters;
        public int itemId;
        public int score;
        public int spellPairId;
        public List<double> synergyIdolsCoeff;
        public List<int> synergyIdolsIds;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Description
        {
            get => description;
            set => description = value;
        }

        [D2OIgnore]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public int ItemId
        {
            get => itemId;
            set => itemId = value;
        }

        [D2OIgnore]
        public bool GroupOnly
        {
            get => groupOnly;
            set => groupOnly = value;
        }

        [D2OIgnore]
        public int SpellPairId
        {
            get => spellPairId;
            set => spellPairId = value;
        }

        [D2OIgnore]
        public int Score
        {
            get => score;
            set => score = value;
        }

        [D2OIgnore]
        public int ExperienceBonus
        {
            get => experienceBonus;
            set => experienceBonus = value;
        }

        [D2OIgnore]
        public int DropBonus
        {
            get => dropBonus;
            set => dropBonus = value;
        }

        [D2OIgnore]
        public List<int> SynergyIdolsIds
        {
            get => synergyIdolsIds;
            set => synergyIdolsIds = value;
        }

        [D2OIgnore]
        public List<double> SynergyIdolsCoeff
        {
            get => synergyIdolsCoeff;
            set => synergyIdolsCoeff = value;
        }

        [D2OIgnore]
        public List<int> IncompatibleMonsters
        {
            get => incompatibleMonsters;
            set => incompatibleMonsters = value;
        }

        int IIndexedData.Id => id;
    }
}