using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightTackledMessage : AbstractGameActionMessage
    {
        public new const uint Id = 1004;

        public GameActionFightTackledMessage(ushort actionId, double sourceId, double[] tacklersIds)
        {
            ActionId = actionId;
            SourceId = sourceId;
            TacklersIds = tacklersIds;
        }

        public GameActionFightTackledMessage()
        {
        }

        public override uint MessageId => Id;

        public double[] TacklersIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) TacklersIds.Count());
            for (var tacklersIdsIndex = 0; tacklersIdsIndex < TacklersIds.Count(); tacklersIdsIndex++)
                writer.WriteDouble(TacklersIds[tacklersIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var tacklersIdsCount = reader.ReadUShort();
            TacklersIds = new double[tacklersIdsCount];
            for (var tacklersIdsIndex = 0; tacklersIdsIndex < tacklersIdsCount; tacklersIdsIndex++)
                TacklersIds[tacklersIdsIndex] = reader.ReadDouble();
        }
    }
}