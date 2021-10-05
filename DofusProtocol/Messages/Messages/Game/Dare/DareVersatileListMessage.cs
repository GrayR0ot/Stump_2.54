using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareVersatileListMessage : Message
    {
        public const uint Id = 6657;

        public DareVersatileListMessage(DareVersatileInformations[] dares)
        {
            Dares = dares;
        }

        public DareVersatileListMessage()
        {
        }

        public override uint MessageId => Id;

        public DareVersatileInformations[] Dares { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Dares.Count());
            for (var daresIndex = 0; daresIndex < Dares.Count(); daresIndex++)
            {
                var objectToSend = Dares[daresIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var daresCount = reader.ReadUShort();
            Dares = new DareVersatileInformations[daresCount];
            for (var daresIndex = 0; daresIndex < daresCount; daresIndex++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                Dares[daresIndex] = objectToAdd;
            }
        }
    }
}