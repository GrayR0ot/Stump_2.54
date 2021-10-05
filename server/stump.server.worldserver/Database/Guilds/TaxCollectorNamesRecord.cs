﻿using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Guilds
{
    public class TaxCollectorNamesRelator
    {
        public static string FetchQuery = "SELECT * FROM taxcollector_names";
    }

    [TableName("taxcollector_names")]
    [D2OClass("TaxCollectorName", "com.ankamagames.dofus.datacenter.npcs")]
    public class TaxCollectorNamesRecord : IAssignedByD2O, IAutoGeneratedRecord
    {
        [PrimaryKey("Id", false)] public int Id { get; set; }

        public uint NameId { get; set; }

        public void AssignFields(object d2oObject)
        {
            var name = (TaxCollectorName) d2oObject;
            Id = name.Id;
            NameId = name.NameId;
        }
    }
}