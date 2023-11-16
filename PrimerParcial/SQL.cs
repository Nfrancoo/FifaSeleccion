using System;
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

        public void AgregarJugador(Jugador jugador, Equipo equipo)
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

                equipo.ListaPesonal.Add(jugador);

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

        public void AgregarEntrenador(Entrenador entrenador, Equipo equipo)
        {
            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandText = @"
                    MERGE INTO entrenador AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @tactica)) AS Source (nombre, apellido, edad, pais, tactica)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.tactica = Source.tactica
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

                equipo.ListaPesonal.Add(entrenador);
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
        public void AgregarMasajista(Masajista masajista, Equipo equipo)
        {
            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandText = @"
                    MERGE INTO masajistas AS Target
                    USING (VALUES (@nombre, @apellido, @edad, @pais, @lugarDeEstudio)) AS Source (nombre, apellido, edad, pais, lugarDeEstudio)
                    ON Target.nombre = Source.nombre AND Target.apellido = Source.apellido AND Target.edad = Source.edad AND Target.pais = Source.pais
                    WHEN MATCHED THEN
                        UPDATE SET Target.lugarDeEstudio = Source.lugarDeEstudio
                    WHEN NOT MATCHED THEN
                        INSERT (nombre, apellido, edad, pais, lugarDeEstudio) VALUES (Source.nombre, Source.apellido, Source.edad, Source.pais, Source.lugarDeEstudio);
                ";

                this.comando.Parameters.AddWithValue("@nombre", masajista.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", masajista.Apellido);
                this.comando.Parameters.AddWithValue("@edad", masajista.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)masajista.Pais);
                this.comando.Parameters.AddWithValue("@lugarDeEstudio", masajista.CertificadoMasaje);

                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    // Éxito: se actualizó o insertó un registro
                }

                equipo.ListaPesonal.Add(masajista);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar Masajista a la base de datos: " + ex.Message);
            }
            finally
            {
                this.conexion.Close();
            }
        }

        public bool ModificarDato(Jugador jugador)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
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

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }
        public bool ModificarDato(Entrenador jugador)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", jugador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", jugador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)jugador.Pais);
                this.comando.Parameters.AddWithValue("@tactica", jugador.Tactica);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = @"UPDATE entrenador SET edad = @edad, tactica = @tactica
                                            WHERE nombre = @nombre AND apellido = @apellido AND pais = @pais";

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }
        public bool ModificarDato(Masajista jugador)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@id", jugador.id);
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", jugador.Apellido);
                this.comando.Parameters.AddWithValue("@edad", jugador.Edad);
                this.comando.Parameters.AddWithValue("@pais", (int)jugador.Pais);
                this.comando.Parameters.AddWithValue("@lugarDeEstudio", jugador.CertificadoMasaje);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = @"UPDATE masajistas SET edad = @edad, lugarDeEstudio = @lugarDeEstudio
                                            WHERE nombre = @nombre AND apellido = @apellido AND pais = @pais";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        public bool BorrarDato(Jugador jugador, Equipo equipo)
        {
            bool result = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexion;
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM jugador WHERE nombre=@nombre";

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            equipo.ListaPesonal.Remove(jugador);

            return result;
        }

        public bool BorrarDato(Entrenador jugador, Equipo equipo)
        {
            bool result = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexion;
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM entrenador WHERE nombre=@nombre";

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            equipo.ListaPesonal.Remove(jugador);

            return result;
        }

        public bool BorrarDato(Masajista jugador, Equipo equipo)
        {
            bool result = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexion;
                this.comando.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM masajistas WHERE nombre=@nombre";

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            equipo.ListaPesonal.Remove(jugador);

            return result;
        }


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
                    Masajista masajistas = new Masajista();
                    masajistas.Edad = (int)this.lector["edad"];
                    masajistas.Nombre = this.lector["nombre"].ToString();
                    masajistas.Apellido = this.lector["apellido"].ToString();
                    masajistas.Pais = (EPaises)Convert.ToInt32(this.lector["pais"]);
                    masajistas.CertificadoMasaje = this.lector["lugarDeEstudio"].ToString();

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

        public void CargarDatosDesdeBaseDeDatos(List<PersonalEquipoSeleccion> lista)
        {
            try
            {
                CargarJugadoresDesdeBaseDeDatos(lista);
                CargarEntrenadoresDesdeBaseDeDatos(lista);
                CargarMasajistaDesdeBaseDeDatos(lista);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde la base de datos: " + ex.Message);
            }
        }

    }
}
