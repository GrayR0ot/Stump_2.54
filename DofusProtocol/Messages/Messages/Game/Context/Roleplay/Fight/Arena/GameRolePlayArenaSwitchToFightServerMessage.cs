using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayArenaSwitchToFightServerMessage : Message
    {
        public const uint Id = 6575;

        public GameRolePlayArenaSwitchToFightServerMessage(string address, ushort[] ports, sbyte[] ticket)
        {
            Address = address;
            Ports = ports;
            Ticket = ticket;
        }

        public GameRolePlayArenaSwitchToFightServerMessage()
        {
        }

        public override uint MessageId => Id;

        public string Address { get; set; }
        public ushort[] Ports { get; set; }
        public sbyte[] Ticket { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Address);
            writer.WriteShort((short) Ports.Count());
            for (var portsIndex = 0; portsIndex < Ports.Count(); portsIndex++) writer.WriteUShort(Ports[portsIndex]);
            writer.WriteVarInt(Ticket.Count());
            for (var ticketIndex = 0; ticketIndex < Ticket.Count(); ticketIndex++)
                writer.WriteSByte(Ticket[ticketIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Address = reader.ReadUTF();
            var portsCount = reader.ReadUShort();
            Ports = new ushort[portsCount];
            for (var portsIndex = 0; portsIndex < portsCount; portsIndex++) Ports[portsIndex] = reader.ReadUShort();
            var ticketCount = reader.ReadVarInt();
            Ticket = new sbyte[ticketCount];
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
                Ticket[ticketIndex] = reader.ReadSByte();
        }
    }
}