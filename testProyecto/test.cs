using SegundoParcial;

namespace testProyecto
{
    /// <summary>
    /// Clase de pruebas para verificar la funcionalidad de las clases del proyecto.
    /// </summary>
    [TestClass]
    public class test
    {
        /// <summary>
        /// Método de prueba para verificar la igualdad entre dos jugadores.
        /// </summary>
        [TestMethod]
        public void VerificarIgualJugadores()
        {
            // Arrange
            Jugador jugador1 = new Jugador(30, "Franco", "Quiro", EPaises.Argentina, 10, EPosicion.Delantero);
            Jugador jugador2 = new Jugador(40, "Franco", "Quiro", EPaises.Argentina, 20, EPosicion.Mediocentro);

            // Act
            bool rta = jugador1 == jugador2;

            // Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Método de prueba para verificar la desigualdad entre dos jugadores.
        /// </summary>
        [TestMethod]
        public void VerificarIgualJugadore_Falla()
        {
            // Arrange
            Jugador jugador1 = new Jugador(30, "Franco", "Quiro", EPaises.Argentina, 10, EPosicion.Delantero);
            Jugador jugador2 = new Jugador(40, "Franco", "Quiroga", EPaises.Brasil, 20, EPosicion.Mediocentro);

            // Act
            bool rta = jugador1 == jugador2;

            // Assert
            Assert.IsFalse(rta);
        }

        /// <summary>
        /// Método de prueba para verificar la igualdad entre dos entrenadores nulos.
        /// </summary>
        [TestMethod]
        public void VerificarIgualEntrenadoresNulos()
        {
            // Arrange
            Entrenador e1 = null;
            Entrenador e2 = null;

            // Act
            bool rta = e1 == e2;

            // Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Método de prueba para verificar la existencia del certificado de masaje de un masajista.
        /// </summary>
        [TestMethod]
        public void masajista()
        {
            // Arrange
            Masajista m = new Masajista(30, "Roberto", "Butragueño", EPaises.Francia, "UBA");

            // Act
            string certificadoMasaje = m.CertificadoMasaje;

            // Assert
            Assert.IsNotNull(certificadoMasaje);
        }
    }
}
