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
    public partial class frmClientes : Form
    {
        private ListaClientes listado = null;
        public frmClientes()
        {
            InitializeComponent();
        }

        public frmClientes(ListaClientes listado)
        {
            InitializeComponent();
            this.listado = listado;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            if (listado!=null)
            {

                Text = "Ver / modificar datos";
                btnModificar.Visible = true;
                btnCargar.Visible = false;
                txtId.Text = listado.Id.ToString();
                txtNombre.Text = listado.Nombre;
                txtApellido.Text = listado.Apellido;
                txtDireccion.Text = listado.Direccion;
                txtTelefono.Text = listado.NumeroDeTelefono.ToString();
                txtVehiculo.Text= listado.Vehiculo;
                txtPatente.Text = listado.Patente;
                txtChasis.Text = listado.NumeroChasis.ToString();
                txtKms.Text = listado.Kilometros.ToString();
                dtpFechaMant.Text = listado.FechaDeMantenimiento.ToString();
                dtpFechaProximo.Text = listado.FechaProximoMant.ToString();
                txtDescripcion.Text = listado.Descripcion;
            }

        }

        private void txtModificar_Click(object sender, EventArgs e)
        {

           
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = "data source=DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=true";
                conexion.Open();
                //int flag= 0;
                string cadena = "UPDATE DatosClientes SET Nombre = '" + txtNombre.Text + "', Apellido = '" + txtApellido.Text + "', Dirección = '" + txtDireccion.Text + "', NumeroDeTelefono = '" + txtTelefono.Text + "'" +
                ", Vehículo = '" + txtVehiculo.Text + "', Patente= '" + txtPatente.Text + "', NumeroChasis = '" + txtChasis.Text + "', Kilómetros = " + txtKms.Text + ", FechaDeMantenimiento = '" + dtpFechaMant.Text + "'" +
                    ", FechaProximoMant = '" + dtpFechaProximo.Text + "', Descripción = '" + txtDescripcion.Text + "' Where Id = '" + txtId.Text + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Datos modificados con exito");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaClientes nuevo = new ListaClientes();
                ListaConexiones conexion = new ListaConexiones();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.NumeroDeTelefono = Int64.Parse(txtTelefono.Text);
                nuevo.Vehiculo = txtVehiculo.Text;
                nuevo.Patente = txtPatente.Text;
                nuevo.NumeroChasis = txtChasis.Text;
                nuevo.Kilometros = int.Parse(txtKms.Text);
                nuevo.FechaDeMantenimiento = dtpFechaMant.Text;
                nuevo.FechaProximoMant = dtpFechaProximo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                conexion.agregar(nuevo);

                MessageBox.Show("Los datos se cargaron con exito");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error; campos incompletos o Sintaxis incorrecta");
               
            }

            finally
            {
                Refresh();
            }
           
        }
    }
}
