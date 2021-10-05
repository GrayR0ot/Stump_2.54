﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FocusedExchangeReadyMessage : ExchangeReadyMessage
    {
        public new const uint Id = 6701;

        public FocusedExchangeReadyMessage(bool ready, ushort step, uint focusActionId)
        {
            Ready = ready;
            Step = step;
            FocusActionId = focusActionId;
        }

        public FocusedExchangeReadyMessage()
        {
        }

        public override uint MessageId => Id;

        public uint FocusActionId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(FocusActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FocusActionId = reader.ReadVarUInt();
        }
    }
}