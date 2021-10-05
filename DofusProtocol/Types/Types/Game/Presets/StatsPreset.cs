using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class StatsPreset : Preset
    {
        public new const short Id = 521;

        public StatsPreset(short objectId, SimpleCharacterCharacteristicForPreset[] stats)
        {
            ObjectId = objectId;
            Stats = stats;
        }

        public StatsPreset()
        {
        }

        public override short TypeId => Id;

        public SimpleCharacterCharacteristicForPreset[] Stats { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Stats.Count());
            for (var statsIndex = 0; statsIndex < Stats.Count(); statsIndex++)
            {
                var objectToSend = Stats[statsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var statsCount = reader.ReadUShort();
            Stats = new SimpleCharacterCharacteristicForPreset[statsCount];
            for (var statsIndex = 0; statsIndex < statsCount; statsIndex++)
            {
                var objectToAdd = new SimpleCharacterCharacteristicForPreset();
                objectToAdd.Deserialize(reader);
                Stats[statsIndex] = objectToAdd;
            }
        }
    }
}