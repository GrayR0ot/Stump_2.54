using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("PlaylistSound", "com.ankamagames.dofus.datacenter.ambientSounds")]
    [Serializable]
    public class PlaylistSound : IDataObject
    {
        public const string MODULE = "PlaylistSounds";
        public int channel;
        public string id;
        public int volume;

        [D2OIgnore]
        public string Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int Volume
        {
            get => volume;
            set => volume = value;
        }

        [D2OIgnore]
        public int Channel
        {
            get => channel;
            set => channel = value;
        }
    }
}