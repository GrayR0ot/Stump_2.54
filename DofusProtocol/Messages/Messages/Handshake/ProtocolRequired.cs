﻿
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ProtocolRequired : Message
    {
        public const uint Id = 1;

        public override uint MessageId
        {
            get { return Id; }
        }

        public int requiredVersion;
        public int currentVersion;


        public ProtocolRequired()
        {
        }

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;
        }


        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(requiredVersion);
            writer.WriteInt(currentVersion);
        }

        public override void Deserialize(IDataReader reader)
        {
            requiredVersion = reader.ReadInt();
            currentVersion = reader.ReadInt();
        }
    }
}