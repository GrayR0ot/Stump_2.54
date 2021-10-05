﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeOnHumanVendorRequestMessage : Message
    {
        public const uint Id = 5772;

        public ExchangeOnHumanVendorRequestMessage(ulong humanVendorId, ushort humanVendorCell)
        {
            HumanVendorId = humanVendorId;
            HumanVendorCell = humanVendorCell;
        }

        public ExchangeOnHumanVendorRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong HumanVendorId { get; set; }
        public ushort HumanVendorCell { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(HumanVendorId);
            writer.WriteVarUShort(HumanVendorCell);
        }

        public override void Deserialize(IDataReader reader)
        {
            HumanVendorId = reader.ReadVarULong();
            HumanVendorCell = reader.ReadVarUShort();
        }
    }
}