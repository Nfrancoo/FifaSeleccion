using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegundoParcial;


namespace FormSelecciones
{
    /// <summary>
    /// Formulario para gestionar el personal de la selección.
    /// </summary>
    public partial class Personal : Form
    {
        /// <summary>
        /// Obtiene o establece un nuevo personal(juugador,entrenador,masajista) creado o editado.
        /// </summary>
        public Jugador nuevoJugador;
        public Entrenador nuevoEntrenador;
        public Masajista nuevoMasajista;
        public bool esJugador;
        public bool esEntrenador;
        public bool esMasajista;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Personal"/>.
        /// </summary>
        public Personal()
        {
            this.esJugador = false;
            this.esEntrenador = false;
            this.esMasajista = false;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        /// <summary>
        /// Maneja el evento Click del botón "Jugador" lo que hace que abra el form de
        /// ConvocarJugador y asi convocar el jugador
        /// </summary>
        private void btnJugador_Click(object sender, EventArgs e)
        {
            ConvocarJugador jugador = new ConvocarJugador();
            jugador.ShowDialog();

            this.esJugador = true;
            if (jugador.DialogResult == DialogResult.OK)
            {
                nuevoJugador = jugador.NuevoJugador;
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        /// <summary>
        /// Maneja el evento Click del botón "Entrenador" lo que hace que abra el form de
        /// ConvocarEntrenador y asi convocar el entrenador
        /// </summary>
        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            ConvocarEntrenador entrenador = new ConvocarEntrenador();
            entrenador.ShowDialog();


            this.esMasajista = true;
            if (entrenador.DialogResult == DialogResult.OK)
            {
                nuevoEntrenador = entrenador.NuevoEntrenador;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

            this.Close();
        }

        /// <summary>
        /// Maneja el evento Click del botón "Masajista" lo que hace que abra el form de
        /// ConvocarMasajista y asi convocar el masajista
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            ConvocarMasajista masajista = new ConvocarMasajista();
            masajista.ShowDialog();

            this.esMasajista = true;
            if (masajista.DialogResult == DialogResult.OK)
            {
                nuevoMasajista = masajista.NuevoMasajista;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}