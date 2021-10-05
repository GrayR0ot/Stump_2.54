using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MountBehavior", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class MountBehavior : IDataObject, IIndexedData
    {
        public const string MODULE = "MountBehaviors";

        [I18NField] public uint descriptionId;

        public uint id;

        [I18NField] public uint nameId;

        [D2OIgnore]
        public uint Id
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

        int IIndexedData.Id => (int) id;
    }
}