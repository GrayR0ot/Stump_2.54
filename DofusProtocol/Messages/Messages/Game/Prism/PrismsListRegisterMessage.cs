using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismsListRegisterMessage : Message
    {
        public const uint Id = 6441;

        public PrismsListRegisterMessage(sbyte listen)
        {
            Listen = listen;
        }

        public PrismsListRegisterMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Listen { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Listen);
        }

        public override void Deserialize(IDataReader reader)
        {
            Listen = reader.ReadSByte();
        }
    }
}