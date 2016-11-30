using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.ClasesDB;
using System.Data;

namespace CLogica.Gestores
{
    public class GestorDeJuegos
    {
        public void unirUsuarioAJuego(int idJuego)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                string usuario = GestorDeUsuario.getUsuarioLogeado();
                cdatos.unirUsuarioAJuego(idJuego, usuario);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void agregarSala(string nombre, int capacidad)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                cdatos.agregarSala(nombre, GestorDeUsuario.getUsuarioLogeado(), capacidad);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void eliminarJuego(int idJuego, string propietario)
        {
            try
            {
                string usuario = GestorDeUsuario.getUsuarioLogeado();
                if (usuario == propietario)
                {
                    JuegosDB cdatos = new JuegosDB();
                    cdatos.eliminarJuego(idJuego);
                }
                else
                {
                    throw new ExceptionPersonalizada("Ustede no puede eliminar la sala porque no es el propietario.");
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }

        }

        public DataSet getJuegos(int idJuego)
        {
            string where = "WHERE J.Id = " + idJuego;
            try
            {
                JuegosDB cdatos = new JuegosDB();
                return cdatos.getJuegos(where);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public DataSet getBanderas(int idJuego)
        {
            string where = "WHERE IdJuego = " + idJuego;
            try
            {
                JuegosDB cdatos = new JuegosDB();
                return cdatos.getBanderas(where);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public DataSet getJuegos(string prop, string nom, bool llenas, bool vacias)
        {
            string where = "WHERE ";
            if(prop != "")
            {
                where += "U.NombreUsuario LIKE \"" + prop + "%\" AND ";
            }
            if(nom != "")
            {
                where += "J.Nombre LIKE \"" + nom + "%\" AND ";
            }
            if (llenas)
            {
                where += "((J.Capacidad - J.Unidos) > 0) AND ";
            }
            if (vacias)
            {
                where += "J.Unidos > 0 AND ";
            }
            where = where.Remove((where.Length - 5), 5);
            if (where.Equals("W"))
            {
                where = "";
            }
            try
            {
                JuegosDB cdatos = new JuegosDB();
                return cdatos.getJuegos(where);
            }
            catch(Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
    }
}
