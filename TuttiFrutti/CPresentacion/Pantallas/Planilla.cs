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
using CEntidades.Entidades;

namespace CPresentacion.Pantallas
{
    public partial class Planilla : Form
    {

        public int idJuego;
        public int nroRonda;
        public bool tuttiFrutti = false;
        int empezar;
        int terminar = 3000;
        bool agregandoPalabras = false;
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
                tbObjeto.Enabled = false;
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
                        timer.Enabled = false;
                        terminar = 300;
                        timer1.Enabled = true;
                        btnTuttiFrutti.Enabled = false;
                        tbNombre.Enabled = false;
                        tbAnimal.Enabled = false;
                        tbColor.Enabled = false;
                        tbComida.Enabled = false;
                        tbLugar.Enabled = false;
                        tbObjeto.Enabled = false;
                        if (!tuttiFrutti)
                        {
                            clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, false);
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
                        tbObjeto.Enabled = true;
                    }
                    empezar--;
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
                if (tbNombre.Text != "" && tbAnimal.Text != "" && tbColor.Text != "" && tbObjeto.Text != "" && tbLugar.Text != "" && tbComida.Text != "")
                {
                    timer.Enabled = false;
                    terminar = 300;
                    timer1.Enabled = true;
                    clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, true);
                    tuttiFrutti = true;
                    btnTuttiFrutti.Enabled = false;
                    tbNombre.Enabled = false;
                    tbAnimal.Enabled = false;
                    tbColor.Enabled = false;
                    tbComida.Enabled = false;
                    tbLugar.Enabled = false;
                    tbObjeto.Enabled = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (terminar == 0)
            {
                timer1.Enabled = false;
                this.Close();
            }
            else
            {
                if (terminar == 200)
                {
                    terminar--;
                    GestorDeJuegos clogJue = new GestorDeJuegos();
                    RdoRonda resultado = clogJue.calcularPuntaje(idJuego, nroRonda, GestorDeUsuario.getUsuarioLogeado());
                    GestorDePalabra clogPal = new GestorDePalabra();
                    resultado.Palabras = resultado.Palabras.Union(resultado.Palabras).ToList();
                    clogPal.agregarPalabrasDudosas(idJuego, resultado.Palabras);
                    resultado.Palabras.RemoveAll(pal => pal.Pala.Equals(tbAnimal.Text) || pal.Pala.Equals(tbColor.Text) || pal.Pala.Equals(tbNombre.Text) || pal.Pala.Equals(tbComida.Text) || pal.Pala.Equals(tbLugar.Text) || pal.Pala.Equals(tbObjeto.Text));
                    MessageBox.Show("Felicitaicones, su puntaje fue: " + resultado.Puntos, "Ronda completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timer1.Stop();
                    agregandoPalabras = true;
                    this.Hide();
                    AgregarPalabra agregarPalabras = new AgregarPalabra(idJuego, resultado.Palabras);
                    agregarPalabras.Show(this);
                }
                else
                {
                    terminar--;
                }
            }
        }

        private void Planilla_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible && agregandoPalabras)
            {
                timer1.Start();
                GestorDePalabra clogPal = new GestorDePalabra();
                clogPal.limpiarPalabrasDudosas(idJuego);
            }
        }
    }
}
