﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildMemberWarnOnConnectionStateMessage : Message
    {
        public const uint Id = 6160;

        public GuildMemberWarnOnConnectionStateMessage(bool enable)
        {
            Enable = enable;
        }

        public GuildMemberWarnOnConnectionStateMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}