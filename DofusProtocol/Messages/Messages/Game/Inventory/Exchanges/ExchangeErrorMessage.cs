using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeErrorMessage : Message
    {
        public const uint Id = 5513;

        public ExchangeErrorMessage(sbyte errorType)
        {
            ErrorType = errorType;
        }

        public ExchangeErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ErrorType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ErrorType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ErrorType = reader.ReadSByte();
        }
    }
}