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
        public static bool operator +(Equipo r, PersonalEquipoSeleccion j)
        {
            bool agregado = true;
            if (r.listaPersonal.Count > 0)
            {
                foreach (PersonalEquipoSeleccion personal in r.ListaPesonal)
                {
                    if (personal.Equals(j))
                    {
                        agregado = false;
                        break;
                    }

                }
            }

            if (agregado || r.ListaPesonal.Count == 0)
            {
                r.ListaPesonal.Add(j);

            }
            return agregado;
        }
        public static bool operator -(Equipo r, PersonalEquipoSeleccion j)
        {
            bool eliminado = false;
            if (r.listaPersonal.Count > 0)
            {
                foreach (PersonalEquipoSeleccion personal in r.listaPersonal)
                {
                    if (personal.Equals(j))
                    {
                        r.listaPersonal.Remove(personal);
                        eliminado = true;
                        break;
                    }
                }
            }

            return eliminado;
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
