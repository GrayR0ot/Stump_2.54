using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdolFightPreparationUpdateMessage : Message
    {
        public const uint Id = 6586;

        public IdolFightPreparationUpdateMessage(sbyte idolSource, Idol[] idols)
        {
            IdolSource = idolSource;
            Idols = idols;
        }

        public IdolFightPreparationUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte IdolSource { get; set; }
        public Idol[] Idols { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(IdolSource);
            writer.WriteShort((short) Idols.Count());
            for (var idolsIndex = 0; idolsIndex < Idols.Count(); idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolSource = reader.ReadSByte();
            var idolsCount = reader.ReadUShort();
            Idols = new Idol[idolsCount];
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<Idol>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Idols[idolsIndex] = objectToAdd;
            }
        }
    }
}