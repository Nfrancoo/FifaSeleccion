using System.Text.Json;
using SegundoParcial;

namespace FormSelecciones
{
    /// <summary>
    /// Formulario de inicio de sesi�n de la aplicaci�n.
    /// </summary>
    public partial class Login : Form
    {
        private List<Usuario> usuarios;
        private System.Windows.Forms.Timer timerHora = new System.Windows.Forms.Timer();

        /// <summary>
        /// Constructor de la clase Login.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            usuarios = LeerUsuariosDesdeJSON(@"..//..//..//..//MOCK_DATA.json");
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            ModificarColores(Color.LightBlue);
            BordesBoton(FlatStyle.Flat, Color.LightSkyBlue, 2, btnIniciarSesion);

            // Configurar el Timer para actualizar la hora cada segundo
            timerHora.Interval = 1000;
            timerHora.Tick += TimerHora_Tick;
            timerHora.Start();
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            // Actualizar la hora en la etiqueta
            lblHoraActual.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Maneja el evento Click del bot�n de inicio de sesi�n.
        /// Busca que el correo y la clave sean iguales al JSON del usuario.
        /// Luego abre el FormPrincipal. Con el lambda verifica si se cre� el evento FormClosed y cierra el form Usuario
        /// (necesario por un error que no permit�a cerrarlo).
        /// </summary>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = this.txtCorreo.Text;
            string contrase�a = this.txtContrase�a.Text;

            Usuario usuario = usuarios.Find(u => u.correo == correo && u.clave == contrase�a);

            if (usuario != null)
            {
                // Mostrar un mensaje de bienvenida con el nombre, apellido y perfil del usuario.
                MessageBox.Show($"Bienvenido, {usuario.nombre} {usuario.apellido}. Perfil: {usuario.perfil}");

                this.Hide();

                FormPrincipal formPrincipal = new FormPrincipal(usuario);

                formPrincipal.Show();

                // Manejar el evento FormClosed del FormPrincipal
                formPrincipal.FormClosed += (s, args) =>
                {
                    // Cerrar otros formularios si es necesario
                    this.Close();
                };
            }
            else
            {
                MessageBox.Show("Correo o contrase�a incorrectos");
            }
        }

        /// <summary>
        /// Lee la lista de usuarios desde un archivo JSON.
        /// </summary>
        /// <param name="archivo">La ruta del archivo JSON que contiene la lista de usuarios.</param>
        /// <returns>La lista de usuarios le�da desde el archivo JSON.</returns>
        private List<Usuario> LeerUsuariosDesdeJSON(string archivo)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    // Leer y deserializar la lista de usuarios desde un archivo JSON.
                    string jsonString = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<List<Usuario>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}");
                return new List<Usuario>();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.txtContrase�a.UseSystemPasswordChar = true;
            this.lblOcultar.Visible = false;
        }

        private void ModificarColores(Color colorin)
        {
            btnIniciarSesion.BackColor = colorin;
        }

        private void BordesBoton(FlatStyle flat, Color colorin, int tama�o, Button FrmCRUD1)
        {
            FrmCRUD1.FlatStyle = flat;
            FrmCRUD1.FlatAppearance.BorderColor = colorin;
            FrmCRUD1.FlatAppearance.BorderSize = tama�o;
        }

        private void lblMostrar_Click(object sender, EventArgs e)
        {
            this.txtContrase�a.UseSystemPasswordChar = false;
            this.lblMostrar.Visible = false;
            this.lblOcultar.Visible = true;
        }

        private void lblOcultar_Click(object sender, EventArgs e)
        {
            this.txtContrase�a.UseSystemPasswordChar = true;
            this.lblOcultar.Visible = false;
            this.lblMostrar.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarContrase�a recuperarForm = new RecuperarContrase�a(usuarios);

            recuperarForm.RecuperarContrase�aFormClosed += RecuperarForm_RecuperarContrase�aFormClosed;

            this.Hide();

            recuperarForm.ShowDialog();
        }
        /// <summary>
        /// vuelvo a abrir el form una vez recordado la contrase�a al usuario
        /// </summary>

        private void RecuperarForm_RecuperarContrase�aFormClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}