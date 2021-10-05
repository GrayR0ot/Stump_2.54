using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightTurnListMessage : Message
    {
        public const uint Id = 713;

        public GameFightTurnListMessage(double[] ids, double[] deadsIds)
        {
            Ids = ids;
            DeadsIds = deadsIds;
        }

        public GameFightTurnListMessage()
        {
        }

        public override uint MessageId => Id;

        public double[] Ids { get; set; }
        public double[] DeadsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Ids.Count());
            for (var idsIndex = 0; idsIndex < Ids.Count(); idsIndex++) writer.WriteDouble(Ids[idsIndex]);
            writer.WriteShort((short) DeadsIds.Count());
            for (var deadsIdsIndex = 0; deadsIdsIndex < DeadsIds.Count(); deadsIdsIndex++)
                writer.WriteDouble(DeadsIds[deadsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new double[idsCount];
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) Ids[idsIndex] = reader.ReadDouble();
            var deadsIdsCount = reader.ReadUShort();
            DeadsIds = new double[deadsIdsCount];
            for (var deadsIdsIndex = 0; deadsIdsIndex < deadsIdsCount; deadsIdsIndex++)
                DeadsIds[deadsIdsIndex] = reader.ReadDouble();
        }
    }
}