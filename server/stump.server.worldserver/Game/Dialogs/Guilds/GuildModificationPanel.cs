using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Handlers.Dialogs;
using Stump.Server.WorldServer.Handlers.Guilds;

namespace Stump.Server.WorldServer.Game.Dialogs.Guilds
{
    public class GuildModificationPanel : IDialog
    {
        public GuildModificationPanel(Character character)
        {
            Character = character;
        }

        public Character Character { get; }

        public bool ChangeName { get; set; }

        public bool ChangeEmblem { get; set; }

        public DialogTypeEnum DialogType => DialogTypeEnum.DIALOG_GUILD_RENAME;

        public void Close()
        {
            Character.CloseDialog(this);
            DialogHandler.SendLeaveDialogMessage(Character.Client, DialogType);
        }

        public void Open()
        {
            Character.SetDialog(this);
            GuildHandler.SendGuildModificationStartedMessage(Character.Client, ChangeName, ChangeEmblem);
        }

        public void ModifyGuildName(string guildName)
        {
            if (!ChangeName)
                return;

            if (Character.GuildMember == null)
                return;

            if (!Character.GuildMember.IsBoss)
                return;

            var result = Character.Guild.SetGuildName(Character, guildName);
            GuildHandler.SendGuildCreationResultMessage(Character.Client, result);

            if (result == SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_OK)
                Close();
        }

        public void ModifyGuildEmblem(GuildEmblem emblem)
        {
            if (!ChangeEmblem)
                return;

            if (Character.GuildMember == null)
                return;

            if (!Character.GuildMember.IsBoss)
                return;

            var result = Character.Guild.SetGuildEmblem(Character, emblem);
            GuildHandler.SendGuildCreationResultMessage(Character.Client, result);

            if (result == SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_OK)
                Close();
        }
    }
}