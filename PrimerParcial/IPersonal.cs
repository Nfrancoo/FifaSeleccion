using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    /// <summary>
    /// Interfaz que define las acciones que debe realizar el personal del equipo de selección.
    /// </summary>
    public interface IPersonal
    {
        /// <summary>
        /// Realiza una acción específica.
        /// </summary>
        /// <returns>Cadena que describe la acción realizada.</returns>
        string RealizarAccion();

        /// <summary>
        /// Realiza una acción de concentración.
        /// </summary>
        /// <returns>Cadena que describe la acción de concentración.</returns>
        string RealizarConcentracion();
    }
}