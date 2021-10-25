using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpellEffect
{
    public partial class SpellEffect : Form
    {
        public static int selectedId = -1;
        public static int selectedLevel = -1;

        private readonly List<string> columnName = new List<string>();
        private readonly MySqlConn mysqlCon;

        public SpellEffect()
        {
            InitializeComponent();
        }

        public SpellEffect(MySqlConn _mysqlCon)
        {
            InitializeComponent();
            mysqlCon = _mysqlCon;
        }

        private void editSpell_Click(object sender, EventArgs e)
        {
            int convertedSortID;
            if (!int.TryParse(sortID.Text, out convertedSortID))
            {
                MessageBox.Show("Veuillez entrer un numéro valide");
                return;
            }

            selectedId = -1;
            mysqlCon.cmd.CommandText = "select count(id) from " + Form1.spells_levels + " where SpellId = '" +
                                       convertedSortID + "'";
            try
            {
                mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                mysqlCon.reader.Read();
                var count = mysqlCon.reader.GetInt32(0);
                mysqlCon.reader.Close();
                if (count > 0)
                {
                    Hide();
                    var selectSpellLevel = new SelectSpellLevel(mysqlCon, convertedSortID);
                    selectSpellLevel.Show();
                    selectSpellLevel.FormClosing += SelectSpellLevel_FormClosing;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                switch (ex.Number)
                {
                    case 1146:
                        var selectionTable = new SelectionTable(mysqlCon);
                        selectionTable.Show();
                        selectionTable.FormClosed += SelectionTable_FormClosed;
                        Enabled = false;
                        break;
                    default:
                        MessageBox.Show(ex.ToString());
                        break;
                }
            }
        }

        private void SelectionTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Form).Tag != null)
            {
                Form1.spells_levels = (sender as Form).Tag.ToString();
                Enabled = true;
            }
        }

        private void SelectSpellLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Show();
            if (selectedId == -1)
                return;
            showInfo();
        }

        private void showInfo()
        {
            spellLevelL.Text = "Level " + selectedLevel;
            dataGridView1.Columns.Clear();
            //// recuperer le nom des colonnes
            var mysqlCon2 = new MySqlConn(Form1.userDB, Form1.passwordDB, "information_schema", Form1.adresseDB);
            mysqlCon2.cmd.CommandText = "SELECT column_name FROM information_schema.columns WHERE table_schema = '" +
                                        Form1.DBName + "' AND table_name = '" + Form1.spells_levels + "'";
            mysqlCon2.reader = mysqlCon2.cmd.ExecuteReader();
            var count = 0;
            columnName.Clear();
            while (mysqlCon2.reader.Read())
            {
                count++;
                var column = mysqlCon2.reader[0].ToString();
                columnName.Add(column);
            }

            mysqlCon2.reader.Close();

            for (var cnt = 0; cnt < count; cnt++)
            {
                var column = new DataGridViewTextBoxColumn();
                column.HeaderText = columnName[cnt];
                column.Name = columnName[cnt];
                column.ReadOnly = true;
                column.Resizable = DataGridViewTriState.True;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns.Add(column);
            }

            ///////////////////////////////// insertion des données
            dataGridView1.Rows.Clear();
            dataGridView1.CellDoubleClick -= DataGridView1_CellDoubleClick;
            mysqlCon.cmd.CommandText = "select * from " + Form1.spells_levels + " where Id = '" + selectedId + "'";
            mysqlCon.reader = mysqlCon.cmd.ExecuteReader();

            while (mysqlCon.reader.Read())
            {
                var data = new object[count];
                for (var cnt = 0; cnt < data.Length; cnt++)
                    data[cnt] = mysqlCon.reader[cnt];

                dataGridView1.Rows.Add(data);
            }

            mysqlCon.reader.Close();
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = dataGridView1.Height + 120;
            panel2.Visible = true;
            Location = new Point(0, 0);
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (value.GetType() == typeof(byte[]) && (columnName[e.ColumnIndex] == "EffectsBin" ||
                                                      columnName[e.ColumnIndex] == "CriticalEffectsBin" ||
                                                      columnName[e.ColumnIndex] == "Effects" ||
                                                      columnName[e.ColumnIndex] == "CriticalEffect" ||
                                                      columnName[e.ColumnIndex] == "CriticalEffects" ||
                                                      columnName[e.ColumnIndex] == "Effect"))
            {
                Hide();
                var effectBin = new EffectBin(value as byte[], mysqlCon,
                    Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    columnName[e.ColumnIndex]);
                effectBin.FormClosed += EffectBin_FormClosed;
                effectBin.Show();
            }

            dataGridView1.BeginEdit(true);
            dataGridView1.CurrentCell.ReadOnly = false;
        }

        private void EffectBin_FormClosed(object sender, FormClosedEventArgs e)
        {
            showInfo();
            Show();
        }

        private void sortID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                editSpell_Click(null, null);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var value = "";

                for (var cnt = 2; cnt < dataGridView1.Rows[0].Cells.Count; cnt++)
                {
                    if (columnName[cnt] == "EffectsBin" || columnName[cnt] == "CriticalEffectsBin")
                        continue;
                    var dgvtbc = (DataGridViewTextBoxCell) dataGridView1.Rows[0].Cells[cnt];
                    value += Form1.spells_levels + "." + columnName[cnt] + " = '" + dgvtbc.Value + "', ";
                }

                value = value.Substring(0, value.Length - 2);

                mysqlCon.cmd.CommandText = "update " + Form1.spells_levels + " set " + value + " where id = '" +
                                           selectedId + "'";
                mysqlCon.reader = mysqlCon.cmd.ExecuteReader();
                mysqlCon.reader.Close();
                MessageBox.Show("Enregistré");
            }
        }

        private void Hta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
        }


        private void Ht_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
        }
    }
}