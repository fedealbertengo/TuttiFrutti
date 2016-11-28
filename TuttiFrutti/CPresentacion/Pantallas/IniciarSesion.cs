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
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        public void limpiarCampos()
        {
            tbNombre.Text = "";
            tbContra.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDeUsuario.iniciarSesion(tbNombre.Text, tbContra.Text);
                Lobby lobby = new Lobby();
                this.Hide();
                limpiarCampos();
                lobby.Show(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbContra.Text = "";
            }
        }
    }
}
