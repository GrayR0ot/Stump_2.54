using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SoundUiElement", "com.ankamagames.dofus.datacenter.sounds")]
    [Serializable]
    public class SoundUiElement : IDataObject, IIndexedData
    {
        public string file;
        public uint hookId;
        public uint id;
        public string MODULE = "SoundUiElement";
        public string name;
        public uint volume;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [D2OIgnore]
        public uint HookId
        {
            get => hookId;
            set => hookId = value;
        }

        [D2OIgnore]
        public string File
        {
            get => file;
            set => file = value;
        }

        [D2OIgnore]
        public uint Volume
        {
            get => volume;
            set => volume = value;
        }

        int IIndexedData.Id => (int) id;
    }
}