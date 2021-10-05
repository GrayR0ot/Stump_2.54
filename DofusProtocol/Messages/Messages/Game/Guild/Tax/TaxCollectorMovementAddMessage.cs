using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TaxCollectorMovementAddMessage : Message
    {
        public const uint Id = 5917;

        public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
        {
            Informations = informations;
        }

        public TaxCollectorMovementAddMessage()
        {
        }

        public override uint MessageId => Id;

        public TaxCollectorInformations Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Informations.TypeId);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
            Informations.Deserialize(reader);
        }
    }
}