using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class QuestStepInfoMessage : Message
    {
        public const uint Id = 5625;

        public QuestStepInfoMessage(QuestActiveInformations infos)
        {
            Infos = infos;
        }

        public QuestStepInfoMessage()
        {
        }

        public override uint MessageId => Id;

        public QuestActiveInformations Infos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Infos.TypeId);
            Infos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
            Infos.Deserialize(reader);
        }
    }
}