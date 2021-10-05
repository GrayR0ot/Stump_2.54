using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SetUpdateMessage : Message
    {
        public const uint Id = 5503;

        public SetUpdateMessage(ushort setId, ushort[] setObjects, ObjectEffect[] setEffects)
        {
            SetId = setId;
            SetObjects = setObjects;
            SetEffects = setEffects;
        }

        public SetUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort SetId { get; set; }
        public ushort[] SetObjects { get; set; }
        public ObjectEffect[] SetEffects { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(SetId);
            writer.WriteShort((short) SetObjects.Count());
            for (var setObjectsIndex = 0; setObjectsIndex < SetObjects.Count(); setObjectsIndex++)
                writer.WriteVarUShort(SetObjects[setObjectsIndex]);
            writer.WriteShort((short) SetEffects.Count());
            for (var setEffectsIndex = 0; setEffectsIndex < SetEffects.Count(); setEffectsIndex++)
            {
                var objectToSend = SetEffects[setEffectsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SetId = reader.ReadVarUShort();
            var setObjectsCount = reader.ReadUShort();
            SetObjects = new ushort[setObjectsCount];
            for (var setObjectsIndex = 0; setObjectsIndex < setObjectsCount; setObjectsIndex++)
                SetObjects[setObjectsIndex] = reader.ReadVarUShort();
            var setEffectsCount = reader.ReadUShort();
            SetEffects = new ObjectEffect[setEffectsCount];
            for (var setEffectsIndex = 0; setEffectsIndex < setEffectsCount; setEffectsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                SetEffects[setEffectsIndex] = objectToAdd;
            }
        }
    }
}