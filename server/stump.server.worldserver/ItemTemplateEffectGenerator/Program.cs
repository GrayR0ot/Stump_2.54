using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Database.Spells;

namespace SpellEffectGenerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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

            D2OReader d2OReader;

            #region ItemTemplate
            databaseAccessor.Database.Execute("TRUNCATE TABLE `items_templates`");
            d2OReader =
                new D2OReader(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\common\\Items.d2o");
            Dictionary<int, Item> items = d2OReader.ReadObjects<Item>();

            foreach (Item item in items.Values)
            {
                if (!(item is Weapon))
                {
                    ItemTemplate itemTemplate = new ItemTemplate();
                    itemTemplate.AssignFields(item);
                    databaseAccessor.Database.Insert(itemTemplate);
                }
            }
            #endregion
            
            #region WeaponTemplate
            databaseAccessor.Database.Execute("TRUNCATE TABLE `items_templates_weapons`");
            d2OReader =
                new D2OReader(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\common\\Items.d2o");
            Dictionary<int, Weapon> weapons = d2OReader.ReadObjects<Weapon>();

            foreach (Weapon weapon in weapons.Values)
            {
                WeaponTemplate weaponTemplate = new WeaponTemplate();
                weaponTemplate.AssignFields(weapon);

                databaseAccessor.Database.Insert(weaponTemplate);
            }
            #endregion
            
            #region ItemSetTemplate
            databaseAccessor.Database.Execute("TRUNCATE TABLE `items_sets`");
            d2OReader =
                new D2OReader(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\common\\ItemSets.d2o");
            Dictionary<int, ItemSet> itemSets = d2OReader.ReadObjects<ItemSet>();
            foreach (ItemSet itemSet in itemSets.Values)
            {
                ItemSetTemplate itemSetTemplate = new ItemSetTemplate();
                itemSetTemplate.AssignFields(itemSet);

                databaseAccessor.Database.Insert(itemSetTemplate);
            }
            databaseAccessor.Database.Execute("TRUNCATE TABLE `items_sets`");
            #endregion

            databaseAccessor.CloseConnection();
        }
    }
}