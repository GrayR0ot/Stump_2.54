using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Stump.Server.WorldServer.Game.Effects.Instances;
using System.Text.Json;
using Stump.Core.IO;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.Server.WorldServer.Database.Spells;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SpellEffectGenerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (!Directory.Exists(@"output"))
                Directory.CreateDirectory(@"output");
            if (!Directory.Exists(@"output\spellEffects"))
                Directory.CreateDirectory(@"output\spellEffects");

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

            databaseAccessor.Database.Execute("TRUNCATE TABLE `spells_levels`");

            D2OReader d2OReader =
                new D2OReader(
                    @"C:\\Users\\leomo\\Mon Drive\C#\\Nexytrus\\Nexytrus\\bin\Debug\\net5.0\\dofus_windows_main_5.0_2.54.16.345 - Copie\\data\\common\\SpellLevels.d2o");
            Dictionary<int, SpellLevel> spellLevels = d2OReader.ReadObjects<SpellLevel>();

            foreach (SpellLevel spellLevel in spellLevels.Values)
            {
                SpellLevelTemplate spellLevelTemplate = new SpellLevelTemplate();
                spellLevelTemplate.AssignFields(spellLevel);
                    /*SpellLevelTemplate spellLevelTemplate = new SpellLevelTemplate(
                        spellLevel.Id,
                        spellLevel.SpellId,
                        spellLevel.SpellBreed,
                        spellLevel.ApCost,
                        spellLevel.Range,
                        spellLevel.CastInLine,
                        spellLevel.CastInDiagonal,
                        spellLevel.CastTestLos,
                        spellLevel.CriticalHitProbability,
                        0,
                        spellLevel.NeedFreeCell,
                        spellLevel.NeedFreeTrapCell,
                        spellLevel.NeedTakenCell,
                        spellLevel.RangeCanBeBoosted,
                        spellLevel.MaxStack,
                        spellLevel.MaxCastPerTurn,
                        spellLevel.MaxCastPerTarget,
                        spellLevel.MinCastInterval,
                        spellLevel.InitialCooldown,
                        spellLevel.GlobalCooldown,
                        spellLevel.MinPlayerLevel,
                        spellLevel.HideEffects,
                        spellLevel.Hidden,
                        spellLevel.MinRange,
                        spellLevel.StatesRequired.ToCSV(","),
                        spellLevel.StatesForbidden.ToCSV(","),
                        spellLevel.AdditionalEffectsZones.ToCSV(","),
                        spellLevel.StatesAuthorized.ToCSV(","),
                        spellLevel.CriticalEffect.ToBinary(),
                        spellLevel.Effects.ToBinary()
                        );*/
                    
                databaseAccessor.Database.Insert(spellLevelTemplate);
            }

            databaseAccessor.CloseConnection();
        }
    }
}