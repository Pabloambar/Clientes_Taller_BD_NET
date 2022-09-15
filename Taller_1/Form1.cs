using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Taller_1
{
    public partial class FrmBaseDeDatos : Form
    {
      
        public FrmBaseDeDatos()
        {
            InitializeComponent();
        }

       
        public void Cargar()
        {
            ListaConexiones conexion = new ListaConexiones();
            dgvClientes.DataSource = conexion.ListarClientes();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           // this.datosClientesTableAdapter.Fill(this.tALLER_DBDataSet.DatosClientes);
            ListaConexiones conexion = new ListaConexiones();//----------------------------------------------ok
            dgvClientes.DataSource = conexion.ListarClientes();

           // Refresh();

        }

        private void btnVerMod_Click(object sender, EventArgs e)
        {
            try
            {
                ListaClientes seleccionada = (ListaClientes)dgvClientes.CurrentRow.DataBoundItem;
                frmClientes clientes = new frmClientes(seleccionada);
                clientes.ShowDialog();
                //Cargar();
                //Refrescar();
            }
            catch (Exception)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtVehiculo.Text = "";
                //MessageBox.Show("Ocurrio un error inesperado, intentelo nuevamente");
                Cargar();
            }
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult x = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo);

                if (x == DialogResult.No)
                {
                    frmClientes cancelar = new frmClientes();
                    cancelar.Refresh();
                }
                else
                {

                    ListaClientes item = (ListaClientes)dgvClientes.CurrentRow.DataBoundItem;
                    txtId.Text = item.Id.ToString();

                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "data source=DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=true";
                    conexion.Open();
                    string cadena = "Delete from DatosClientes Where Id = '" + txtId.Text + "'";
                    SqlCommand comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Registro eliminado");
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtVehiculo.Text = "";
                // MessageBox.Show("Ocurrio un error inesperado", ex.Message);
                Cargar();
            }
           
            
        }

        private void Refrescar()
        {
            using (Model.TALLER_DBEntities2 db = new Model.TALLER_DBEntities2())
            {
                var lst = (from d in db.DatosClientes
                           select new Model.ViewModel.ClientesViewModel
                           {
                               Id = d.Id,
                               Nombre = d.Nombre,
                               Apellido = d.Apellido,
                               Direccion = d.Dirección,
                               NumeroDeTelefono = (long)d.NumeroDeTelefono,
                               Vehiculo = d.Vehículo,
                               Patente = d.Patente.ToString(),
                               NumeroChasis = d.NumeroChasis,
                               Kilometros = (long)d.Kilómetros,
                               FechaDeMantenimiento = d.FechaDeMantenimiento,
                               FechaProximoMant = d.FechaProximoMant,
                               Descripcion = d.Descripción

                           }).AsQueryable();



                if (!txtNombre.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Nombre.Contains(txtNombre.Text.Trim()));
                }

                if (!txtApellido.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Apellido.Contains(txtApellido.Text.Trim()));
                }

                if (!txtVehiculo.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Vehiculo.Contains(txtVehiculo.Text.Trim()));
                }

                dgvClientes.DataSource = lst.ToList();
            }



        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {

                Refrescar();


            }
            catch (Exception)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtVehiculo.Text = "";
                //MessageBox.Show("Fallo Filtro");
                Cargar();
            }

            

        }
    }
}
