﻿using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceJoinedMessage : Message
    {
        public const uint Id = 6402;

        public AllianceJoinedMessage(AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
        {
            AllianceInfo = allianceInfo;
            Enabled = enabled;
            LeadingGuildId = leadingGuildId;
        }

        public AllianceJoinedMessage()
        {
        }

        public override uint MessageId => Id;

        public AllianceInformations AllianceInfo { get; set; }
        public bool Enabled { get; set; }
        public uint LeadingGuildId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            AllianceInfo.Serialize(writer);
            writer.WriteBoolean(Enabled);
            writer.WriteVarUInt(LeadingGuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceInfo = new AllianceInformations();
            AllianceInfo.Deserialize(reader);
            Enabled = reader.ReadBoolean();
            LeadingGuildId = reader.ReadVarUInt();
        }
    }
}