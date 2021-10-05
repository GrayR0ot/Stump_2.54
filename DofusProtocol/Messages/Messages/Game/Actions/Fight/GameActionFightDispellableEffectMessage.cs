using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public new const uint Id = 6070;

        public GameActionFightDispellableEffectMessage(ushort actionId, double sourceId,
            AbstractFightDispellableEffect effect)
        {
            ActionId = actionId;
            SourceId = sourceId;
            Effect = effect;
        }

        public GameActionFightDispellableEffectMessage()
        {
        }

        public override uint MessageId => Id;

        public AbstractFightDispellableEffect Effect { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Effect.TypeId);
            Effect.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadShort());
            Effect.Deserialize(reader);
        }
    }
}