using System;
using System.Data;
using System.Windows.Forms;

namespace SpellEffect
{
    public partial class Form1 : Form
    {
        public static string userDB;
        public static string passwordDB;
        public static string adresseDB;
        public static string DBName;
        public static string spells_levels = "spells_levels";
        public static string clientVersion;
        private MySqlConn mysqlCon;
        private ToolTip ToolTip1 = new ToolTip();

        public Form1()
        {
            InitializeComponent();
        }


        private void connection_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("Entrer le nom d'utilisateur");
                return;
            }

            if (DB.Text == "")
            {
                MessageBox.Show("Entrer la Base de donné");
                return;
            }

            if (Ip.Text == "")
            {
                MessageBox.Show("Entrer l'adresse Ip");
                return;
            }


            var mysqlCon = new MySqlConn(username.Text, Password.Text, DB.Text, Ip.Text);

            if (mysqlCon.conn.State == ConnectionState.Open)
            {
                userDB = username.Text;
                passwordDB = Password.Text;
                adresseDB = Ip.Text;
                DBName = DB.Text;
                Hide();

                var spellEffect = new SpellEffect(mysqlCon);
                spellEffect.Show();
                spellEffect.FormClosed += SpellEffect_FormClosed;
            }
        }

        private void SpellEffect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mysqlCon != null && mysqlCon.conn.State == ConnectionState.Open)
            {
                mysqlCon.conn.Close();
                mysqlCon.Dispose();
                mysqlCon = null;
            }
        }

        private void username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connection_Click(null, null);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
            Enabled = false;
            about.FormClosed += About_FormClosed;
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
        }
    }
}