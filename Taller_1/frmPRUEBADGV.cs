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


namespace Taller_1
{
    public partial class frmPRUEBADGV : Form
    {
        public frmPRUEBADGV()
        {
            InitializeComponent();
            
        }

        private void Refresh()
        {
            using (Model.TALLER_DBEntities2 db = new Model.TALLER_DBEntities2())
            {
                var lst = (from d in db.DatosClientes
                           select new Model.ViewModel.ClientesViewModel
                           {
                               Id = d.Id,
                               Nombre= d.Nombre,
                               Apellido= d.Apellido,
                               Direccion= d.Dirección,
                               NumeroDeTelefono = (long)d.NumeroDeTelefono,
                               Vehiculo = d.Vehículo,
                               Patente = d.Patente,
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

                dataGridView1.DataSource = lst.ToList();
            }


            
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch 
            {

                return null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmPRUEBADGV_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
           Presentation.frmNuevo oFrmNuevo = new Presentation.frmNuevo();
                oFrmNuevo.ShowDialog();

            Refresh();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            
            if (id !=null)
            {
                Presentation.frmNuevo oFrmNuevo = new Presentation.frmNuevo(id);
                oFrmNuevo.ShowDialog();
                Refresh();
            }
        }
    }
}
