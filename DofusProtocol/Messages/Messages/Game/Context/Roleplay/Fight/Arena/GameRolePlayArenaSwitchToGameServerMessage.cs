using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayArenaSwitchToGameServerMessage : Message
    {
        public const uint Id = 6574;

        public GameRolePlayArenaSwitchToGameServerMessage(bool validToken, sbyte[] ticket, short homeServerId)
        {
            ValidToken = validToken;
            Ticket = ticket;
            HomeServerId = homeServerId;
        }

        public GameRolePlayArenaSwitchToGameServerMessage()
        {
        }

        public override uint MessageId => Id;

        public bool ValidToken { get; set; }
        public sbyte[] Ticket { get; set; }
        public short HomeServerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(ValidToken);
            writer.WriteVarInt(Ticket.Count());
            for (var ticketIndex = 0; ticketIndex < Ticket.Count(); ticketIndex++)
                writer.WriteSByte(Ticket[ticketIndex]);
            writer.WriteShort(HomeServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ValidToken = reader.ReadBoolean();
            var ticketCount = reader.ReadVarInt();
            Ticket = new sbyte[ticketCount];
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
                Ticket[ticketIndex] = reader.ReadSByte();
            HomeServerId = reader.ReadShort();
        }
    }
}