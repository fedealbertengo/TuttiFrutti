using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidades.Entidades;

namespace CDatos.ClasesDB
{
    public class JuegosDB
    {
        string select = "SELECT J.Id, J.Nombre, U.NombreUsuario, J.Unidos, J.Capacidad, J.Estado FROM Juego J INNER JOIN Usuario U ON J.IdPropietario = U.Id";
        string orderBy = "ORDER BY J.Nombre ASC";

        public void actualizarPuntajeRonda(int idJuego, int nroRonda, string usuario, int puntaje)
        {
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("UPDATE Ronda SET Puntos = " + puntaje + " WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND Jugador = '" + usuario + "'", con);

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

        public Palabra obtenerPalabrasDudosas(int idJuego, int nroRonda, string usuario, char letra, string palabra, string categoria)
        {
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                Palabra pal = new Palabra();
                pal.Pala = "";
                pal.Letra = letra;
                pal.Categoria = categoria;

                DataSet ds = new DataSet();
                Conexion.conectar(con);

                string where = "";
                if (categoria.Equals("Objeto"))
                {
                    where = "WHERE Palabra = '" + palabra + "' AND Letra = '" + letra + "'";
                }
                else
                {
                    where = "WHERE Palabra = '" + palabra + "' AND Categoria = '" + categoria + "' AND Letra = '" + letra + "'";
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Palabras " + where, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                if (ds.Tables[0].Rows.Count == 0)
                {
                    pal.Pala = palabra;
                }
                return pal;
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
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                int puntos = 10;

                DataSet ds = new DataSet();
                Conexion.conectar(con);

                string where = "";
                if (categoria.Equals("Objeto"))
                {
                    where = "WHERE Palabra = '" + palabra + "' AND Letra = '" + letra + "'";
                }
                else
                {
                    where = "WHERE Palabra = '" + palabra + "' AND Categoria = '" + categoria + "' AND Letra = '" + letra + "'";
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Palabras " + where, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                DataSet ds1 = new DataSet();

                cmd = new SqlCommand("SELECT * FROM Ronda WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND " + categoria + " = '" + palabra + "' AND NOT(Jugador = '" + usuario + "')", con);

                da = new SqlDataAdapter(cmd);

                da.Fill(ds1, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                if(ds.Tables[0].Rows.Count == 0)
                {
                    puntos = 0;
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

        public string getUsuarioTuttiFrutti(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT U.NombreUsuario FROM Juego J INNER JOIN Usuario U ON J.IdPropietario = U.Id WHERE J.Id = " + idJuego, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
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
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                List<string> lista = new List<string>();

                DataSet ds = new DataSet();
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT Letra, Nombre, Animal, Color, Objeto, Lugar, Comida FROM Ronda WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND Jugador = '" + usuario + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT IFNULL(MAX(nroRonda),0), IF(EXISTS(SELECT * FROM Ronda WHERE IdJuego = " + juego + " AND TuttiFrutti = 1),1,0) FROM Ronda WHERE IdJuego = " + juego, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                int nroRonda;
                if (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[1].ToString()) == 1) {
                    nroRonda = (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) + 1);
                }
                else
                {
                    nroRonda = Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
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
            SqlConnection con = Conexion.obtenerConexion();

            try
            {

                DataSet ds = new DataSet();

                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT IFNULL(MAX(IdRespuesta),0) FROM Ronda", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                int nroRespuesta = (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) + 1);

                cmd = new SqlCommand("INSERT INTO Ronda VALUES (" +  nroRespuesta + ",  '" + datos, con);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("UPDATE Ronda SET " + datos + " " + where, con);

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

        public bool todosEsperando(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT * FROM BanderasJuego WHERE IdJuego = " + idJuego + " AND Bandera = 'Esperando'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                DataSet ds1 = new DataSet();

                cmd = new SqlCommand("SELECT Unidos FROM Juego WHERE Id = " + idJuego, con);

                da = new SqlDataAdapter(cmd);

                da.Fill(ds1, "Ronda");

                cmd.ExecuteNonQuery();


                con.Dispose();
                con.Close();

                return (ds.Tables[0].Rows.Count == (int)ds1.Tables[0].Rows[0].ItemArray[0]);
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
            SqlConnection con = Conexion.obtenerConexion();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("SELECT * FROM Ronda WHERE IdJuego = " + juego + " AND NroRonda = " + ronda + " AND TuttiFrutti = 1", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("UPDATE Juego SET Estado = '" + estado + "' WHERE Id = " + idJuego, con);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("Select Max(IdBandera) As M From BanderasJuego", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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

        public void eliminarBanderas(int idJuego, SqlConnection con)
        {
            try
            {
                string consulta = "DELETE FROM BanderasJuego WHERE IdJuego = " + idJuego;

                SqlCommand cmd = new SqlCommand(consulta, con);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("Select Max(Id) As M From Juego", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                int idJuego = this.obtenerUltimoIDJuego();

                UsuarioDB cdatosU = new UsuarioDB();

                int idUsuario = cdatosU.getIdUsuario(usuario);

                string consulta = "INSERT INTO Juego VALUES (" + idJuego + ", '" + nombre + "', " + idUsuario + ", " + capacidad + ", 0, 'Esperando')";

                SqlCommand cmd = new SqlCommand(consulta, con);

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                idJuego = obtenerUltimoIDJuego() -1;

                SalaDB cdatosSala = new SalaDB();
                cdatosSala.crearChat(idJuego);
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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                this.eliminarBanderas(idJuego, con);

                string consulta = "DELETE FROM Juego WHERE Id = " + idJuego;

                SqlCommand cmd = new SqlCommand(consulta, con);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                string consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE (NOT(J.Estado = 'Terminado') AND BJ.NombreUsuario = '" + usuario + "' AND NOT(J.Id = " + idJuego + "))";

                SqlCommand cmd = new SqlCommand(consulta, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "Juego");

                cmd.ExecuteNonQuery();


                consulta = "SELECT * FROM Juego WHERE Estado = 'Esperando' AND Id = " + idJuego + " AND (Capacidad - Unidos > 0)";

                cmd = new SqlCommand(consulta, con);

                da = new SqlDataAdapter(cmd);

                DataSet ds2 = new DataSet();

                da.Fill(ds2, "Juego");

                cmd.ExecuteNonQuery();


                consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE J.Estado = 'Jugando' AND BJ.NombreUsuario = '" + usuario + "' AND J.Id = " + idJuego;

                cmd = new SqlCommand(consulta, con);

                da = new SqlDataAdapter(cmd);

                DataSet ds3 = new DataSet();

                da.Fill(ds3, "Juego");

                cmd.ExecuteNonQuery();

                //----------------------------------------------------------------------

                consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE J.Estado = 'Esperando' AND BJ.NombreUsuario = '" + usuario + "' AND J.Id = " + idJuego;

                cmd = new SqlCommand(consulta, con);

                da = new SqlDataAdapter(cmd);

                DataSet ds4 = new DataSet();

                da.Fill(ds4, "Juego");

                cmd.ExecuteNonQuery();

                //----------------------------------------------------------------------


                if (ds4.Tables[0].Rows.Count == 1)
                {
                   throw new ExceptionPersonalizada("Usted ya se encuentra en la sala.");
                }
                else
                {
                    if (ds.Tables[0].Rows.Count == 0 && (ds2.Tables[0].Rows.Count == 1 || ds3.Tables[0].Rows.Count == 1))
                    {
                        int idBandera = this.obtenerUltimoIDBandera();

                        consulta = "INSERT INTO BanderasJuego VALUES (" + idBandera + ", " + idJuego + ", '" + usuario + "', 'Esperando')";

                        cmd = new SqlCommand(consulta, con);

                        cmd.ExecuteNonQuery();

                        //----------------------------------------------------------------------

                        ds = new DataSet();

                        consulta = "SELECT Unidos FROM Juego WHERE Id = " + idJuego;

                        cmd = new SqlCommand(consulta, con);

                        da = new SqlDataAdapter(cmd);

                        da.Fill(ds, "Juego");

                        cmd.ExecuteNonQuery();

                        int unidos = (int)ds.Tables[0].Rows[0].ItemArray[0];

                        consulta = "UPDATE Juego SET Unidos = ( " + unidos + " + 1) WHERE Id = " + idJuego;

                        cmd = new SqlCommand(consulta, con);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string str = "";
                        if (ds.Tables[0].Rows.Count != 0)
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
            }
            catch (Exception e)
            {
                string message;
                if (e.Message.Contains("Duplicate entry") || e.Message.Contains("crearían valores duplicados"))
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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                string consulta;
                if (where != "")
                {
                    consulta = select + " " + where + " AND NOT(Estado = 'Terminado') " + orderBy;
                }
                else
                {
                    consulta = select + " " + orderBy;
                }

                SqlCommand cmd = new SqlCommand(consulta, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                string selectB = "SELECT BJ.IdBandera, BJ.IdJuego, BJ.NombreUsuario, BJ.Bandera, U.fotoPerfil FROM BanderasJuego BJ INNER JOIN Usuario U ON BJ.NombreUsuario = U.NombreUsuario";

                string orderByB = "ORDER BY IdBandera ASC";

                string consulta;
                if (where != "")
                {
                    consulta = selectB + " " + where + " " + orderByB;
                }
                else
                {
                    consulta = select + " " + orderByB;
                }

                SqlCommand cmd = new SqlCommand(consulta, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

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
