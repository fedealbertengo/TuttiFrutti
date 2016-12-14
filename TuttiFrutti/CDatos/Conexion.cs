using CDatos.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace CDatos
{
    public class Conexion {
        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection MySqlConnection = new MySqlConnection(CDatos.Properties.Settings.Default.Conexion);
            return MySqlConnection;
        }

        public static void conectar(MySqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        /*
            CLogica.Conexion cn = new CLogica.Conexion();
            MySqlConnection conn = cn.conectar();
            try
            {
                conn.Open();
                MessageBox.Show("Conecto");
                conn.Dispose();
                conn.Close();
            }
            catch(Exception ex)
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Conecto");
                    conn.Dispose();
                    conn.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Ha ocurrido un problema:\n" + ex1);
                }
            }
        */
    }
}
