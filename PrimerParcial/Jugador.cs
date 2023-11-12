using System;
using System.Text;
using System.Text.Json.Serialization;

namespace PrimerParcial
{
    /// <summary>
    /// Clase que representa a un jugador en un equipo de selección.
    /// </summary>
    public class Jugador : PersonalEquipoSeleccion
    {
        private int dorsal;
        private EPosicion posicion;
        public Equipo jugador;

        /// <summary>
        /// Constructor que inicializa un jugador con su información básica.
        /// </summary>
        public Jugador(int edad, string nombre, string apellido, EPaises pais, int dorsal, EPosicion posicion)
            : base(edad, nombre, apellido, pais)
        {
            this.dorsal = dorsal;
            this.posicion = posicion;
            this.jugador = new Equipo();
        }

        /// <summary>
        /// Propiedad para obtener o establecer el nombre del jugador.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el apellido del jugador.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }

        }

        /// <summary>
        /// Propiedad para obtener o establecer la edad del jugador.
        /// </summary>
        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el país del jugador con conversión JSON.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPaises Pais 
        {
            get {return this.paises; }
            set {this.paises = value; } 
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
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Posicion: {this.posicion}, Dorsal: {this.dorsal}");
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
            if (obj is Jugador jugador)
            {
                // Compara los nombres y apellidos de los jugadores.
                return this.Nombre == jugador.Nombre && this.Apellido == jugador.Apellido;
            }
            return false;
        }


        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
