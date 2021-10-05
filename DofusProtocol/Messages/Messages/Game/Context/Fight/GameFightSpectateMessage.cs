using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightSpectateMessage : Message
    {
        public const uint Id = 6069;

        public GameFightSpectateMessage(FightDispellableEffectExtendedInformations[] effects, GameActionMark[] marks,
            ushort gameTurn, int fightStart, Idol[] idols)
        {
            Effects = effects;
            Marks = marks;
            GameTurn = gameTurn;
            FightStart = fightStart;
            Idols = idols;
        }

        public GameFightSpectateMessage()
        {
        }

        public override uint MessageId => Id;

        public FightDispellableEffectExtendedInformations[] Effects { get; set; }
        public GameActionMark[] Marks { get; set; }
        public ushort GameTurn { get; set; }
        public int FightStart { get; set; }
        public Idol[] Idols { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Effects.Count());
            for (var effectsIndex = 0; effectsIndex < Effects.Count(); effectsIndex++)
            {
                var objectToSend = Effects[effectsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) Marks.Count());
            for (var marksIndex = 0; marksIndex < Marks.Count(); marksIndex++)
            {
                var objectToSend = Marks[marksIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteVarUShort(GameTurn);
            writer.WriteInt(FightStart);
            writer.WriteShort((short) Idols.Count());
            for (var idolsIndex = 0; idolsIndex < Idols.Count(); idolsIndex++)
            {
                var objectToSend = Idols[idolsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var effectsCount = reader.ReadUShort();
            Effects = new FightDispellableEffectExtendedInformations[effectsCount];
            for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
            {
                var objectToAdd = new FightDispellableEffectExtendedInformations();
                objectToAdd.Deserialize(reader);
                Effects[effectsIndex] = objectToAdd;
            }

            var marksCount = reader.ReadUShort();
            Marks = new GameActionMark[marksCount];
            for (var marksIndex = 0; marksIndex < marksCount; marksIndex++)
            {
                var objectToAdd = new GameActionMark();
                objectToAdd.Deserialize(reader);
                Marks[marksIndex] = objectToAdd;
            }

            GameTurn = reader.ReadVarUShort();
            FightStart = reader.ReadInt();
            var idolsCount = reader.ReadUShort();
            Idols = new Idol[idolsCount];
            for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
            {
                var objectToAdd = new Idol();
                objectToAdd.Deserialize(reader);
                Idols[idolsIndex] = objectToAdd;
            }
        }
    }
}