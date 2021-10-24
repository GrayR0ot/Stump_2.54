using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stump.Core.Extensions;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2i;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.Server.WorldServer.Database.I18n;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Database.Mounts;
using Stump.Server.WorldServer.Database.Npcs;
using Stump.Server.WorldServer.Database.Spells;
using Stump.Server.WorldServer.Game.Items;
using Item = Stump.DofusProtocol.D2oClasses.Item;

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

            JObject appearancesJson = JObject.Parse(File.ReadAllText(@"appearances.json"));
            Dictionary<int, int> appearances = new Dictionary<int, int>();
            foreach (var jsonObject in (JArray)appearancesJson["data"])
            {
                try
                {
                        appearances.Add((int) jsonObject["official"], (int) jsonObject["swf"]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Failed on " + jsonObject["id"]);
                }
            }
            Console.WriteLine("Loaded " + appearances.Count + " appearances!");

            #region Lang

            databaseAccessor.Database.Execute("TRUNCATE TABLE `langs`");
            databaseAccessor.Database.Execute("TRUNCATE TABLE `langs_ui`");
            D2IFile d2IFile =
                new D2IFile(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\i18n\\i18n_fr.d2i");
            Dictionary<int, string> langs = d2IFile.GetAllText();
            Dictionary<string, string> langsUi = d2IFile.GetAllUiText();

            foreach (var entrySet in langs)
            {
                LangText langText = new LangText();
                langText.Id = (uint) entrySet.Key;
                langText.French = entrySet.Value;
                databaseAccessor.Database.Insert(langText);
            }

            foreach (var entrySet in langsUi)
            {
                LangTextUi langText = new LangTextUi();
                langText.Name = entrySet.Key;
                langText.French = entrySet.Value;
                databaseAccessor.Database.Insert(langText);
            }

            #endregion

            #region Npc

            /*databaseAccessor.Database.Execute("TRUNCATE TABLE `npcs_templates`");
            d2OReader =
                new D2OReader(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\common\\Npcs.d2o");
            Dictionary<int, Npc> npcs = d2OReader.ReadObjects<Npc>();

            foreach (Npc npc in npcs.Values)
            {
                    NpcTemplate npcTemplate = new NpcTemplate();
                    npcTemplate.AssignFields(npc);
                    databaseAccessor.Database.Insert(npcTemplate);
            }*/

            #endregion

            #region Mount

            databaseAccessor.Database.Execute("TRUNCATE TABLE `mounts_templates`");
            d2OReader =
                new D2OReader(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\common\\Mounts.d2o");
            Dictionary<int, Mount> mounts = d2OReader.ReadObjects<Mount>();

            foreach (Mount mount in mounts.Values)
            {
                    MountTemplate mountTemplate = new MountTemplate();
                    mountTemplate.AssignFields(mount);
                    databaseAccessor.Database.Insert(mountTemplate);
            }

            #endregion

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
                    if (appearances.ContainsKey((int)itemTemplate.Id))
                    {
                        int appearanceId = 0;
                        appearances.TryGetValue((int)itemTemplate.Id, out appearanceId);
                        itemTemplate.AppearanceId = (uint)appearanceId;
                    }
                    if (langs.ContainsKey((int)itemTemplate.NameId))
                    {
                        string name = "toDo";
                        langs.TryGetValue((int)itemTemplate.NameId, out name);
                        itemTemplate.Name = name;
                    }
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