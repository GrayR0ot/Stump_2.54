using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{

    public class InvalidPresetsMessage : Message
    {

        public const uint Id = 6839;
        public override uint MessageId
        {
            get { return Id; }
        }

        public short[] presetIds;
        

        public InvalidPresetsMessage()
        {
        }

        public InvalidPresetsMessage(short[] presetIds)
        {
            this.presetIds = presetIds;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteShort((short)presetIds.Length);
            foreach (var entry in presetIds)
            {
                writer.WriteShort(entry);
            }
            

        }

        public override void Deserialize(IDataReader reader)
        {

            var limit = (ushort)reader.ReadUShort();
            presetIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                presetIds[i] = reader.ReadShort();
            }
            

        }


    }


}