using SegundoParcial;

namespace testProyecto
{
    [TestClass]
    public class test
    {
        [TestMethod]
        public void VerificarIgualJugadores()
        {
            Jugador jugador1 = new Jugador(30, "Franco", "Quiro", EPaises.Argentina, 10, EPosicion.Delantero);
            Jugador jugador2 = new Jugador(40, "Franco", "Quiro", EPaises.Argentina, 20, EPosicion.Mediocentro);

            bool rta = jugador1 == jugador2;

            Assert.IsTrue(rta);

        }

        [TestMethod]
        public void VerificarIgualJugadore_Falla()
        {
            //Arrange
            Jugador jugador1 = new Jugador(30, "Franco", "Quiro", EPaises.Argentina, 10, EPosicion.Delantero);
            Jugador jugador2 = new Jugador(40, "Franco", "Quiroga", EPaises.Brasil, 20, EPosicion.Mediocentro);

            //Act
            bool rta = jugador1 == jugador2;

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void VerificarIgualEntrenadoresNulos()
        {
            //Arrange
            Entrenador e1 = null;
            Entrenador e2 = null;

            //Act
            bool rta = e1 == e2;

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void masajista()
        {
            Masajista m = new Masajista(30, "Roberto", "Butragueño", EPaises.Francia, "UBA");

            string certificadoMasaje = m.CertificadoMasaje;

            Assert.IsNotNull(certificadoMasaje);
        }
    }
}