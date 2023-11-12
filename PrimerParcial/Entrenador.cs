using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrimerParcial
{
    /// <summary>
    /// Clase que representa a un entrenador en un equipo de selección.
    /// </summary>
    public class Entrenador : PersonalEquipoSeleccion
    {
        public string tactica;

        /// <summary>
        /// Constructor que inicializa un entrenador con su información básica y la táctica a utilizar.
        /// </summary>
        public Entrenador(int edad, string nombre,string apellido,EPaises pais ,string tactica):base(edad, nombre, apellido, pais)
        {
            this.tactica = tactica;
        }

        
        //public PersonalEquipoSeleccion Equipo { get; set; }

        
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

        /// <summary>
        /// Propiedad para obtener o establecer la táctica del entrenador.
        /// </summary>
        public string Tactica
        {
            get { return this.tactica; }
            set { this.tactica = value; }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EPaises Pais
        {
            get { return this.paises; }
            set { this.paises = value; }
        }

        /// <summary>
        /// Método que describe la acción de concentración del entrenador con el equipo.
        /// </summary>
        public override string Concentrarse()
        {
            return $"{base.nombre} {base.apellido} se está concentrando con el equipo.";
        }

        ///// <summary>
        ///// Método que describe la acción de viajar del entrenador con el equipo.
        ///// </summary>
        //public override string Viajar()
        //{
        //    return $"{base.nombre} {base.apellido} está viajando con el equipo.";
        //}


        /// <summary>
        /// Método que describe la acción que realiza el entrenador.
        /// </summary>
        public override string RealizarAccion()
        {
            return $"{this.nombre} {this.apellido} esta preparando al equipo para salir con la tactica: {this.tactica}.";
        }

        /// <summary>
        /// Método que devuelve una representación en cadena del entrenador, incluyendo los jugadores relacionados.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}, Tactica a usar: {this.tactica}");
            return sb.ToString();
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Entrenador entre)
            {
                // Compara los nombres y apellidos de los jugadores.
                return this.Nombre == entre.Nombre && this.Apellido == entre.Apellido;
            }
            return false;
        }
    }
}
