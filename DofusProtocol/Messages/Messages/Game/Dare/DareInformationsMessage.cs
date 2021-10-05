using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareInformationsMessage : Message
    {
        public const uint Id = 6656;

        public DareInformationsMessage(DareInformations dareFixedInfos, DareVersatileInformations dareVersatilesInfos)
        {
            DareFixedInfos = dareFixedInfos;
            DareVersatilesInfos = dareVersatilesInfos;
        }

        public DareInformationsMessage()
        {
        }

        public override uint MessageId => Id;

        public DareInformations DareFixedInfos { get; set; }
        public DareVersatileInformations DareVersatilesInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            DareFixedInfos.Serialize(writer);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareFixedInfos = new DareInformations();
            DareFixedInfos.Deserialize(reader);
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}