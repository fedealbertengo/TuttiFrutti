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

namespace CPresentacion.Pantallas
{
    public partial class Sala : Form
    {

        public int idJuego;
        public bool empezar = true;
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
            this.Controls.Remove(pnUs1);
            foreach (DataRow dr in jugadoresUnidos.Rows)
            {
                string usuario = dr.ItemArray[2].ToString();
                string estado = dr.ItemArray[3].ToString();
                Panel panUs = new Panel();
                if ((xant + pnUs1.Size.Width + 50) + pnUs1.Size.Width >= 589)
                {
                    yant = yant + pnUs1.Size.Height + 50;
                    xant = 50;
                }
                else
                {
                    xant = xant + pnUs1.Size.Width + 50;
                }
                panUs.Location = new Point(xant, yant);
                panUs.Font = pnUs1.Font;
                panUs.ForeColor = pnUs1.ForeColor;
                if (usuario.Equals(GestorDeUsuario.getUsuarioLogeado()))
                {
                    if (estado.Equals("Esperando"))
                    {
                        panUs.BackColor = Color.Blue;
                        empezar = false;
                    }
                    else
                    {
                        if (estado.Equals("Listo"))
                        {
                            panUs.BackColor = Color.Yellow;
                            panUs.ForeColor = Color.Black;
                        }
                    }
                }
                else
                {
                    if (estado.Equals("Esperando"))
                    {
                        panUs.BackColor = Color.Red;
                        empezar = false;
                    }
                    else
                    {
                        if (estado.Equals("Listo"))
                        {
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
        }

        public void empezarJuego()
        {

        }

        private void Sala_Load(object sender, EventArgs e)
        {
            try
            {
                dibujarPraticipantes();
                if (empezar)
                {
                    empezarJuego();
                }
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

        private void dibujarParticipantes2()
        {
            GestorDeJuegos clogJue = new GestorDeJuegos();
            DataTable juego = clogJue.getJuegos(idJuego).Tables[0];

            DataTable jugadoresUnidos = clogJue.getBanderas(idJuego).Tables[0];
            int i = 0;
            empezar = true;
            foreach (DataRow dr in jugadoresUnidos.Rows)
            {
                string usuario = dr.ItemArray[2].ToString();
                string estado = dr.ItemArray[3].ToString();
                Panel panUs = (Panel) this.Controls[i];
                Panel panFoto = (Panel) panUs.Controls[0];
                Label lblNombre = (Label) panUs.Controls[1];
                if (usuario.Equals(GestorDeUsuario.getUsuarioLogeado()))
                {
                    if (estado.Equals("Esperando"))
                    {
                        empezar = false;
                    }
                    if (panUs.BackColor == Color.Yellow && estado.Equals("Esperando"))
                    {
                        panUs.BackColor = Color.Blue;
                        panUs.ForeColor = Color.White;
                        if (empezar)
                        {
                            empezar = false;
                        }
                    }
                    else
                    {
                        if (panUs.BackColor == Color.Blue && estado.Equals("Listo"))
                        {
                            panUs.BackColor = Color.Yellow;
                            panUs.ForeColor = Color.Black;
                        }
                    }
                }
                else
                {
                    if(estado == "Esperando")
                    {
                        empezar = false;
                    }
                    if (panUs.BackColor == Color.Green && estado.Equals("Esperando"))
                    {
                        panUs.BackColor = Color.Red;
                        if (empezar)
                        {
                            empezar = false;
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
            dibujarParticipantes2();
            if (empezar)
            {
                empezarJuego();
            }
        }
    }
}
