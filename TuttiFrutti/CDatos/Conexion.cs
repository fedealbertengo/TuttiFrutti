using CDatos.Properties;
using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CDatos
{
    public class Conexion {
        public static OleDbConnection obtenerConexion()
        {
            OleDbConnection oledbConnection = new OleDbConnection(CDatos.Properties.Settings.Default.Conexion);
            return oledbConnection;
        }

        public static void conectar(OleDbConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch(Exception)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex1)
                {
                    throw new ExceptionPersonalizada(ex1.Message);
                }
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
