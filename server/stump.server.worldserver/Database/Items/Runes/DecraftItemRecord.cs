﻿using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Items.Runes
{
    public class DecraftItemRelator
    {
        public static string FetchQuery = "SELECT * FROM items_decraft_history";
    }

    [TableName("items_decraft_history")]
    public class DecraftItemRecord : IAutoGeneratedRecord
    {
        [PrimaryKey("ItemId", false)] public int ItemId { get; set; }

        public int Amount { get; set; }
    }
}