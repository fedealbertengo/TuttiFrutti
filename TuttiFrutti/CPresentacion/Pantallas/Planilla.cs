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
using CPresentacion.Pantallas;

namespace CPresentacion.Pantallas
{
    public partial class Planilla : Form
    {

        public int idJuego;
        public int nroRonda;
        public bool tuttiFrutti = false;
        int empezar;
        int terminar = 3000;
        public Planilla()
        {
            InitializeComponent();
        }

        public Planilla(int idJue)
        {
            idJuego = idJue;
            InitializeComponent();
        }

        private void Planilla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void Planilla_Load(object sender, EventArgs e)
        {
            empezar = 3000;
            GestorDeJuegos clogJue = new GestorDeJuegos();
            nroRonda = clogJue.obtenerNroRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego);
            clogJue.crearRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0]);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            if(empezar == 0)
            {
                if (clogJue.hayTuttiFrutti(idJuego, nroRonda))
                {
                    terminar = 3000;
                    btnTuttiFrutti.Enabled = false;
                    if (!tuttiFrutti)
                    {
                        clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbRopa.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, tbDeporte.Text, false);
                        nroRonda++;
                    }
                    else
                    {
                        tuttiFrutti = false;
                    }
                }
            }
            else
            {
                if (empezar - 1 == 0)
                {
                    btnTuttiFrutti.Enabled = true;
                }
                empezar--;
            }
            if(terminar == 0)
            {
                this.Close();
            }
            else
            {
                terminar--;
            }
        }

        private void btnTuttiFrutti_Click(object sender, EventArgs e)
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado, idJuego, nroRonda, lblLetra.Text, tbNombre.Text, tbAnimal.Text, tbColor.Text, tbRopa.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, tbDeporte.Text, true);
            tuttiFrutti = true;
        }
    }
}
