using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SubArea", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class SubArea : IDataObject, IIndexedData
    {
        public const string MODULE = "SubAreas";
        public List<uint> achievements;
        public List<AmbientSound> ambientSounds;
        public int areaId;
        public int associatedZaapMapId;
        public bool basicAccountAllowed;
        public Rectangle bounds;
        public bool capturable;
        public List<uint> customWorldMap;
        public bool displayOnWorldMap;
        public List<double> entranceMapIds;
        public List<double> exitMapIds;
        public int exploreAchievementId;
        public List<int> harvestables;
        public int id;
        public bool isConquestVillage;
        public bool isDiscovered;
        public uint level;
        public List<double> mapIds;
        public List<uint> monsters;
        public bool mountAutoTripAllowed;

        [I18NField] public uint nameId;

        public List<List<double>> npcs;
        public int packId;
        public List<List<int>> playlists;
        public List<List<double>> quests;
        public List<int> shape;
        public short bonus;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public int AreaId
        {
            get => areaId;
            set => areaId = value;
        }

        [D2OIgnore]
        public List<AmbientSound> AmbientSounds
        {
            get => ambientSounds;
            set => ambientSounds = value;
        }

        [D2OIgnore]
        public List<List<int>> Playlists
        {
            get => playlists;
            set => playlists = value;
        }

        [D2OIgnore]
        public List<double> MapIds
        {
            get => mapIds;
            set => mapIds = value;
        }

        [D2OIgnore]
        public Rectangle Bounds
        {
            get => bounds;
            set => bounds = value;
        }

        [D2OIgnore]
        public List<int> Shape
        {
            get => shape;
            set => shape = value;
        }

        [D2OIgnore]
        public List<uint> CustomWorldMap
        {
            get => customWorldMap;
            set => customWorldMap = value;
        }

        [D2OIgnore]
        public int PackId
        {
            get => packId;
            set => packId = value;
        }

        [D2OIgnore]
        public uint Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public bool IsConquestVillage
        {
            get => isConquestVillage;
            set => isConquestVillage = value;
        }

        [D2OIgnore]
        public bool BasicAccountAllowed
        {
            get => basicAccountAllowed;
            set => basicAccountAllowed = value;
        }

        [D2OIgnore]
        public bool DisplayOnWorldMap
        {
            get => displayOnWorldMap;
            set => displayOnWorldMap = value;
        }

        [D2OIgnore]
        public bool MountAutoTripAllowed
        {
            get => mountAutoTripAllowed;
            set => mountAutoTripAllowed = value;
        }

        [D2OIgnore]
        public List<uint> Monsters
        {
            get => monsters;
            set => monsters = value;
        }

        [D2OIgnore]
        public List<double> EntranceMapIds
        {
            get => entranceMapIds;
            set => entranceMapIds = value;
        }

        [D2OIgnore]
        public List<double> ExitMapIds
        {
            get => exitMapIds;
            set => exitMapIds = value;
        }

        [D2OIgnore]
        public bool Capturable
        {
            get => capturable;
            set => capturable = value;
        }

        [D2OIgnore]
        public List<uint> Achievements
        {
            get => achievements;
            set => achievements = value;
        }

        [D2OIgnore]
        public List<List<double>> Quests
        {
            get => quests;
            set => quests = value;
        }

        [D2OIgnore]
        public List<List<double>> Npcs
        {
            get => npcs;
            set => npcs = value;
        }

        [D2OIgnore]
        public int ExploreAchievementId
        {
            get => exploreAchievementId;
            set => exploreAchievementId = value;
        }

        [D2OIgnore]
        public bool IsDiscovered
        {
            get => isDiscovered;
            set => isDiscovered = value;
        }

        [D2OIgnore]
        public List<int> Harvestables
        {
            get => harvestables;
            set => harvestables = value;
        }

        [D2OIgnore]
        public int AssociatedZaapMapId
        {
            get => associatedZaapMapId;
            set => associatedZaapMapId = value;
        }

        [D2OIgnore]
        public short Bonus
        {
            get => bonus;
            set => bonus = value;
        }
        

        int IIndexedData.Id => id;
    }
}