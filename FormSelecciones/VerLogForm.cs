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
    public partial class VerLogForm : Form
    {
        public VerLogForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
        }

        /// <summary>
        /// miro los usuarios que ingresaron a la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerLogForm_Load(object sender, EventArgs e)
        {
            string rutaArchivoLog = "usuarios.log";

            if (File.Exists(rutaArchivoLog))
            {
                try
                {
                    // Leer el contenido del archivo y mostrarlo en el control ListBox
                    string[] registros = File.ReadAllLines(rutaArchivoLog);
                    lstLog.Items.Clear(); // Limpia el ListBox antes de agregar los registros
                    lstLog.Items.AddRange(registros); // Agrega los registros al ListBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo de registro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("El archivo de registro no existe o está vacío.");
            }
        }
    }
}
