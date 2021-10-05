using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TrustStatusMessage : Message
    {
        public const uint Id = 6267;

        public TrustStatusMessage(bool trusted, bool certified)
        {
            Trusted = trusted;
            Certified = certified;
        }

        public TrustStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Trusted { get; set; }
        public bool Certified { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, Trusted);
            flag = BooleanByteWrapper.SetFlag(flag, 1, Certified);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Trusted = BooleanByteWrapper.GetFlag(flag, 0);
            Certified = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}