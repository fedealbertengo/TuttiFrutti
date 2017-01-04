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
        int terminar = 3;
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
                DataTable juego = clogJue.getJuegos(idJuego).Tables[0];
                nroRonda = clogJue.obtenerNroRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego);
                char letra = clogJue.obtenerLetraRonda(idJuego, nroRonda);
                lblLetra.Text = letra.ToString();
                if (!GestorDeUsuario.getUsuarioLogeado().Equals(juego.Rows[0].ItemArray[2]))
                {
                    clogJue.crearRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0]);
                }
                btnTuttiFrutti.Enabled = false;
                tbNombre.Enabled = false;
                tbAnimal.Enabled = false;
                tbColor.Enabled = false;
                tbComida.Enabled = false;
                tbLugar.Enabled = false;
                tbObjeto.Enabled = false;
                empezar = 3;
                timer.Enabled = true;

            }
            catch (Exception ex){
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
                        terminar = 3;
                        timer1.Enabled = true;
                        btnTuttiFrutti.Enabled = false;
                        tbNombre.Enabled = false;
                        tbAnimal.Enabled = false;
                        tbColor.Enabled = false;
                        tbComida.Enabled = false;
                        tbLugar.Enabled = false;
                        tbObjeto.Enabled = false;
                        clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, false);
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
                    clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], "", "", "", "", "", "", true);
                    this.agregarPalabrasDudosas();
                    timer.Enabled = false;
                    terminar = 3;
                    timer1.Enabled = true;
                    //clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, true);
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

        private void agregarPalabrasDudosas()
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            List<Palabra> palabrasDudosas = clogJue.obtenerPalabrasDudosas(idJuego);
            GestorDePalabra clogPal = new GestorDePalabra();
            List<Palabra> lp = new List<Palabra>();
            List<Palabra> palabrasRonda = new List<Palabra>();
            palabrasRonda.Add(new Palabra { Pala = tbNombre.Text, Categoria = "Nombre", Letra = (lblLetra.Text)[0] });
            palabrasRonda.Add(new Palabra { Pala = tbAnimal.Text, Categoria = "Animal", Letra = (lblLetra.Text)[0] });
            palabrasRonda.Add(new Palabra { Pala = tbColor.Text, Categoria = "Color", Letra = (lblLetra.Text)[0] });
            palabrasRonda.Add(new Palabra { Pala = tbComida.Text, Categoria = "Comida", Letra = (lblLetra.Text)[0] });
            palabrasRonda.Add(new Palabra { Pala = tbLugar.Text, Categoria = "Lugar", Letra = (lblLetra.Text)[0] });
            palabrasRonda.Add(new Palabra { Pala = tbObjeto.Text, Categoria = "Objeto", Letra = (lblLetra.Text)[0] });
            List<Palabra> palabrasDudosasRonda = clogJue.obtenerPalabrasDudosas(idJuego, nroRonda, GestorDeUsuario.getUsuarioLogeado(), palabrasRonda);
            foreach (Palabra pal in palabrasDudosasRonda)
            {
                if (lp.All(p => p.Pala != pal.Pala || p.Categoria != pal.Categoria))
                {
                    lp.Add(pal);
                }
            }
            palabrasDudosas = lp;
            clogPal.agregarPalabrasDudosas(idJuego, palabrasDudosas);
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
                if (terminar == 2)
                {
                    terminar--;
                    try
                    {
                        if (!tuttiFrutti)
                        {
                            this.agregarPalabrasDudosas();
                        }
                        GestorDePalabra clogPal = new GestorDePalabra();
                        List<Palabra> palabrasDudosas = clogPal.obtenerPalabrasDudosas(idJuego);
                        palabrasDudosas.RemoveAll(pal => (pal.Pala.Equals(tbAnimal.Text) && pal.Categoria.Equals("Animal")) || (pal.Pala.Equals(tbColor.Text) && pal.Categoria.Equals("Color")) || (pal.Pala.Equals(tbNombre.Text) && pal.Categoria.Equals("Nombre")) || (pal.Pala.Equals(tbComida.Text) && pal.Categoria.Equals("Comida")) || (pal.Pala.Equals(tbLugar.Text) && pal.Categoria.Equals("Lugar")) || (pal.Pala.Equals(tbObjeto.Text) && pal.Categoria.Equals("Objeto")));
                        GestorDeUsuario clogUs = new GestorDeUsuario();
                        timer1.Stop();
                        if (palabrasDudosas.Count > 0)
                        {
                            clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Votando");
                            agregandoPalabras = true;
                            this.Hide();
                            AgregarPalabra agregarPalabras = new AgregarPalabra(idJuego, palabrasDudosas);
                            agregarPalabras.Show(this);
                        }
                        else
                        {
                            clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Esperando");
                        }
                        votacion.Enabled = true;
                        votacion.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    terminar--;
                }
            }
        }

        private void Planilla_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible && agregandoPalabras)
                {
                    GestorDeUsuario clogUs = new GestorDeUsuario();
                    clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Esperando");
                }
            }
            catch (Exception ex){
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void votacion_Tick(object sender, EventArgs e)
        {
            try
            {
                GestorDeJuegos clogJue = new GestorDeJuegos();
                if (clogJue.todosEsperando(idJuego))
                {
                    GestorDePalabra clogPal = new GestorDePalabra();
                    DataTable juego = clogJue.getJuegos(idJuego).Tables[0];
                    if (!GestorDeUsuario.getUsuarioLogeado().Equals(juego.Rows[0].ItemArray[2]))
                    {
                        clogPal.agregarPalabrasCorrectas(idJuego);
                    }
                    List<Palabra> palabras = new List<Palabra>();
                    palabras.Add(new Palabra { Pala = tbNombre.Text, Categoria = "Nombre", Letra = (lblLetra.Text)[0] });
                    palabras.Add(new Palabra { Pala = tbAnimal.Text, Categoria = "Animal", Letra = (lblLetra.Text)[0] });
                    palabras.Add(new Palabra { Pala = tbColor.Text, Categoria = "Color", Letra = (lblLetra.Text)[0] });
                    palabras.Add(new Palabra { Pala = tbComida.Text, Categoria = "Comida", Letra = (lblLetra.Text)[0] });
                    palabras.Add(new Palabra { Pala = tbLugar.Text, Categoria = "Lugar", Letra = (lblLetra.Text)[0] });
                    palabras.Add(new Palabra { Pala = tbObjeto.Text, Categoria = "Objeto", Letra = (lblLetra.Text)[0] });
                    votacion.Stop();
                    if (tuttiFrutti)
                    {
                        if (palabras.All(pal => palabras.Where(pal2 => pal2.Pala.Equals(pal.Pala)).Count() == 1))
                        {
                            if (clogJue.tuttifruttiCorrecto(idJuego, nroRonda, GestorDeUsuario.getUsuarioLogeado(), (lblLetra.Text)[0], palabras))
                            {
                                timer1.Start();
                                clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], tbNombre.Text, tbAnimal.Text, tbColor.Text, tbObjeto.Text, tbLugar.Text, tbComida.Text, tuttiFrutti);
                                int puntaje = clogJue.calcularPuntaje(idJuego, nroRonda, GestorDeUsuario.getUsuarioLogeado());
                                MessageBox.Show("Felicitaicones, su puntaje fue: " + puntaje, "Ronda completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clogPal.limpiarPalabrasDudosas(idJuego);
                            }
                            else
                            {
                                clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], "", "", "", "", "", "", false);
                                timer.Enabled = true;
                                empezar = 0;
                                btnTuttiFrutti.Enabled = true;
                                tbNombre.Enabled = true;
                                tbAnimal.Enabled = true;
                                tbColor.Enabled = true;
                                tbComida.Enabled = true;
                                tbLugar.Enabled = true;
                                tbObjeto.Enabled = true;
                                clogPal.limpiarPalabrasDudosas(idJuego);
                            }
                        }
                        else
                        {
                            clogJue.cargarRonda(GestorDeUsuario.getUsuarioLogeado(), idJuego, nroRonda, lblLetra.Text[0], "", "", "", "", "", "", false);
                            timer.Enabled = true;
                            empezar = 0;
                            btnTuttiFrutti.Enabled = true;
                            tbNombre.Enabled = true;
                            tbAnimal.Enabled = true;
                            tbColor.Enabled = true;
                            tbComida.Enabled = true;
                            tbLugar.Enabled = true;
                            tbObjeto.Enabled = true;
                            clogPal.limpiarPalabrasDudosas(idJuego);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
