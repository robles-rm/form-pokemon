﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Creo libreria sql
using dominio;


namespace negocio
{
    public class PokemonNegcio //Creo metodos de acceso a datos para los pokemons
    {
        public List<Pokemon> listar()//Lista de elementos a devolver
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection(); //Objeto para conectarme a la base de datos
            SqlCommand comando = new SqlCommand();        //Objeto para realizar acciones
            SqlDataReader lector;                         //Set de datos para la conexion

            try//Si funciona retorna un valor
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true"; //Me conecto al motor, cadena de conexion
                comando.CommandType = System.Data.CommandType.Text; //Le asigno formato a la consulta sql
                comando.CommandText = "select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad  From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo  And D.Id = P.IdDebilidad"; //Consulta SQL al motor
                comando.Connection = conexion; 

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())  //Coloca el puntero en la columna uno
                {
                    Pokemon aux = new Pokemon(); //Creo un pokemon auxiliar para cargarlo con los datos del registro
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento(); //Para que no devuelva referencia nula, ya que el pokemon no tiene 'tipo' configurado
                    aux.Tipo.Descripcion = (string)lector["TIpo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)//sino funciona devuelve el error sin romperse
            {
                throw ex;
            }
        }
    }
}

