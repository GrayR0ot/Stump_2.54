using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public new const uint Id = 6067;

        public GameFightResumeMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks,
            ushort gameTurn, int fightStart, Idol[] idols, GameFightSpellCooldown[] spellCooldowns, sbyte summonCount,
            sbyte bombCount)
        {
            Effects = effects;
            Marks = marks;
            GameTurn = gameTurn;
            FightStart = fightStart;
            Idols = idols;
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }

        public GameFightResumeMessage()
        {
        }

        public override uint MessageId => Id;

        public GameFightSpellCooldown[] SpellCooldowns { get; set; }
        public sbyte SummonCount { get; set; }
        public sbyte BombCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) SpellCooldowns.Count());
            for (var spellCooldownsIndex = 0; spellCooldownsIndex < SpellCooldowns.Count(); spellCooldownsIndex++)
            {
                var objectToSend = SpellCooldowns[spellCooldownsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteSByte(SummonCount);
            writer.WriteSByte(BombCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var spellCooldownsCount = reader.ReadUShort();
            SpellCooldowns = new GameFightSpellCooldown[spellCooldownsCount];
            for (var spellCooldownsIndex = 0; spellCooldownsIndex < spellCooldownsCount; spellCooldownsIndex++)
            {
                var objectToAdd = new GameFightSpellCooldown();
                objectToAdd.Deserialize(reader);
                SpellCooldowns[spellCooldownsIndex] = objectToAdd;
            }

            SummonCount = reader.ReadSByte();
            BombCount = reader.ReadSByte();
        }
    }
}