using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ServerOptionalFeaturesMessage : Message
    {
        public const uint Id = 6305;

        public ServerOptionalFeaturesMessage(sbyte[] features)
        {
            Features = features;
        }

        public ServerOptionalFeaturesMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte[] Features { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Features.Count());
            for (var featuresIndex = 0; featuresIndex < Features.Count(); featuresIndex++)
                writer.WriteSByte(Features[featuresIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var featuresCount = reader.ReadUShort();
            Features = new sbyte[featuresCount];
            for (var featuresIndex = 0; featuresIndex < featuresCount; featuresIndex++)
                Features[featuresIndex] = reader.ReadSByte();
        }
    }
}