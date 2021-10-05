using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Jobs
{
    public static class SecretRecipeRelator
    {
        public static string FetchQuery = "SELECT * FROM recipes_secret";
    }

    [TableName("recipes_secret")]
    [D2OIgnore]
    public class SecretRecipeRecord : RecipeRecord
    {
    }
}