using System;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Items.BidHouse
{
    public class BidHouseItemRelator
    {
        public static string FetchQuery = "SELECT * FROM bidhouse_items";

        /// <summary>
        ///     Use string.Format
        /// </summary>
        public static string FetchByOwner = "SELECT * FROM bidhouse_items WHERE OwnerId={0}";
    }

    [TableName("bidhouse_items")]
    public class BidHouseItemRecord : ItemRecord<BidHouseItemRecord>, IAutoGeneratedRecord
    {
        private int m_ownerId;

        private long m_price;

        private DateTime m_sellDate;

        private bool m_sold;

        public int OwnerId
        {
            get => m_ownerId;
            set
            {
                m_ownerId = value;
                IsDirty = true;
            }
        }

        public long Price
        {
            get => m_price;
            set
            {
                m_price = value;
                IsDirty = true;
            }
        }

        public bool Sold
        {
            get => m_sold;
            set
            {
                m_sold = value;
                IsDirty = true;
            }
        }

        public DateTime SellDate
        {
            get => m_sellDate;
            set
            {
                m_sellDate = value;
                IsDirty = true;
            }
        }
    }
}