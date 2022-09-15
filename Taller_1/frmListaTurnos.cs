using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_1
{
    public partial class frmListaTurnos : Form
    {
        public frmListaTurnos()
        {
            InitializeComponent();
        }

        private void frmListaTurnos_Load(object sender, EventArgs e)
        {
             ListaConexiones1 conexion1 = new ListaConexiones1();
            dgvTurnos.DataSource = conexion1.ListarTurnos();
        }

        private void Cargar()
        {
            ListaConexiones1 conexion1 = new ListaConexiones1();
            dgvTurnos.DataSource = conexion1.ListarTurnos();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            ListaTurnos seleccionada = (ListaTurnos)dgvTurnos.CurrentRow.DataBoundItem;
            frmVer ver = new frmVer(seleccionada);
            ver.ShowDialog();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo);

            if (x == DialogResult.No)
            {
                frmListaTurnos cancelar = new frmListaTurnos();
                cancelar.Refresh();
            }
            else
            {

                ListaTurnos item = (ListaTurnos)dgvTurnos.CurrentRow.DataBoundItem;
                txtId.Text = item.Id.ToString();

                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = "data source=DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=true";
                conexion.Open();
                string cadena = "Delete from Turnos Where Id = '" + txtId.Text + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro eliminado");
                frmListaTurnos cancelar = new frmListaTurnos();
                Cargar();
            }
        }
    }
}
