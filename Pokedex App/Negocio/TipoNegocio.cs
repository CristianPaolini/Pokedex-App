using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Tipo> lista = new List<Tipo>();

            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=POKEMON_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select Id, Descripcion from TIPOS";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                lista.Add(new Tipo((int)lector["Id"], (string)lector["Descripcion"]));

            }

            lector.Close();
            conexion.Close();
            return lista;
        }
    }
}
