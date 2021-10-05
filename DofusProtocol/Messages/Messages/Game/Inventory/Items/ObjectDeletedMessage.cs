﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectDeletedMessage : Message
    {
        public const uint Id = 3024;

        public ObjectDeletedMessage(uint objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectDeletedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUInt();
        }
    }
}