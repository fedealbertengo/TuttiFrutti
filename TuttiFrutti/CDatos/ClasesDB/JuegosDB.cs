using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.ClasesDB
{
    public class JuegosDB
    {
        string select = "SELECT J.Id, J.Nombre, U.NombreUsuario, J.Unidos, J.Capacidad FROM Juego J INNER JOIN Usuario U ON J.IdPropietario = U.Id";
        string orderBy = "ORDER BY J.Nombre ASC";

        public int obtenerUltimoIDBandera()
        {
            DataSet ds = new DataSet();
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("Select Max(IdBandera) As M From BanderasJuego", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "BanderasJuego");

                cmd.ExecuteNonQuery();

                string proxIDStr = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                int proxID;
                if (proxIDStr == "")
                {
                    proxID = -1;
                }
                else
                {
                    proxID = Int32.Parse(proxIDStr);
                }
                con.Dispose();
                con.Close();
                return (proxID + 1);
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(e.Message);
            }
        }

        public void eliminarBanderas(int idJuego, OleDbConnection con)
        {
            try
            {
                string consulta = "DELETE FROM BanderasJuego WHERE IdJuego = " + idJuego;

                OleDbCommand cmd = new OleDbCommand(consulta, con);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                string message = e.Message;
                throw new ExceptionPersonalizada(message);
            }
        }

        public int obtenerUltimoIDJuego()
        {
            DataSet ds = new DataSet();
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("Select Max(Id) As M From Juego", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Juego");

                cmd.ExecuteNonQuery();

                string proxIDStr = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                int proxID;
                if (proxIDStr == "")
                {
                    proxID = -1;
                }
                else
                {
                    proxID = Int32.Parse(proxIDStr);
                }
                con.Dispose();
                con.Close();
                return (proxID + 1);
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(e.Message);
            }

        }

        public void agregarSala(string nombre, string usuario, int capacidad)
        {
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                int idJuego = this.obtenerUltimoIDJuego();

                UsuarioDB cdatosU = new UsuarioDB();

                int idUsuario = cdatosU.getIdUsuario(usuario);

                string consulta = "INSERT INTO Juego VALUES (" + idJuego + ", \"" + nombre + "\", " + idUsuario + ", " + capacidad + ", 0)";

                OleDbCommand cmd = new OleDbCommand(consulta, con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                string message = e.Message;
                throw new ExceptionPersonalizada(message);
            }

        }

        public void eliminarJuego(int idJuego)
        {
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                this.eliminarBanderas(idJuego, con);

                string consulta = "DELETE FROM Juego WHERE Id = " + idJuego;

                OleDbCommand cmd = new OleDbCommand(consulta, con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                string message = e.Message;
                throw new ExceptionPersonalizada(message);
            }
        }

        public void unirUsuarioAJuego(int idJuego, string usuario)
        {
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                int idBandera = this.obtenerUltimoIDBandera();

                string consulta = "INSERT INTO BanderasJuego VALUES (" + idBandera + ", " + idJuego +", \"" + usuario + "\", \"Esperando\")";

                OleDbCommand cmd = new OleDbCommand(consulta, con);

                cmd.ExecuteNonQuery();

                //----------------------------------------------------------------------

                DataSet ds = new DataSet();

                consulta = "SELECT Unidos FROM Juego WHERE Id = " + idJuego;

                cmd = new OleDbCommand(consulta, con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Juego");

                cmd.ExecuteNonQuery();

                int unidos = (int) ds.Tables[0].Rows[0].ItemArray[0];

                consulta = "UPDATE Juego SET Unidos = ( " + unidos + " + 1) WHERE Id = " + idJuego;

                cmd = new OleDbCommand(consulta, con);

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                string message;
                if (e.Message.Contains("create duplicate values"))
                {
                    message = "Usted ya se encuentra en la sala.";
                }
                else
                {
                    message = e.Message;
                }
                throw new ExceptionPersonalizada(message);
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

        }

        public DataSet getJuegos(string where)
        {
            DataSet ds = new DataSet();
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                string consulta;
                if (where != "")
                {
                    consulta = select + " " + where + " " + orderBy;
                }
                else
                {
                    consulta = select + " " + orderBy;
                }

                OleDbCommand cmd = new OleDbCommand(consulta, con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Juego");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                return ds;
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(e.Message);
            }
        }
    }
}
