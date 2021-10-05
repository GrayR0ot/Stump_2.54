using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : Message
    {
        public const uint Id = 6020;

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed)
        {
            Allowed = allowed;
        }

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Allowed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Allowed);
        }

        public override void Deserialize(IDataReader reader)
        {
            Allowed = reader.ReadBoolean();
        }
    }
}