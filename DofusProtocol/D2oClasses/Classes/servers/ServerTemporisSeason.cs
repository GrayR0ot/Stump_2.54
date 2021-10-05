using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerTemporisSeason", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerTemporisSeason : IDataObject, IIndexedData
    {
        public const string MODULE = "ServerTemporisSeasons";
        public double beginning;
        public double closure;
        public string information;
        public uint seasonNumber;
        public int uid;

        [D2OIgnore]
        public int Uid
        {
            get => uid;
            set => uid = value;
        }

        [D2OIgnore]
        public uint SeasonNumber
        {
            get => seasonNumber;
            set => seasonNumber = value;
        }

        [D2OIgnore]
        public string Information
        {
            get => information;
            set => information = value;
        }

        [D2OIgnore]
        public double Beginning
        {
            get => beginning;
            set => beginning = value;
        }

        [D2OIgnore]
        public double Closure
        {
            get => closure;
            set => closure = value;
        }

        int IIndexedData.Id => uid;
    }
}