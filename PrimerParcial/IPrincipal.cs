using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SegundoParcial
{
    public interface IConvocar
    {
        public bool EsTextoValido(string texto);

        void Modificador<T>(T personal) where T : PersonalEquipoSeleccion;

        public string Capitalize(string input);
    }
}
