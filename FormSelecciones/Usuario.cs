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
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el número de legajo del usuario.
        /// </summary>
        public int Legajo { get; set; }

        /// <summary>
        /// Obtiene o establece el correo del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Obtiene o establece el perfil del usuario.
        /// </summary>
        public string Perfil { get; set; }

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
