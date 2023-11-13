using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using SegundoParcial;

namespace SegundoParcial
{
    public class SQL
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlCommand comando;
        //private SqlDataReader lector;

        static SQL()
        {
            SQL.cadena_conexion = Properties.Resources.miConexion;
        }

        public SQL()
        {
            this.conexion = new SqlConnection(SQL.cadena_conexion);
        }

        public void AgregarJugador(Jugador jugador)
        {
            try
            {
                this.conexion.Open();

                string query = "INSERT INTO Jugador (edad, nombre, apellido, pais, dorsal, posicion)" +
                               "VALUES (@nombre, @apellido, @edad, @pais, @dorsal, @posicio)";

                this.comando = new SqlCommand(query, conexion);
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", jugador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", jugador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)jugador.Pais);
                this.comando.Parameters.AddWithValue("@dorsal", jugador.Dorsal);
                this.comando.Parameters.AddWithValue("@posicion", (int)jugador.Posicion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar Jugador a la base de datos: " + ex.Message);
            }
            finally
            {
                this.conexion.Close();
            }
        }

        public void AgregarEntrenador(Entrenador entrenador)
        {
            try
            {
                this.conexion.Open();

                string query = "INSERT INTO entrenador (edad, nombre, apellido, paises, tactica)" +
                               "VALUES (@nombre, @apellido, @edad, @pais, @tactica)";

                this.comando = new SqlCommand(query, conexion);
                this.comando.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", entrenador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", entrenador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)entrenador.Pais);
                this.comando.Parameters.AddWithValue("@tactica", entrenador.Tactica);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar Entrenador a la base de datos: " + ex.Message);
            }
            finally
            {
                this.conexion.Close();
            }
        }
        public void AgregarMasajista(Masajista masajista)
        {
            try
            {
                this.conexion.Open();

                string query = "INSERT INTO masajista (edad, nombre, apellido, paises, lugarDeTituloDeEstudio)" +
                               "VALUES (@nombre, @apellido, @edad, @pais, @[lugar de estudio])";

                this.comando = new SqlCommand(query, conexion);
                this.comando.Parameters.AddWithValue("@nombre", masajista.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", masajista.Apellido);
                this.comando.Parameters.AddWithValue("@edad", masajista.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)masajista.Pais);
                this.comando.Parameters.AddWithValue("@[lugar de estudio]", masajista.CertificadoMasaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar Entrenador a la base de datos: " + ex.Message);
            }
            finally
            {
                this.conexion.Close();
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                {
                    conexion.Close();
                    Console.WriteLine("Conexión cerrada correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}
