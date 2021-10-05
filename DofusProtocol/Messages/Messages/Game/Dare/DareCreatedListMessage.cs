using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareCreatedListMessage : Message
    {
        public const uint Id = 6663;

        public DareCreatedListMessage(DareInformations[] daresFixedInfos,
            DareVersatileInformations[] daresVersatilesInfos)
        {
            DaresFixedInfos = daresFixedInfos;
            DaresVersatilesInfos = daresVersatilesInfos;
        }

        public DareCreatedListMessage()
        {
        }

        public override uint MessageId => Id;

        public DareInformations[] DaresFixedInfos { get; set; }
        public DareVersatileInformations[] DaresVersatilesInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) DaresFixedInfos.Count());
            for (var daresFixedInfosIndex = 0; daresFixedInfosIndex < DaresFixedInfos.Count(); daresFixedInfosIndex++)
            {
                var objectToSend = DaresFixedInfos[daresFixedInfosIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) DaresVersatilesInfos.Count());
            for (var daresVersatilesInfosIndex = 0;
                daresVersatilesInfosIndex < DaresVersatilesInfos.Count();
                daresVersatilesInfosIndex++)
            {
                var objectToSend = DaresVersatilesInfos[daresVersatilesInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var daresFixedInfosCount = reader.ReadUShort();
            DaresFixedInfos = new DareInformations[daresFixedInfosCount];
            for (var daresFixedInfosIndex = 0; daresFixedInfosIndex < daresFixedInfosCount; daresFixedInfosIndex++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                DaresFixedInfos[daresFixedInfosIndex] = objectToAdd;
            }

            var daresVersatilesInfosCount = reader.ReadUShort();
            DaresVersatilesInfos = new DareVersatileInformations[daresVersatilesInfosCount];
            for (var daresVersatilesInfosIndex = 0;
                daresVersatilesInfosIndex < daresVersatilesInfosCount;
                daresVersatilesInfosIndex++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                DaresVersatilesInfos[daresVersatilesInfosIndex] = objectToAdd;
            }
        }
    }
}