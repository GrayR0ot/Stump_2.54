using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Phoenix", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class Phoenix : IDataObject
    {
        public const string MODULE = "Phoenixes";
        public double mapId;

        [D2OIgnore]
        public double MapId
        {
            get => mapId;
            set => mapId = value;
        }
    }
}