using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPresentacion.Pantallas
{
    public partial class Planilla : Form
    {
        public Planilla()
        {
            InitializeComponent();
        }

        private void Planilla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }
    }
}
