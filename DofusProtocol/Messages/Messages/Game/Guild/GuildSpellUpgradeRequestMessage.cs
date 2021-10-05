﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildSpellUpgradeRequestMessage : Message
    {
        public const uint Id = 5699;

        public GuildSpellUpgradeRequestMessage(int spellId)
        {
            SpellId = spellId;
        }

        public GuildSpellUpgradeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public int SpellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
        }
    }
}