using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PortalDialogCreationMessage : NpcDialogCreationMessage
    {
        public new const uint Id = 6737;

        public PortalDialogCreationMessage(double mapId, int npcId, int type)
        {
            MapId = mapId;
            NpcId = npcId;
            Type = type;
        }

        public PortalDialogCreationMessage()
        {
        }

        public override uint MessageId => Id;

        public int Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Type = reader.ReadInt();
        }
    }
}