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
    public partial class Sala : Form
    {
        public static int TAMMAXFILA = 4;
        public int idJuego;
        public bool listo = true;
        public bool empezar = false;
        public bool oculto = false;
        public Sala()
        {
            InitializeComponent();
        }

        public Sala(int idJue)
        {
            idJuego = idJue;
            InitializeComponent();
        }

        private void dibujarPraticipantes()
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            DataTable juego = clogJue.getJuegos(idJuego).Tables[0];
            int unidos = (int)juego.Rows[0].ItemArray[3];
            int xant = -115;
            int yant = 50;
            DataTable jugadoresUnidos = clogJue.getBanderas(idJuego).Tables[0];
            int i = 0;
            int columnas = 0;
            int filas = 0;
            this.Controls.Remove(pnUs1);
            foreach (DataRow dr in jugadoresUnidos.Rows)
            {
                string usuario = dr.ItemArray[2].ToString();
                string estado = dr.ItemArray[3].ToString();
                Panel panUs = new Panel();
                if (columnas + 1 > TAMMAXFILA)
                {
                    yant = yant + pnUs1.Size.Height + 50;
                    xant = 50;
                    filas++;
                }
                else
                {
                    xant = xant + pnUs1.Size.Width + 50;
                    columnas++;
                }
                panUs.Location = new Point(xant, yant);
                panUs.Font = pnUs1.Font;
                panUs.ForeColor = pnUs1.ForeColor;
                if (usuario.Equals(GestorDeUsuario.getUsuarioLogeado()))
                {
                    if (estado.Equals("Esperando"))
                    {
                        if (usuario.Equals(juego.Rows[0].ItemArray[2]))
                        {
                            botonUniversal.Text = "Empezar";
                            empezar = false;
                        }
                        else
                        {
                            botonUniversal.Text = "Listo";
                            listo = false;
                        }
                        panUs.BackColor = Color.Blue;
                    }
                    else
                    {
                        if (estado.Equals("Listo"))
                        {
                            if (usuario.Equals(juego.Rows[0].ItemArray[2]))
                            {
                                botonUniversal.Text = "Cancelar";
                                empezar = true;
                            }
                            else
                            {
                                botonUniversal.Text = "No Listo";
                            }
                            panUs.BackColor = Color.Yellow;
                            panUs.ForeColor = Color.Black;
                        }
                    }
                }
                else
                {
                    if (estado.Equals("Esperando"))
                    {
                        if (usuario.Equals(juego.Rows[0].ItemArray[2]))
                        {
                            empezar = false;
                        }
                        else
                        {
                            listo = false;
                        }
                        panUs.BackColor = Color.Red;
                    }
                    else
                    {
                        if (estado.Equals("Listo"))
                        {
                            if (usuario.Equals(juego.Rows[0].ItemArray[2]))
                            {
                                empezar = true;
                            }
                            panUs.BackColor = Color.Green;
                        }
                    }
                }
                panUs.Size = pnUs1.Size;
                panUs.Name = ("pnUs" + (i + 1).ToString());
                panUs.BorderStyle = pnUs1.BorderStyle;

                Panel panFoto = new Panel();
                panFoto.Location = pnFotoUs1.Location;
                panFoto.Size = pnFotoUs1.Size;
                panFoto.Name = ("pnFotoUs" + (i + 1).ToString());
                panFoto.BackColor = Color.Gray;
                panFoto.BackgroundImage = CPresentacion.Properties.Resources.Foto1;
                panFoto.BackgroundImageLayout = ImageLayout.Stretch;

                Label lblNombre = new Label();
                lblNombre.Text = usuario;
                lblNombre.Location = new Point(panFoto.Location.X, panFoto.Location.Y + panFoto.Size.Height + 2);
                lblNombre.Name = ("lblNombreUs" + (i + 1).ToString());

                panUs.Controls.Add(panFoto);
                panUs.Controls.Add(lblNombre);
                this.Controls.Add(panUs);
                i++;
            }
            if(filas == 0)
            {
                filas = 1;
            }
            this.Size = new Size((columnas * (pnUs1.Size.Width + 50)) + 50, (filas * (pnUs1.Size.Height + 50)) + 100);
            botonUniversal.Location = new Point(((this.Size.Width / 2) - (botonUniversal.Size.Width / 2)), ((this.Size.Height) - (botonUniversal.Size.Height/2) - 25));
            this.Size = new Size(this.Size.Width, this.Size.Height + 50);
            if (!listo)
            {
                botonUniversal.Text = "No Listo";
                botonUniversal.Enabled = false;
            }
        }

        public void empezarJuego()
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            DataTable juego = clogJue.getJuegos(idJuego).Tables[0];

            if (GestorDeUsuario.getUsuarioLogeado().Equals(juego.Rows[0].ItemArray[2]))
            {
                if(listo && !empezar && !botonUniversal.Text.Equals("Empezar"))
                {
                    botonUniversal.Enabled = true;
                    botonUniversal.Text = "Empezar";
                }
                else
                {
                    if (!listo && empezar)
                    {
                        botonUniversal.Enabled = false;
                        botonUniversal.Text = "No Listo";
                        empezar = false;
                    }
                }
            }
            else
            {
                if (listo && empezar && botonUniversal.Text.Equals("Empezar"))
                {
                    botonUniversal.Enabled = true;
                    botonUniversal.Text = "Cancelar";
                    empezar = false;
                    listo = false;
                }
                else
                {
                    if (listo && empezar && botonUniversal.Enabled && !botonUniversal.Text.Equals("Cancelar"))
                    {
                        botonUniversal.Enabled = false;
                    }
                }
            }
        }

        private void Sala_Load(object sender, EventArgs e)
        {
            try
            {
                dibujarPraticipantes();
                empezarJuego();
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sala_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void redibujarParticipantes()
        {

            GestorDeJuegos clogJue = new GestorDeJuegos();
            DataTable juego = clogJue.getJuegos(idJuego).Tables[0];

            DataTable jugadoresUnidos = clogJue.getBanderas(idJuego).Tables[0];
            int i = 0;
            listo = true;
            foreach (DataRow dr in jugadoresUnidos.Rows)
            {
                string usuario = dr.ItemArray[2].ToString();
                string estado = dr.ItemArray[3].ToString();
                Panel panUs = (Panel) this.Controls[i+1];
                Panel panFoto = (Panel) panUs.Controls[0];
                Label lblNombre = (Label) panUs.Controls[1];
                if (usuario.Equals(GestorDeUsuario.getUsuarioLogeado()))
                {
                    if (panUs.BackColor == Color.Yellow && estado.Equals("Esperando"))
                    {
                        panUs.BackColor = Color.Blue;
                        panUs.ForeColor = Color.White;
                        if (usuario.Equals(juego.Rows[0].ItemArray[2]))
                        {
                            botonUniversal.Text = "Empezar";
                            empezar = false;
                        }
                        else
                        {
                            if (listo)
                            {
                                botonUniversal.Text = "Listo";
                                listo = false;
                            }
                        }
                    }
                    else
                    {
                        if (panUs.BackColor == Color.Blue && estado.Equals("Listo"))
                        {
                            panUs.BackColor = Color.Yellow;
                            panUs.ForeColor = Color.Black;
                            if (usuario.Equals(juego.Rows[0].ItemArray[2]))
                            {
                                botonUniversal.Text = "Cancelar";
                                empezar = true;
                            }
                            else
                            {
                                botonUniversal.Text = "No Listo";
                                if (empezar)
                                {
                                    botonUniversal.Enabled = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (panUs.BackColor == Color.Green && estado.Equals("Esperando"))
                    {
                        panUs.BackColor = Color.Red;
                        if (listo)
                        {
                            listo = false;
                        }
                    }
                    else
                    {
                        if (panUs.BackColor == Color.Red && estado.Equals("Listo"))
                        {
                            panUs.BackColor = Color.Green;
                        }
                    }
                }
                i++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            redibujarParticipantes();
            empezarJuego();
            if (empezar && listo)
            {
                GestorDeJuegos clogJue = new GestorDeJuegos();
                try
                {
                    clogJue.modificarEstado(idJuego, "Jugando");
                    Planilla planilla = new Planilla(idJuego);
                    this.Hide();
                    oculto = true;
                    timer1.Enabled = false;
                    botonUniversal.Enabled = false;
                    planilla.Show(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void botonUniversal_Click(object sender, EventArgs e)
        {
            GestorDeUsuario clogUs = new GestorDeUsuario();
            try
            {
                if(empezar && listo && botonUniversal.Text.Equals("Cancelar"))
                {
                    clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Esperando");
                    MessageBox.Show("El inicio ha sido cancelado.");
                }
                else
                {
                    if (botonUniversal.Text.Equals("Listo") || botonUniversal.Text.Equals("Empezar"))
                    {
                        clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Listo");
                    }
                    else
                    {
                        clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Esperando");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sala_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && oculto)
            {
                GestorDeUsuario clogUs = new GestorDeUsuario();
                clogUs.cambiarEstado(GestorDeUsuario.getUsuarioLogeado(), "Esperando");
                timer1.Enabled = true;
                botonUniversal.Enabled = true;
            }
        }
    }
}
