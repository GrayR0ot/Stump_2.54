﻿using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Guilds
{
    public class TaxCollectorFirstnamesRelator
    {
        public static string FetchQuery = "SELECT * FROM taxcollector_firstnames";
    }

    [TableName("taxcollector_firstnames")]
    [D2OClass("TaxCollectorFirstname", "com.ankamagames.dofus.datacenter.npcs")]
    public class TaxCollectorFirstnamesRecord : IAssignedByD2O, IAutoGeneratedRecord
    {
        [PrimaryKey("Id", false)] public int Id { get; set; }

        public uint FirstnameId { get; set; }

        public void AssignFields(object d2oObject)
        {
            var firstname = (TaxCollectorFirstname) d2oObject;
            Id = firstname.Id;
            FirstnameId = firstname.FirstnameId;
        }
    }
}