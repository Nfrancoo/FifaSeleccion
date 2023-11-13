using System;
using System.Text;
using System.Text.Json.Serialization;

namespace SegundoParcial
{
    /// <summary>
    /// Clase que representa a un jugador en un equipo de selección.
    /// </summary>
    public class Jugador : PersonalEquipoSeleccion
    {
        private int dorsal;
        private EPosicion posicion;

        /// <summary>
        /// Constructor que inicializa un jugador con su información básica.
        /// </summary>
        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, EPosicion posicion)
            : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.posicion = posicion;
        }

        /// <summary>
        /// Propiedad para obtener o establecer el número dorsal del jugador.
        /// </summary>
        public int Dorsal
        {
            get { return this.dorsal; }
            set { this.dorsal = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer la posición del jugador con conversión JSON.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPosicion Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        /// <summary>
        /// Método que devuelve una representación en cadena del jugador.
        /// </summary>
        public override string ToString()
        {
            string baseInfo = base.ToString(); // Obtén la representación en cadena de la clase base
            StringBuilder sb = new StringBuilder(baseInfo);

            // Agrega la información específica del Jugador
            sb.Append($", Posicion: {this.posicion}, Dorsal: {this.dorsal}");

            return sb.ToString();
        }

        /// <summary>
        /// Método que describe la acción que realiza el jugador.
        /// </summary>
        public override string RealizarAccion()
        {
            return $"El jugador {this.nombre} {this.apellido} está entrenando.";
        }

        /// <summary>
        /// Método que describe la acción de concentración del jugador.
        /// </summary>
        public override string Concentrarse()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.nombre} {this.apellido} se está concentrando.");
            return sb.ToString().Trim();
            //Console.WriteLine($"{this.nombre} {this.apellido} se está concentrando.");
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Jugador)
            {
                retorno = this == (Jugador)obj;
            }
            return retorno;
        }

        public static List<Jugador> operator +(List<Jugador> lista, Jugador entrenador)
        {
            if (!lista.Contains(entrenador))
            {
                lista.Add(entrenador);
            }
            return lista;
        }

        public static bool operator ==(Jugador uno, Jugador dos)
        {
            return uno.Nombre == dos.Nombre && uno.Apellido == dos.Apellido;
        }

        public static bool operator !=(Jugador uno, Jugador dos)
        {
            return !(uno == dos);
        }
    }
}
