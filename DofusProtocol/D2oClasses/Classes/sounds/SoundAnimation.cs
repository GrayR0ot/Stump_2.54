using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SoundAnimation", "com.ankamagames.dofus.datacenter.sounds")]
    [Serializable]
    public class SoundAnimation : IDataObject, IIndexedData
    {
        public int automationDuration;
        public int automationFadeIn;
        public int automationFadeOut;
        public int automationVolume;
        public string filename;
        public uint id;
        public string label;
        public string MODULE = "SoundAnimations";
        public string name;
        public bool noCutSilence;
        public int rolloff;
        public uint startFrame;
        public int volume;

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
        public string Label
        {
            get => label;
            set => label = value;
        }

        [D2OIgnore]
        public string Filename
        {
            get => filename;
            set => filename = value;
        }

        [D2OIgnore]
        public int Volume
        {
            get => volume;
            set => volume = value;
        }

        [D2OIgnore]
        public int Rolloff
        {
            get => rolloff;
            set => rolloff = value;
        }

        [D2OIgnore]
        public int AutomationDuration
        {
            get => automationDuration;
            set => automationDuration = value;
        }

        [D2OIgnore]
        public int AutomationVolume
        {
            get => automationVolume;
            set => automationVolume = value;
        }

        [D2OIgnore]
        public int AutomationFadeIn
        {
            get => automationFadeIn;
            set => automationFadeIn = value;
        }

        [D2OIgnore]
        public int AutomationFadeOut
        {
            get => automationFadeOut;
            set => automationFadeOut = value;
        }

        [D2OIgnore]
        public bool NoCutSilence
        {
            get => noCutSilence;
            set => noCutSilence = value;
        }

        [D2OIgnore]
        public uint StartFrame
        {
            get => startFrame;
            set => startFrame = value;
        }

        int IIndexedData.Id => (int) id;
    }
}