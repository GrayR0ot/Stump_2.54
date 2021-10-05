using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildPaddockBoughtMessage : Message
    {
        public const uint Id = 5952;

        public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
        {
            PaddockInfo = paddockInfo;
        }

        public GuildPaddockBoughtMessage()
        {
        }

        public override uint MessageId => Id;

        public PaddockContentInformations PaddockInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PaddockInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockInfo = new PaddockContentInformations();
            PaddockInfo.Deserialize(reader);
        }
    }
}