﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class TrustCertificate
    {
        public const short Id = 377;

        public TrustCertificate(int objectId, string hash)
        {
            ObjectId = objectId;
            Hash = hash;
        }

        public TrustCertificate()
        {
        }

        public virtual short TypeId => Id;

        public int ObjectId { get; set; }
        public string Hash { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ObjectId);
            writer.WriteUTF(Hash);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadInt();
            Hash = reader.ReadUTF();
        }
    }
}