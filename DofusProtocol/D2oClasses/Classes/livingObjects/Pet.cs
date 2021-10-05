using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Pet", "com.ankamagames.dofus.datacenter.livingObjects")]
    [Serializable]
    public class Pet : IDataObject, IIndexedData
    {
        public const string MODULE = "Pets";
        public List<int> foodItems;
        public List<int> foodTypes;
        public int id;
        public int maxDurationBeforeMeal;
        public int minDurationBeforeMeal;
        public List<EffectInstance> possibleEffects;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public List<int> FoodItems
        {
            get => foodItems;
            set => foodItems = value;
        }

        [D2OIgnore]
        public List<int> FoodTypes
        {
            get => foodTypes;
            set => foodTypes = value;
        }

        [D2OIgnore]
        public int MinDurationBeforeMeal
        {
            get => minDurationBeforeMeal;
            set => minDurationBeforeMeal = value;
        }

        [D2OIgnore]
        public int MaxDurationBeforeMeal
        {
            get => maxDurationBeforeMeal;
            set => maxDurationBeforeMeal = value;
        }

        [D2OIgnore]
        public List<EffectInstance> PossibleEffects
        {
            get => possibleEffects;
            set => possibleEffects = value;
        }

        int IIndexedData.Id => id;
    }
}