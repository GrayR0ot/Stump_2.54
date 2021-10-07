using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Stump.Server.WorldServer.Game.Effects.Instances;
using System.Text.Json;
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
            EffectManager effectManager = new EffectManager();
            
            byte[] binaryEffects = File.ReadAllBytes(@"input\\spellEffects.bin");
            List<EffectBase> effects = effectManager.DeserializeEffects(binaryEffects);

            foreach (EffectBase effectBase in effects)
            {
                Console.WriteLine("Priority: " + effectBase.Priority);
            }
            
            string jsonEffects = JsonSerializer.Serialize(effects.ToArray());
            using (StreamWriter sw = new StreamWriter(@"output\\spellEffects.json"))
            {
                sw.Write(jsonEffects);
            }
            
            /*foreach (string file in files)
            {
                Console.WriteLine("Reading file " + file);
                string jsonEffects = File.ReadAllText(@""+file);

                List<EffectBase> effects = effectManager.DeserializeEffectsFromJson(jsonEffects);
            
                //Console.WriteLine("Read " + effects.Count + " effects from json!");
            
                byte[] serializedEffects = effectManager.SerializeEffects(effects);

                String outputName = file.Replace("input\\", "output\\");
                outputName = outputName.Replace(".json", ".bin");
                using (StreamWriter sw = new StreamWriter(@""+outputName))
                {
                    sw.BaseStream.Write(serializedEffects, 0, serializedEffects.Length);
                    //Console.WriteLine("Wrote " + effects.Count + " effects from json!");
                }
            }*/
        }
    }
}