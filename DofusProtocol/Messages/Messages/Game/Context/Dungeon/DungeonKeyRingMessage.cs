using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonKeyRingMessage : Message
    {
        public const uint Id = 6299;

        public DungeonKeyRingMessage(ushort[] availables, ushort[] unavailables)
        {
            Availables = availables;
            Unavailables = unavailables;
        }

        public DungeonKeyRingMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] Availables { get; set; }
        public ushort[] Unavailables { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Availables.Count());
            for (var availablesIndex = 0; availablesIndex < Availables.Count(); availablesIndex++)
                writer.WriteVarUShort(Availables[availablesIndex]);
            writer.WriteShort((short) Unavailables.Count());
            for (var unavailablesIndex = 0; unavailablesIndex < Unavailables.Count(); unavailablesIndex++)
                writer.WriteVarUShort(Unavailables[unavailablesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var availablesCount = reader.ReadUShort();
            Availables = new ushort[availablesCount];
            for (var availablesIndex = 0; availablesIndex < availablesCount; availablesIndex++)
                Availables[availablesIndex] = reader.ReadVarUShort();
            var unavailablesCount = reader.ReadUShort();
            Unavailables = new ushort[unavailablesCount];
            for (var unavailablesIndex = 0; unavailablesIndex < unavailablesCount; unavailablesIndex++)
                Unavailables[unavailablesIndex] = reader.ReadVarUShort();
        }
    }
}