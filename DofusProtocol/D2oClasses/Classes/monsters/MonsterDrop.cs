using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MonsterDrop", "com.ankamagames.dofus.datacenter.monsters")]
    [Serializable]
    public class MonsterDrop : IDataObject, IIndexedData
    {
        public int count;
        public string criteria;
        public uint dropId;
        public bool hasCriteria;
        public int monsterId;
        public int objectId;
        public double percentDropForGrade1;
        public double percentDropForGrade2;
        public double percentDropForGrade3;
        public double percentDropForGrade4;
        public double percentDropForGrade5;
        public List<MonsterDropCoefficient> specificDropCoefficient;

        [D2OIgnore]
        public uint DropId
        {
            get => dropId;
            set => dropId = value;
        }

        [D2OIgnore]
        public int MonsterId
        {
            get => monsterId;
            set => monsterId = value;
        }

        [D2OIgnore]
        public int ObjectId
        {
            get => objectId;
            set => objectId = value;
        }

        [D2OIgnore]
        public double PercentDropForGrade1
        {
            get => percentDropForGrade1;
            set => percentDropForGrade1 = value;
        }

        [D2OIgnore]
        public double PercentDropForGrade2
        {
            get => percentDropForGrade2;
            set => percentDropForGrade2 = value;
        }

        [D2OIgnore]
        public double PercentDropForGrade3
        {
            get => percentDropForGrade3;
            set => percentDropForGrade3 = value;
        }

        [D2OIgnore]
        public double PercentDropForGrade4
        {
            get => percentDropForGrade4;
            set => percentDropForGrade4 = value;
        }

        [D2OIgnore]
        public double PercentDropForGrade5
        {
            get => percentDropForGrade5;
            set => percentDropForGrade5 = value;
        }

        [D2OIgnore]
        public int Count
        {
            get => count;
            set => count = value;
        }

        [D2OIgnore]
        public string Criteria
        {
            get => criteria;
            set => criteria = value;
        }

        [D2OIgnore]
        public bool HasCriteria
        {
            get => hasCriteria;
            set => hasCriteria = value;
        }

        [D2OIgnore]
        public List<MonsterDropCoefficient> SpecificDropCoefficient
        {
            get => specificDropCoefficient;
            set => specificDropCoefficient = value;
        }

        int IIndexedData.Id => (int) dropId;
    }
}