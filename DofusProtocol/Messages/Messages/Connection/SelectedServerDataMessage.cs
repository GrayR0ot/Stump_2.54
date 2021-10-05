using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SelectedServerDataMessage : Message
    {
        public const uint Id = 42;

        public SelectedServerDataMessage(ushort serverId, string address, int[] ports, bool canCreateNewCharacter,
            sbyte[] ticket)
        {
            ServerId = serverId;
            Address = address;
            Ports = ports;
            CanCreateNewCharacter = canCreateNewCharacter;
            Ticket = ticket;
        }

        public SelectedServerDataMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ServerId { get; set; }
        public string Address { get; set; }
        public int[] Ports { get; set; }
        public bool CanCreateNewCharacter { get; set; }
        public sbyte[] Ticket { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ServerId);
            writer.WriteUTF(Address);
            writer.WriteShort((short) Ports.Count());
            for (var portsIndex = 0; portsIndex < Ports.Count(); portsIndex++) writer.WriteInt(Ports[portsIndex]);
            writer.WriteBoolean(CanCreateNewCharacter);
            writer.WriteVarInt(Ticket.Count());
            for (var ticketIndex = 0; ticketIndex < Ticket.Count(); ticketIndex++)
                writer.WriteSByte(Ticket[ticketIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUShort();
            Address = reader.ReadUTF();
            var portsCount = reader.ReadUShort();
            Ports = new int[portsCount];
            for (var portsIndex = 0; portsIndex < portsCount; portsIndex++) Ports[portsIndex] = reader.ReadInt();
            CanCreateNewCharacter = reader.ReadBoolean();
            var ticketCount = reader.ReadVarInt();
            Ticket = new sbyte[ticketCount];
            for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
                Ticket[ticketIndex] = reader.ReadSByte();
        }
    }
}