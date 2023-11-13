using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace SegundoParcial
{
    internal class SQL
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static SQL()
        {
            SQL.cadena_conexion = Properties.Resources.miConexion;
        }

        public SQL()
        {
            this.conexion = new SqlConnection(SQL.cadena_conexion);

        }
    }
}
