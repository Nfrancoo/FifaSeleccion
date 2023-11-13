using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    /// <summary>
    /// Clase que representa un equipo y contiene una lista de miembros del equipo.
    /// </summary>
    public class Equipo
    {
        private List<PersonalEquipoSeleccion> miembros = new List<PersonalEquipoSeleccion>();

        /// <summary>
        /// Sobrecarga del operador '+' para agregar un miembro al equipo.
        /// </summary>
        public static Equipo operator +(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            equipo.miembros.Add(miembro);
            return equipo;
        }

        /// <summary>
        /// Sobrecarga del operador '-' para eliminar un miembro del equipo.
        /// </summary>
        public static Equipo operator -(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            equipo.miembros.Remove(miembro);
            return equipo;
        }

        /// <summary>
        /// Sobrecarga del operador '==' para verificar si un miembro está en el equipo.
        /// </summary>
        public static bool operator ==(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            return equipo.miembros.Contains(miembro);
        }

        /// <summary>
        /// Sobrecarga del operador '!=' para verificar si un miembro no está en el equipo.
        /// </summary>
        public static bool operator !=(Equipo equipo, PersonalEquipoSeleccion miembro)
        {
            return !equipo.miembros.Contains(miembro);
        }

        /// <summary>
        /// Muestra en la consola los miembros del equipo con sus respectivas representaciones en cadena.
        /// </summary>
        public void MostrarMiembros()
        {
            Console.WriteLine("Miembros del equipo:");
            foreach (var miembro in miembros)
            {
                Console.WriteLine(miembro.ToString());
            }
        }
    }
}
