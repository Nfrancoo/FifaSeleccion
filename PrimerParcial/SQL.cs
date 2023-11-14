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
        private SqlDataReader lector;

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
                this.comando = new SqlCommand();

                this.comando.CommandText = @"
                    MERGE INTO jugador AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @dorsal, @posicion)) AS Source (nombre, apellido, edad, pais, dorsal, posicion)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.dorsal = Source.dorsal, Target.posicion = Source.posicion
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais, dorsal, posicion) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source.dorsal, Source.posicion);
                ";

                this.comando.Parameters.AddWithValue("@edad", jugador.Edad);
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", jugador.Apellido);
                this.comando.Parameters.AddWithValue("@pais", (int)jugador.Pais);
                this.comando.Parameters.AddWithValue("@dorsal", jugador.Dorsal);
                this.comando.Parameters.AddWithValue("@posicion", (int)jugador.Posicion);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                }
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
                this.comando = new SqlCommand();

                this.comando.CommandText = @"
                    MERGE INTO entrenador AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @tactica)) AS Source (nombre, apellido, edad, pais, tactica)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.dorsal = Source.dorsal, Target.posicion = Source.posicion
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais, tactica) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source.tactica);
                ";

                this.comando.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", entrenador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", entrenador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)entrenador.Pais);
                this.comando.Parameters.AddWithValue("@tactica", entrenador.Tactica);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                }
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
                this.comando = new SqlCommand();

                this.comando.CommandText = @"
                    MERGE INTO masajistas AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @[lugar de estudio])) AS Source (nombre, apellido, edad, pais,  lugarDeTituloDeEstudio)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.dorsal = Source.dorsal, Target.posicion = Source.posicion
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais,  lugarDeTituloDeEstudio) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source. lugarDeTituloDeEstudio);
                ";

                this.comando.Parameters.AddWithValue("@nombre", masajista.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", masajista.Apellido);
                this.comando.Parameters.AddWithValue("@edad", masajista.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)masajista.Pais);
                this.comando.Parameters.AddWithValue("@[lugar de estudio]", masajista.CertificadoMasaje);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                }
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

        public void CargarDatosDesdeBaseDeDatosJug<T>(int pais, ref List<T> lista) where T : Jugador, new()
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM jugador WHERE pais = @pais";
                this.comando.Parameters.AddWithValue("@pais", pais);
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    T jugador = new T();
                    jugador.Edad = (int)this.lector["edad"];
                    jugador.Nombre = this.lector["nombre"].ToString();
                    jugador.Apellido = this.lector["apellido"].ToString();
                    jugador.Pais = (EPaises)pais;
                    jugador.Dorsal = (int)this.lector["dorsal"];

                    // Intentar convertir el valor de 'posicion' a EPosicion
                    if (Enum.TryParse(this.lector["posicion"].ToString(), out EPosicion posicionEnum))
                    {
                        jugador.Posicion = posicionEnum;
                    }
                    else
                    {
                        // Manejo de error: No se pudo convertir el valor a EPosicion
                        Console.WriteLine("Error al convertir el valor de 'posicion' a EPosicion.");
                    }

                    lista.Add(jugador);
                }

                this.lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde la base de datos: " + ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }
        public void CargarDatosDesdeBaseDeDatosEntre<T>(int pais, ref List<T> lista) where T : Entrenador, new()
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM entrenador WHERE pais = @pais";
                this.comando.Parameters.AddWithValue("@pais", pais);
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    T entrenador = new T();
                    entrenador.Edad = (int)this.lector["edad"];
                    entrenador.Nombre = this.lector["nombre"].ToString();
                    entrenador.Apellido = this.lector["apellido"].ToString();
                    entrenador.Pais = (EPaises)pais;
                    entrenador.Tactica = this.lector["tactica"].ToString();

                    lista.Add(entrenador);
                }

                this.lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde la base de datos: " + ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public void CargarDatosDesdeBaseDeDatosMasaj<T>(int pais, ref List<T> lista) where T : Masajista, new()
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM masajistas WHERE pais = @pais";
                this.comando.Parameters.AddWithValue("@pais", pais);
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    T masajistas = new T();
                    masajistas.Edad = (int)this.lector["edad"];
                    masajistas.Nombre = this.lector["nombre"].ToString();
                    masajistas.Apellido = this.lector["apellido"].ToString();
                    masajistas.Pais = (EPaises)pais;
                    masajistas.CertificadoMasaje = this.lector["[lugar de estudio]"].ToString();

                    lista.Add(masajistas);
                }

                this.lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde la base de datos: " + ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }
    }
}
