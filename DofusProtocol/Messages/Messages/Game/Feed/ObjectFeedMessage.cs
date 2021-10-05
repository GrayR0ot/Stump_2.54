using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectFeedMessage : Message
    {
        public const uint Id = 6290;

        public ObjectFeedMessage(uint objectUID, ObjectItemQuantity[] meal)
        {
            ObjectUID = objectUID;
            Meal = meal;
        }

        public ObjectFeedMessage()
        {
        }

        public override uint MessageId => Id;

        public uint ObjectUID { get; set; }
        public ObjectItemQuantity[] Meal { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectUID);
            writer.WriteShort((short) Meal.Count());
            for (var mealIndex = 0; mealIndex < Meal.Count(); mealIndex++)
            {
                var objectToSend = Meal[mealIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUInt();
            var mealCount = reader.ReadUShort();
            Meal = new ObjectItemQuantity[mealCount];
            for (var mealIndex = 0; mealIndex < mealCount; mealIndex++)
            {
                var objectToAdd = new ObjectItemQuantity();
                objectToAdd.Deserialize(reader);
                Meal[mealIndex] = objectToAdd;
            }
        }
    }
}