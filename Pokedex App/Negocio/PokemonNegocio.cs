using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List < Pokemon > lista = new List<Pokemon>();
            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=POKEMON_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select P.id, P.nombre, P.descripcion, P.Imagen, T.Descripcion Tipo From POKEMONS P, TIPOS T Where P.IdTipo=T.Id";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Pokemon aux = new Pokemon();
                aux.Nombre = lector.GetString(1);
                aux.Descripcion = lector.GetString(2);
                aux.UrlImage = lector.GetString(3);

                aux.Tipo = new Tipo();
                aux.Tipo.Descripcion = (string)lector["Tipo"];

                lista.Add(aux);
            }

            conexion.Close();
            return lista;

        }

        public void agregar(Pokemon nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=POKEMON_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Insert Into POKEMONS (Nombre, Descripcion, Imagen, idTipo) Values (@Nombre, @Descripcion, @Imagen, @idTipo)";
            comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
            comando.Parameters.AddWithValue("@Imagen", nuevo.UrlImage);
            comando.Parameters.AddWithValue("@idTipo", nuevo.Tipo.Id);
            comando.Connection = conexion;

            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
