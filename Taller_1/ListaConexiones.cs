using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_1
{
    public class ListaConexiones
    {
        public List<ListaClientes> ListarClientes()
        {
            List<ListaClientes> lista = new List<ListaClientes>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            conexion.ConnectionString = "data source=DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select * from DatosClientes";
            comando.Connection = conexion;
            conexion.Open();

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaClientes aux = new ListaClientes();
                aux.Id = lector.GetInt32(0);
                aux.Nombre = lector.GetString(1);
                aux.Apellido = lector.GetString(2);
                aux.Direccion = lector.GetString(3);
                aux.NumeroDeTelefono = lector.GetInt64(4);
                aux.Vehiculo = lector.GetString(5);
                aux.Patente = lector.GetString(6);
                aux.NumeroChasis = lector.GetString(7);
                aux.Kilometros = lector.GetInt64(8);
                aux.FechaDeMantenimiento = lector.GetString(9);
                aux.FechaProximoMant = lector.GetString(10);
                aux.Descripcion= lector.GetString(11);

                lista.Add(aux);

            }
            conexion.Close();

            return lista;

        }

        

        internal void agregar(ListaClientes nuevo)
        {
            
            
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();

                conexion.ConnectionString = "data source =DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=true ";
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into DatosClientes values ('" + nuevo.Nombre + "', '" + nuevo.Apellido + "','" + nuevo.Direccion + "','" + nuevo.NumeroDeTelefono + "','" + nuevo.Vehiculo + "','" +nuevo.Patente+ "', '" + nuevo.NumeroChasis + "', '" + nuevo.Kilometros + "', '" + nuevo.FechaDeMantenimiento + "', '" + nuevo.FechaProximoMant + "', '" + nuevo.Descripcion + "')";



                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            
            
        }
    }
}
