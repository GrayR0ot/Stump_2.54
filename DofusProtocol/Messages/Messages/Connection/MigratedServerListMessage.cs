using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MigratedServerListMessage : Message
    {
        public const uint Id = 6731;

        public MigratedServerListMessage(ushort[] migratedServerIds)
        {
            MigratedServerIds = migratedServerIds;
        }

        public MigratedServerListMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] MigratedServerIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MigratedServerIds.Count());
            for (var migratedServerIdsIndex = 0;
                migratedServerIdsIndex < MigratedServerIds.Count();
                migratedServerIdsIndex++) writer.WriteVarUShort(MigratedServerIds[migratedServerIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var migratedServerIdsCount = reader.ReadUShort();
            MigratedServerIds = new ushort[migratedServerIdsCount];
            for (var migratedServerIdsIndex = 0;
                migratedServerIdsIndex < migratedServerIdsCount;
                migratedServerIdsIndex++) MigratedServerIds[migratedServerIdsIndex] = reader.ReadVarUShort();
        }
    }
}