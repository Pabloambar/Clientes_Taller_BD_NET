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
    public partial class frmTurnos : Form
    {
        public frmTurnos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Cargar
        {
            try
            {
                ListaTurnos nuevoT = new ListaTurnos();
                ListaConexiones1 conexion = new ListaConexiones1();

                nuevoT.Nombre = txtNombre.Text;
                nuevoT.Vehiculo = txtVehiculo.Text;
                nuevoT.Telefono = Int64.Parse(txtTelefono.Text);
                nuevoT.Fecha = dtpFecha.Text;
                nuevoT.Trabajos = txtTrabajos.Text;

                conexion.agregarT(nuevoT);

                MessageBox.Show("Turno cargado con exito");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Faltan campos de completar o la sintaxis es erronea...");
                
            }

            
        }
    }
}
