using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("BreedRoleByBreed", "com.ankamagames.dofus.datacenter.breeds")]
    [Serializable]
    public class BreedRoleByBreed : IDataObject, IIndexedData
    {
        public const string MODULE = "BreedRoleByBreeds";
        public int breedId;

        [I18NField] public uint descriptionId;

        public int order;
        public int roleId;
        public int value;

        [D2OIgnore]
        public int BreedId
        {
            get => breedId;
            set => breedId = value;
        }

        [D2OIgnore]
        public int RoleId
        {
            get => roleId;
            set => roleId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int Value
        {
            get => value;
            set => this.value = value;
        }

        [D2OIgnore]
        public int Order
        {
            get => order;
            set => order = value;
        }

        int IIndexedData.Id => breedId;
    }
}