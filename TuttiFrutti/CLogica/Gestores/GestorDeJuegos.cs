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

        public DataSet getJuegos(string prop, string nom, bool llenas, bool vacias)
        {
            string where = "";
            try
            {
                JuegosDB cdatos = new JuegosDB();
                if(prop == "")
                {
                    if(nom == "")
                    {
                        if (!llenas)
                        {
                            if (!vacias)
                            {
                                where = "";
                            }
                            else
                            {
                                where = "WHERE J.Unidos > 0";
                            }
                        }
                        else
                        {
                            if (!vacias)
                            {
                                where = "WHERE ((J.Capacidad - J.Unidos) > 0)";
                            }
                            else
                            {
                                where = "WHERE J.Unidos > 0 AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                        }
                    }
                    else
                    {
                        if (!llenas)
                        {
                            if (!vacias)
                            {
                                where = "WHERE J.Nombre LIKE \"" + nom + "%\"";
                            }
                            else
                            {
                                where = "WHERE J.Nombre LIKE \"" + nom + "%\" AND J.Unidos > 0";
                            }
                        }
                        else
                        {
                            if (!vacias)
                            {
                                where = "WHERE J.Nombre LIKE \"" + nom + "%\" AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                            else
                            {
                                where = "WHERE J.Nombre LIKE \"" + nom + "%\" AND J.Unidos > 0 AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                        }
                    }
                }
                else
                {
                    if (nom == "")
                    {
                        if (!llenas)
                        {
                            if (!vacias)
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\"";
                            }
                            else
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND J.Unidos > 0";
                            }
                        }
                        else
                        {
                            if (!vacias)
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                            else
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND J.Unidos > 0 AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                        }
                    }
                    else
                    {
                        if (!llenas)
                        {
                            if (!vacias)
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND J.Nombre LIKE \"" + nom + "%\"";
                            }
                            else
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND J.Nombre LIKE \"" + nom + "%\" AND J.Unidos > 0";
                            }
                        }
                        else
                        {
                            if (!vacias)
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND J.Nombre LIKE \"" + nom + "%\" AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                            else
                            {
                                where = "WHERE U.NombreUsuario LIKE \"" + prop + "%\" AND J.Nombre LIKE \"" + nom + "%\" AND J.Unidos > 0 AND ((J.Capacidad - J.Unidos) > 0)";
                            }
                        }
                    }
                }
                return cdatos.getJuegos(where);
            }
            catch(Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
    }
}
