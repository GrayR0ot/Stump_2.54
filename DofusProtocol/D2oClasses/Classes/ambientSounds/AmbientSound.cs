using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AmbientSound", "com.ankamagames.dofus.datacenter.ambientSounds")]
    [Serializable]
    public class AmbientSound : PlaylistSound
    {
        public const int AMBIENT_TYPE_ROLEPLAY = 1;
        public const int AMBIENT_TYPE_AMBIENT = 2;
        public const int AMBIENT_TYPE_FIGHT = 3;
        public const int AMBIENT_TYPE_BOSS = 4;
        public const string MODULE = "AmbientSounds";
        public int criterionId;
        public uint silenceMax;
        public uint silenceMin;
        public int type_id;

        [D2OIgnore]
        public int CriterionId
        {
            get => criterionId;
            set => criterionId = value;
        }

        [D2OIgnore]
        public uint SilenceMin
        {
            get => silenceMin;
            set => silenceMin = value;
        }

        [D2OIgnore]
        public uint SilenceMax
        {
            get => silenceMax;
            set => silenceMax = value;
        }

        [D2OIgnore]
        public int Type_id
        {
            get => type_id;
            set => type_id = value;
        }
    }
}