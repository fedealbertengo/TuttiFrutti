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
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            GestorDeJuegos clog = new GestorDeJuegos();
            try
            {
                DataTable dt = clog.getJuegos(tbProp.Text, tbNombreSala.Text, cbLlenas.Checked, cbVacias.Checked).Tables[0];
                dt.Columns.RemoveAt(0);
                dgvSalas.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lobby_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GestorDeJuegos clog = new GestorDeJuegos();
            try
            {
                DataTable dt = clog.getJuegos(tbProp.Text, tbNombreSala.Text, cbLlenas.Checked, cbVacias.Checked).Tables[0];
                dt.Columns.RemoveAt(0);
                dgvSalas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSalas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GestorDeJuegos clog = new GestorDeJuegos();
            try
            {
                int idJuego = (int) clog.getJuegos(dgvSalas.SelectedRows[0].Cells[1].Value.ToString(), dgvSalas.SelectedRows[0].Cells[0].Value.ToString(), false, false).Tables[0].Rows[0].ItemArray[0];
                int unidos = (int) dgvSalas.SelectedRows[0].Cells[2].Value;
                int capacidad = (int)dgvSalas.SelectedRows[0].Cells[3].Value;
                if (capacidad - unidos > 0)
                {
                    clog.unirUsuarioAJuego(idJuego);
                    MessageBox.Show("Usted se ha unido correctamente a la sala " + dgvSalas.SelectedRows[0].Cells[0].Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable dt = clog.getJuegos(tbProp.Text, tbNombreSala.Text, cbLlenas.Checked, cbVacias.Checked).Tables[0];
                    dt.Columns.RemoveAt(0);
                    dgvSalas.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(("La sala a la que intenta unirse está llena."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Usted ya se encuentra en la sala"))
                {
                    int idJuego = (int)clog.getJuegos(dgvSalas.SelectedRows[0].Cells[1].Value.ToString(), dgvSalas.SelectedRows[0].Cells[0].Value.ToString(), false, false).Tables[0].Rows[0].ItemArray[0];
                    Sala sala = new Pantallas.Sala(idJuego);
                    this.Hide();
                    sala.Show(this);
                }
                else
                {
                    MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            GestorDeJuegos clog = new GestorDeJuegos();
            try
            {
                int idJuego = (int)clog.getJuegos(dgvSalas.SelectedRows[0].Cells[1].Value.ToString(), dgvSalas.SelectedRows[0].Cells[0].Value.ToString(), false, false).Tables[0].Rows[0].ItemArray[0];
                clog.eliminarJuego(idJuego, dgvSalas.SelectedRows[0].Cells[1].Value.ToString());
                MessageBox.Show("La sala " + dgvSalas.SelectedRows[0].Cells[0].Value.ToString() + " se ha eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = clog.getJuegos(tbProp.Text, tbNombreSala.Text, cbLlenas.Checked, cbVacias.Checked).Tables[0];
                dt.Columns.RemoveAt(0);
                dgvSalas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearSala crearSala = new CrearSala();
            this.Hide();
            crearSala.Show(this);
        }

        private void Lobby_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                GestorDeJuegos clog = new GestorDeJuegos();
                try
                {
                    DataTable dt = clog.getJuegos(tbProp.Text, tbNombreSala.Text, cbLlenas.Checked, cbVacias.Checked).Tables[0];
                    dt.Columns.RemoveAt(0);
                    dgvSalas.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(("Se ha producido un error:\n" + ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
