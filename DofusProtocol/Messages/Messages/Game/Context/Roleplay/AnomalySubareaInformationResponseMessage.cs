using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AnomalySubareaInformationResponseMessage : Message
    {
        public const uint Id = 6836;

        public AnomalySubareaInformationResponseMessage(AnomalySubareaInformation[] subareas)
        {
            Subareas = subareas;
        }

        public AnomalySubareaInformationResponseMessage()
        {
        }

        public override uint MessageId => Id;

        public AnomalySubareaInformation[] Subareas { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Subareas.Count());
            for (var subareasIndex = 0; subareasIndex < Subareas.Count(); subareasIndex++)
            {
                var objectToSend = Subareas[subareasIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var subareasCount = reader.ReadUShort();
            Subareas = new AnomalySubareaInformation[subareasCount];
            for (var subareasIndex = 0; subareasIndex < subareasCount; subareasIndex++)
            {
                var objectToAdd = new AnomalySubareaInformation();
                objectToAdd.Deserialize(reader);
                Subareas[subareasIndex] = objectToAdd;
            }
        }
    }
}