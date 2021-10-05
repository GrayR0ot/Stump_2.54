﻿using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeObjectModifiedMessage : ExchangeObjectMessage
    {
        public new const uint Id = 5519;

        public ExchangeObjectModifiedMessage(bool remote, ObjectItem @object)
        {
            Remote = remote;
            this.@object = @object;
        }

        public ExchangeObjectModifiedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem @object { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            @object.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            @object = new ObjectItem();
            @object.Deserialize(reader);
        }
    }
}