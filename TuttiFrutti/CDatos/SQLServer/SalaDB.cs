using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.SQLServer
{
    public class SalaDB
    {

        public string obtenerChat(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT * FROM Chat WHERE IdJuego = " + idJuego, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Chat");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();
                return ds.Tables[0].Rows[0].ItemArray[1].ToString();
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw ex;
            }

        }

        public void crearChat(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();

            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("INSERT INTO Chat VALUES (" + idJuego + ", '')", con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw ex;
            }

        }

        public void actualizarChat(int idJuego, string texto)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();

            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("UPDATE Chat SET Texto = '" + texto + "' WHERE IdJuego = " + idJuego, con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw ex;
            }
        }

    }
}
