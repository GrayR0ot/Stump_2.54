using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapRunningFightListMessage : Message
    {
        public const uint Id = 5743;

        public MapRunningFightListMessage(FightExternalInformations[] fights)
        {
            Fights = fights;
        }

        public MapRunningFightListMessage()
        {
        }

        public override uint MessageId => Id;

        public FightExternalInformations[] Fights { get; set; }

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
            Fights = new FightExternalInformations[fightsCount];
            for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
            {
                var objectToAdd = new FightExternalInformations();
                objectToAdd.Deserialize(reader);
                Fights[fightsIndex] = objectToAdd;
            }
        }
    }
}