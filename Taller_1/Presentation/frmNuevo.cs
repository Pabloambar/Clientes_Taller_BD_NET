using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_1.Model;

namespace Taller_1.Presentation
{
    public partial class frmNuevo : Form
    {
        public int? id;
       
        public frmNuevo(int? id = null)
        {
            InitializeComponent();
            this.id = id;
           
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (TALLER_DBEntities2 db = new TALLER_DBEntities2()) 
            {
           
       
                DatosClientes oDatosClientes = new DatosClientes();

                oDatosClientes.Nombre = txtNombre.Text;
                oDatosClientes.Apellido = txtApellido.Text;
                oDatosClientes.Dirección = txtDireccion.Text;
                oDatosClientes.NumeroDeTelefono = long.Parse(txtTelefono.Text);
                oDatosClientes.Vehículo=txtVehiculo.Text;
                oDatosClientes.Patente = txtPatente.Text;
                oDatosClientes.NumeroChasis = txtNumeroChasis.Text;
                oDatosClientes.Kilómetros = long.Parse(txtKms.Text);
                oDatosClientes.FechaDeMantenimiento = dtpFechaMant.Text;
                oDatosClientes.FechaProximoMant= dtpFechaProximo.Text;
                oDatosClientes.Descripción = txtDescripcion.Text;

               
                db.DatosClientes.Add(oDatosClientes);
                db.SaveChanges();
                this.Close();

            }
        }
    }
}
