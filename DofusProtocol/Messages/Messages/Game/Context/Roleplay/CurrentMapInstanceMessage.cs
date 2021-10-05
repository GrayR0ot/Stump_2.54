using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CurrentMapInstanceMessage : CurrentMapMessage
    {
        public new const uint Id = 6738;

        public CurrentMapInstanceMessage(double mapId, string mapKey, double instantiatedMapId)
        {
            MapId = mapId;
            MapKey = mapKey;
            InstantiatedMapId = instantiatedMapId;
        }

        public CurrentMapInstanceMessage()
        {
        }

        public override uint MessageId => Id;

        public double InstantiatedMapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(InstantiatedMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            InstantiatedMapId = reader.ReadDouble();
        }
    }
}