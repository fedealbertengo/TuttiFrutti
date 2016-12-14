using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLogica.Gestores;
using CEntidades.Entidades;

namespace CPresentacion.Pantallas
{
    public partial class AgregarPalabra : Form
    {
        int idJuego;
        List<Palabra> palabras;
        public AgregarPalabra()
        {
            InitializeComponent();
        }

        public AgregarPalabra(int idJue, List<Palabra> pal)
        {
            palabras = pal;
            idJuego = idJue;
            InitializeComponent();
        }

        private void AgregarPalabra_Load(object sender, EventArgs e)
        {
            GestorDePalabra clogPal = new GestorDePalabra();
            //dgvPalabrasDudosas.DataSource = clogPal.obtenerPalabrasDudosas(idJuego).Select(pal => new { pal.Pala, pal.Categoria }).ToList();
            dgvPalabrasDudosas.DataSource = palabras.Select(pal => new { pal.Pala, pal.Categoria }).ToList();
        }

        private void AgregarPalabra_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void btnAgregarPalabras_Click(object sender, EventArgs e)
        {
            GestorDePalabra clogPal = new GestorDePalabra();
            List<Palabra> palabrasSeleccionadas = new List<Palabra>();
            foreach(DataRow fila in dgvPalabrasDudosas.SelectedRows)
            {
                Palabra palabra = palabras.First<Palabra>(pal => pal.Pala.Equals(fila.ItemArray[0]) && pal.Categoria.Equals(fila.ItemArray[1]));
                if(palabra != null)
                {
                    palabrasSeleccionadas.Add(palabra);
                }
            }
            clogPal.agregarVotos(idJuego, palabrasSeleccionadas);
        }
    }
}
