using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LifePointsRegenEndMessage : UpdateLifePointsMessage
    {
        public new const uint Id = 5686;

        public LifePointsRegenEndMessage(uint lifePoints, uint maxLifePoints, uint lifePointsGained)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            LifePointsGained = lifePointsGained;
        }

        public LifePointsRegenEndMessage()
        {
        }

        public override uint MessageId => Id;

        public uint LifePointsGained { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(LifePointsGained);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LifePointsGained = reader.ReadVarUInt();
        }
    }
}