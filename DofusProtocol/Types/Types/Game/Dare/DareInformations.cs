using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class DareInformations
    {
        public const short Id = 502;

        public DareInformations(double dareId, CharacterBasicMinimalInformations creator, ulong subscriptionFee,
            ulong jackpot, ushort maxCountWinners, double endDate, bool isPrivate, uint guildId, uint allianceId,
            DareCriteria[] criterions, double startDate)
        {
            DareId = dareId;
            Creator = creator;
            SubscriptionFee = subscriptionFee;
            Jackpot = jackpot;
            MaxCountWinners = maxCountWinners;
            EndDate = endDate;
            IsPrivate = isPrivate;
            GuildId = guildId;
            AllianceId = allianceId;
            Criterions = criterions;
            StartDate = startDate;
        }

        public DareInformations()
        {
        }

        public virtual short TypeId => Id;

        public double DareId { get; set; }
        public CharacterBasicMinimalInformations Creator { get; set; }
        public ulong SubscriptionFee { get; set; }
        public ulong Jackpot { get; set; }
        public ushort MaxCountWinners { get; set; }
        public double EndDate { get; set; }
        public bool IsPrivate { get; set; }
        public uint GuildId { get; set; }
        public uint AllianceId { get; set; }
        public DareCriteria[] Criterions { get; set; }
        public double StartDate { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            Creator.Serialize(writer);
            writer.WriteVarULong(SubscriptionFee);
            writer.WriteVarULong(Jackpot);
            writer.WriteUShort(MaxCountWinners);
            writer.WriteDouble(EndDate);
            writer.WriteBoolean(IsPrivate);
            writer.WriteVarUInt(GuildId);
            writer.WriteVarUInt(AllianceId);
            writer.WriteShort((short) Criterions.Count());
            for (var criterionsIndex = 0; criterionsIndex < Criterions.Count(); criterionsIndex++)
            {
                var objectToSend = Criterions[criterionsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteDouble(StartDate);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Creator = new CharacterBasicMinimalInformations();
            Creator.Deserialize(reader);
            SubscriptionFee = reader.ReadVarULong();
            Jackpot = reader.ReadVarULong();
            MaxCountWinners = reader.ReadUShort();
            EndDate = reader.ReadDouble();
            IsPrivate = reader.ReadBoolean();
            GuildId = reader.ReadVarUInt();
            AllianceId = reader.ReadVarUInt();
            var criterionsCount = reader.ReadUShort();
            Criterions = new DareCriteria[criterionsCount];
            for (var criterionsIndex = 0; criterionsIndex < criterionsCount; criterionsIndex++)
            {
                var objectToAdd = new DareCriteria();
                objectToAdd.Deserialize(reader);
                Criterions[criterionsIndex] = objectToAdd;
            }

            StartDate = reader.ReadDouble();
        }
    }
}