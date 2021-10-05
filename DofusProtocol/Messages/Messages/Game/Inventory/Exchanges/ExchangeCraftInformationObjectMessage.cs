using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeCraftInformationObjectMessage : ExchangeCraftResultWithObjectIdMessage
    {
        public new const uint Id = 5794;

        public ExchangeCraftInformationObjectMessage(sbyte craftResult, ushort objectGenericId, ulong playerId)
        {
            CraftResult = craftResult;
            ObjectGenericId = objectGenericId;
            PlayerId = playerId;
        }

        public ExchangeCraftInformationObjectMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarULong();
        }
    }
}