using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Stump.Core.IO;
using Stump.DofusProtocol.D2oClasses;
using Stump.Server.WorldServer.Game.Effects.Instances;

namespace ItemTemplateEffectGenerator
{
    internal class ItemTemplateProgram
    {
        public static void aMain(string[] args)
        {
            if (!Directory.Exists(@"output"))
                Directory.CreateDirectory(@"output");
            if (!Directory.Exists(@"output\itemTemplates"))
                Directory.CreateDirectory(@"output\itemTemplates");
            
            EffectManager effectManager = new EffectManager();

            string[] files = Directory.GetFiles(@"input\\itemTemplates\\");

            foreach (string file in files)
            {
                //Console.WriteLine("Reading file " + file);
                string jsonEffects = File.ReadAllText(@""+file);

                List<EffectDice> effects = JsonConvert.DeserializeObject<List<EffectDice>>(jsonEffects);
                List<EffectInstance> effectInstances = new List<EffectInstance>();
                foreach (var effect in effects)
                {
                    effectInstances.Add(effect.GetEffectInstance());
                }
                byte[] serializedEffects = effectInstances.ToBinary();

                String outputName = file.Replace("input\\", "output\\");
                outputName = outputName.Replace(".json", ".bin");
                using (StreamWriter sw = new StreamWriter(@""+outputName))
                {
                    sw.BaseStream.Write(serializedEffects, 0, serializedEffects.Length);
                }
            }
        }
    }
}