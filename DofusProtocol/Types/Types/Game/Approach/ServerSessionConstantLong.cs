﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ServerSessionConstantLong : ServerSessionConstant
    {
        public new const short Id = 429;

        public ServerSessionConstantLong(ushort objectId, double value)
        {
            ObjectId = objectId;
            Value = value;
        }

        public ServerSessionConstantLong()
        {
        }

        public override short TypeId => Id;

        public double Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadDouble();
        }
    }
}