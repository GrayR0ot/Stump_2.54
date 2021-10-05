using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismUseRequestMessage : Message
    {
        public const uint Id = 6041;

        public PrismUseRequestMessage(sbyte moduleToUse)
        {
            ModuleToUse = moduleToUse;
        }

        public PrismUseRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ModuleToUse { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ModuleToUse);
        }

        public override void Deserialize(IDataReader reader)
        {
            ModuleToUse = reader.ReadSByte();
        }
    }
}