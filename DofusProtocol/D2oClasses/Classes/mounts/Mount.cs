using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Mount", "com.ankamagames.dofus.datacenter.mounts")]
    [Serializable]
    public class Mount : IDataObject, IIndexedData
    {
        public const string MODULE = "Mounts";
        public uint certificateId;
        public List<EffectInstance> effects;
        public uint familyId;
        public uint id;
        public string look;

        [I18NField] public uint nameId;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint FamilyId
        {
            get => familyId;
            set => familyId = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public string Look
        {
            get => look;
            set => look = value;
        }

        [D2OIgnore]
        public uint CertificateId
        {
            get => certificateId;
            set => certificateId = value;
        }

        [D2OIgnore]
        public List<EffectInstance> Effects
        {
            get => effects;
            set => effects = value;
        }

        int IIndexedData.Id => (int) id;
    }
}