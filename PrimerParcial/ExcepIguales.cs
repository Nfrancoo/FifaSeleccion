using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class ExcepIguales : Exception
    {
        public ExcepIguales(string msj) : base(msj) { }
    }
}
