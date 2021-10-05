using System;

namespace Stump.DofusProtocol.Enums
{
    [Flags]
    public enum TeleporterTypeEnum
    {
        TELEPORTER_ZAAP = 0,
        TELEPORTER_SUBWAY = 1,
        TELEPORTER_PRISM = 2,
        TELEPORTER_HAVENBAG = 3,
        TELEPORTER_ANOMALY = 4
    }
}