using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PauseDialogMessage : Message
    {
        public const uint Id = 6012;

        public PauseDialogMessage(sbyte dialogType)
        {
            DialogType = dialogType;
        }

        public PauseDialogMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte DialogType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(DialogType);
        }

        public override void Deserialize(IDataReader reader)
        {
            DialogType = reader.ReadSByte();
        }
    }
}