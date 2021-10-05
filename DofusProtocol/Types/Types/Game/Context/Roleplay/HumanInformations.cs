using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class HumanInformations
    {
        public const short Id = 157;

        public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, HumanOption[] options)
        {
            Restrictions = restrictions;
            Sex = sex;
            Options = options;
        }

        public HumanInformations()
        {
        }

        public virtual short TypeId => Id;

        public ActorRestrictionsInformations Restrictions { get; set; }
        public bool Sex { get; set; }
        public HumanOption[] Options { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            Restrictions.Serialize(writer);
            writer.WriteBoolean(Sex);
            writer.WriteShort((short) Options.Count());
            for (var optionsIndex = 0; optionsIndex < Options.Count(); optionsIndex++)
            {
                var objectToSend = Options[optionsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
            Sex = reader.ReadBoolean();
            var optionsCount = reader.ReadUShort();
            Options = new HumanOption[optionsCount];
            for (var optionsIndex = 0; optionsIndex < optionsCount; optionsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Options[optionsIndex] = objectToAdd;
            }
        }
    }
}