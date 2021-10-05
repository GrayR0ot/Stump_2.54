using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareCreationRequestMessage : Message
    {
        public const uint Id = 6665;

        public DareCreationRequestMessage(bool isPrivate, bool isForGuild, bool isForAlliance, bool needNotifications,
            ulong subscriptionFee, ulong jackpot, ushort maxCountWinners, uint delayBeforeStart, uint duration,
            DareCriteria[] criterions)
        {
            IsPrivate = isPrivate;
            IsForGuild = isForGuild;
            IsForAlliance = isForAlliance;
            NeedNotifications = needNotifications;
            SubscriptionFee = subscriptionFee;
            Jackpot = jackpot;
            MaxCountWinners = maxCountWinners;
            DelayBeforeStart = delayBeforeStart;
            Duration = duration;
            Criterions = criterions;
        }

        public DareCreationRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public bool IsPrivate { get; set; }
        public bool IsForGuild { get; set; }
        public bool IsForAlliance { get; set; }
        public bool NeedNotifications { get; set; }
        public ulong SubscriptionFee { get; set; }
        public ulong Jackpot { get; set; }
        public ushort MaxCountWinners { get; set; }
        public uint DelayBeforeStart { get; set; }
        public uint Duration { get; set; }
        public DareCriteria[] Criterions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, IsPrivate);
            flag = BooleanByteWrapper.SetFlag(flag, 1, IsForGuild);
            flag = BooleanByteWrapper.SetFlag(flag, 2, IsForAlliance);
            flag = BooleanByteWrapper.SetFlag(flag, 3, NeedNotifications);
            writer.WriteByte(flag);
            writer.WriteVarULong(SubscriptionFee);
            writer.WriteVarULong(Jackpot);
            writer.WriteUShort(MaxCountWinners);
            writer.WriteUInt(DelayBeforeStart);
            writer.WriteUInt(Duration);
            writer.WriteShort((short) Criterions.Count());
            for (var criterionsIndex = 0; criterionsIndex < Criterions.Count(); criterionsIndex++)
            {
                var objectToSend = Criterions[criterionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            IsPrivate = BooleanByteWrapper.GetFlag(flag, 0);
            IsForGuild = BooleanByteWrapper.GetFlag(flag, 1);
            IsForAlliance = BooleanByteWrapper.GetFlag(flag, 2);
            NeedNotifications = BooleanByteWrapper.GetFlag(flag, 3);
            SubscriptionFee = reader.ReadVarULong();
            Jackpot = reader.ReadVarULong();
            MaxCountWinners = reader.ReadUShort();
            DelayBeforeStart = reader.ReadUInt();
            Duration = reader.ReadUInt();
            var criterionsCount = reader.ReadUShort();
            Criterions = new DareCriteria[criterionsCount];
            for (var criterionsIndex = 0; criterionsIndex < criterionsCount; criterionsIndex++)
            {
                var objectToAdd = new DareCriteria();
                objectToAdd.Deserialize(reader);
                Criterions[criterionsIndex] = objectToAdd;
            }
        }
    }
}