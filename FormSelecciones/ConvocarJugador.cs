using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegundoParcial;

namespace FormSelecciones
{
    /// <summary>
    /// Formulario para la convocatoria de un jugador.
    /// </summary>
    public partial class ConvocarJugador : Form
    {
        /// <summary>
        /// Obtiene o establece el jugador para editar.
        /// </summary>
        public Jugador JugadorParaEditar { get; set; }

        /// <summary>
        /// Obtiene el nuevo jugador creado o editado.
        /// </summary>
        public Jugador NuevoJugador;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConvocarJugador"/> con un jugador existente para editar.
        /// </summary>
        /// <param name="jug">El jugador a editar.</param>
        public ConvocarJugador(Jugador jug)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            Modificador(jug);
        }

        public ConvocarJugador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList; // Deja el ComboBox de países en modo de edición al crear un nuevo jugador
            cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
            cmbPosiciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosiciones.DataSource = Enum.GetValues(typeof(EPosicion));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Maneja el evento Click del botón "Aceptar" lo que hace quye
        /// se convoque al jugador segun lo escrito en los TextBox, utilizo
        /// Regex para verificar que el nombre y el apellido no sean numero,
        /// tambien utilizo un metodo creado Capitalize() (haciendo referencia a Python)
        /// que hace de cualquier manera que pongas algo en los TextBox este siempre va a terminar
        /// mostrandose con la primera letra mayuscula y las demas minuscula y por ultimo verifico que lo
        /// puesto en los enum pertenezcan a ellos
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de nombre.");
                return;
            }

            string apellido = this.txtApellido.Text;
            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de apellido.");
                return;
            }

            nombre = Capitalize(nombre);
            apellido = Capitalize(apellido);

            if (!EsTextoValido(nombre) || !EsTextoValido(apellido))
            {
                MessageBox.Show("El nombre y el apellido no deben contener números ni caracteres especiales.");
                return;
            }

            if (!int.TryParse(this.txtEdad.Text, out int edad))
            {
                MessageBox.Show("El valor ingresado en el campo de edad no es válido.");
                return;
            }

            if (!int.TryParse(this.txtDorsal.Text, out int dorsal))
            {
                MessageBox.Show("El valor ingresado en el campo de dorsal no es válido.");
                return;
            }

            string paisInput = this.cmbPaises.SelectedItem.ToString();
            string posicionInput = this.cmbPosiciones.SelectedItem.ToString();

            if (!Enum.TryParse(paisInput, out EPaises pais))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return;
            }


            // Verificar si la posición ingresada es válida
            if (!Enum.TryParse(posicionInput, out EPosicion posicion))
            {
                MessageBox.Show("Por favor, ingrese una posición válida.");
                return;
            }

            NuevoJugador = new Jugador(edad, nombre, apellido, pais, dorsal, posicion);

            this.DialogResult = DialogResult.OK; // Configura el resultado del formulario

            // Cerrar el formulario
            this.Close();


            if (this.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(NuevoJugador.Concentrarse());
            }


        }

        /// <summary>
        /// Maneja el evento Click del botón "Cancelar".
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region Metodos
        /// <summary>
        /// Modifica los campos del formulario con los datos del jugador existente pero desabilitando
        /// la edicion de algunos TextBox
        /// </summary>
        /// <param name="jug">El jugador a editar.</param>
        public void Modificador(Jugador jug)
        {
            this.txtApellido.Text = jug.apellido;
            this.txtNombre.Text = jug.nombre;
            this.txtEdad.Text = jug.edad.ToString();
            this.txtDorsal.Text = jug.Dorsal.ToString();
            this.cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
            this.cmbPaises.SelectedItem = jug.Pais;
            this.cmbPosiciones.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPosiciones.DataSource = Enum.GetValues(typeof(EPosicion));
            this.cmbPosiciones.SelectedItem = jug.Posicion;
            this.txtApellido.Enabled = false;
            this.txtNombre.Enabled = false;
            this.cmbPaises.Enabled = false;
            // No necesitas hacer nada más para el ComboBox de Países, ya que ya configuraste su estilo aquí.
        }


        /// <summary>
        /// Verifica si el texto contiene solo caracteres alfabéticos.
        /// </summary>
        /// <param name="texto">El texto a verificar.</param>
        /// <returns><c>true</c> si el texto contiene solo caracteres alfabéticos; de lo contrario, <c>false</c>.</returns>
        private bool EsTextoValido(string texto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Convierte la primera letra del texto en mayúscula y el resto en minúscula.
        /// </summary>
        /// <param name="input">El texto de entrada.</param>
        /// <returns>El texto con la primera letra en mayúscula y el resto en minúscula.</returns>
        private string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Convierte el primer carácter a mayúscula y el resto a minúscula
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
        #endregion
    }
}
