using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormSelecciones
{
    public partial class RecuperarContraseña : Form
    {
        private List<Usuario> usuarios;
        private System.Windows.Forms.Timer timerHora = new System.Windows.Forms.Timer();
        public event EventHandler RecuperarContraseñaFormClosed;

        public RecuperarContraseña(List<Usuario> usuarios)
        {
            InitializeComponent();
            this.usuarios = usuarios;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            ModificarColores(Color.LightBlue);
            BordesBoton(FlatStyle.Flat, Color.LightSkyBlue, 2, btnRecuperarContraseña);

            // Configurar el Timer para actualizar la hora cada segundo
            timerHora.Interval = 1000;
            timerHora.Tick += TimerHora_Tick;
            timerHora.Start();

        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lblHoraActual.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void btnRecuperarContraseña_Click(object sender, EventArgs e)
        {
            // Obtener el correo ingresado por el usuario
            string correoRecuperacion = txtCorreo.Text;

            // Buscar el usuario en la lista de usuarios
            Usuario usuarioRecuperado = usuarios.Find(u => u.correo == correoRecuperacion);

            if (usuarioRecuperado != null)
            {
                MessageBox.Show($"La contraseña del usuario {usuarioRecuperado.nombre} {usuarioRecuperado.apellido} es: {usuarioRecuperado.clave}", "Contraseña Recuperada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lanzar el evento personalizado
                OnRecuperarContraseñaFormClosed();
            }
            else
            {
                MessageBox.Show("Correo no encontrado. Verifica la dirección de correo e inténtalo de nuevo.");
            }
        }

        private void ModificarColores(Color colorin)
        {
            btnRecuperarContraseña.BackColor = colorin;
        }

        private void BordesBoton(FlatStyle flat, Color colorin, int tamaño, Button FrmCRUD1)
        {
            FrmCRUD1.FlatStyle = flat;
            FrmCRUD1.FlatAppearance.BorderColor = colorin;
            FrmCRUD1.FlatAppearance.BorderSize = tamaño;
        }

        private void RecuperarContraseña_Load(object sender, EventArgs e)
        {

        }

        protected virtual void OnRecuperarContraseñaFormClosed()
        {
            RecuperarContraseñaFormClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
