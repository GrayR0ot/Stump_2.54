using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpellVariant", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class SpellVariant : IDataObject, IIndexedData
    {
        public const string MODULE = "SpellVariants";
        public uint breedId;
        public int id;
        public List<uint> spellIds;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint BreedId
        {
            get => breedId;
            set => breedId = value;
        }

        [D2OIgnore]
        public List<uint> SpellIds
        {
            get => spellIds;
            set => spellIds = value;
        }

        int IIndexedData.Id => id;
    }
}