using CDatos.Properties;
using System.Data.SqlClient;
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CDatos
{
    public class Conexion {
        public static SqlConnection obtenerConexionSQLServer()
        {
            SqlConnection SqlConnection = new SqlConnection(CDatos.Properties.Settings.Default.ConexionSQLServer);
            return SqlConnection;
        }

        public static MySqlConnection obtenerConexionMySQL()
        {
            MySqlConnection SqlConnection = new MySqlConnection(CDatos.Properties.Settings.Default.ConexionMySQL);
            return SqlConnection;
        }

        public static void conectar(SqlConnection conn)
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
                catch (Exception ex)
                {
                    throw new ExceptionPersonalizada(ex.Message);
                }
            }
        }

        public static void conectar(MySqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
    }
}
