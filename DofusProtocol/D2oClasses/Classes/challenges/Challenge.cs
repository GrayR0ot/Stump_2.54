using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Challenge", "com.ankamagames.dofus.datacenter.challenges")]
    [Serializable]
    public class Challenge : IDataObject, IIndexedData
    {
        public const string MODULE = "Challenge";
        public bool dareAvailable;

        [I18NField] public uint descriptionId;

        public int id;
        public List<uint> incompatibleChallenges;

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
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public bool DareAvailable
        {
            get => dareAvailable;
            set => dareAvailable = value;
        }

        [D2OIgnore]
        public List<uint> IncompatibleChallenges
        {
            get => incompatibleChallenges;
            set => incompatibleChallenges = value;
        }

        int IIndexedData.Id => id;
    }
}