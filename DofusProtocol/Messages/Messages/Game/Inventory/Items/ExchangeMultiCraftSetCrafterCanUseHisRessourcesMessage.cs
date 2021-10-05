using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : Message
    {
        public const uint Id = 6021;

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow)
        {
            Allow = allow;
        }

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Allow { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Allow);
        }

        public override void Deserialize(IDataReader reader)
        {
            Allow = reader.ReadBoolean();
        }
    }
}