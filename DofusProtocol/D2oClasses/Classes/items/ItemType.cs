using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ItemType", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class ItemType : IDataObject, IIndexedData
    {
        public const string MODULE = "ItemTypes";
        public uint categoryId;
        public int craftXpRatio;
        public int evolutiveTypeId;
        public uint gender;
        public int id;
        public bool isInEncyclopedia;
        public bool mimickable;

        [I18NField] public uint nameId;

        public bool plural;
        public string rawZone;
        public uint superTypeId;

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
        public uint SuperTypeId
        {
            get => superTypeId;
            set => superTypeId = value;
        }

        [D2OIgnore]
        public uint CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public bool IsInEncyclopedia
        {
            get => isInEncyclopedia;
            set => isInEncyclopedia = value;
        }

        [D2OIgnore]
        public bool Plural
        {
            get => plural;
            set => plural = value;
        }

        [D2OIgnore]
        public uint Gender
        {
            get => gender;
            set => gender = value;
        }

        [D2OIgnore]
        public string RawZone
        {
            get => rawZone;
            set => rawZone = value;
        }

        [D2OIgnore]
        public bool Mimickable
        {
            get => mimickable;
            set => mimickable = value;
        }

        [D2OIgnore]
        public int CraftXpRatio
        {
            get => craftXpRatio;
            set => craftXpRatio = value;
        }

        [D2OIgnore]
        public int EvolutiveTypeId
        {
            get => evolutiveTypeId;
            set => evolutiveTypeId = value;
        }

        int IIndexedData.Id => id;
    }
}