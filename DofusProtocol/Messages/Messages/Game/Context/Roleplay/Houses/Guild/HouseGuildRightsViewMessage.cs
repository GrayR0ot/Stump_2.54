﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseGuildRightsViewMessage : Message
    {
        public const uint Id = 5700;

        public HouseGuildRightsViewMessage(uint houseId, int instanceId)
        {
            HouseId = houseId;
            InstanceId = instanceId;
        }

        public HouseGuildRightsViewMessage()
        {
        }

        public override uint MessageId => Id;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(HouseId);
            writer.WriteInt(InstanceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUInt();
            InstanceId = reader.ReadInt();
        }
    }
}