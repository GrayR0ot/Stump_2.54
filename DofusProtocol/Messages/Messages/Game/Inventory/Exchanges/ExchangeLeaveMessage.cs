using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeLeaveMessage : LeaveDialogMessage
    {
        public new const uint Id = 5628;

        public ExchangeLeaveMessage(sbyte dialogType, bool success)
        {
            DialogType = dialogType;
            Success = success;
        }

        public ExchangeLeaveMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Success { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Success = reader.ReadBoolean();
        }
    }
}