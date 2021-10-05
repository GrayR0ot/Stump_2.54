using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TaxCollectorMovementsOfflineMessage : Message
    {
        public const uint Id = 6611;

        public TaxCollectorMovementsOfflineMessage(TaxCollectorMovement[] movements)
        {
            Movements = movements;
        }

        public TaxCollectorMovementsOfflineMessage()
        {
        }

        public override uint MessageId => Id;

        public TaxCollectorMovement[] Movements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Movements.Count());
            for (var movementsIndex = 0; movementsIndex < Movements.Count(); movementsIndex++)
            {
                var objectToSend = Movements[movementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var movementsCount = reader.ReadUShort();
            Movements = new TaxCollectorMovement[movementsCount];
            for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
            {
                var objectToAdd = new TaxCollectorMovement();
                objectToAdd.Deserialize(reader);
                Movements[movementsIndex] = objectToAdd;
            }
        }
    }
}