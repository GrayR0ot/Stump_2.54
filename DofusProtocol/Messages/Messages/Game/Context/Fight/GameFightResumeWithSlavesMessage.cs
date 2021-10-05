using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public new const uint Id = 6215;

        public GameFightResumeWithSlavesMessage(FightDispellableEffectExtendedInformations[] effects,
            GameActionMark[] marks, ushort gameTurn, int fightStart, Idol[] idols,
            GameFightSpellCooldown[] spellCooldowns, sbyte summonCount, sbyte bombCount,
            GameFightResumeSlaveInfo[] slavesInfo)
        {
            Effects = effects;
            Marks = marks;
            GameTurn = gameTurn;
            FightStart = fightStart;
            Idols = idols;
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
            SlavesInfo = slavesInfo;
        }

        public GameFightResumeWithSlavesMessage()
        {
        }

        public override uint MessageId => Id;

        public GameFightResumeSlaveInfo[] SlavesInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) SlavesInfo.Count());
            for (var slavesInfoIndex = 0; slavesInfoIndex < SlavesInfo.Count(); slavesInfoIndex++)
            {
                var objectToSend = SlavesInfo[slavesInfoIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var slavesInfoCount = reader.ReadUShort();
            SlavesInfo = new GameFightResumeSlaveInfo[slavesInfoCount];
            for (var slavesInfoIndex = 0; slavesInfoIndex < slavesInfoCount; slavesInfoIndex++)
            {
                var objectToAdd = new GameFightResumeSlaveInfo();
                objectToAdd.Deserialize(reader);
                SlavesInfo[slavesInfoIndex] = objectToAdd;
            }
        }
    }
}