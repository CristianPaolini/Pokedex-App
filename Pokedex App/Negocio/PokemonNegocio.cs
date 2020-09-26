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
            comando.CommandText = "Select P.id idPoke, P.nombre, P.descripcion, P.Imagen, T.Descripcion Tipo, T.Id idTipo From POKEMONS P, TIPOS T Where P.IdTipo=T.Id";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Pokemon aux = new Pokemon();
                aux.Nombre = lector.GetString(1);
                aux.Descripcion = lector.GetString(2);
                aux.UrlImage = lector.GetString(3);
                aux.Id = (int)lector["idPoke"]; 
                aux.Tipo = new Tipo();
                aux.Tipo.Descripcion = (string)lector["Tipo"];
                aux.Tipo.Id = (int)lector["idTipo"];

                lista.Add(aux);
            }

            conexion.Close();
            return lista;

        }

        public void modificar(Pokemon pokemon)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearQuery("Update POKEMONS Set Nombre=@Nombre, Descripcion=@Descripcion, Imagen=@Imagen, idTipo=@idTipo Where Id=@id");
                conexion.agregarParametro("@Nombre", pokemon.Nombre);
                conexion.agregarParametro("@Descripcion", pokemon.Descripcion);
                conexion.agregarParametro("@Imagen", pokemon.UrlImage);
                conexion.agregarParametro("@idTipo", pokemon.Tipo.Id);
                conexion.agregarParametro("@id", pokemon.Id);
                conexion.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearQuery("Delete from POKEMONS Where Id=@id");
                conexion.agregarParametro("@id", id);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void agregar(Pokemon nuevo)
        {
            AccesoDatos conexion = new AccesoDatos();
            conexion.setearQuery("Insert Into POKEMONS (Nombre, Descripcion, Imagen, idTipo) Values (@Nombre, @Descripcion, @Imagen, @idTipo)");
            conexion.agregarParametro("@Nombre", nuevo.Nombre);
            conexion.agregarParametro("@Descripcion", nuevo.Descripcion);
            conexion.agregarParametro("@Imagen", nuevo.UrlImage);
            conexion.agregarParametro("@idTipo", nuevo.Tipo.Id);
            conexion.ejecutarAccion();

        }
    }
}
