using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LeaveDialogMessage : Message
    {
        public const uint Id = 5502;

        public LeaveDialogMessage(sbyte dialogType)
        {
            DialogType = dialogType;
        }

        public LeaveDialogMessage()
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