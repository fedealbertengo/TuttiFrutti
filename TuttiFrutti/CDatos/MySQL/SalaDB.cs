using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.MySQL
{
    public class SalaDB
    {

        public string obtenerChat(int idJuego)
        {
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Chat WHERE IdJuego = " + idJuego, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO Chat VALUES (" + idJuego + ", \"\")", con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("UPDATE Chat SET Texto = \"" + texto + "\" WHERE IdJuego = " + idJuego, con);

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
