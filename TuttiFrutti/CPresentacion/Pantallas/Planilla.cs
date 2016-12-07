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
            GestorDeJuegos clogJue = new GestorDeJuegos();
            try
            {
                Random rnd = new Random();
                char letra = (char)((rnd.Next() % 26) + 65);
                lblLetra.Text = letra.ToString();
                nroRonda = clogJue.obtenerNroRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego);
                clogJue.crearRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0]);
                btnTuttiFrutti.Enabled = false;
                tbNombre.Enabled = false;
                tbAnimal.Enabled = false;
                tbColor.Enabled = false;
                tbComida.Enabled = false;
                tbLugar.Enabled = false;
                tbDeporte.Enabled = false;
                tbObjeto.Enabled = false;
                tbRopa.Enabled = false;
                empezar = 300;
                timer.Enabled = true;
            }
            catch(Exception ex){
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            try
            {
                if (empezar == 0)
                {
                    if (clogJue.hayTuttiFrutti(idJuego, nroRonda))
                    {
                        terminar = 300;
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
                        tbNombre.Enabled = true;
                        tbAnimal.Enabled = true;
                        tbColor.Enabled = true;
                        tbComida.Enabled = true;
                        tbLugar.Enabled = true;
                        tbDeporte.Enabled = true;
                        tbObjeto.Enabled = true;
                        tbRopa.Enabled = true;
                    }
                    empezar--;
                }
                if (terminar == 0)
                {
                    this.Close();
                }
                else
                {
                    terminar--;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTuttiFrutti_Click(object sender, EventArgs e)
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            try
            {
                if (tbNombre.Text != "" && tbAnimal.Text != "" && tbColor.Text != "" && tbObjeto.Text != "" && tbLugar.Text != "" && tbRopa.Text != "" && tbDeporte.Text != "" && tbComida.Text != "")
                {
                    clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbRopa.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, tbDeporte.Text, true);
                    tuttiFrutti = true;
                }
                else
                {
                    MessageBox.Show(("Debe completar todos los campos."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
