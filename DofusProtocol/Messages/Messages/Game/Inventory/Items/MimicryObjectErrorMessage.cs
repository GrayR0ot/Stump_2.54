﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const uint Id = 6461;

        public MimicryObjectErrorMessage(sbyte reason, sbyte errorCode, bool preview)
        {
            Reason = reason;
            ErrorCode = errorCode;
            Preview = preview;
        }

        public MimicryObjectErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Preview { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Preview = reader.ReadBoolean();
        }
    }
}