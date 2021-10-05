using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Breed", "com.ankamagames.dofus.datacenter.breeds")]
    [Serializable]
    public class Breed : IDataObject, IIndexedData
    {
        public const string MODULE = "Breeds";
        public List<BreedRoleByBreed> breedRoles;
        public List<uint> breedSpellsId;
        public uint complexity;
        public uint creatureBonesId;

        [I18NField] public uint descriptionId;

        public int femaleArtwork;
        public List<uint> femaleColors;
        public string femaleLook;

        [I18NField] public uint gameplayDescriptionId;

        public int id;

        [I18NField] public uint longNameId;

        public int maleArtwork;
        public List<uint> maleColors;
        public string maleLook;

        [I18NField] public uint shortNameId;

        public uint sortIndex;
        public uint spawnMap;
        public List<List<uint>> statsPointsForAgility;
        public List<List<uint>> statsPointsForChance;
        public List<List<uint>> statsPointsForIntelligence;
        public List<List<uint>> statsPointsForStrength;
        public List<List<uint>> statsPointsForVitality;
        public List<List<uint>> statsPointsForWisdom;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint ShortNameId
        {
            get => shortNameId;
            set => shortNameId = value;
        }

        [D2OIgnore]
        public uint LongNameId
        {
            get => longNameId;
            set => longNameId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public uint GameplayDescriptionId
        {
            get => gameplayDescriptionId;
            set => gameplayDescriptionId = value;
        }

        [D2OIgnore]
        public string MaleLook
        {
            get => maleLook;
            set => maleLook = value;
        }

        [D2OIgnore]
        public string FemaleLook
        {
            get => femaleLook;
            set => femaleLook = value;
        }

        [D2OIgnore]
        public uint CreatureBonesId
        {
            get => creatureBonesId;
            set => creatureBonesId = value;
        }

        [D2OIgnore]
        public int MaleArtwork
        {
            get => maleArtwork;
            set => maleArtwork = value;
        }

        [D2OIgnore]
        public int FemaleArtwork
        {
            get => femaleArtwork;
            set => femaleArtwork = value;
        }

        [D2OIgnore]
        public List<List<uint>> StatsPointsForStrength
        {
            get => statsPointsForStrength;
            set => statsPointsForStrength = value;
        }

        [D2OIgnore]
        public List<List<uint>> StatsPointsForIntelligence
        {
            get => statsPointsForIntelligence;
            set => statsPointsForIntelligence = value;
        }

        [D2OIgnore]
        public List<List<uint>> StatsPointsForChance
        {
            get => statsPointsForChance;
            set => statsPointsForChance = value;
        }

        [D2OIgnore]
        public List<List<uint>> StatsPointsForAgility
        {
            get => statsPointsForAgility;
            set => statsPointsForAgility = value;
        }

        [D2OIgnore]
        public List<List<uint>> StatsPointsForVitality
        {
            get => statsPointsForVitality;
            set => statsPointsForVitality = value;
        }

        [D2OIgnore]
        public List<List<uint>> StatsPointsForWisdom
        {
            get => statsPointsForWisdom;
            set => statsPointsForWisdom = value;
        }

        [D2OIgnore]
        public List<uint> BreedSpellsId
        {
            get => breedSpellsId;
            set => breedSpellsId = value;
        }

        [D2OIgnore]
        public List<BreedRoleByBreed> BreedRoles
        {
            get => breedRoles;
            set => breedRoles = value;
        }

        [D2OIgnore]
        public List<uint> MaleColors
        {
            get => maleColors;
            set => maleColors = value;
        }

        [D2OIgnore]
        public List<uint> FemaleColors
        {
            get => femaleColors;
            set => femaleColors = value;
        }

        [D2OIgnore]
        public uint SpawnMap
        {
            get => spawnMap;
            set => spawnMap = value;
        }

        [D2OIgnore]
        public uint Complexity
        {
            get => complexity;
            set => complexity = value;
        }

        [D2OIgnore]
        public uint SortIndex
        {
            get => sortIndex;
            set => sortIndex = value;
        }

        int IIndexedData.Id => id;
    }
}