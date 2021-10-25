using System;
using System.Windows.Forms;

namespace SpellEffect
{
    public partial class SelectionTable : Form
    {
        public SelectionTable()
        {
            InitializeComponent();
        }

        public SelectionTable(MySqlConn mysqlConn)
        {
            InitializeComponent();
            mysqlConn.cmd.CommandText = "show tables";
            mysqlConn.reader = mysqlConn.cmd.ExecuteReader();
            while (mysqlConn.reader.Read())
            {
                var column = mysqlConn.reader[0].ToString();
                tablesName.Items.Add(column);
            }

            tablesName.SelectedIndex = 0;
            mysqlConn.reader.Close();
        }


        private void connexion_Click(object sender, EventArgs e)
        {
            Tag = tablesName.SelectedItem;
            Close();
        }
    }
}