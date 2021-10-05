using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareListMessage : Message
    {
        public const uint Id = 6661;

        public DareListMessage(DareInformations[] dares)
        {
            Dares = dares;
        }

        public DareListMessage()
        {
        }

        public override uint MessageId => Id;

        public DareInformations[] Dares { get; set; }

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
            Dares = new DareInformations[daresCount];
            for (var daresIndex = 0; daresIndex < daresCount; daresIndex++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                Dares[daresIndex] = objectToAdd;
            }
        }
    }
}