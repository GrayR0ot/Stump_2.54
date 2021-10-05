using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CreatureBoneType", "com.ankamagames.dofus.datacenter.appearance")]
    [Serializable]
    public class CreatureBoneType : IDataObject, IIndexedData
    {
        public const string MODULE = "CreatureBonesTypes";
        public int creatureBoneId;
        public int id;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int CreatureBoneId
        {
            get => creatureBoneId;
            set => creatureBoneId = value;
        }

        int IIndexedData.Id => id;
    }
}