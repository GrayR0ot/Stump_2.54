﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class RawDataMessage : Message
    {
        public const uint Id = 6253;

        public RawDataMessage()
        {
        }

        public RawDataMessage(byte[] content)
        {
            Content = content;
        }

        public override uint MessageId => Id;
        public byte[] Content { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var contentLength = Content.Length;
            writer.WriteVarInt(contentLength);
            for (var i = 0; i < contentLength; i++)
                writer.WriteByte(Content[i]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var contentLength = reader.ReadVarInt();
            reader.ReadBytes(contentLength);
        }
    }
}