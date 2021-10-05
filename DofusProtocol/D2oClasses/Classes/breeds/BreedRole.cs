using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreedRole", "com.ankamagames.dofus.datacenter.breeds")]
    [Serializable]
    public class BreedRole : IDataObject, IIndexedData
    {
        public const string MODULE = "BreedRoles";
        public int assetId;
        public int color;

        [I18NField] public uint descriptionId;

        public int id;

        [I18NField] public uint nameId;

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
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int AssetId
        {
            get => assetId;
            set => assetId = value;
        }

        [D2OIgnore]
        public int Color
        {
            get => color;
            set => color = value;
        }

        int IIndexedData.Id => id;
    }
}