using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpellEffect
{
    public class MySqlConn : IDisposable
    {
        public IDbCommand cmd;

        // pour une créer une instance de connexion Mysql
        public IDbConnection conn;
        public IDataReader reader; // pour créer des cmd SQL
        public MySqlDataReader readerSql = null;

        public MySqlConn(string username, string password, string db, string ip)
        {
            MySqlOpenConn(username, password, db, ip);
        }

        public void Dispose()
        {
            MysqlDisconnect();
        }

        public void MySqlOpenConn(string username, string password, string db, string ip)
        {
            if (conn != null)
                conn.Close();

            // initialisation de la connexion
            var connStr = string.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                ip, username, password, db);
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                cmd = conn.CreateCommand();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                    MessageBox.Show("Nom de table '" + db + "' introuvable dans la base de donnée.");
                else
                    MessageBox.Show("Erreur de connexion: \n" + ex.Message);
            }
        }

        public void MysqlDisconnect()
        {
            conn.Close();
        }
    }
}