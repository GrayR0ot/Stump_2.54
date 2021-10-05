using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Item", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class Item : IDataObject, IIndexedData
    {
        public const string MODULE = "Items";
        public const int MAX_JOB_LEVEL_GAP = 100;
        public uint appearanceId;
        public bool bonusIsSecret;
        public List<uint> containerIds;
        public string craftFeasible;
        public string craftVisible;
        public int craftXpRatio;
        public string criteria;
        public string criteriaTarget;
        public bool cursed;

        [I18NField] public uint descriptionId;

        public List<uint> dropMonsterIds;
        public List<uint> dropTemporisMonsterIds;
        public bool enhanceable;
        public bool etheral;
        public List<uint> evolutiveEffectIds;
        public bool exchangeable;
        public List<uint> favoriteSubAreas;
        public uint favoriteSubAreasBonus;
        public bool hideEffects;
        public int iconId;
        public int id;
        public bool isDestructible;
        public bool isSaleable;
        public int itemSetId;
        public uint level;

        [I18NField] public uint nameId;

        public bool needUseConfirm;
        public bool nonUsableOnAnother;
        public List<List<double>> nuggetsBySubarea;
        public bool objectIsDisplayOnWeb;
        public List<EffectInstance> possibleEffects;
        public double price;
        public uint realWeight;
        public List<uint> recipeIds;
        public uint recipeSlots;
        public List<List<int>> resourcesBySubarea;
        public bool secretRecipe;
        public bool targetable;
        public bool twoHanded;
        public uint typeId;
        public bool usable;
        public int useAnimationId;
        public uint weight;

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
        public uint TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public uint Level
        {
            get => level;
            set => level = value;
        }

        [D2OIgnore]
        public uint RealWeight
        {
            get => realWeight;
            set => realWeight = value;
        }

        [D2OIgnore]
        public bool Cursed
        {
            get => cursed;
            set => cursed = value;
        }

        [D2OIgnore]
        public int UseAnimationId
        {
            get => useAnimationId;
            set => useAnimationId = value;
        }

        [D2OIgnore]
        public bool Usable
        {
            get => usable;
            set => usable = value;
        }

        [D2OIgnore]
        public bool Targetable
        {
            get => targetable;
            set => targetable = value;
        }

        [D2OIgnore]
        public bool Exchangeable
        {
            get => exchangeable;
            set => exchangeable = value;
        }

        [D2OIgnore]
        public double Price
        {
            get => price;
            set => price = value;
        }

        [D2OIgnore]
        public bool TwoHanded
        {
            get => twoHanded;
            set => twoHanded = value;
        }

        [D2OIgnore]
        public bool Etheral
        {
            get => etheral;
            set => etheral = value;
        }

        [D2OIgnore]
        public int ItemSetId
        {
            get => itemSetId;
            set => itemSetId = value;
        }

        [D2OIgnore]
        public string Criteria
        {
            get => criteria;
            set => criteria = value;
        }

        [D2OIgnore]
        public string CriteriaTarget
        {
            get => criteriaTarget;
            set => criteriaTarget = value;
        }

        [D2OIgnore]
        public bool HideEffects
        {
            get => hideEffects;
            set => hideEffects = value;
        }

        [D2OIgnore]
        public bool Enhanceable
        {
            get => enhanceable;
            set => enhanceable = value;
        }

        [D2OIgnore]
        public bool NonUsableOnAnother
        {
            get => nonUsableOnAnother;
            set => nonUsableOnAnother = value;
        }

        [D2OIgnore]
        public uint AppearanceId
        {
            get => appearanceId;
            set => appearanceId = value;
        }

        [D2OIgnore]
        public bool SecretRecipe
        {
            get => secretRecipe;
            set => secretRecipe = value;
        }

        [D2OIgnore]
        public List<uint> DropMonsterIds
        {
            get => dropMonsterIds;
            set => dropMonsterIds = value;
        }

        [D2OIgnore]
        public List<uint> DropTemporisMonsterIds
        {
            get => dropTemporisMonsterIds;
            set => dropTemporisMonsterIds = value;
        }

        [D2OIgnore]
        public uint RecipeSlots
        {
            get => recipeSlots;
            set => recipeSlots = value;
        }

        [D2OIgnore]
        public List<uint> RecipeIds
        {
            get => recipeIds;
            set => recipeIds = value;
        }

        [D2OIgnore]
        public bool ObjectIsDisplayOnWeb
        {
            get => objectIsDisplayOnWeb;
            set => objectIsDisplayOnWeb = value;
        }

        [D2OIgnore]
        public bool BonusIsSecret
        {
            get => bonusIsSecret;
            set => bonusIsSecret = value;
        }

        [D2OIgnore]
        public List<EffectInstance> PossibleEffects
        {
            get => possibleEffects;
            set => possibleEffects = value;
        }

        [D2OIgnore]
        public List<uint> EvolutiveEffectIds
        {
            get => evolutiveEffectIds;
            set => evolutiveEffectIds = value;
        }

        [D2OIgnore]
        public List<uint> FavoriteSubAreas
        {
            get => favoriteSubAreas;
            set => favoriteSubAreas = value;
        }

        [D2OIgnore]
        public uint FavoriteSubAreasBonus
        {
            get => favoriteSubAreasBonus;
            set => favoriteSubAreasBonus = value;
        }

        [D2OIgnore]
        public int CraftXpRatio
        {
            get => craftXpRatio;
            set => craftXpRatio = value;
        }

        [D2OIgnore]
        public string CraftVisible
        {
            get => craftVisible;
            set => craftVisible = value;
        }

        [D2OIgnore]
        public string CraftFeasible
        {
            get => craftFeasible;
            set => craftFeasible = value;
        }

        [D2OIgnore]
        public bool NeedUseConfirm
        {
            get => needUseConfirm;
            set => needUseConfirm = value;
        }

        [D2OIgnore]
        public bool IsDestructible
        {
            get => isDestructible;
            set => isDestructible = value;
        }

        [D2OIgnore]
        public bool IsSaleable
        {
            get => isSaleable;
            set => isSaleable = value;
        }

        [D2OIgnore]
        public List<List<double>> NuggetsBySubarea
        {
            get => nuggetsBySubarea;
            set => nuggetsBySubarea = value;
        }

        [D2OIgnore]
        public List<uint> ContainerIds
        {
            get => containerIds;
            set => containerIds = value;
        }

        [D2OIgnore]
        public List<List<int>> ResourcesBySubarea
        {
            get => resourcesBySubarea;
            set => resourcesBySubarea = value;
        }

        [D2OIgnore]
        public uint Weight
        {
            get => weight;
            set => weight = value;
        }

        int IIndexedData.Id => id;
    }
}