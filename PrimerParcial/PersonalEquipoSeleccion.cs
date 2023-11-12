using System.Text;

namespace PrimerParcial
{
    public abstract class PersonalEquipoSeleccion
    {
        /// <summary>
        /// Constructor predeterminado que inicializa valores por defecto.
        /// </summary>
        public int edad;
        public string nombre;
        public string apellido;
        public EPaises paises;

        
        public PersonalEquipoSeleccion()
        {
            this.edad = 0;
            this.nombre = "SIN NOMBRE";
            this.apellido = "SIN APELLIDO";
            this.paises = EPaises.Brasil;
        }

        /// <summary>
        /// Constructor con un parámetro 'edad' que llama al constructor predeterminado.
        /// </summary>
        public PersonalEquipoSeleccion(int edad) : this()
        {
            this.edad= edad;
        }

        /// <summary>
        /// Constructor con dos parámetros 'edad' y 'nombre' que llama al constructor anterior.
        /// </summary>
        public PersonalEquipoSeleccion(int edad, string nombre) : this(edad)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Constructor con tres parámetros 'edad', 'nombre' y 'apellido' que llama al constructor anterior.
        /// </summary>
        public PersonalEquipoSeleccion(int edad, string nombre, string apellido) : this(edad, nombre)
        {
            this.apellido = apellido;
        }

        /// <summary>
        /// Constructor con cuatro parámetros 'edad', 'nombre', 'apellido' y 'paises' que llama al constructor anterior.
        /// </summary>
        public PersonalEquipoSeleccion(int edad, string nombre, string apellido, EPaises paises) : this(edad, nombre, apellido)
        {
            this.paises = paises;
        }

        /// <summary>
        /// Método abstracto que debe ser implementado por las clases derivadas.
        /// </summary>
        public abstract string RealizarAccion();

        /// <summary>
        /// Método virtual que puede ser sobrescrito por las clases derivadas para representar la acción de concentración.
        /// </summary>
        public virtual string Concentrarse()
        {
            return $"{this.nombre} {this.apellido}";
        }

        /// <summary>
        /// Método virtual que puede ser sobrescrito por las clases derivadas para representar la acción de viajar.
        /// </summary>
        public virtual string Viajar()
        {
            return $"{this.nombre} {this.apellido}";
        }

        /// <summary>
        /// Método que devuelve una representación en cadena del objeto.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}, Apellido: {this.apellido}, Edad: {this.edad}, País: {this.paises}");
            return sb.ToString();
        }

        /// <summary>
        /// Método que verifica la igualdad entre dos objetos.
        /// </summary>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is PersonalEquipoSeleccion)
            {
                retorno = this == (PersonalEquipoSeleccion)obj;
            }
            return retorno;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }



        //public static bool operator ==(GenteEquipoSeleccion a, GenteEquipoSeleccion b)
        //{
        //    if (ReferenceEquals(a, b))
        //        return true;
        //    if (a is null || b is null)
        //        return false;

        //    return a.Equals(b);
        //}

        //public static bool operator !=(GenteEquipoSeleccion a, GenteEquipoSeleccion b)
        //{
        //    return !(a == b);
        //}
    }
}