using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidades.Entidades;
using System.Data;

namespace CDatos.SQLServer
{
    public class PalabraDB
    {

        public List<Palabra> obtenerPalabras(char letra)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {

                Conexion.conectar(con);

                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("SELECT Palabra, Categoria, Letra FROM Palabras WHERE Letra = '" + letra + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                Palabra pal;
                List<Palabra> palabrasDudosas = new List<Palabra>();
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    pal = new Palabra();
                    pal.Pala = fila.ItemArray[0].ToString();
                    pal.Categoria = fila.ItemArray[1].ToString();
                    pal.Letra = fila.ItemArray[2].ToString()[0];
                    palabrasDudosas.Add(pal);
                }
                return palabrasDudosas;
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw ex;
            }

        }

        public List<Palabra> obtenerPalabrasDudosas(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {

                Conexion.conectar(con);

                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("SELECT Palabra, Categoria, Letra FROM PalabrasDudosas WHERE IdJuego = " + idJuego, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Ronda");

                cmd.ExecuteNonQuery();

                con.Dispose();
                con.Close();

                Palabra pal;
                List<Palabra> palabrasDudosas = new List<Palabra>();
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    pal = new Palabra();
                    pal.Pala = fila.ItemArray[0].ToString();
                    pal.Categoria = fila.ItemArray[1].ToString();
                    pal.Letra = fila.ItemArray[2].ToString()[0];
                    palabrasDudosas.Add(pal);
                }
                return palabrasDudosas;
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw ex;
            }

        }

        public void limpiarPalabrasDudosas(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {
                Conexion.conectar(con);

                string strConsulta = "DELETE FROM PalabrasDudosas WHERE IdJuego = " + idJuego;
                SqlCommand cmd = new SqlCommand(strConsulta, con);

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
        public void agregarVotos(int idJuego, List<Palabra> palabras)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {
                List<Palabra> palabrasDudosas = this.obtenerPalabrasDudosas(idJuego);

                foreach (Palabra pal in palabrasDudosas)
                {
                    if (palabras.Contains(pal))
                    {
                        string strConsulta = "UPDATE PalabrasDudosas SET votos = (SELECT votos FROM PalabrasDudosas WHERE (idJuego = " + idJuego + " AND palabra = '" + pal.Pala + "' AND categoria = '" + pal.Categoria + "')) + 1, aprobados = (SELECT aprobados FROM PalabrasDudosas WHERE (idJuego = " + idJuego + " AND palabra = '" + pal.Pala + "' AND categoria = '" + pal.Categoria + "')) + 1 WHERE (idJuego = " + idJuego + " AND palabra = '" + pal.Pala + "' AND categoria = '" + pal.Categoria + "')";
                        SqlCommand cmd = new SqlCommand(strConsulta, con);

                        cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        string strConsulta = "UPDATE PalabrasDudosas SET votos = (SELECT votos FROM PalabrasDudosas WHERE (idJuego = " + idJuego + " AND palabra = '" + pal.Pala + "' AND categoria = '" + pal.Categoria + "')) + 1 WHERE (idJuego = " + idJuego + " AND palabra = '" + pal.Pala + "' AND categoria = '" + pal.Categoria + "')";
                        SqlCommand cmd = new SqlCommand(strConsulta, con);

                        cmd.ExecuteNonQuery();
                    }
                }

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

        public List<Palabra> obtenerPalabrasDudosasAprobadas(int idJuego)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {
                Conexion.conectar(con);

                string strConsulta = "SELECT Palabra, Categoria, Letra FROM PalabrasDudosas WHERE IdJuego = " + idJuego + " AND Aprobados > ((Votos / 2) + 1)";
                SqlCommand cmd = new SqlCommand(strConsulta, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "PalabrasDudosas");

                cmd.ExecuteNonQuery();

                List<Palabra> lp = new List<Palabra>();
                Palabra p;

                foreach(DataRow fila in ds.Tables[0].Rows){
                    p = new Palabra();
                    p.Pala = fila.ItemArray[0].ToString();
                    p.Categoria = fila.ItemArray[1].ToString();
                    p.Letra = fila.ItemArray[2].ToString()[0];
                    lp.Add(p);
                }

                return lp;
            }
            catch (Exception ex)
            {
                con.Dispose();
                con.Close();
                throw ex;
            }

        }

        public void agregarPalabraDudosa(int idJuego, Palabra palabra)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {
                Conexion.conectar(con);

                string strConsulta = "SELECT IFNULL(MAX(Id), 0) FROM PalabrasDudosas WHERE IdJuego = " + idJuego;
                SqlCommand cmd = new SqlCommand(strConsulta, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "PalabrasDudosas");

                cmd.ExecuteNonQuery();

                strConsulta = "INSERT INTO PalabrasDudosas VALUES (" + (Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()) + 1) + ", " + idJuego +", '" + palabra.Pala + "', '" + palabra.Categoria + "', '" + palabra.Letra + "', 0, 0)";
                cmd = new SqlCommand(strConsulta, con);

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

        public void agregarPalabra(string palabra, char letra, string categoria)
        {
            SqlConnection con = Conexion.obtenerConexionSQLServer();
            try
            {
                Conexion.conectar(con);

                string strConsulta = "INSERT INTO Palabras VALUES ('" + palabra + "', '" + categoria + "', '" + letra + "')";
                SqlCommand cmd = new SqlCommand(strConsulta, con);

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
