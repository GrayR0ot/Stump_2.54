using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInformationsPaddocksMessage : Message
    {
        public const uint Id = 5959;

        public GuildInformationsPaddocksMessage(sbyte nbPaddockMax, PaddockContentInformations[] paddocksInformations)
        {
            NbPaddockMax = nbPaddockMax;
            PaddocksInformations = paddocksInformations;
        }

        public GuildInformationsPaddocksMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte NbPaddockMax { get; set; }
        public PaddockContentInformations[] PaddocksInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(NbPaddockMax);
            writer.WriteShort((short) PaddocksInformations.Count());
            for (var paddocksInformationsIndex = 0;
                paddocksInformationsIndex < PaddocksInformations.Count();
                paddocksInformationsIndex++)
            {
                var objectToSend = PaddocksInformations[paddocksInformationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            NbPaddockMax = reader.ReadSByte();
            var paddocksInformationsCount = reader.ReadUShort();
            PaddocksInformations = new PaddockContentInformations[paddocksInformationsCount];
            for (var paddocksInformationsIndex = 0;
                paddocksInformationsIndex < paddocksInformationsCount;
                paddocksInformationsIndex++)
            {
                var objectToAdd = new PaddockContentInformations();
                objectToAdd.Deserialize(reader);
                PaddocksInformations[paddocksInformationsIndex] = objectToAdd;
            }
        }
    }
}