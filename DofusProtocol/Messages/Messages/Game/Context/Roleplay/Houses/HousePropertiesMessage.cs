using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HousePropertiesMessage : Message
    {
        public const uint Id = 5734;

        public HousePropertiesMessage(uint houseId, int[] doorsOnMap, HouseInstanceInformations properties)
        {
            HouseId = houseId;
            DoorsOnMap = doorsOnMap;
            Properties = properties;
        }

        public HousePropertiesMessage()
        {
        }

        public override uint MessageId => Id;

        public uint HouseId { get; set; }
        public int[] DoorsOnMap { get; set; }
        public HouseInstanceInformations Properties { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(HouseId);
            writer.WriteShort((short) DoorsOnMap.Count());
            for (var doorsOnMapIndex = 0; doorsOnMapIndex < DoorsOnMap.Count(); doorsOnMapIndex++)
                writer.WriteInt(DoorsOnMap[doorsOnMapIndex]);
            writer.WriteShort(Properties.TypeId);
            Properties.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUInt();
            var doorsOnMapCount = reader.ReadUShort();
            DoorsOnMap = new int[doorsOnMapCount];
            for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
                DoorsOnMap[doorsOnMapIndex] = reader.ReadInt();
            Properties = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
            Properties.Deserialize(reader);
        }
    }
}