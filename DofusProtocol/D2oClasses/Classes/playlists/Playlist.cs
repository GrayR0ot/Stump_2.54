using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Playlist", "com.ankamagames.dofus.datacenter.playlists")]
    [Serializable]
    public class Playlist : IDataObject, IIndexedData
    {
        public const int AMBIENT_TYPE_ROLEPLAY = 1;
        public const int AMBIENT_TYPE_AMBIENT = 2;
        public const int AMBIENT_TYPE_FIGHT = 3;
        public const int AMBIENT_TYPE_BOSS = 4;
        public const string MODULE = "Playlists";
        public int id;
        public int iteration;
        public int silenceDuration;
        public List<PlaylistSound> sounds;
        public int type;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int SilenceDuration
        {
            get => silenceDuration;
            set => silenceDuration = value;
        }

        [D2OIgnore]
        public int Iteration
        {
            get => iteration;
            set => iteration = value;
        }

        [D2OIgnore]
        public int Type
        {
            get => type;
            set => type = value;
        }

        [D2OIgnore]
        public List<PlaylistSound> Sounds
        {
            get => sounds;
            set => sounds = value;
        }

        int IIndexedData.Id => id;
    }
}