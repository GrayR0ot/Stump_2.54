using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HavenBagPackListMessage : Message
    {
        public const uint Id = 6620;

        public HavenBagPackListMessage(sbyte[] packIds)
        {
            PackIds = packIds;
        }

        public HavenBagPackListMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte[] PackIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PackIds.Count());
            for (var packIdsIndex = 0; packIdsIndex < PackIds.Count(); packIdsIndex++)
                writer.WriteSByte(PackIds[packIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var packIdsCount = reader.ReadUShort();
            PackIds = new sbyte[packIdsCount];
            for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++)
                PackIds[packIdsIndex] = reader.ReadSByte();
        }
    }
}