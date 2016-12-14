using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.ClasesDB;
using CEntidades.Entidades;

namespace CLogica.Gestores
{
    public class GestorDePalabra
    {

        public void agregarPalabrasDudosas(int idJuego, List<Palabra> palabras)
        {
            try
            {
                PalabraDB cdatos = new PalabraDB();
                foreach (Palabra palabra in palabras)
                {
                    cdatos.agregarPalabraDudosa(idJuego, palabra);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarVotos(int idJuego, List<Palabra> palabras)
        {
            try
            {
                PalabraDB cdatos = new PalabraDB();
                cdatos.agregarVotos(idJuego, palabras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void limpiarPalabrasDudosas(int idJuego)
        {
            try
            {
                PalabraDB cdatos = new PalabraDB();
                cdatos.limpiarPalabrasDudosas(idJuego);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Palabra> obtenerPalabrasDudosas(int idJuego)
        {
            try
            {
                PalabraDB cdatos = new PalabraDB();
                return cdatos.obtenerPalabrasDudosas(idJuego);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void agregarPalabra(string palabra, char letra, string categoria)
        {
            try
            {
                PalabraDB cdatos = new PalabraDB();
                cdatos.agregarPalabra(palabra, letra, categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
