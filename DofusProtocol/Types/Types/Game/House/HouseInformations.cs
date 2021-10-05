﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class HouseInformations
    {
        public const short Id = 111;

        public HouseInformations(uint houseId, ushort modelId)
        {
            HouseId = houseId;
            ModelId = modelId;
        }

        public HouseInformations()
        {
        }

        public virtual short TypeId => Id;

        public uint HouseId { get; set; }
        public ushort ModelId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(HouseId);
            writer.WriteVarUShort(ModelId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUInt();
            ModelId = reader.ReadVarUShort();
        }
    }
}