using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AcquaintanceInformation : AbstractContactInformations
    {
        public new const short Id = 561;

        public AcquaintanceInformation(int accountId, string accountName, sbyte playerState)
        {
            AccountId = accountId;
            AccountName = accountName;
            PlayerState = playerState;
        }

        public AcquaintanceInformation()
        {
        }

        public override short TypeId => Id;

        public sbyte PlayerState { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PlayerState);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerState = reader.ReadSByte();
        }
    }
}