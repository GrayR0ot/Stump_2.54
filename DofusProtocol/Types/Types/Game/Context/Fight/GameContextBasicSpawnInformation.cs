using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{

    public class GameContextBasicSpawnInformation
    {

        public const short Id = 568;
        public virtual short TypeId
        {
            get { return Id; }
        }

        public sbyte teamId;
        public bool alive;
        public Types.GameContextActorPositionInformations informations;
        

        public GameContextBasicSpawnInformation()
        {
        }

        public GameContextBasicSpawnInformation(sbyte teamId, bool alive, Types.GameContextActorPositionInformations informations)
        {
            this.teamId = teamId;
            this.alive = alive;
            this.informations = informations;
        }
        

        public virtual void Serialize(IDataWriter writer)
        {

            writer.WriteSByte(teamId);
            writer.WriteBoolean(alive);
            writer.WriteShort(informations.TypeId);
            informations.Serialize(writer);
            

        }

        public virtual void Deserialize(IDataReader reader)
        {

            teamId = reader.ReadSByte();
            alive = reader.ReadBoolean();
            informations = ProtocolTypeManager.GetInstance<Types.GameContextActorPositionInformations>(reader.ReadShort());
            informations.Deserialize(reader);
            

        }


    }


}