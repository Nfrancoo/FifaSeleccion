using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSelecciones
{
    /// <summary>
    /// Representa un usuario en la aplicación.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtiene o establece a cada uno de los elementos del Json.
        /// </summary>
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }


        /// <summary>
        /// Delegado para notificar acceso no permitido.
        /// </summary>
        public delegate void DelegadoString(string str);

        /// <summary>
        /// Evento para notificar acceso no permitido.
        /// </summary>
        public event DelegadoString notificarAccesoNoPermitido;


        /// <summary>
        /// Agrega un suscriptor al evento NotificarAccesoNoPermitido.
        /// </summary>
        public event DelegadoString NotificarAccesoNoPermitido
        {
            add
            {
                notificarAccesoNoPermitido += value;
            }
            remove
            {
                notificarAccesoNoPermitido -= value;
            }
        }

        /// <summary>
        /// Notifica acceso no permitido invocando el evento.
        /// </summary>
        public void NotificarAcceso(string mensaje)
        {
            notificarAccesoNoPermitido?.Invoke(mensaje);
        }
    }
}