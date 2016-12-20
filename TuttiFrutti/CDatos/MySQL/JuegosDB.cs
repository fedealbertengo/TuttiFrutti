using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidades.Entidades;
using MySql.Data.MySqlClient;

namespace CDatos.MySQL
{
    public class JuegosDB
    {
        string select = "SELECT J.Id, J.Nombre, U.NombreUsuario, J.Unidos, J.Capacidad, J.Estado FROM Juego J INNER JOIN Usuario U ON J.IdPropietario = U.Id";
        string orderBy = "ORDER BY J.Nombre ASC";

        public void actualizarPuntajeRonda(int idJuego, int nroRonda, string usuario, int puntaje)
        {
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("UPDATE Ronda SET Puntos = " + puntaje + " WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND Jugador = \"" + usuario + "\"", con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

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
                    where = "WHERE Palabra = \"" + palabra + "\" AND Letra = \"" + letra + "\"";
                }
                else
                {
                    where = "WHERE Palabra = \"" + palabra + "\" AND Categoria = \"" + categoria + "\" AND Letra = \"" + letra + "\"";
                }

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Palabras " + where, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Palabras " + where, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                DataSet ds1 = new DataSet();

                cmd = new MySqlCommand("SELECT * FROM Ronda WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND " + categoria + " = \"" + palabra + "\" AND NOT(Jugador = \"" + usuario + "\")", con);

                da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT U.NombreUsuario FROM Juego J INNER JOIN Usuario U ON J.IdPropietario = U.Id WHERE J.Id = " + idJuego, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                List<string> lista = new List<string>();

                DataSet ds = new DataSet();
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT Letra, Nombre, Animal, Color, Objeto, Lugar, Comida FROM Ronda WHERE IdJuego = " + idJuego + " AND NroRonda = " + nroRonda + " AND Jugador = \"" + usuario + "\"", con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT IFNULL(MAX(nroRonda),0), IF(EXISTS(SELECT * FROM Ronda WHERE IdJuego = " + juego + " AND TuttiFrutti = 1),1,0) FROM Ronda WHERE IdJuego = " + juego, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {

                DataSet ds = new DataSet();

                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT IFNULL(MAX(IdRespuesta),0) FROM Ronda", con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                int nroRespuesta = (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) + 1);

                cmd = new MySqlCommand("INSERT INTO Ronda VALUES (" +  nroRespuesta + ",  \"" + datos, con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("UPDATE Ronda SET " + datos + " " + where, con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM BanderasJuego WHERE IdJuego = " + idJuego + " AND Bandera = \"Esperando\"", con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                DataSet ds1 = new DataSet();

                cmd = new MySqlCommand("SELECT Unidos FROM Juego WHERE Id = " + idJuego, con);

                da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();

            try
            {
                DataSet ds = new DataSet();
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Ronda WHERE IdJuego = " + juego + " AND NroRonda = " + ronda + " AND TuttiFrutti = 1", con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("UPDATE Juego SET Estado = \"" + estado + "\" WHERE Id = " + idJuego, con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("Select Max(IdBandera) As M From BanderasJuego", con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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

        public void eliminarBanderas(int idJuego, MySqlConnection con)
        {
            try
            {
                string consulta = "DELETE FROM BanderasJuego WHERE IdJuego = " + idJuego;

                MySqlCommand cmd = new MySqlCommand(consulta, con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                MySqlCommand cmd = new MySqlCommand("Select Max(Id) As M From Juego", con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                int idJuego = this.obtenerUltimoIDJuego();

                UsuarioDB cdatosU = new UsuarioDB();

                int idUsuario = cdatosU.getIdUsuario(usuario);

                string consulta = "INSERT INTO Juego VALUES (" + idJuego + ", \"" + nombre + "\", " + idUsuario + ", " + capacidad + ", 0, \"Esperando\")";

                MySqlCommand cmd = new MySqlCommand(consulta, con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                this.eliminarBanderas(idJuego, con);

                string consulta = "DELETE FROM Juego WHERE Id = " + idJuego;

                MySqlCommand cmd = new MySqlCommand(consulta, con);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
            try
            {
                Conexion.conectar(con);

                string consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE (NOT(J.Estado = \"Terminado\") AND BJ.NombreUsuario = \"" + usuario + "\" AND NOT(J.Id = " + idJuego + "))";

                MySqlCommand cmd = new MySqlCommand(consulta, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "Juego");

                cmd.ExecuteNonQuery();


                consulta = "SELECT * FROM Juego WHERE Estado = \"Esperando\" AND Id = " + idJuego + " AND (Capacidad - Unidos > 0)";

                cmd = new MySqlCommand(consulta, con);

                da = new MySqlDataAdapter(cmd);

                DataSet ds2 = new DataSet();

                da.Fill(ds2, "Juego");

                cmd.ExecuteNonQuery();


                consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE J.Estado = \"Jugando\" AND BJ.NombreUsuario = \"" + usuario + "\" AND J.Id = " + idJuego;

                cmd = new MySqlCommand(consulta, con);

                da = new MySqlDataAdapter(cmd);

                DataSet ds3 = new DataSet();

                da.Fill(ds3, "Juego");

                cmd.ExecuteNonQuery();

                //----------------------------------------------------------------------

                consulta = "SELECT * FROM BanderasJuego BJ INNER JOIN Juego J ON BJ.IdJuego = J.Id WHERE J.Estado = \"Esperando\" AND BJ.NombreUsuario = \"" + usuario + "\" AND J.Id = " + idJuego;

                cmd = new MySqlCommand(consulta, con);

                da = new MySqlDataAdapter(cmd);

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

                        consulta = "INSERT INTO BanderasJuego VALUES (" + idBandera + ", " + idJuego + ", \"" + usuario + "\", \"Esperando\")";

                        cmd = new MySqlCommand(consulta, con);

                        cmd.ExecuteNonQuery();

                        //----------------------------------------------------------------------

                        ds = new DataSet();

                        consulta = "SELECT Unidos FROM Juego WHERE Id = " + idJuego;

                        cmd = new MySqlCommand(consulta, con);

                        da = new MySqlDataAdapter(cmd);

                        da.Fill(ds, "Juego");

                        cmd.ExecuteNonQuery();

                        int unidos = (int)ds.Tables[0].Rows[0].ItemArray[0];

                        consulta = "UPDATE Juego SET Unidos = ( " + unidos + " + 1) WHERE Id = " + idJuego;

                        cmd = new MySqlCommand(consulta, con);

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
                        str = str.Remove(str.LastIndexOf('n'));
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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
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

                MySqlCommand cmd = new MySqlCommand(consulta, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
            MySqlConnection con = Conexion.obtenerConexionMySQL();
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

                MySqlCommand cmd = new MySqlCommand(consulta, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

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
