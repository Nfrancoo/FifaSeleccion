using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class ExcepSql : Exception
    {
        public ExcepSql(string msj) : base(msj) { }
    }
}
