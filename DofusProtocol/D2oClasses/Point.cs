using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [Serializable]
    [D2OClass("Point", "flash.geom")]
    public class Point : IDataObject
    {
        public double length;
        public int x;
        public int y;
    }
}