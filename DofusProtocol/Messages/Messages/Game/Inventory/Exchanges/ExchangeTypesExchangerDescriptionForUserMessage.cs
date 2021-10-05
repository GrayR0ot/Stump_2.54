using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeTypesExchangerDescriptionForUserMessage : Message
    {
        public const uint Id = 5765;

        public ExchangeTypesExchangerDescriptionForUserMessage(uint[] typeDescription)
        {
            TypeDescription = typeDescription;
        }

        public ExchangeTypesExchangerDescriptionForUserMessage()
        {
        }

        public override uint MessageId => Id;

        public uint[] TypeDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) TypeDescription.Count());
            for (var typeDescriptionIndex = 0; typeDescriptionIndex < TypeDescription.Count(); typeDescriptionIndex++)
                writer.WriteVarUInt(TypeDescription[typeDescriptionIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var typeDescriptionCount = reader.ReadUShort();
            TypeDescription = new uint[typeDescriptionCount];
            for (var typeDescriptionIndex = 0; typeDescriptionIndex < typeDescriptionCount; typeDescriptionIndex++)
                TypeDescription[typeDescriptionIndex] = reader.ReadVarUInt();
        }
    }
}