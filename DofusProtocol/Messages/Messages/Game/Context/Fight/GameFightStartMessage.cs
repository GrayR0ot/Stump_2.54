using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightStartMessage : Message
    {
        public const uint Id = 712;

        public GameFightStartMessage(Idol[] idols)
        {
            Idols = idols;
        }

        public GameFightStartMessage()
        {
        }

        public override uint MessageId => Id;

        public Idol[] Idols { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Idols.Count());
            for (var idolsIndex = 0; idolsIndex < Idols.Count(); idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var idolsCount = reader.ReadUShort();
            Idols = new Idol[idolsCount];
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = new Idol();
                objectToAdd.Deserialize(reader);
                Idols[idolsIndex] = objectToAdd;
            }
        }
    }
}