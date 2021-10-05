using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PrismsInfoValidMessage : Message
    {
        public const uint Id = 6451;

        public PrismsInfoValidMessage(PrismFightersInformation[] fights)
        {
            Fights = fights;
        }

        public PrismsInfoValidMessage()
        {
        }

        public override uint MessageId => Id;

        public PrismFightersInformation[] Fights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Fights.Count());
            for (var fightsIndex = 0; fightsIndex < Fights.Count(); fightsIndex++)
            {
                var objectToSend = Fights[fightsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var fightsCount = reader.ReadUShort();
            Fights = new PrismFightersInformation[fightsCount];
            for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
            {
                var objectToAdd = new PrismFightersInformation();
                objectToAdd.Deserialize(reader);
                Fights[fightsIndex] = objectToAdd;
            }
        }
    }
}