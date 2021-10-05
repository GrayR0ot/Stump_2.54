﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountReleaseRequestMessage : Message
    {
        public const uint Id = 5980;

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}