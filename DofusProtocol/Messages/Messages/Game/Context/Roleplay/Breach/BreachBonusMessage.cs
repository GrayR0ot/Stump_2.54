using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachBonusMessage : Message
    {
        public const uint Id = 6800;

        public BreachBonusMessage(ObjectEffectInteger bonus)
        {
            Bonus = bonus;
        }

        public BreachBonusMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectEffectInteger Bonus { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Bonus.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bonus = new ObjectEffectInteger();
            Bonus.Deserialize(reader);
        }
    }
}