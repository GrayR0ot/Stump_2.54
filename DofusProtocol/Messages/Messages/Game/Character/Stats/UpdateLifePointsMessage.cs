using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class UpdateLifePointsMessage : Message
    {
        public const uint Id = 5658;

        public UpdateLifePointsMessage(uint lifePoints, uint maxLifePoints)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
        }

        public UpdateLifePointsMessage()
        {
        }

        public override uint MessageId => Id;

        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(LifePoints);
            writer.WriteVarUInt(MaxLifePoints);
        }

        public override void Deserialize(IDataReader reader)
        {
            LifePoints = reader.ReadVarUInt();
            MaxLifePoints = reader.ReadVarUInt();
        }
    }
}