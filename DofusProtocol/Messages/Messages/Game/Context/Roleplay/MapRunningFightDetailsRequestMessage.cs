using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapRunningFightDetailsRequestMessage : Message
    {
        public const uint Id = 5750;

        public MapRunningFightDetailsRequestMessage(ushort fightId)
        {
            FightId = fightId;
        }

        public MapRunningFightDetailsRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort FightId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUShort();
        }
    }
}