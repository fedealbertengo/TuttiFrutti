using System;
using System.Collections.Generic;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.ClasesDB
{
    public class PalabraDB
    {
        public void agregarPalabra(string palabra, char letra, string categoria)
        {
            MySqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                string strConsulta = "INSERT INTO Palabras VALUES (\"" + palabra + "\", \"" + categoria + "\", \"" + letra + "\")";
                MySqlCommand cmd = new MySqlCommand(strConsulta, con);

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
