using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_1
{
    public partial class frmGaleriaFotos : Form
    {
        public frmGaleriaFotos()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;

            }
        }

        private void Refresh()
        {
            //using (Model.TALLER_DBEntities db = new Model.TALLER_DBEntities())
            //{
            //    var lst = from d in db.Imagenes
            //              select new { d.Id, d.Nombre };
            //    dgvListaImagenes.DataSource = lst.ToList();
            //    txtFile.Text = "";
            //    txtName.Text = "";
            //}

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (txtName.Text.Trim().Equals("")||txtFile.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("Nombre y Archivo son obligatorios");
            //    return;
            //}

            //byte[] file = null;
            //Stream myStream = openFileDialog1.OpenFile();
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    myStream.CopyTo(ms);
            //    file = ms.ToArray();
            //}

            //using (Model.TALLER_DBEntities db = new Model.TALLER_DBEntities())
            //{
            //    Model.Imagenes oImage = new Model.Imagenes();
            //    oImage.Nombre = txtName.Text.Trim();
            //    oImage.Imagen = file;

            //    db.Imagenes.Add(oImage);
            //    db.SaveChanges();
            //}

            Refresh();

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //if (dgvListaImagenes.Rows.Count > 0)
            //{
            //    int Id = int.Parse(dgvListaImagenes.Rows[dgvListaImagenes.CurrentRow.Index].Cells[0].Value.ToString());

            //    using (Model.TALLER_DBEntities db = new Model.TALLER_DBEntities())
            //    {
            //        var oImage = db.Imagenes.Find(Id);

            //        MemoryStream ms = new MemoryStream(oImage.Imagen);
            //        Bitmap bitmap = new Bitmap(ms);
            //        pctImagen.Image = bitmap;
            //    }
            //}
        }

        private void frmGaleriaFotos_Load(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
