using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightSpectateMessage : Message
    {
        public const uint Id = 6069;

        public override uint MessageId
        {
            get { return Id; }
        }

        public Types.FightDispellableEffectExtendedInformations[] Efects;
        public Types.GameActionMark[] Marks;
        public uint GameTurn;
        public int FightStart;
        public Types.Idol[] Idols;
        public Types.GameFightEffectTriggerCount[] FxTriggerCounts;


        public GameFightSpectateMessage()
        {
        }

        public GameFightSpectateMessage(Types.FightDispellableEffectExtendedInformations[] effects,
            Types.GameActionMark[] marks, uint gameTurn, int fightStart, Types.Idol[] idols,
            Types.GameFightEffectTriggerCount[] fxTriggerCounts)
        {
            this.Efects = effects;
            this.Marks = marks;
            this.GameTurn = gameTurn;
            this.FightStart = fightStart;
            this.Idols = idols;
            this.FxTriggerCounts = fxTriggerCounts;
        }


        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Efects.Length);
            foreach (var entry in Efects)
            {
                entry.Serialize(writer);
            }

            writer.WriteShort((short) Marks.Length);
            foreach (var entry in Marks)
            {
                entry.Serialize(writer);
            }

            writer.WriteVarShort((short)GameTurn);
            writer.WriteInt(FightStart);
            writer.WriteShort((short) Idols.Length);
            foreach (var entry in Idols)
            {
                entry.Serialize(writer);
            }

            writer.WriteShort((short) FxTriggerCounts.Length);
            foreach (var entry in FxTriggerCounts)
            {
                entry.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var limit = (ushort) reader.ReadUShort();
            Efects = new Types.FightDispellableEffectExtendedInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                Efects[i] = new Types.FightDispellableEffectExtendedInformations();
                Efects[i].Deserialize(reader);
            }

            limit = (ushort) reader.ReadUShort();
            Marks = new Types.GameActionMark[limit];
            for (int i = 0; i < limit; i++)
            {
                Marks[i] = new Types.GameActionMark();
                Marks[i].Deserialize(reader);
            }

            GameTurn = reader.ReadVarUShort();
            FightStart = reader.ReadInt();
            limit = (ushort) reader.ReadUShort();
            Idols = new Types.Idol[limit];
            for (int i = 0; i < limit; i++)
            {
                Idols[i] = new Types.Idol();
                Idols[i].Deserialize(reader);
            }

            limit = (ushort) reader.ReadUShort();
            FxTriggerCounts = new Types.GameFightEffectTriggerCount[limit];
            for (int i = 0; i < limit; i++)
            {
                FxTriggerCounts[i] = new Types.GameFightEffectTriggerCount();
                FxTriggerCounts[i].Deserialize(reader);
            }
        }
    }
}