using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("LuaFormula", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class LuaFormula : IDataObject, IIndexedData
    {
        public const string MODULE = "LuaFormulas";
        public string formulaName;
        public int id;
        public string luaFormula;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string FormulaName
        {
            get => formulaName;
            set => formulaName = value;
        }

        [D2OIgnore]
        public string LuaFormula_
        {
            get => luaFormula;
            set => luaFormula = value;
        }

        int IIndexedData.Id => id;
    }
}