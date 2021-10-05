using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("HavenbagFurniture", "com.ankamagames.dofus.datacenter.houses")]
    [Serializable]
    public class HavenbagFurniture : IDataObject, IIndexedData
    {
        public const string MODULE = "HavenbagFurnitures";
        public bool blocksMovement;
        public uint cellsHeight;
        public uint cellsWidth;
        public int color;
        public int elementId;
        public bool isStackable;
        public int layerId;
        public uint order;
        public int skillId;
        public int themeId;
        public int typeId;

        [D2OIgnore]
        public int TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public int ThemeId
        {
            get => themeId;
            set => themeId = value;
        }

        [D2OIgnore]
        public int ElementId
        {
            get => elementId;
            set => elementId = value;
        }

        [D2OIgnore]
        public int Color
        {
            get => color;
            set => color = value;
        }

        [D2OIgnore]
        public int SkillId
        {
            get => skillId;
            set => skillId = value;
        }

        [D2OIgnore]
        public int LayerId
        {
            get => layerId;
            set => layerId = value;
        }

        [D2OIgnore]
        public bool BlocksMovement
        {
            get => blocksMovement;
            set => blocksMovement = value;
        }

        [D2OIgnore]
        public bool IsStackable
        {
            get => isStackable;
            set => isStackable = value;
        }

        [D2OIgnore]
        public uint CellsWidth
        {
            get => cellsWidth;
            set => cellsWidth = value;
        }

        [D2OIgnore]
        public uint CellsHeight
        {
            get => cellsHeight;
            set => cellsHeight = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        int IIndexedData.Id => themeId;
    }
}