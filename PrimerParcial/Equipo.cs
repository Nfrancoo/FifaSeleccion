﻿using Microsoft.Win32;
using SegundoParcial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SegundoParcial
{
    /// <summary>
    /// Clase que representa un equipo y contiene una lista de miembros del equipo.
    /// </summary>
    public class Equipo
    {
        private List<PersonalEquipoSeleccion> listaPersonal;

        /// <summary>
        /// Obtiene o establece la lista de miembros del equipo.
        /// </summary>
        public List<PersonalEquipoSeleccion> ListaPesonal
        {
            get { return this.listaPersonal; }
            set { this.listaPersonal = value; }
        }

        /// <summary>
        /// Constructor predeterminado de la clase Equipo.
        /// </summary>
        public Equipo()
        {
            this.listaPersonal = new List<PersonalEquipoSeleccion>();
        }

        /// <summary>
        /// Operador de adición. Agrega un nuevo miembro al equipo si no existe.
        /// </summary>
        /// <param name="equipo">Equipo al que se agregará el miembro.</param>
        /// <param name="personal">Miembro a agregar al equipo.</param>
        /// <returns>El equipo con el nuevo miembro agregado.</returns>
        public static Equipo operator +(Equipo equipo, PersonalEquipoSeleccion personal)
        {
            if (equipo != null && personal != null)
            {
                bool existe = equipo.ListaPesonal.Any(p => p.Equals(personal));

                if (!existe)
                {
                    equipo.ListaPesonal.Add(personal);  // Agrega el nuevo miembro al equipo existente
                }
            }

            return equipo;
        }

        /// <summary>
        /// Operador de sustracción. Intenta eliminar un miembro del equipo si existe.
        /// </summary>
        /// <param name="equipo">Equipo del que se eliminará el miembro.</param>
        /// <param name="personal">Miembro a eliminar del equipo.</param>
        /// <returns>El equipo con el miembro eliminado, si existía.</returns>
        public static Equipo operator -(Equipo equipo, PersonalEquipoSeleccion personal)
        {
            if (equipo != null && personal != null)
            {
                // Intenta encontrar y eliminar el miembro en el equipo existente
                PersonalEquipoSeleccion miembroAEliminar = equipo.ListaPesonal.FirstOrDefault(p => p.Equals(personal));

                if (miembroAEliminar != null)
                {
                    equipo.ListaPesonal.Remove(miembroAEliminar);  // Elimina el miembro del equipo existente
                }
            }

            return equipo;
        }

        /// <summary>
        /// Método de ordenación por edad de forma ascendente.
        /// </summary>
        public static int OrdenarPorEdadAS(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2)
        {
            if (j1.Edad < j2.Edad)
            {
                return -1;
            }
            else if (j1.Edad > j2.Edad)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Método de ordenación por edad de forma descendente.
        /// </summary>
        public static int OrdenarPorEdadDes(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2)
        {
            if (j1.Edad > j2.Edad)
            {
                return -1;
            }
            else if (j1.Edad < j2.Edad)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Método de ordenación por país de forma ascendente.
        /// </summary>
        public static int OrdenarPorPaisAs(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2)
        {
            return j1.Pais.CompareTo(j2.Pais);
        }

        /// <summary>
        /// Método de ordenación por país de forma descendente.
        /// </summary>
        public static int OrdenarPorPaisDes(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2)
        {
            return j2.Pais.CompareTo(j1.Pais);
        }
    }
}
