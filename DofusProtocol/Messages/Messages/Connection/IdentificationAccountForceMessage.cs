using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;
using Version = Stump.DofusProtocol.Types.Version;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdentificationAccountForceMessage : IdentificationMessage
    {
        public new const uint Id = 6119;

        public IdentificationAccountForceMessage(bool autoconnect, bool useCertificate, bool useLoginToken,
            Version version, string lang, sbyte[] credentials, short serverId, long sessionOptionalSalt,
            ushort[] failedAttempts, string forcedAccountLogin)
        {
            autoconnect = autoconnect;
            useCertificate = useCertificate;
            useLoginToken = useLoginToken;
            version = version;
            lang = lang;
            credentials = credentials;
            serverId = serverId;
            sessionOptionalSalt = sessionOptionalSalt;
            failedAttempts = failedAttempts;
            ForcedAccountLogin = forcedAccountLogin;
        }

        public IdentificationAccountForceMessage()
        {
        }

        public override uint MessageId => Id;

        public string ForcedAccountLogin { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(ForcedAccountLogin);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ForcedAccountLogin = reader.ReadUTF();
        }
    }
}