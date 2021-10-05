using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceInvitedMessage : Message
    {
        public const uint Id = 6397;

        public AllianceInvitedMessage(ulong recruterId, string recruterName,
            BasicNamedAllianceInformations allianceInfo)
        {
            RecruterId = recruterId;
            RecruterName = recruterName;
            AllianceInfo = allianceInfo;
        }

        public AllianceInvitedMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong RecruterId { get; set; }
        public string RecruterName { get; set; }
        public BasicNamedAllianceInformations AllianceInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(RecruterId);
            writer.WriteUTF(RecruterName);
            AllianceInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RecruterId = reader.ReadVarULong();
            RecruterName = reader.ReadUTF();
            AllianceInfo = new BasicNamedAllianceInformations();
            AllianceInfo.Deserialize(reader);
        }
    }
}