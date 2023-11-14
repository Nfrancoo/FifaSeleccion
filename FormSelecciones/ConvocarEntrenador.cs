using SegundoParcial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSelecciones
{
    public partial class ConvocarEntrenador : Form, IConvocar
    {
        public Entrenador NuevoEntrenador;
        public Entrenador EntrendorParaEditar { get; set; }
        public Entrenador EntrenadorParaEditar { get; internal set; }

        public ConvocarEntrenador(Entrenador jug)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            Modificador(jug);
        }
        public ConvocarEntrenador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
        }

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

            if (!((IConvocar)this).EsTextoValido(nombre) || !((IConvocar)this).EsTextoValido(apellido))
            {
                MessageBox.Show("El nombre y el apellido no deben contener números ni caracteres especiales.");
                return;
            }

            if (!int.TryParse(this.txtEdad.Text, out int edad))
            {
                MessageBox.Show("El valor ingresado en el campo de edad no es válido.");
                return;
            }

            string tactica = this.txtTactica.Text;
            if (string.IsNullOrEmpty(tactica))
            {
                MessageBox.Show("Por favor, ingrese un valor en el campo de tactica.");
                return;
            }

            string paisInput = this.cmbPaises.SelectedItem.ToString();

            // Verificar si el país ingresado es válido
            if (!Enum.TryParse(paisInput, out EPaises pais))
            {
                MessageBox.Show("Por favor, ingrese un país válido.");
                return;
            }


            // Crear el nuevo entrenador
            NuevoEntrenador = new Entrenador(edad, nombre, apellido, pais, tactica);



            // Establecer el resultado del formulario como "Aceptar"
            this.DialogResult |= DialogResult.OK;

            // Cerrar el formulario
            this.Close();


            if (this.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(NuevoEntrenador.RealizarConcentracion());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        #region Metodos
        bool IConvocar.EsTextoValido(string texto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        public void Modificador<T>(T personal) where T : PersonalEquipoSeleccion
        {
            if (personal is Entrenador entre)
            {
                // Realizar las operaciones específicas para entreista
                this.txtApellido.Text = entre.Apellido;
                this.txtNombre.Text = entre.Nombre;
                this.txtEdad.Text = entre.Edad.ToString();
                this.cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
                this.cmbPaises.SelectedItem = entre.Pais;
                this.txtTactica.Text = entre.Tactica;
                this.txtApellido.Enabled = false;
                this.txtNombre.Enabled = false;
                this.cmbPaises.Enabled = false;
            }
        }

        public string Capitalize(string input)
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
