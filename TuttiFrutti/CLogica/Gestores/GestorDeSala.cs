using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.ClasesDB;

namespace CLogica.Gestores
{
    public class GestorDeSala
    {

        public string obtenerChat(int idJuego)
        {
            try
            {
                SalaDB cdatos = new SalaDB();
                return cdatos.obtenerChat(idJuego);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void actualizarChat(int idJuego, string texto)
        {
            try
            {
                SalaDB cdatos = new SalaDB();
                cdatos.actualizarChat(idJuego, texto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
