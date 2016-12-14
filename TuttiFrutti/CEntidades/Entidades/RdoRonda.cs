using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class RdoRonda
    {
        private int puntos;
        private List<Palabra> palabras;

        public RdoRonda()
        {
            puntos = 0;
            palabras = new List<Palabra>();
        }

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

        public List<Palabra> Palabras
        {
            get
            {
                return palabras;
            }

            set
            {
                palabras = value;
            }
        }
    }
}
