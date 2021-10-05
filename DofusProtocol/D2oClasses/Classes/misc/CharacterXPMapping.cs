using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CharacterXPMapping", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class CharacterXPMapping : IDataObject
    {
        public const string MODULE = "CharacterXPMappings";
        public double experiencePoints;
        public int level;

        [D2OIgnore]
        public int Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public double ExperiencePoints
        {
            get => experiencePoints;
            set => experiencePoints = value;
        }
    }
}