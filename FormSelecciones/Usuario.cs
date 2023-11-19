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

        public delegate void DelegadoString(string str);
        public event DelegadoString notificarAccesoNoPermitido;

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

        public void NotificarAcceso(string mensaje)
        {
            notificarAccesoNoPermitido?.Invoke(mensaje);
        }
    }
}
