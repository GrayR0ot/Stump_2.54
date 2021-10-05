using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SoundUi", "com.ankamagames.dofus.datacenter.sounds")]
    [Serializable]
    public class SoundUi : IDataObject, IIndexedData
    {
        public string closeFile;
        public uint id;
        public string MODULE = "SoundUi";
        public string openFile;
        public List<SoundUiElement> subElements;
        public string uiName;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string UiName
        {
            get => uiName;
            set => uiName = value;
        }

        [D2OIgnore]
        public string OpenFile
        {
            get => openFile;
            set => openFile = value;
        }

        [D2OIgnore]
        public string CloseFile
        {
            get => closeFile;
            set => closeFile = value;
        }

        [D2OIgnore]
        public List<SoundUiElement> SubElements
        {
            get => subElements;
            set => subElements = value;
        }

        int IIndexedData.Id => (int) id;
    }
}