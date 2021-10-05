using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PartyIdol : Idol
    {
        public new const short Id = 490;

        public PartyIdol(ushort objectId, ushort xpBonusPercent, ushort dropBonusPercent, ulong[] ownersIds)
        {
            ObjectId = objectId;
            XpBonusPercent = xpBonusPercent;
            DropBonusPercent = dropBonusPercent;
            OwnersIds = ownersIds;
        }

        public PartyIdol()
        {
        }

        public override short TypeId => Id;

        public ulong[] OwnersIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) OwnersIds.Count());
            for (var ownersIdsIndex = 0; ownersIdsIndex < OwnersIds.Count(); ownersIdsIndex++)
                writer.WriteVarULong(OwnersIds[ownersIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ownersIdsCount = reader.ReadUShort();
            OwnersIds = new ulong[ownersIdsCount];
            for (var ownersIdsIndex = 0; ownersIdsIndex < ownersIdsCount; ownersIdsIndex++)
                OwnersIds[ownersIdsIndex] = reader.ReadVarULong();
        }
    }
}