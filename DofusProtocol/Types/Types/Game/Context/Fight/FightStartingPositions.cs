// Generated on 04/19/2020 04:35:17

using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightStartingPositions
    {
        public const short Id = 513;

        public IEnumerable<ushort> positionsForChallengers;
        public IEnumerable<ushort> positionsForDefenders;

        public FightStartingPositions()
        {
        }

        public FightStartingPositions(IEnumerable<ushort> positionsForChallengers,
            IEnumerable<ushort> positionsForDefenders)
        {
            this.positionsForChallengers = positionsForChallengers;
            this.positionsForDefenders = positionsForDefenders;
        }

        public virtual short TypeId => Id;

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) positionsForChallengers.Count());
            foreach (var objectToSend in positionsForChallengers) writer.WriteVarUShort(objectToSend);
            writer.WriteShort((short) positionsForDefenders.Count());
            foreach (var objectToSend in positionsForDefenders) writer.WriteVarUShort(objectToSend);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var positionsForChallengersCount = reader.ReadUShort();
            var positionsForChallengers_ = new ushort[positionsForChallengersCount];
            for (var positionsForChallengersIndex = 0;
                positionsForChallengersIndex < positionsForChallengersCount;
                positionsForChallengersIndex++)
                positionsForChallengers_[positionsForChallengersIndex] = reader.ReadVarUShort();
            positionsForChallengers = positionsForChallengers_;
            var positionsForDefendersCount = reader.ReadUShort();
            var positionsForDefenders_ = new ushort[positionsForDefendersCount];
            for (var positionsForDefendersIndex = 0;
                positionsForDefendersIndex < positionsForDefendersCount;
                positionsForDefendersIndex++)
                positionsForDefenders_[positionsForDefendersIndex] = reader.ReadVarUShort();
            positionsForDefenders = positionsForDefenders_;
        }
    }
}