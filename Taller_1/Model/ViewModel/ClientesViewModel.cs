using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_1.Model.ViewModel
{
    internal class ClientesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public Int64 NumeroDeTelefono { get; set; }
        public string Vehiculo { get; set; }
        public string Patente { get; set; }
        public string NumeroChasis { get; set; }
        public Int64 Kilometros { get; set; }
        public string FechaDeMantenimiento { get; set; }
        public string FechaProximoMant { get; set; }
        public string Descripcion { get; set; }

    }
}
