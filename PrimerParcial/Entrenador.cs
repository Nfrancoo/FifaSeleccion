using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SegundoParcial
{
    /// <summary>
    /// Clase que representa a un entrenador en un equipo de selección.
    /// </summary>
    public class Entrenador : PersonalEquipoSeleccion
    {
        public string tactica;

        /// <summary>
        /// Constructor predeterminado que inicializa un entrenador con su información básica y sin táctica definida.
        /// </summary>
        public Entrenador() : base()
        {
        }

        /// <summary>
        /// Constructor que inicializa un entrenador con su información básica y la táctica a utilizar.
        /// </summary>
        /// <param name="edad">Edad del entrenador.</param>
        /// <param name="nombre">Nombre del entrenador.</param>
        /// <param name="apellido">Apellido del entrenador.</param>
        /// <param name="pais">País del entrenador.</param>
        /// <param name="tactica">Táctica a utilizar por el entrenador.</param>
        public Entrenador(int edad, string nombre, string apellido, EPaises pais, string tactica) : base(edad, nombre, apellido, pais)
        {
            this.tactica = tactica;
        }

        /// <summary>
        /// Propiedad para obtener o establecer la táctica del entrenador.
        /// </summary>
        public string Tactica
        {
            get { return this.tactica; }
            set { this.tactica = value; }
        }

        /// <summary>
        /// Método que describe la acción de concentración del entrenador con el equipo.
        /// </summary>
        public override string RealizarConcentracion()
        {
            return $"{base.nombre} {base.apellido} se está concentrando con el equipo.";
        }

        /// <summary>
        /// Método que describe la acción que realiza el entrenador.
        /// </summary>
        public override string RealizarAccion()
        {
            return $"{this.nombre} {this.apellido} está preparando al equipo para salir con la táctica: {this.tactica}.";
        }

        /// <summary>
        /// Método que devuelve una representación en cadena del entrenador, incluyendo los jugadores relacionados.
        /// </summary>
        public override string ToString()
        {
            string baseInfo = base.ToString(); // Obtén la representación en cadena de la clase base
            StringBuilder sb = new StringBuilder(baseInfo);

            // Agrega la información específica del Entrenador
            sb.Append($", Táctica a usar: {this.tactica}, Personal: Entrenador");

            return sb.ToString();
        }

        /// <summary>
        /// Método que verifica la igualdad entre dos objetos Entrenador.
        /// </summary>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Entrenador)
            {
                retorno = this == (Entrenador)obj;
            }
            return retorno;
        }
    }
}
