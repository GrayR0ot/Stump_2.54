using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpeakingItemText", "com.ankamagames.dofus.datacenter.livingObjects")]
    [Serializable]
    public class SpeakingItemText : IDataObject, IIndexedData
    {
        public const string MODULE = "SpeakingItemsText";
        public int textId;
        public int textLevel;
        public double textProba;
        public string textRestriction;
        public int textSound;

        [I18NField] public uint textStringId;

        [D2OIgnore]
        public int TextId
        {
            get => textId;
            set => textId = value;
        }

        [D2OIgnore]
        public double TextProba
        {
            get => textProba;
            set => textProba = value;
        }

        [D2OIgnore]
        public uint TextStringId
        {
            get => textStringId;
            set => textStringId = value;
        }

        [D2OIgnore]
        public int TextLevel
        {
            get => textLevel;
            set => textLevel = value;
        }

        [D2OIgnore]
        public int TextSound
        {
            get => textSound;
            set => textSound = value;
        }

        [D2OIgnore]
        public string TextRestriction
        {
            get => textRestriction;
            set => textRestriction = value;
        }

        int IIndexedData.Id => textId;
    }
}