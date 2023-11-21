using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public interface IPrincipal<T> where T : PersonalEquipoSeleccion
    {
        void ModificarList<T>(List<T> lista) where T : PersonalEquipoSeleccion;

        void ModificarElemento<T>(List<T> lista) where T : PersonalEquipoSeleccion;

        bool ExistePersonal<T>(T nuevoPersonal) where T : PersonalEquipoSeleccion;


    }
}
