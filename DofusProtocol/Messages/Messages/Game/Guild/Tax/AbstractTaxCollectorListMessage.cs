using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AbstractTaxCollectorListMessage : Message
    {
        public const uint Id = 6568;

        public AbstractTaxCollectorListMessage(TaxCollectorInformations[] informations)
        {
            Informations = informations;
        }

        public AbstractTaxCollectorListMessage()
        {
        }

        public override uint MessageId => Id;

        public TaxCollectorInformations[] Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Informations.Count());
            for (var informationsIndex = 0; informationsIndex < Informations.Count(); informationsIndex++)
            {
                var objectToSend = Informations[informationsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var informationsCount = reader.ReadUShort();
            Informations = new TaxCollectorInformations[informationsCount];
            for (var informationsIndex = 0; informationsIndex < informationsCount; informationsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Informations[informationsIndex] = objectToAdd;
            }
        }
    }
}