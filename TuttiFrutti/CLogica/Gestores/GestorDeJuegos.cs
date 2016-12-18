using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.ClasesDB;
using System.Data;
using CEntidades.Entidades;


namespace CLogica.Gestores
{
    public class GestorDeJuegos
    {

        public bool tuttifruttiCorrecto(int idJuego, int idRonda, string usuario, char letra, List<Palabra> lp)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                PalabraDB cdatosPal = new PalabraDB();
                List<Palabra> palabras = cdatosPal.obtenerPalabras(letra);
                bool encontrado = false;
                bool correcto = true;
                foreach (Palabra pal in lp)
                {
                    foreach (Palabra p in palabras)
                    {
                        if (pal.Categoria.Equals("Objeto"))
                        {
                            encontrado = (pal.Pala.ToUpper().Equals(p.Pala.ToUpper()) && Char.ToUpper(pal.Letra) == Char.ToUpper(p.Letra));
                        }
                        else
                        {
                            encontrado = (pal.Pala.ToUpper().Equals(p.Pala.ToUpper()) && pal.Categoria.ToUpper().Equals(p.Categoria.ToUpper()) && Char.ToUpper(pal.Letra) == Char.ToUpper(p.Letra));
                        }
                        if (encontrado)
                        {
                            break;
                        }
                    }
                    correcto = encontrado;
                    if (!correcto)
                    {
                        break;
                    }
                }
                return correcto;
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }

        }

        public bool todosEsperando(int idJuego)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                return cdatos.todosEsperando(idJuego);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public List<Palabra> obtenerPalabrasDudosas(int idJuego, int nroRonda, string usuario)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                List<string> ronda = cdatos.obtenerDatosRonda(idJuego, nroRonda, usuario);
                char letra = ronda[0][0];
                List<Palabra> lp = new List<Palabra>();
                for (int i = 1; i < ronda.Count(); i++)
                {
                    string categoria = "";
                    switch (i)
                    {
                        case 1:
                            categoria = "Nombre";
                            break;
                        case 2:
                            categoria = "Animal";
                            break;
                        case 3:
                            categoria = "Color";
                            break;
                        case 4:
                            categoria = "Objeto";
                            break;
                        case 5:
                            categoria = "Lugar";
                            break;
                        case 6:
                            categoria = "Comida";
                            break;
                    }
                    Palabra pal = cdatos.obtenerPalabrasDudosas(idJuego, nroRonda, usuario, letra, ronda[i], categoria);
                    if(pal.Pala != "")
                    {
                        lp.Add(pal);
                    }
                }
                return lp;
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public int calcularPuntaje(int idJuego, int nroRonda, string usuario)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                List<string> ronda = cdatos.obtenerDatosRonda(idJuego, nroRonda, usuario);
                char letra = ronda[0][0];
                int puntaje = 0;
                for(int i = 1; i<ronda.Count(); i++)
                {
                    string categoria = "";
                    switch (i)
                    {
                        case 1:
                            categoria = "Nombre";
                            break;
                        case 2:
                            categoria = "Animal";
                            break;
                        case 3:
                            categoria = "Color";
                            break;
                        case 4:
                            categoria = "Objeto";
                            break;
                        case 5:
                            categoria = "Lugar";
                            break;
                        case 6:
                            categoria = "Comida";
                            break;
                    }
                    int puntos = cdatos.obtenerPuntosPalabra(idJuego, nroRonda, usuario, letra, ronda[i], categoria);
                    puntaje += puntos;
                }
                cdatos.actualizarPuntajeRonda(idJuego, nroRonda, usuario, puntaje);
                return puntaje;
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
        public int obtenerNroRonda(string usuario, int idJuego)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                return cdatos.obtenerNroRonda(usuario, idJuego);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void crearRonda(string usuario, int idJuego, int nroRonda, char letra)
        {
            try
            {
                string datos = usuario + "', " + idJuego + ", " + nroRonda + ", '" + letra + "', NULL, NULL, NULL, NULL, NULL, NULL, 0, 0)";
                JuegosDB cdatos = new JuegosDB();
                cdatos.crearRonda(datos);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }
        public void cargarRonda(string usuario, int idJuego, int nroRonda, char letra, string nombre, string animal, string color, string objeto, string lugar, string comida, bool tuttifrutti)
        {
            try
            {
                //string datos = "Jugador = '" + usuario + "',";
                string datos = "";
                if(nombre != "")
                {
                    datos += "Nombre = '" + nombre + "',";
                }
                if(animal != "")
                {
                    datos += "Animal = '" + animal + "',";
                }
                if (color != "")
                {
                    datos += "Color = '" + color + "',";
                }
                if (objeto != "")
                {
                    datos += "Objeto = '" + objeto + "',";
                }
                if (lugar != "")
                {
                    datos += "Lugar = '" + lugar + "',";
                }
                if (comida != "")
                {
                    datos += "Comida = '" + comida + "',";
                }
                if (tuttifrutti)
                {
                    datos += "TuttiFrutti = 1,";
                }
                if(datos != "")
                {
                    datos = datos.Remove(datos.LastIndexOf(','));
                    string where = "WHERE Jugador = '" + usuario + "' AND IdJuego = " + idJuego + " AND NroRonda = " + nroRonda;
                    JuegosDB cdatos = new JuegosDB();
                    cdatos.cargarRonda(datos, where);
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }

        }

        public bool hayTuttiFrutti(int juego, int ronda)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                return cdatos.hayTuttiFrutti(juego, ronda);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

        public void modificarEstado(int idJuego, string estado)
        {
            try
            {
                JuegosDB cdatos = new JuegosDB();
                cdatos.modificarEstado(idJuego, estado);
            }
            catch (Exception ex)
            {
                throw new ExceptionPersonalizada(ex.Message);
            }
        }

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
                where += "U.NombreUsuario LIKE '" + prop + "%' AND ";
            }
            if(nom != "")
            {
                where += "J.Nombre LIKE '" + nom + "%' AND ";
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
