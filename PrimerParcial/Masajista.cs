using System;
using System.Text;
using System.Text.Json.Serialization;

namespace SegundoParcial
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
        public Masajista()
        {
            this.lugarDeTituloDeEstudio = "";
        }

        /// <summary>
        /// Constructor que inicializa un masajista con su información básica y el lugar donde obtuvo el título de estudio.
        /// </summary>
        /// <param name="edad">Edad del masajista.</param>
        /// <param name="nombre">Nombre del masajista.</param>
        /// <param name="apellido">Apellido del masajista.</param>
        /// <param name="pais">País del masajista.</param>
        /// <param name="lugarDeTituloDeEstudio">Lugar donde el masajista obtuvo su título de estudio.</param>
        public Masajista(int edad, string nombre, string apellido, EPaises pais, string lugarDeTituloDeEstudio) : base(edad, nombre, apellido, pais)
        {
            this.lugarDeTituloDeEstudio = lugarDeTituloDeEstudio;
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
        public override string RealizarConcentracion()
        {
            return $"{base.nombre} {base.apellido} se está concentrando con el equipo.";
        }

        /// <summary>
        /// Método que devuelve una representación en cadena del masajista.
        /// </summary>
        public override string ToString()
        {
            string baseInfo = base.ToString(); // Obtén la representación en cadena de la clase base
            StringBuilder sb = new StringBuilder(baseInfo);

            // Agrega la información específica del Masajista
            sb.Append($", Facultad donde estudió: {this.lugarDeTituloDeEstudio}, Personal: Masajista");

            return sb.ToString();
        }

        /// <summary>
        /// Método que verifica la igualdad entre dos objetos Masajista.
        /// </summary>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Masajista)
            {
                retorno = this == (Masajista)obj;
            }
            return retorno;
        }
    }
}
