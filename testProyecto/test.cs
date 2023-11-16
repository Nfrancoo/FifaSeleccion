using SegundoParcial;

namespace testProyecto
{
    [TestClass]
    public class test
    {
        [TestMethod]
        public void VerificarJugadoresIguales()
        {
            Jugador jugador1 = new Jugador(30, "Franco", "Quiro", EPaises.Argentina, 10, EPosicion.Delantero);
            Jugador jugador2 = new Jugador(40, "Franco", "Quiro", EPaises.Argentina, 20, EPosicion.Mediocentro);

            bool rta = jugador1 == jugador2;

            Assert.IsTrue(rta);

        }
    }
}