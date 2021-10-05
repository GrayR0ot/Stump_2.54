using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountHarnessColorsUpdateRequestMessage : Message
    {
        public const uint Id = 6697;

        public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
        {
            UseHarnessColors = useHarnessColors;
        }

        public MountHarnessColorsUpdateRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public bool UseHarnessColors { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(UseHarnessColors);
        }

        public override void Deserialize(IDataReader reader)
        {
            UseHarnessColors = reader.ReadBoolean();
        }
    }
}