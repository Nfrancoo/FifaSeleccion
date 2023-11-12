using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimerParcial;


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

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Personal"/>.
        /// </summary>
        public Personal()
        {
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

            if (entrenador.DialogResult == DialogResult.OK)
            {
                nuevoEntrenador = entrenador.NuevoEntrenador;
                this.DialogResult = DialogResult.OK; // Establece DialogResult en OK
            }
            else
            {
                this.DialogResult = DialogResult.Cancel; // Establece DialogResult en Cancel si se presiona el botón Cancelar
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
