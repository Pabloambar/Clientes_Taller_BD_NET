using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_1
{
    public partial class frmVer : Form
    {
        ListaTurnos listado = null;
        public frmVer()
        {
            InitializeComponent();
        }

        public frmVer(ListaTurnos listado)
        {
            InitializeComponent();
            this.listado = listado;
        }

        private void frmVer_Load(object sender, EventArgs e)
        {
            if (listado !=null)
            {
                txtNombre.Text = listado.Nombre;
                txtVehiculo.Text = listado.Vehiculo;
                txtTelefono.Text = listado.Telefono.ToString(); 
                txtFecha.Text = listado.Fecha;
                txtTrabajos.Text = listado.Trabajos;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
