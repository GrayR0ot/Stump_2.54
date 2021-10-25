using System.Windows.Forms;

namespace SpellEffect
{
    public partial class SelectSpellLevel : Form
    {
        public SelectSpellLevel()
        {
            InitializeComponent();
        }

        public SelectSpellLevel(MySqlConn mysqlCon, int spellID)
        {
            InitializeComponent();

            mysqlCon.cmd.CommandText = "select * from " + Form1.spells_levels + " where SpellId = '" + spellID + "'";
            mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
            var counter = 0;
            while (mysqlCon.reader.Read())
                dataGridView1.Rows.Add(mysqlCon.reader["Id"].ToString(), mysqlCon.reader["SpellID"].ToString(),
                    ++counter);
            mysqlCon.reader.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            var selectedId = dataGridView1.Rows[index].Cells[0].Value.ToString();
            int.TryParse(selectedId, out SpellEffect.selectedId);
            var selectedLevel = dataGridView1.Rows[index].Cells[2].Value.ToString();
            int.TryParse(selectedLevel, out SpellEffect.selectedLevel);
            Close();
        }
    }
}