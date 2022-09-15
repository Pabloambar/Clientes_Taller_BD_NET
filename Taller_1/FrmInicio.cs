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
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBaseDeDatos BaseDatos = new FrmBaseDeDatos();
            BaseDatos.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarNuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes agregar = new frmClientes();
            agregar.ShowDialog();
            
            
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe acercaDe = new frmAcercaDe();
            acercaDe.ShowDialog();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cargarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTurnos turnos = new frmTurnos();
            turnos.ShowDialog();
        }

        private void listaDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaTurnos listaTurnos = new frmListaTurnos();
            listaTurnos.ShowDialog();
        }

        private void imprimirCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void datosDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatosUsuario datosUsuario = new frmDatosUsuario();
            datosUsuario.ShowDialog();
        }

        private void galeriaDeFotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGaleriaFotos galeriaFotos = new frmGaleriaFotos();
            galeriaFotos.ShowDialog();
        }

        private void manualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManuales manuales = new frmManuales();
            manuales.ShowDialog();
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArchivos archivos = new frmArchivos();
            archivos.ShowDialog();
        }

        private void fiatLíneaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheck check = new frmCheck();
            check.Show();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido ");
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPRUEBADGV pruebaDgv = new frmPRUEBADGV();
            pruebaDgv.ShowDialog(); 
        }
    }
}
