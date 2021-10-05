using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TitlesAndOrnamentsListMessage : Message
    {
        public const uint Id = 6367;

        public TitlesAndOrnamentsListMessage(ushort[] titles, ushort[] ornaments, ushort activeTitle,
            ushort activeOrnament)
        {
            Titles = titles;
            Ornaments = ornaments;
            ActiveTitle = activeTitle;
            ActiveOrnament = activeOrnament;
        }

        public TitlesAndOrnamentsListMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort[] Titles { get; set; }
        public ushort[] Ornaments { get; set; }
        public ushort ActiveTitle { get; set; }
        public ushort ActiveOrnament { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Titles.Count());
            for (var titlesIndex = 0; titlesIndex < Titles.Count(); titlesIndex++)
                writer.WriteVarUShort(Titles[titlesIndex]);
            writer.WriteShort((short) Ornaments.Count());
            for (var ornamentsIndex = 0; ornamentsIndex < Ornaments.Count(); ornamentsIndex++)
                writer.WriteVarUShort(Ornaments[ornamentsIndex]);
            writer.WriteVarUShort(ActiveTitle);
            writer.WriteVarUShort(ActiveOrnament);
        }

        public override void Deserialize(IDataReader reader)
        {
            var titlesCount = reader.ReadUShort();
            Titles = new ushort[titlesCount];
            for (var titlesIndex = 0; titlesIndex < titlesCount; titlesIndex++)
                Titles[titlesIndex] = reader.ReadVarUShort();
            var ornamentsCount = reader.ReadUShort();
            Ornaments = new ushort[ornamentsCount];
            for (var ornamentsIndex = 0; ornamentsIndex < ornamentsCount; ornamentsIndex++)
                Ornaments[ornamentsIndex] = reader.ReadVarUShort();
            ActiveTitle = reader.ReadVarUShort();
            ActiveOrnament = reader.ReadVarUShort();
        }
    }
}