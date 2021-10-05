using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Commands;
using Stump.Server.BaseServer.IPC.Objects;

namespace Stump.Server.WorldServer.Database.Accounts
{
    public class UserGroup
    {
        private readonly UserGroupData m_data;

        public UserGroup(UserGroupData data)
        {
            m_data = data;
        }

        public int Id => m_data.Id;

        public string Name => m_data.Name;

        public RoleEnum Role => m_data.Role;

        public bool IsGameMaster => m_data.IsGameMaster;


        public bool IsCommandAvailable(CommandBase command)
        {
            return Role >= command.RequiredRole ||
                   m_data.Commands != null && command.GetFullAliases().Any(x => m_data.Commands.Contains(x));
        }
    }
}