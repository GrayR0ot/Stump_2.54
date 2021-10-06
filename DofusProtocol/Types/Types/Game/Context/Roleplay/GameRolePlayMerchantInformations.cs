using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
    {
        public new const short Id = 129;

        public GameRolePlayMerchantInformations(double contextualId, 
            EntityDispositionInformations disposition, EntityLook look, string name, sbyte sellType, HumanOption[] options)
        {
            ContextualId = contextualId;
            Disposition = disposition;
            Look = look;
            Name = name;
            SellType = sellType;
            Options = options;
        }

        public GameRolePlayMerchantInformations()
        {
        }

        public override short TypeId => Id;

        public sbyte SellType { get; set; }
        public HumanOption[] Options { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(SellType);
            writer.WriteShort((short) Options.Count());
            for (var optionsIndex = 0; optionsIndex < Options.Count(); optionsIndex++)
            {
                var objectToSend = Options[optionsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SellType = reader.ReadSByte();
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