using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using DofusRE.GameData;
using DofusRE.GameData.classes;
using Stump.ORM;
using Stump.Server.WorldServer.Database.Items.Templates;

namespace SpellEffectGenerator
{
    internal class Program
    {
        private static Dictionary<int, ItemTemplate> itemTemplates;

        public static void Main(string[] args)
        {
            if (!Directory.Exists(@"d2o"))
                Directory.CreateDirectory(@"d2o");

            if (!Directory.Exists(@"d2o"))
                Directory.CreateDirectory(@"d2o");
            DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", MySql.Data.MySqlClient.MySqlClientFactory.Instance);
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration
            {
                Host = "localhost",
                Port = "3306",
                DbName = "world",
                User = "root",
                Password = "",
                ProviderName = "MySql.Data.MySqlClient"
            };
            DatabaseAccessor databaseAccessor = new DatabaseAccessor(databaseConfiguration);
            databaseAccessor.OpenConnection();
            
            itemTemplates = databaseAccessor.Database.Query<ItemTemplate>(ItemTemplateRelator.FetchQuery).ToDictionary(entry => entry.Id);
            int addedItems = 0;
            var d2oItems = new GameDataReader(@"./d2o/Items.d2o");
            d2oItems.Read();
            int index = d2oItems.Classes.Last().Key+1;
            foreach (var entry in itemTemplates)
            {
                if (!d2oItems.Classes.ContainsKey(entry.Key))
                {
                    ItemTemplate itemTemplate = entry.Value;
                    Item item = new Item();
                    item.id = itemTemplate.Id;
                    item.nameId = itemTemplate.NameId;
                    item.typeId = itemTemplate.TypeId;
                    item.descriptionId = itemTemplate.DescriptionId;
                    item.iconId = itemTemplate.IconId;
                    item.level = itemTemplate.Level;
                    item.realWeight = itemTemplate.RealWeight;
                    item.cursed = itemTemplate.Cursed;
                    item.useAnimationId = itemTemplate.UseAnimationId;
                    item.usable = itemTemplate.Usable;
                    item.targetable = itemTemplate.Targetable;
                    item.exchangeable = !itemTemplate.IsLinkedToOwner;
                    item.price = itemTemplate.Price;
                    item.twoHanded = itemTemplate.TwoHanded;
                    item.etheral = itemTemplate.Etheral;
                    item.itemSetId = itemTemplate.ItemSetId;
                    item.criteria = itemTemplate.Criteria;
                    item.criteriaTarget = itemTemplate.CriteriaExpression.ToString();
                    item.hideEffects = itemTemplate.HideEffects;
                    item.enhanceable = false;
                    item.nonUsableOnAnother = !itemTemplate.Targetable;
                    item.appearanceId = itemTemplate.AppearanceId;
                    item.secretRecipe = false;
                    item.dropMonsterIds = new List<uint>() { };
                    item.dropTemporisMonsterIds = new List<uint>() { };
                    item.recipeSlots = 0;
                    item.recipeIds = new List<uint>() { };
                    item.objectIsDisplayOnWeb = true;
                    item.bonusIsSecret = itemTemplate.BonusIsSecret;
                    item.possibleEffects = null;
                    item.evolutiveEffectIds = new List<uint>();
                    item.favoriteSubAreas = new List<uint>();
                    item.favoriteSubAreasBonus = 0;
                    item.craftXpRatio = itemTemplate.CraftXpRatio;
                    item.craftVisible = null;
                    item.craftFeasible = null;
                    item.needUseConfirm = true;
                    item.isDestructible = true;
                    item.nuggetsBySubarea = new List<List<double>>();
                    item.containerIds = new List<uint>();
                    item.resourcesBySubarea = new List<List<int>>();
                    ItemType itemType = new ItemType();
                    itemType.id = itemTemplate.Type.Id;
                    itemType.nameId = itemTemplate.Type.NameId;
                    itemType.superTypeId = itemTemplate.Type.SuperTypeId;
                    itemType.categoryId = itemTemplate.TypeId;
                    itemType.isInEncyclopedia = true;
                    itemType.plural = itemTemplate.Type.Plural;
                    itemType.gender = itemTemplate.Type.Gender;
                    itemType.rawZone = "";
                    itemType.mimickable = itemTemplate.Type.Mimickable;
                    itemType.craftXpRatio = itemTemplate.Type.CraftXpRatio;
                    itemType.evolutiveTypeId = 0;
                    item.type = itemType;
                    item.weight = itemTemplate.Weight;
                    d2oItems.Classes.Add(index, item);
                    addedItems++;
                    index++;
                }
            }
            Console.WriteLine("Readed " + d2oItems.Classes.Count + " items!");
            Console.WriteLine("Added " + addedItems + " new items!");

            /*int index = 0;
            foreach (var entry in d2oItems.Classes)
            {
                int key = entry.Key;
                var monster = entry.Value as Item;
                List<MonsterDrop> newDrops = monster != null ? new List<MonsterDrop>(monster.drops) : new List<MonsterDrop>();
                MonsterDrop monsterDrop = new MonsterDrop();
                monsterDrop.dropId = 7754;
                monsterDrop.monsterId = monster.id;
                monsterDrop.objectId = 7754;
                monsterDrop.percentDropForGrade1 = 1.1;
                monsterDrop.percentDropForGrade2 = 1.2;
                monsterDrop.percentDropForGrade3 = 1.3;
                monsterDrop.percentDropForGrade4 = 1.4;
                monsterDrop.percentDropForGrade5 = 1.5;
                monsterDrop.count = 1;
                monsterDrop.criteria = "";
                monsterDrop.hasCriteria = false;
                newDrops.Add(monsterDrop);
                monster.drops = newDrops;
            }*/

            var writer = new GameDataWriter(@"./d2o/Items.d2o.new");
            writer.Write(d2oItems.ClassesDefinitions, d2oItems.Classes);
        }
    }
}