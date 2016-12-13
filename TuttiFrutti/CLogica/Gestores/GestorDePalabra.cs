using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.ClasesDB;

namespace CLogica.Gestores
{
    public class GestorDePalabra
    {
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
