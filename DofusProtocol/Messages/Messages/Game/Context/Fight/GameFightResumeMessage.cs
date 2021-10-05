using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public const uint Id = 6067;

        public override uint MessageId
        {
            get { return Id; }
        }

        public Types.GameFightSpellCooldown[] SpellCooldowns;
        public sbyte SummonCount;
        public sbyte BombCount;


        public GameFightResumeMessage()
        {
        }

        public GameFightResumeMessage(Types.FightDispellableEffectExtendedInformations[] effects,
            Types.GameActionMark[] marks, uint gameTurn, int fightStart, Types.Idol[] idols,
            Types.GameFightEffectTriggerCount[] fxTriggerCounts, Types.GameFightSpellCooldown[] spellCooldowns,
            sbyte summonCount, sbyte bombCount)
            : base(effects, marks, gameTurn, fightStart, idols, fxTriggerCounts)
        {
            this.SpellCooldowns = spellCooldowns;
            this.SummonCount = summonCount;
            this.BombCount = bombCount;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) SpellCooldowns.Length);
            foreach (var entry in SpellCooldowns)
            {
                entry.Serialize(writer);
            }

            writer.WriteSByte(SummonCount);
            writer.WriteSByte(BombCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = (ushort) reader.ReadUShort();
            SpellCooldowns = new Types.GameFightSpellCooldown[limit];
            for (int i = 0; i < limit; i++)
            {
                SpellCooldowns[i] = new Types.GameFightSpellCooldown();
                SpellCooldowns[i].Deserialize(reader);
            }

            SummonCount = reader.ReadSByte();
            BombCount = reader.ReadSByte();
        }
    }
}