using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BasicStatWithDataMessage : BasicStatMessage
    {
        public new const uint Id = 6573;

        public BasicStatWithDataMessage(double timeSpent, ushort statId, StatisticData[] datas)
        {
            TimeSpent = timeSpent;
            StatId = statId;
            Datas = datas;
        }

        public BasicStatWithDataMessage()
        {
        }

        public override uint MessageId => Id;

        public StatisticData[] Datas { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Datas.Count());
            for (var datasIndex = 0; datasIndex < Datas.Count(); datasIndex++)
            {
                var objectToSend = Datas[datasIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var datasCount = reader.ReadUShort();
            Datas = new StatisticData[datasCount];
            for (var datasIndex = 0; datasIndex < datasCount; datasIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<StatisticData>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Datas[datasIndex] = objectToAdd;
            }
        }
    }
}