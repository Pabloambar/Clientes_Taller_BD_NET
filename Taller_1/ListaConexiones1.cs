using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_1
{
    public class ListaConexiones1
    {

        public List<ListaTurnos> ListarTurnos()
        {
            List<ListaTurnos> listaT = new List<ListaTurnos>();
            SqlConnection conexion1 = new SqlConnection();
            SqlCommand comando1 = new SqlCommand();
            SqlDataReader lector1;

            conexion1.ConnectionString = "data source=DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=sspi";
            comando1.CommandType = System.Data.CommandType.Text;
            comando1.CommandText = "Select * from Turnos";
            comando1.Connection = conexion1;
            conexion1.Open();

            lector1 = comando1.ExecuteReader();
            while (lector1.Read())
            {
                ListaTurnos aux = new ListaTurnos();
                aux.Id = lector1.GetInt32(0);
                aux.Nombre = lector1.GetString(1);
                aux.Vehiculo = lector1.GetString(2);
                aux.Fecha = lector1.GetString(3);
                aux.Telefono = lector1.GetInt64(4);
                aux.Trabajos = lector1.GetString(5);

                listaT.Add(aux);

            }
            conexion1.Close();

            return listaT;
        }

        internal void agregarT(ListaTurnos nuevoT)
        {


            SqlConnection conexion1 = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            conexion1.ConnectionString = "data source =DESKTOP-42J5272\\MSSQLSERVER01; initial catalog=TALLER_DB; integrated security=true ";
            comando.Connection = conexion1;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "insert into Turnos values ('" + nuevoT.Nombre + "','" + nuevoT.Vehiculo + "','" + nuevoT.Fecha + "','" + nuevoT.Telefono + "','" + nuevoT.Trabajos + "')";



            conexion1.Open();
            comando.ExecuteNonQuery();
            conexion1.Close();


        }
    }
}