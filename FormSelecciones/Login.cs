using System.Text.Json;
using SegundoParcial;

namespace FormSelecciones
{
    /// <summary>
    /// Formulario de inicio de sesión de la aplicación.
    public partial class Login : Form
    {
        private List<Usuario> usuarios;


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

        }

        /// <summary>
        /// Maneja el evento Click del botón de inicio de sesión.
        /// busca que el correo y la clave sean iguales al json usuario
        /// y luego abro mi FormPrincipal, con el lambda verifico que si se creo el evento FormClosed
        /// cierra el form Usuario(tuve que hacerlo asi por un error que no me dejaba cerrarlo)
        /// </summary>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = this.txtCorreo.Text;
            string contraseña = this.txtContraseña.Text;


            Usuario usuario = usuarios.Find(u => u.correo == correo && u.clave == contraseña);


            if (usuario != null)
            {
                // Mostrar un mensaje de bienvenida con el nombre, apellido y perfil del usuario.
                MessageBox.Show($"Bienvenido, {usuario.nombre} {usuario.apellido}. Perfil: {usuario.perfil}");

                this.Hide();

                FormPrincipal formPrincipal = new FormPrincipal(usuario);

                formPrincipal.Show();

                //manejo el evento FormClosed del FormPrincipal
                formPrincipal.FormClosed += (s, args) =>
                //expresion lambda que se va a ejecutar cuando el evento FormClosed pase
                {
                    // Cerrar otros formularios si es necesario
                    this.Close();
                };
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
        }

        /// <summary>
        /// Lee la lista de usuarios desde un archivo JSON.
        /// </summary>
        /// <param name="archivo">La ruta del archivo JSON que contiene la lista de usuarios.</param>
        /// <returns>La lista de usuarios leída desde el archivo JSON.</returns>
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
            this.txtContraseña.UseSystemPasswordChar = true;
            this.lblOcultar.Visible = false;
        }

        private void lblOcultar_Click_1(object sender, EventArgs e)
        {
            this.txtContraseña.UseSystemPasswordChar = true;
            this.lblOcultar.Visible = false;
            this.lblMostrar.Visible = true;
        }

        private void lblMostrar_Click_1(object sender, EventArgs e)
        {
            this.txtContraseña.UseSystemPasswordChar = false;
            this.lblMostrar.Visible = false;
            this.lblOcultar.Visible = true;
        }

        private void ModificarColores(Color colorin)
        {
            btnIniciarSesion.BackColor = colorin;
        }

        private void BordesBoton(FlatStyle flat, Color colorin, int tamaño, Button FrmCRUD1)
        {
            FrmCRUD1.FlatStyle = flat;
            FrmCRUD1.FlatAppearance.BorderColor = colorin; // Color del borde
            FrmCRUD1.FlatAppearance.BorderSize = tamaño; // Grosor del borde en píxeles
        }
    }
}