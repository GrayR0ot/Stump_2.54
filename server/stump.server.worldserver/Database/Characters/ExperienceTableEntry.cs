using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Characters
{
    public class ExperienceTableRelator
    {
        public static string FetchQuery = "SELECT * FROM experiences";
    }

    [TableName("experiences")]
    public class ExperienceTableEntry : IAutoGeneratedRecord
    {
        // Primitive properties

        [PrimaryKey("Level")] public short Level { get; set; }

        public long? CharacterExp { get; set; }

        public long? GuildExp { get; set; }

        public long? MountExp { get; set; }

        public long? PetExp { get; set; }

        public ushort? AlignmentHonor { get; set; }

        public long? JobExp { get; set; }
    }
}