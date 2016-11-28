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
    public partial class Registrarse : Form
    {
        Color colorTb = Color.White;
        public Registrarse()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrarse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        public void limpiarCampos()
        {
            tbNombre.Text = "";
            tbContra.Text = "";
            tbContra2.Text = "";
            tbContra2.BackColor = colorTb;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GestorDeUsuario clog = new GestorDeUsuario();
            try
            {
                if (tbContra.Text == tbContra2.Text)
                {
                    clog.registrarUsuario(tbNombre.Text, tbContra.Text);
                    DialogResult dialogResult = MessageBox.Show("El usuario " + tbNombre.Text + " se ha creado correctamente ¿Desea cargar otro ?.", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    limpiarCampos();
                    if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(("Se ha producido un error:\n" + "Las contraseñas no coinciden"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbContra2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbContra2.Text + e.KeyChar == tbContra.Text)
            {
                tbContra2.BackColor = Color.Green;
            }
            else
            {
                tbContra2.BackColor = Color.Red;
            }
        }

        private void Registrarse_Load(object sender, EventArgs e)
        {

        }
    }
}
