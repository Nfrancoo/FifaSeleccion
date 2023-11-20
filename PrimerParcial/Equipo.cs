using Microsoft.Win32;
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


        public List<PersonalEquipoSeleccion> ListaPesonal
        {
            get { return this.listaPersonal; }
            set { this.listaPersonal = value; }
        }

        public Equipo()
        {
            this.listaPersonal = new List<PersonalEquipoSeleccion>();
        }
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


        public static int OrdenarPorEdadAS(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2) // forma ascendente
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

        public static int OrdenarPorEdadDes(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2) // forma descendente
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

        public static int OrdenarPorPaisAs(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2)
        {
            return j1.Pais.CompareTo(j2.Pais);
        }

        public static int OrdenarPorPaisDes(PersonalEquipoSeleccion j1, PersonalEquipoSeleccion j2)
        {
            return j2.Pais.CompareTo(j1.Pais);
        }
    }
}
