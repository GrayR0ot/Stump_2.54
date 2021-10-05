﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FriendAddRequestMessage : Message
    {
        public const uint Id = 4004;

        public FriendAddRequestMessage(string name)
        {
            Name = name;
        }

        public FriendAddRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }
    }
}