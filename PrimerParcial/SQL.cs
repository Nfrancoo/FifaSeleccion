﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using SegundoParcial;
using Microsoft.Win32;
using System;
using System.IO;

namespace SegundoParcial
{
    /// <summary>
    /// Clase que maneja la conexión y operaciones con una base de datos SQL para objetos del equipo de selección.
    /// </summary>
    public class SQL
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static SQL()
        {
            // Configuración estática de la cadena de conexión desde los recursos del proyecto.
            SQL.cadena_conexion = Properties.Resources.miConexion;
        }

        /// <summary>
        /// Constructor de la clase SQL que inicializa la conexión con la base de datos.
        /// </summary>
        public SQL()
        {
            this.conexion = new SqlConnection(SQL.cadena_conexion);
        }

        /// <summary>
        /// Método para agregar un jugador a la base de datos y al equipo.
        /// </summary>
        public void AgregarJugador(Jugador jugador, Equipo equipo)
        {
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL usando MERGE para insertar o actualizar jugadores según su existencia.
                this.comando.CommandText = @"
                    MERGE INTO jugador AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @dorsal, @posicion)) AS Source (nombre, apellido, edad, pais, dorsal, posicion)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.dorsal = Source.dorsal, Target.posicion = Source.posicion
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais, dorsal, posicion) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source.dorsal, Source.posicion);
                ";

                // Parámetros para la consulta.
                this.comando.Parameters.AddWithValue("@edad", jugador.Edad);
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", jugador.Apellido);
                this.comando.Parameters.AddWithValue("@pais", (int)jugador.Pais);
                this.comando.Parameters.AddWithValue("@dorsal", jugador.Dorsal);
                this.comando.Parameters.AddWithValue("@posicion", (int)jugador.Posicion);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    // Éxito: se actualizó o insertó un registro
                }

                // Agregar el jugador al equipo.
                equipo = equipo + jugador;
            }
            catch { throw new ExcepSql("Error agregando objeto de base de datos"); }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Método para agregar un entrenador a la base de datos y al equipo.
        /// </summary>
        public void AgregarEntrenador(Entrenador entrenador, Equipo equipo)
        {
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL usando MERGE para insertar o actualizar entrenadores según su existencia.
                this.comando.CommandText = @"
                    MERGE INTO entrenador AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @tactica)) AS Source (nombre, apellido, edad, pais, tactica)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.tactica = Source.tactica
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais, tactica) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source.tactica);
                ";

                // Parámetros para la consulta.
                this.comando.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", entrenador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", entrenador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)entrenador.Pais);
                this.comando.Parameters.AddWithValue("@tactica", entrenador.Tactica);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    // Éxito: se actualizó o insertó un registro
                }

                // Agregar el entrenador al equipo.
                equipo = equipo + entrenador;
            }
            catch { throw new ExcepSql("Error agregando objeto de base de datos"); }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Método para agregar un masajista a la base de datos y al equipo.
        /// </summary>
        public void AgregarMasajista(Masajista masajista, Equipo equipo)
        {
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL usando MERGE para insertar o actualizar masajistas según su existencia.
                this.comando.CommandText = @"
                    MERGE INTO masajistas AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @lugarDeEstudio)) AS Source (nombre, apellido, edad, pais, lugarDeEstudio)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.lugarDeEstudio = Source.lugarDeEstudio
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais, lugarDeEstudio) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source.lugarDeEstudio);
                ";

                // Parámetros para la consulta.
                this.comando.Parameters.AddWithValue("@nombre", masajista.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", masajista.Apellido);
                this.comando.Parameters.AddWithValue("@edad", masajista.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)masajista.Pais);
                this.comando.Parameters.AddWithValue("@lugarDeEstudio", masajista.CertificadoMasaje);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    // Éxito: se actualizó o insertó un registro
                }

                // Agregar el masajista al equipo.
                equipo = equipo + masajista;
            }
            catch { throw new ExcepSql("Error agregando objeto de base de datos"); }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Método para modificar datos de un jugador en la base de datos.
        /// </summary>
        public bool ModificarDato(Jugador jugador)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL para actualizar datos de un jugador.
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", jugador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", jugador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)jugador.Pais);
                this.comando.Parameters.AddWithValue("@dorsal", jugador.Dorsal);
                this.comando.Parameters.AddWithValue("@posicion", (int)jugador.Posicion);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = @"UPDATE jugador SET edad = @edad, dorsal = @dorsal, posicion = @posicion 
                                            WHERE nombre = @nombre AND apellido = @apellido AND pais = @pais";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch { throw new ExcepSql("Error modificando objeto de base de datos"); }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Método para modificar datos de un entrenador en la base de datos.
        /// </summary>
        public bool ModificarDato(Entrenador entrenador)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL para actualizar datos de un entrenador.
                this.comando.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", entrenador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", entrenador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)entrenador.Pais);
                this.comando.Parameters.AddWithValue("@tactica", entrenador.Tactica);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = @"UPDATE entrenador SET edad = @edad, tactica = @tactica
                                            WHERE nombre = @nombre AND apellido = @apellido AND pais = @pais";

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch { throw new ExcepSql("Error modificando objeto de base de datos"); }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Método para modificar datos de un masajista en la base de datos.
        /// </summary>
        public bool ModificarDato(Masajista masajista)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL para actualizar datos de un masajista.
                this.comando.Parameters.AddWithValue("@id", masajista.id);
                this.comando.Parameters.AddWithValue("@nombre", masajista.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", masajista.Apellido);
                this.comando.Parameters.AddWithValue("@edad", masajista.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)masajista.Pais);
                this.comando.Parameters.AddWithValue("@lugarDeEstudio", masajista.CertificadoMasaje);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = @"UPDATE masajistas SET edad = @edad, lugarDeEstudio = @lugarDeEstudio
                                            WHERE nombre = @nombre AND apellido = @apellido AND pais = @pais";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch { throw new ExcepSql("Error modificando objeto de base de datos"); }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Método para borrar datos de un jugador en la base de datos y del equipo.
        /// </summary>
        public bool BorrarDato(Jugador jugador, Equipo equipo)
        {
            bool result = false;
            try
            {
                this.comando = new SqlCommand();

                // Consulta SQL para borrar datos de un jugador.
                this.comando.Connection = this.conexion;
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM jugador WHERE nombre=@nombre";

                this.conexion.Open();

                // Ejecución de la consulta.
                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }

                equipo = equipo - jugador;
            }
            catch { throw new ExcepSql("Error borrando objeto de base de datos"); }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return result;
        }
        /// <summary>
        /// Borra los datos de un entrenador de la base de datos y actualiza el equipo.
        /// </summary>
        /// <param name="entrenador">Objeto Entrenador a ser borrado.</param>
        /// <param name="equipo">Objeto Equipo que se actualizará al borrar el entrenador.</param>
        /// <returns>True si el borrado fue exitoso, False en caso contrario.</returns>
        public bool BorrarDato(Entrenador entrenador, Equipo equipo)
        {
            bool result = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexion;
                this.comando.Parameters.AddWithValue("@nombre", entrenador.Nombre);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM entrenador WHERE nombre=@nombre";

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }

                equipo = equipo - entrenador;
            }
            catch { throw new ExcepSql("Error borrando objeto de base de datos"); }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            

            return result;
        }

        /// <summary>
        /// Borra los datos de un masajista de la base de datos y actualiza el equipo.
        /// </summary>
        /// <param name="masajista">Objeto Masajista a ser borrado.</param>
        /// <param name="equipo">Objeto Equipo que se actualizará al borrar el masajista.</param>
        /// <returns>True si el borrado fue exitoso, False en caso contrario.</returns>
        public bool BorrarDato(Masajista masajista, Equipo equipo)
        {
            bool result = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexion;
                this.comando.Parameters.AddWithValue("@nombre", masajista.Nombre);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM masajistas WHERE nombre=@nombre";

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }

                equipo = equipo - masajista;
            }
            catch { throw new ExcepSql("Error borrando objeto de base de datos"); }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return result;
        }


        /// <summary>
        /// Carga los datos de jugadores desde la base de datos y los agrega a la lista proporcionada.
        /// </summary>
        /// <param name="personal">Lista de objetos de tipo PersonalEquipoSeleccion.</param>
        public void CargarJugadoresDesdeBaseDeDatos(List<PersonalEquipoSeleccion> personal)
        {
            try
            {
                // Aquí debes ajustar la consulta y el mapeo según tu esquema de base de datos.
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "SELECT * FROM jugador";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    Jugador jugador = new Jugador();
                    jugador.Edad = (int)this.lector["edad"];
                    jugador.Nombre = this.lector["nombre"].ToString();
                    jugador.Apellido = this.lector["apellido"].ToString();
                    jugador.Pais = (EPaises)Convert.ToInt32(this.lector["pais"]);
                    jugador.Dorsal = (int)this.lector["dorsal"];
                    if (Enum.TryParse(this.lector["posicion"].ToString(), out EPosicion posicionEnum))
                    {
                        jugador.Posicion = posicionEnum;
                    }
                    else
                    {
                        // Manejo de error: No se pudo convertir el valor a EPosicion
                        Console.WriteLine("Error al convertir el valor de 'posicion' a EPosicion.");
                    }
                    // Otros mapeos específicos para la clase Jugador

                    personal.Add(jugador);
                }

                this.lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos de jugadores desde la base de datos: " + ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        /// <summary>
        /// Carga los datos de entrenadores desde la base de datos y los agrega a la lista proporcionada.
        /// </summary>
        /// <param name="lista">Lista de objetos de tipo PersonalEquipoSeleccion.</param>
        public void CargarEntrenadoresDesdeBaseDeDatos(List<PersonalEquipoSeleccion> lista)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "SELECT * FROM entrenador";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    Entrenador entrenador = new Entrenador();
                    entrenador.Edad = (int)this.lector["edad"];
                    entrenador.Nombre = this.lector["nombre"].ToString();
                    entrenador.Apellido = this.lector["apellido"].ToString();
                    entrenador.Pais = (EPaises)Convert.ToInt32(this.lector["pais"]);
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

        /// <summary>
        /// Carga los datos de masajistas desde la base de datos y los agrega a la lista proporcionada.
        /// </summary>
        /// <param name="lista">Lista de objetos de tipo PersonalEquipoSeleccion.</param>
        public void CargarMasajistaDesdeBaseDeDatos(List<PersonalEquipoSeleccion> lista)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "SELECT * FROM masajistas";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    Masajista masajista = new Masajista();
                    masajista.Edad = (int)this.lector["edad"];
                    masajista.Nombre = this.lector["nombre"].ToString();
                    masajista.Apellido = this.lector["apellido"].ToString();
                    masajista.Pais = (EPaises)Convert.ToInt32(this.lector["pais"]);
                    masajista.CertificadoMasaje = this.lector["lugarDeEstudio"].ToString();

                    lista.Add(masajista);
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

        /// <summary>
        /// Carga todos los datos de personal (jugadores, entrenadores, masajistas) desde la base de datos y los agrega a la lista proporcionada.
        /// </summary>
        /// <param name="lista">Lista de objetos de tipo PersonalEquipoSeleccion.</param>
        public void CargarDatosDesdeBaseDeDatos(List<PersonalEquipoSeleccion> lista)
        {
            try
            {
                CargarJugadoresDesdeBaseDeDatos(lista);
                CargarEntrenadoresDesdeBaseDeDatos(lista);
                CargarMasajistaDesdeBaseDeDatos(lista);
            }
            catch { throw new ExcepSql("Error al traer el catálogo desde la base de datos"); }
        }
    }
}
