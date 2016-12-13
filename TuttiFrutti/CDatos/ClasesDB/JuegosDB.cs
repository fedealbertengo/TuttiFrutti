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
        string select = "SELECT J.Id, J.Nombre, U.NombreUsuario, J.Unidos, J.Capacidad, J.Estado FROM Juego J INNER JOIN Usuario U ON J.IdPropietario = U.Id";
        string orderBy = "ORDER BY J.Nombre ASC";

        public void actualizarPuntajeRonda(int idJuego, int nroRonda, string usuario, int puntaje)
        {
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("UPDATE Ronda SET Puntos = " + puntaje + " WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND Jugador = \"" + usuario + "\"", con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }

        }

        public int obtenerPuntosPalabra(int idJuego, int nroRonda, string usuario, char letra, string palabra, string categoria)
        {
            OleDbConnection con = Conexion.obtenerConexion();

            try
            {
                int puntos = 10;

                DataSet ds = new DataSet();
                Conexion.conectar(con);

                string where = "";
                if (categoria.Equals("Objeto"))
                {
                    where = "WHERE Palabra = \"" + palabra + "\" AND Letra = \"" + letra + "\"";
                }
                else
                {
                    where = "WHERE Palabra = \"" + palabra + "\" AND Categoria = \"" + categoria + "\" AND Letra = \"" + letra + "\"";
                }

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Palabras " + where, con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                DataSet ds1 = new DataSet();

                cmd = new OleDbCommand("SELECT * FROM Ronda WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND " + categoria + " = \"" + palabra + "\" AND NOT(Jugador = \"" + usuario + "\")", con);

                da = new OleDbDataAdapter(cmd);

                da.Fill(ds1, "Ronda");

                cmd.ExecuteNonQuery();

                DataSet ds2 = new DataSet();

                cmd = new OleDbCommand("SELECT * FROM Palabras WHERE Categoria = \"" + categoria + "\" AND Letra = \"" + letra + "\"", con);

                da = new OleDbDataAdapter(cmd);

                da.Fill(ds2, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                if(ds.Tables[0].Rows.Count == 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    puntos = -10;
                }
                else
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        puntos = 5;
                    }
                }

                return puntos;
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public List<string> obtenerDatosRonda(int idJuego, int nroRonda, string usuario)
        {
            OleDbConnection con = Conexion.obtenerConexion();

            try
            {
                List<string> lista = new List<string>();

                DataSet ds = new DataSet();
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("SELECT Letra, Nombre, Animal, Color, Objeto, Lugar, Comida FROM Ronda WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND Jugador = \"" + usuario + "\"", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                foreach (var item in ds.Tables[0].Rows[0].ItemArray)
                {
                    lista.Add(item.ToString());
                }

                return lista;
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
        public int obtenerNroRonda(string usuario, int juego)
        {
            OleDbConnection con = Conexion.obtenerConexion();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("SELECT IIF(ISNULL(MAX(NroRonda)),0,MAX(NroRonda)), IIF(EXISTS(SELECT * FROM Ronda WHERE IdJuego = " + juego + " AND TuttiFrutti = 1),1,0) FROM Ronda WHERE IdJuego = " + juego, con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                int nroRonda;
                if ((int)ds.Tables[0].Rows[0].ItemArray[1] == 1) {
                    nroRonda = ((int)ds.Tables[0].Rows[0].ItemArray[0] + 1);
                }
                else
                {
                    nroRonda = (int)ds.Tables[0].Rows[0].ItemArray[0];
                }

                con.Dispose();
                con.Close();
                return nroRonda;
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void crearRonda(string datos)
        {
            OleDbConnection con = Conexion.obtenerConexion();

            try
            {

                DataSet ds = new DataSet();

                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("SELECT IIF(ISNULL(MAX(IdRespuesta)), 0, MAX(IdRespuesta)) FROM Ronda", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                int nroRespuesta = ((int)ds.Tables[0].Rows[0].ItemArray[0] + 1);

                cmd = new OleDbCommand("INSERT INTO Ronda VALUES (" +  nroRespuesta + ",  \"" + datos, con);

                cmd.ExecuteNonQuery();
                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void cargarRonda(string datos, string where)
        {
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("UPDATE Ronda SET " + datos + " " + where, con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public bool hayTuttiFrutti(int juego, int ronda)
        {
            OleDbConnection con = Conexion.obtenerConexion();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Ronda WHERE IdJuego = " + juego + " AND NroRonda = " + ronda + " AND TuttiFrutti = 1", con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();


                con.Dispose();
                con.Close();

                return (ds.Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }


        public void modificarEstado(int idJuego, string estado)
        {
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                OleDbCommand cmd = new OleDbCommand("UPDATE Juego SET Estado = \"" + estado + "\" WHERE Id = " + idJuego, con);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }


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

                string consulta = "INSERT INTO Juego VALUES (" + idJuego + ", \"" + nombre + "\", " + idUsuario + ", " + capacidad + ", 0, \"Esperando\")";

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

                string consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE (NOT(J.Estado = \"Terminado\") AND BJ.NombreUsuario = \"" + usuario + "\" AND NOT(J.Id = " + idJuego + "))";

                OleDbCommand cmd = new OleDbCommand(consulta, con);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "Juego");

                cmd.ExecuteNonQuery();


                consulta = "SELECT * FROM Juego WHERE Estado = \"Esperando\" AND Id = " + idJuego + " AND (Capacidad - Unidos > 0)";

                cmd = new OleDbCommand(consulta, con);

                da = new OleDbDataAdapter(cmd);

                DataSet ds2 = new DataSet();

                da.Fill(ds2, "Juego");

                cmd.ExecuteNonQuery();


                consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE J.Estado = \"Jugando\" AND BJ.NombreUsuario = \"" + usuario + "\" AND J.Id = " + idJuego;

                cmd = new OleDbCommand(consulta, con);

                da = new OleDbDataAdapter(cmd);

                DataSet ds3 = new DataSet();

                da.Fill(ds3, "Juego");

                cmd.ExecuteNonQuery();

                //----------------------------------------------------------------------

                if (ds.Tables[0].Rows.Count == 0 && (ds2.Tables[0].Rows.Count == 1 || ds3.Tables[0].Rows.Count == 1))
                {
                    int idBandera = this.obtenerUltimoIDBandera();

                    consulta = "INSERT INTO BanderasJuego VALUES (" + idBandera + ", " + idJuego + ", \"" + usuario + "\", \"Esperando\")";

                    cmd = new OleDbCommand(consulta, con);

                    cmd.ExecuteNonQuery();

                    //----------------------------------------------------------------------

                    ds = new DataSet();

                    consulta = "SELECT Unidos FROM Juego WHERE Id = " + idJuego;

                    cmd = new OleDbCommand(consulta, con);

                    da = new OleDbDataAdapter(cmd);

                    da.Fill(ds, "Juego");

                    cmd.ExecuteNonQuery();

                    int unidos = (int)ds.Tables[0].Rows[0].ItemArray[0];

                    consulta = "UPDATE Juego SET Unidos = ( " + unidos + " + 1) WHERE Id = " + idJuego;

                    cmd = new OleDbCommand(consulta, con);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string str = "";
                    if(ds.Tables[0].Rows.Count != 0)
                    {
                        str += "Usted ya se encuentra en una sala activa.\n";
                    }
                    if (ds.Tables[0].Rows.Count != 1)
                    {
                        str += "La sala a la que intenta unirse está llena o está en juego.\n";
                    }
                    str = str.Remove(str.LastIndexOf('\n'));
                    throw new ExceptionPersonalizada(str);
                }
            }
            catch (Exception e)
            {
                string message;
                if (e.Message.Contains("create duplicate values") || e.Message.Contains("crearían valores duplicados"))
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
                    consulta = select + " " + where + " AND NOT(Estado = \"Terminado\") " + orderBy;
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

        public DataSet getBanderas(string where)
        {
            DataSet ds = new DataSet();
            OleDbConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                string selectB = "SELECT * FROM BanderasJuego";

                string consulta;
                if (where != "")
                {
                    consulta = selectB + " " + where;
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
