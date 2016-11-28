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
    public partial class CrearSala : Form
    {
        public CrearSala()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
        {
            tbNombre.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GestorDeJuegos clog = new GestorDeJuegos();
            clog.agregarSala(tbNombre.Text, Int32.Parse(cmbCapacidad.Text));
            DialogResult dialogResult = MessageBox.Show("La sala " + tbNombre.Text + " se ha creado correctamente ¿Desea cargar otro ?.", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            limpiarCampos();
            if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrearSala_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }
    }
}
