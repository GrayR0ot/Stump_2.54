using System;

namespace Stump.DofusProtocol.Enums
{
    [Flags]
    public enum SocialNoticeErrorEnum
    {
        SOCIAL_NOTICE_UNKNOWN_ERROR = 0,
        SOCIAL_NOTICE_INVALID_RIGHTS = 1,
        SOCIAL_NOTICE_COOLDOWN = 2
    }
}