using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeCraftResultMessage : Message
    {
        public const uint Id = 5790;

        public ExchangeCraftResultMessage(sbyte craftResult)
        {
            CraftResult = craftResult;
        }

        public ExchangeCraftResultMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte CraftResult { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(CraftResult);
        }

        public override void Deserialize(IDataReader reader)
        {
            CraftResult = reader.ReadSByte();
        }
    }
}