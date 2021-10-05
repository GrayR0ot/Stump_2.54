﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObtainedItemWithBonusMessage : ObtainedItemMessage
    {
        public new const uint Id = 6520;

        public ObtainedItemWithBonusMessage(ushort genericId, uint baseQuantity, uint bonusQuantity)
        {
            GenericId = genericId;
            BaseQuantity = baseQuantity;
            BonusQuantity = bonusQuantity;
        }

        public ObtainedItemWithBonusMessage()
        {
        }

        public override uint MessageId => Id;

        public uint BonusQuantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(BonusQuantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BonusQuantity = reader.ReadVarUInt();
        }
    }
}