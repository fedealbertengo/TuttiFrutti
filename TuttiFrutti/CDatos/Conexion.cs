using CDatos.Properties;
using System.Data.SqlClient;
using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CDatos
{
    public class Conexion {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection SqlConnection = new SqlConnection(CDatos.Properties.Settings.Default.ConexionOnline);
            return SqlConnection;
        }

        public static void conectar(SqlConnection conn)
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
            SqlConnection conn = cn.conectar();
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
