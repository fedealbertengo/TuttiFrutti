using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPresentacion.Pantallas;

namespace CPresentacion
{
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion insec = new IniciarSesion();
            this.Hide();
            insec.Show(this);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registrarse reg = new Registrarse();
            this.Hide();
            reg.Show(this);
        }
    }
}
