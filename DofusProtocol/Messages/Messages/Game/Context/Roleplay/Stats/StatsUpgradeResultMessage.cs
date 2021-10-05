using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StatsUpgradeResultMessage : Message
    {
        public const uint Id = 5609;

        public StatsUpgradeResultMessage(sbyte result, ushort nbCharacBoost)
        {
            Result = result;
            NbCharacBoost = nbCharacBoost;
        }

        public StatsUpgradeResultMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Result { get; set; }
        public ushort NbCharacBoost { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Result);
            writer.WriteVarUShort(NbCharacBoost);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadSByte();
            NbCharacBoost = reader.ReadVarUShort();
        }
    }
}