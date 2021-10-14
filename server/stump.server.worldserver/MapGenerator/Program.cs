using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using D2pReader;
using D2pReader.MapInformations;
using D2pReader.MapInformations.Elements;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stump.DofusProtocol.D2oClasses;

namespace MapGenerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MapManager mapManager =
                new MapManager(
                    @"C:\Users\leomo\Google Drive\C#\Nexytrus\Nexytrus\bin\Debug\net5.0\dofus_windows_main_5.0_2.54.16.345 - Copie\content\maps");
            Dictionary<uint, Map> maps = mapManager.ParseAllMap(mapManager);
            List<MapUtils> mapJson = new List<MapUtils>();
            if (!Directory.Exists(@"output"))
                Directory.CreateDirectory(@"output");
            if (!Directory.Exists(@"output\maps"))
                Directory.CreateDirectory(@"output\maps");

            foreach (var keyValuePair in maps)
            {
                MapUtils mapUtils = new MapUtils(
                    (int) keyValuePair.Key,
                    keyValuePair.Value.TopNeighbourId,
                    keyValuePair.Value.BottomNeighbourId,
                    keyValuePair.Value.LeftNeighbourId,
                    keyValuePair.Value.RightNeighbourId
                );


                using (StreamWriter sw = new StreamWriter(@"output\maps\\" + keyValuePair.Key + ".json"))
                {
                    /*if (keyValuePair.Value.Count > 0)
                    {*/
                    sw.Write(JsonConvert.SerializeObject(keyValuePair.Value));
                    //}
                }

                //Console.WriteLine("Map ID: " + keyValuePair.Key);
                //Console.WriteLine("Map Cells: " + keyValuePair.Value.CellsCount);
                //Console.WriteLine("Map cells.bin: " + keyValuePair.Value.map.m_compressedCells;

                mapJson.Add(mapUtils);
                byte[] compressedCells = ZipHelper.Compress(keyValuePair.Value.map.GetMap(keyValuePair.Key).m_compressedCells);
                string result;
                using (MD5 hash = MD5.Create())
                {
                    result = String.Join
                    (
                        "",
                        from ba in hash.ComputeHash
                        (
                            Encoding.UTF8.GetBytes(compressedCells.ToJson())
                        ) 
                        select ba.ToString("x2")
                    );
                }
                Console.WriteLine(keyValuePair.Key + " map hash cells is " + result);
                //Console.WriteLine(keyValuePair.Key + " map cells is " + keyValuePair.Value.m_compressedCells.ToJson());
                using (StreamWriter sw = new StreamWriter(@"output\maps\"+keyValuePair.Key+".bin"))
                {
                    //Console.WriteLine("Cells: " + JsonConvert.SerializeObject(keyValuePair.Value.map.GetMap(keyValuePair.Key).Cells.ToList()));
                    //Console.WriteLine("binary: " + keyValuePair.Value.map.GetMap(keyValuePair.Key).map.m_compressedCells.Length);
                    sw.BaseStream.Write(compressedCells, 0, compressedCells.Length);
                    //Console.WriteLine("Saved map #" + keyValuePair.Key + " cells bins");
                    //break;
                }
            }

            using (StreamWriter sw = new StreamWriter(@"output\mapNeighbours.json"))
            {
                string mapNeibours = JsonConvert.SerializeObject(mapJson);
                sw.WriteLine(mapNeibours);
                Console.WriteLine("Saved Map Neighbour json file");
            }
        }
    }
}