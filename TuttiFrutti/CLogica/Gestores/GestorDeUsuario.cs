using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.MySQL;

namespace CLogica.Gestores
{
    public class GestorDeUsuario
    {
        public static string usuarioLogeado;

        public bool algunoEstadoReiniciar(int idJuego)
        {
            UsuarioDB cdatos = new UsuarioDB();
            try
            {
                return cdatos.algunoEstadoReiniciar(idJuego);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public string obtnerEstadoJugador(string usuario)
        {
            UsuarioDB cdatos = new UsuarioDB();
            try
            {
                return cdatos.obtnerEstadoJugador(usuario);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public static string getUsuarioLogeado()
        {
            return usuarioLogeado;
        }

        public void cambiarEstado(string usuario, string estado)
        {
            UsuarioDB cdatos = new UsuarioDB();
            try
            {
                cdatos.cambiarEstado(usuario, estado);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void registrarUsuario(string nombre, string contraseña, byte[] imagen)
        {
            UsuarioDB cdatos = new UsuarioDB();
            try
            {
                if (nombre != "" && contraseña != "")
                {
                    cdatos.registrarUsuario(nombre, contraseña, imagen);
                }
                else
                {
                    string strError = "";
                    if (nombre == "")
                    {
                        strError += "El campo nombre debe estar completo.\n";
                    }
                    if(contraseña == "")
                    {
                        strError += "El campo contraseña debe estar completo.\n";
                    }
                    strError.Remove(strError.LastIndexOf('\n'));
                    throw new ExceptionPersonalizada(strError);
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
        public static void iniciarSesion(string nombre, string contraseña)
        {
            UsuarioDB cdatos = new UsuarioDB();
            try
            {
                if (nombre != "" && contraseña != "")
                {
                    cdatos.iniciarSesion(nombre, contraseña);
                    usuarioLogeado = nombre;
                }
                else
                {
                    string strError = "";
                    if (nombre == "")
                    {
                        strError += "El campo nombre debe estar completo.\n";
                    }
                    if (contraseña == "")
                    {
                        strError += "El campo contraseña debe estar completo.\n";
                    }
                    strError.Remove(strError.LastIndexOf('\n'));
                    throw new ExceptionPersonalizada(strError);
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
    }
}
