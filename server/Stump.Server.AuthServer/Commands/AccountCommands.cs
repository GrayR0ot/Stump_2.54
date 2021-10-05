using Stump.Core.Extensions;
using Stump.DofusProtocol.Enums;
using Stump.Server.AuthServer.Database;
using Stump.Server.AuthServer.Managers;
using Stump.Server.BaseServer.Commands;

namespace Stump.Server.AuthServer.Commands
{
    public class AccountCommands : SubCommandContainer
    {
        public AccountCommands()
        {
            Aliases = new[] {"account", "acc"};
            RequiredRole = RoleEnum.Administrator;
            Description = "Provides many commands to manage accounts";
        }
    }

    public class AccountCreateCommand : SubCommand
    {
        public AccountCreateCommand()
        {
            Aliases = new[] {"create", "cr", "new"};
            ParentCommandType = typeof (AccountCommands);
            RequiredRole = RoleEnum.Administrator;
            Description = "Create a new account.";

            AddParameter<string>("accountname", "name", "Name of the created account");
            AddParameter<string>("password", "pass", "Password of the created accont");
            AddParameter("group", "group", "User group of the created account. See groups table", 1);
            AddParameter("question", "quest", "Secret question", "dummy?");
            AddParameter("answer", "answer", "Answer to the secret question", "dummy!");
        }

        public override void Execute(TriggerBase trigger)
        {
            var accname = trigger.Get<string>("accountname");

            var acc = new Account
                {
                    Login = accname,
                    PasswordHash = trigger.Get<string>("password").GetMD5(),
                    Nickname = trigger.Get<string>("accountname"),
                    SecretQuestion = trigger.Get<string>("question"),
                    SecretAnswer = trigger.Get<string>("answer"),
                    Role = trigger.Get<int>("group"),
                    Email = "",
                    AvailableBreeds = AccountManager.AvailableBreeds,
                    Lang = "fr",
                };

            if (AccountManager.Instance.CreateAccount(acc))
            {

                var accRole = "";

                switch(acc.Role)
                {
                    case 1:
                        accRole = "Joueur";
                        break;
                    case 2:
                        accRole = "Vip";
                        break;
                    case 3:
                        accRole = "Animateur";
                        break;
                    case 4:
                        accRole = "Moderateur";
                        break;
                    case 5:
                        accRole = "Administrateur";
                        break;
                }

                trigger.Reply("Created account.");
                trigger.Reply("Pseudo : " + accname);
                trigger.Reply("Group : " + acc.Role);
            }
            else
            {
                trigger.Reply("Creation refusée. Compte deja existant.");
            }
        }
    }
}