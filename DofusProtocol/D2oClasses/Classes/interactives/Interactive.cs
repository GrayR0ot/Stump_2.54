using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Interactive", "com.ankamagames.dofus.datacenter.interactives")]
    [Serializable]
    public class Interactive : IDataObject, IIndexedData
    {
        public const string MODULE = "Interactives";
        public int actionId;
        public bool displayTooltip;
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
        public int ActionId
        {
            get => actionId;
            set => actionId = value;
        }

        [D2OIgnore]
        public bool DisplayTooltip
        {
            get => displayTooltip;
            set => displayTooltip = value;
        }

        int IIndexedData.Id => id;
    }
}