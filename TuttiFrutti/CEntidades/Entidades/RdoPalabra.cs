using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class RdoPalabra
    {
        private int puntos;
        private Palabra palabra;

        public int Puntos
        {
            get
            {
                return puntos;
            }

            set
            {
                puntos = value;
            }
        }

        public Palabra Palabra
        {
            get
            {
                return palabra;
            }

            set
            {
                palabra = value;
            }
        }
    }
}
