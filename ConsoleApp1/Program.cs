namespace PrimerParcial;
internal class Program
{
    private static void Main(string[] args)
    {

        Equipo equipo = new Equipo();

        Jugador jugador1 = new Jugador(25, "Juan", "Pérez", EPaises.Argentina, 10, EPosicion.Delantero);
        Jugador jugador2 = new Jugador(28, "Luis", "Gómez", EPaises.Brasil, 7, EPosicion.Mediocentro);
        Entrenador entrenador = new Entrenador(45, "Carlos", "Sánchez", EPaises.Argentina, "Táctica 4-4-2");
        Masajista masajista = new Masajista(35, "Ana", "Rodríguez", EPaises.Francia, "Certificado A");

        equipo += jugador1;
        equipo += jugador2;
        equipo += entrenador;
        equipo += masajista;

        equipo.OrdenarPorNombreAscendente();
        equipo.MostrarMiembros();


        Console.WriteLine(jugador1.Viajar());

        Console.WriteLine(jugador1.Concentrarse());
        Console.WriteLine(jugador2.Concentrarse());
        Console.WriteLine(entrenador.Concentrarse());

        jugador1.RealizarAccion();
        entrenador.RealizarAccion();
        masajista.RealizarAccion();

        equipo -= jugador1;
    }
}