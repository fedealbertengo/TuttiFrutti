using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.ClasesDB
{
    public class UsuarioDB
    {

        public int getIdUsuario(string nombre)
        {
            DataSet ds = new DataSet();
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("Select Id From Usuario Where NombreUsuario = \"" + nombre + "\"", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Usuario");

                cmd.ExecuteNonQuery();

                string idStr = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                int id = Int32.Parse(idStr);
                con.Dispose();
                con.Close();
                return (id);
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(e.Message);
            }
        }


        public void cambiarEstado(string usuario, string estado)
        {
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);
                SqlCommand cmd = new SqlCommand("UPDATE BanderasJuego SET Bandera = \"" + estado + "\" WHERE NombreUsuario = \"" + usuario + "\"", con);
                cmd.ExecuteNonQuery();
                con.Dispose();
                con.Close();
            }
            catch(Exception ex)
            {
                con.Dispose();
                con.Close();
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public int obtenerUltimoId()
        {
            DataSet ds = new DataSet();
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                SqlCommand cmd = new SqlCommand("Select Max(Id) As M From Usuario", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Usuario");

                cmd.ExecuteNonQuery();

                string proxIDStr = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                int proxID;
                if(proxIDStr == "")
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

        public void registrarUsuario(string nombre, string contraseña)
        {
            SqlConnection con = Conexion.obtenerConexion();
            try
            {
                Conexion.conectar(con);

                int ultId = obtenerUltimoId();

                string strConsulta = "INSERT INTO Usuario VALUES (" + ultId + ", \"" + nombre + "\", \"" + contraseña + "\")";
                SqlCommand cmd = new SqlCommand(strConsulta, con);

                cmd.ExecuteNonQuery();
                con.Dispose();
                con.Close();
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                string message;
                if (e.Message.Contains("create duplicate values"))
                {
                    message = "Alguno de los valores introducidos ya existe en la base de datos.";
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
        public void iniciarSesion(string nombre, string contraseña)
        {
            SqlConnection con = Conexion.obtenerConexion();
            DataSet ds = new DataSet();
            try
            {
                Conexion.conectar(con);

                string strConsulta = "SELECT * FROM Usuario WHERE NombreUsuario = \"" + nombre + "\" AND Contraseña = \"" + contraseña + "\"";
                SqlCommand cmd = new SqlCommand(strConsulta, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Usuario");

                cmd.ExecuteNonQuery();

                if (ds.Tables[0].Rows.Count != 1)
                {
                    throw new ExceptionPersonalizada("Error, los datos no son correctos.");
                }
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
            finally
            {
                con.Dispose();
                con.Close();
            }
        }
    }
}
