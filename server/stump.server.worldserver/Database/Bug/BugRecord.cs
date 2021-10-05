﻿using System;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Bug
{
    [TableName("Bug")]
    public class BugRecord : IAutoGeneratedRecord
    {
        [PrimaryKey("Id")] public int Id { get; set; }

        public string OwnerName { get; set; }

        public int OwnerId { get; set; }

        public int OwnerAccount { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}