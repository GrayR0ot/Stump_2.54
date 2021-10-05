using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildInformationsMembersMessage : Message
    {
        public const uint Id = 5558;

        public GuildInformationsMembersMessage(GuildMember[] members)
        {
            Members = members;
        }

        public GuildInformationsMembersMessage()
        {
        }

        public override uint MessageId => Id;

        public GuildMember[] Members { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Members.Count());
            for (var membersIndex = 0; membersIndex < Members.Count(); membersIndex++)
            {
                var objectToSend = Members[membersIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var membersCount = reader.ReadUShort();
            Members = new GuildMember[membersCount];
            for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
            {
                var objectToAdd = new GuildMember();
                objectToAdd.Deserialize(reader);
                Members[membersIndex] = objectToAdd;
            }
        }
    }
}