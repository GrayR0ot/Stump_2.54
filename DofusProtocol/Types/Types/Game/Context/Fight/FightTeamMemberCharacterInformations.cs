﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
    {
        public new const short Id = 13;

        public FightTeamMemberCharacterInformations(double objectId, string name, ushort level)
        {
            ObjectId = objectId;
            Name = name;
            Level = level;
        }

        public FightTeamMemberCharacterInformations()
        {
        }

        public override short TypeId => Id;

        public string Name { get; set; }
        public ushort Level { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarUShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Level = reader.ReadVarUShort();
        }
    }
}