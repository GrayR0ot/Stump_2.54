using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Ornament", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class Ornament : IDataObject, IIndexedData
    {
        public const string MODULE = "Ornaments";
        public int assetId;
        public int iconId;
        public int id;

        [I18NField] public uint nameId;

        public int order;
        public int rarity;
        public bool visible;

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
        public bool Visible
        {
            get => visible;
            set => visible = value;
        }

        [D2OIgnore]
        public int AssetId
        {
            get => assetId;
            set => assetId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public int Rarity
        {
            get => rarity;
            set => rarity = value;
        }

        [D2OIgnore]
        public int Order
        {
            get => order;
            set => order = value;
        }

        int IIndexedData.Id => id;
    }
}