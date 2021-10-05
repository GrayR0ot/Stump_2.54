using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareCreatedMessage : Message
    {
        public const uint Id = 6668;

        public DareCreatedMessage(DareInformations dareInfos, bool needNotifications)
        {
            DareInfos = dareInfos;
            NeedNotifications = needNotifications;
        }

        public DareCreatedMessage()
        {
        }

        public override uint MessageId => Id;

        public DareInformations DareInfos { get; set; }
        public bool NeedNotifications { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            DareInfos.Serialize(writer);
            writer.WriteBoolean(NeedNotifications);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareInfos = new DareInformations();
            DareInfos.Deserialize(reader);
            NeedNotifications = reader.ReadBoolean();
        }
    }
}