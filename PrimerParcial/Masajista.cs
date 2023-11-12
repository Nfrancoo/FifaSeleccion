using System;
using System.Text.Json.Serialization;

namespace PrimerParcial
{
    /// <summary>
    /// Clase que representa a un masajista en un equipo de selección.
    /// </summary>
    public class Masajista : PersonalEquipoSeleccion
    {
        private string lugarDeTituloDeEstudio;


        /// <summary>
        /// Constructor predeterminado que inicializa un masajista con un título de estudio en blanco.
        /// </summary>
        [JsonConstructor]
        public Masajista()
        {
            this.lugarDeTituloDeEstudio = "";
        }

        /// <summary>
        /// Constructor que inicializa un masajista con su información básica y el lugar donde obtuvo el título de estudio.
        /// </summary>

        public Masajista(int edad, string nombre, string apellido, EPaises pais, string lugarDeTituloDeEstudio) : base(edad, nombre, apellido, pais)
        {
            this.lugarDeTituloDeEstudio = lugarDeTituloDeEstudio;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }


        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPaises Pais
        {
            get { return this.paises; }
            set { this.paises = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el lugar donde el masajista obtuvo su título de estudio.
        /// </summary>
        public string CertificadoMasaje
        {
            get { return lugarDeTituloDeEstudio; }
            set { this.lugarDeTituloDeEstudio = value; }
        }

        /// <summary>
        /// Método que describe la acción que realiza el masajista.
        /// </summary>
        public override string RealizarAccion()
        {
            return $"{this.nombre} {this.apellido} está masajeando a los jugadores.";
        }

        /// <summary>
        /// Método que describe la acción de concentración del masajista.
        /// </summary>
        public override string Concentrarse()
        {
            return $"{base.nombre} {base.apellido} se está concentrando con el equipo.";
        }

        //public override string Viajar()
        //{
        //    return $"{base.nombre} {base.apellido} está viajando con el equipo.";
        //}

        /// <summary>
        /// Método que devuelve una representación en cadena del masajista.
        /// </summary>
        public override string ToString()
        {
            return $"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Facultadad donde estudio: {this.lugarDeTituloDeEstudio}";
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Masajista masajista)
            {
                // Compara los nombres y apellidos de los jugadores.
                return this.Nombre == masajista.Nombre && this.Apellido == masajista.Apellido;
            }
            return false;
        }
    }
}
