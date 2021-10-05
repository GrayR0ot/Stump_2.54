﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AdminQuietCommandMessage : AdminCommandMessage
    {
        public new const uint Id = 5662;

        public AdminQuietCommandMessage(string content)
        {
            Content = content;
        }

        public AdminQuietCommandMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}