using Microsoft.VisualBasic.PowerPacks.Printing;
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
    public partial class frmCheck : Form
    {
        public frmCheck()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintForm printForm = new PrintForm();
            printForm.Form = this;
            printForm.PrinterSettings.DefaultPageSettings.Landscape = true;
            printForm.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
            printForm.Print(this, PrintForm.PrintOption.FullWindow);
            
        }
    }
}
