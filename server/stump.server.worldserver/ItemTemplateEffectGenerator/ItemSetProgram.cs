/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Stump.Server.WorldServer.Game.Effects.Instances;
using System.Text.Json;
using Stump.Core.IO;
using Stump.DofusProtocol.D2oClasses;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ItemTemplateEffectGenerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (!Directory.Exists(@"output"))
                Directory.CreateDirectory(@"output");
            if (!Directory.Exists(@"output\itemSets"))
                Directory.CreateDirectory(@"output\itemSets");

            EffectManager effectManager = new EffectManager();

            /*byte[] binEffects = File.ReadAllBytes(@"input\itemSets\1.json");
            List<List<EffectBase>> effects = binEffects.ToObject<List<List<EffectBase>>>();
            Console.WriteLine(JsonConvert.SerializeObject(effects));
            using (StreamWriter sw = new StreamWriter(@"output\test1.json"))
            {
                sw.Write(JsonConvert.SerializeObject(effects));
            }*//*
            string[] files = Directory.GetFiles(@"input\\itemSets\\");

            foreach (string file in files)
            {
                Console.WriteLine("Reading file " + file);
                string jsonEffects = File.ReadAllText(@"" + file);
                List<List<EffectBase>> effects = JsonConvert.DeserializeObject<List<List<EffectBase>>>(jsonEffects);
                Console.WriteLine("Items :" + effects.Count);
                foreach (List<EffectBase> effectArray in effects)
                {
                    if (effectArray.Count > 0)
                    {
                        Console.WriteLine("Effects :" + effectArray.Count);
                        foreach (EffectBase effect in effectArray)
                        {
                            if (effect != null)
                            {
                                //Console.WriteLine("Effect: " + JsonConvert.SerializeObject(effect));
                                effect.Modificator = 0;
                            }
                        }
                    }
                }

                byte[] serializedEffects = effects.ToBinary().ToObject<List<List<EffectBase>>>().ToBinary();

                String outputName = file.Replace("input\\", "output\\");
                outputName = outputName.Replace(".json", ".bin");
                using (StreamWriter sw = new StreamWriter(@"" + outputName))
                {
                    sw.BaseStream.Write(serializedEffects, 0, serializedEffects.Length);
                }
            }
        }
    }
}*/