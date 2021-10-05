using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EmblemSymbol", "com.ankamagames.dofus.datacenter.guild")]
    [Serializable]
    public class EmblemSymbol : IDataObject, IIndexedData
    {
        public const string MODULE = "EmblemSymbols";
        public int categoryId;
        public bool colorizable;
        public int iconId;
        public int id;
        public int order;
        public int skinId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public int SkinId
        {
            get => skinId;
            set => skinId = value;
        }

        [D2OIgnore]
        public int Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public bool Colorizable
        {
            get => colorizable;
            set => colorizable = value;
        }

        int IIndexedData.Id => id;
    }
}