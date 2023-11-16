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
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Security.Principal;

namespace FormSelecciones
{
    /// <summary>
    /// Formulario principal que gestiona los miembros de los equipos de selección.
    /// </summary>
    public partial class FormPrincipal : Form
    {
        //JUGADORES
        private List<PersonalEquipoSeleccion> personal;
        private Equipo registro;
        private Usuario usuarioLog;

        private SQL sql;

        /// <summary>
        /// Constructor del formulario principal.
        /// </summary>
        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.personal = new List<PersonalEquipoSeleccion>();
            this.registro = new Equipo();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            ModificarColores(Color.LightBlue);
            BordesBoton(FlatStyle.Flat, Color.LightSkyBlue, 2, btnConvocar, btnModificar, btnEliminar, btnOrdenar, btnGuardarManualmente, btnAccion, btnMostrar);
            this.usuarioLog = usuario;
            this.sql = new SQL();


            if (usuario != null)
            {
                this.Text = $"Operador: {usuario.nombre} - fecha actual: {DateTime.Now.ToShortDateString()}";
            }

            string rutaArchivoLog = "usuarios.log";
            try
            {
                using (StreamWriter sw = File.AppendText(rutaArchivoLog))
                {
                    sw.WriteLine($"Nombre: {usuario.nombre} - Apellido: {usuario.apellido} - Horario de entrada: {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo crear el archivo .log" + ex.Message);
            }

            this.Click += FormPrincipal_Click;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerLogForm archivo = new VerLogForm();

            archivo.ShowDialog();
        }

        /// <summary>
        /// Manejador de eventos al cargar el formulario.
        /// Carga datos de jugadores, entrenadores y masajistas.
        /// </summary>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Manejador de eventos para el botón de convocar.
        /// Abre el formulario de creación de personal y agrega el nuevo personal a las listas correspondientes.
        /// </summary>
        private void btnConvocar_Click(object sender, EventArgs e)
        {
            if (usuarioLog != null && (usuarioLog.perfil == "administrador" || usuarioLog.perfil == "supervisor"))
            {
                Personal personalForm = new Personal();
                personalForm.ShowDialog();

                if (personalForm.esJugador && personalForm.DialogResult == DialogResult.OK)
                {
                    Jugador jugador = personalForm.nuevoJugador;
                    sql.AgregarJugador(jugador, this.registro);
                    ActualizarRegistro(this.registro.ListaPesonal);
                }
                else if (personalForm.esEntrenador && personalForm.DialogResult == DialogResult.OK)
                {
                    Entrenador entrenador = personalForm.nuevoEntrenador;
                    sql.AgregarEntrenador(entrenador, this.registro);
                    ActualizarRegistro(this.registro.ListaPesonal);
                }
                else if (personalForm.esMasajista && personalForm.DialogResult == DialogResult.OK)
                {
                    Masajista masajista = personalForm.nuevoMasajista;
                    sql.AgregarMasajista(masajista, this.registro);
                    ActualizarRegistro(this.registro.ListaPesonal);
                }
            }
            else
            {
                MessageBox.Show("No tienes el rango suficiente para usar esta opción.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        /// <summary>
        /// Manejador de eventos para el cambio en la selección del país en el ComboBox.
        /// Muestra el ListBox correspondiente al país seleccionado y oculta los demás.
        /// </summary>

        /// <summary>
        /// Manejador de eventos al cerrar el formulario.
        /// Realiza la serialización de los datos de jugadores, entrenadores y masajistas.
        /// </summary>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro que quieras salir de la aplicación?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Se acaban de guardar todos los datos automáticamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón de eliminar.
        /// Elimina el elemento seleccionado en el ListBox correspondiente al país seleccionado.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioLog != null)
            {
                if (usuarioLog.perfil == "vendedor" || usuarioLog.perfil == "supervisor")
                {

                    usuarioLog.NotificarAccesoNoPermitido += MostrarMensaje;
                    usuarioLog.NotificarAcceso("No tienes permitido utilizar esta opción.");
                    usuarioLog.NotificarAccesoNoPermitido -= MostrarMensaje;
                    return;
                }

                else if (usuarioLog.perfil == "administrador")
                {
                    int indice = this.lstPersonal.SelectedIndex;

                    if (indice == -1)
                    {
                        MessageBox.Show("Por favor, selecciona un elemento en la lista antes de intentar eliminarlo.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // No se hace nada si no se selecciona ningún elemento
                    }

                    PersonalEquipoSeleccion personal = this.registro.ListaPesonal[indice];
                    // Muestra un cuadro de diálogo de confirmación
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar estos elementos?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Verifica el tipo de personal utilizando 'is'
                        if (personal is Jugador)
                        {
                            Jugador jugador = (Jugador)personal;
                            this.sql.BorrarDato(jugador, this.registro);
                            this.ActualizarRegistro(this.registro.ListaPesonal);
                        }
                        else if (personal is Entrenador)
                        {
                            Entrenador entrenador = (Entrenador)personal;
                            this.sql.BorrarDato(entrenador, this.registro);
                            this.ActualizarRegistro(this.registro.ListaPesonal);
                        }
                        else if (personal is Masajista)
                        {
                            Masajista masajista = (Masajista)personal;
                            this.sql.BorrarDato(masajista, this.registro);
                            this.ActualizarRegistro(this.registro.ListaPesonal);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el personal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Modificar". 
        /// Modifica un elemento seleccionado en la lista correspondiente 
        /// (jugadores, entrenadores o masajistas) según el país seleccionado.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (usuarioLog != null)
            {
                if (usuarioLog.perfil == "vendedor")
                {
                    usuarioLog.NotificarAccesoNoPermitido += MostrarMensaje;
                    usuarioLog.NotificarAcceso("No tienes permitido utilizar esta opción.");
                    usuarioLog.NotificarAccesoNoPermitido -= MostrarMensaje;
                    return;
                }

                else if (usuarioLog.perfil == "administrador" || usuarioLog.perfil == "supervisor")
                {
                    int indice = this.lstPersonal.SelectedIndex;

                    if (indice == -1)
                    {
                        return;
                    }

                    PersonalEquipoSeleccion personalAModificar = this.registro.ListaPesonal[indice];

                    if (personalAModificar is Jugador)
                    {
                        Jugador futbolista = (Jugador)personalAModificar;
                        ConvocarJugador fmrf = new ConvocarJugador(futbolista);
                        this.ModificarElemento(this.lstPersonal, this.registro.ListaPesonal);
                    }
                    else if (personalAModificar is Entrenador)
                    {
                        Entrenador Entrenador = (Entrenador)personalAModificar;
                        ConvocarEntrenador fmrba = new ConvocarEntrenador(Entrenador);
                        this.ModificarElemento(this.lstPersonal, this.registro.ListaPesonal);
                    }
                    else
                    {
                        Masajista masajista = (Masajista)personalAModificar;
                        ConvocarMasajista fmrbe = new ConvocarMasajista(masajista);
                        this.ModificarElemento(this.lstPersonal, this.registro.ListaPesonal);
                    }
                }
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            int indice = this.lstPersonal.SelectedIndex;

            if (indice == -1)
            {
                return;
            }
            PersonalEquipoSeleccion jugadorAModificar = this.registro.ListaPesonal[indice];

            // Verifica si el objeto seleccionado es de tipo Jugador.
            if (jugadorAModificar is Jugador jugador)
            {
                // Llama al método RealizarAccion del jugador seleccionado.
                string accion = jugador.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (jugadorAModificar is Entrenador entrenador)
            {
                string accion = entrenador.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (jugadorAModificar is Masajista masajista)
            {
                // Llama al método RealizarAccion del jugador seleccionado.
                string accion = masajista.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Masajeador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Maneja el evento Click del formulario principal y deselecciona todos los elementos en las listas.
        /// </summary>
        private void FormPrincipal_Click(object sender, EventArgs e)
        {
            lstPersonal.ClearSelected();
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Ordenar". 
        /// Ordena los elementos de la lista correspondiente (jugadores, entrenadores o masajistas) 
        /// en función de la opción seleccionada (ascendente o descendente) y el país seleccionado
        /// Los jugadores de van a poder ordenar en cuanto a posicion y edad y los entrenador y masajistas solo por edad
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.rdoAscendenteEdad.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorEdadAS);
                ActualizarRegistro(this.registro.ListaPesonal);

            }
            else if (this.rdoDescendenteEdad.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorEdadDes);
                ActualizarRegistro(this.registro.ListaPesonal);

            }
            else if (this.rdoAscendentePosicion.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorPaisAs);
                ActualizarRegistro(this.registro.ListaPesonal);
            }
            else
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorPaisDes);
                ActualizarRegistro(this.registro.ListaPesonal);
            }

        }
        private void btnGuardarManualmente_Click(object sender, EventArgs e)
        {
            GuardarArchivo(this.registro.ListaPesonal);
        }

        #region metodos

        /// <summary>
        /// Modifica el color de fondo de los botones de convocar, eliminar y modificar.
        /// </summary>
        /// <param name="colorin">Color de fondo a establecer para los botones</param>
        private void ModificarColores(Color colorin)
        {
            btnConvocar.BackColor = colorin;
            btnEliminar.BackColor = colorin;
            btnModificar.BackColor = colorin;
            btnOrdenar.BackColor = colorin;
            btnGuardarManualmente.BackColor = colorin;
            btnMostrar.BackColor = colorin;
            btnAccion.BackColor = colorin;
            btnCargarDatos.BackColor = colorin;
        }

        /// <summary>
        /// Configura el estilo y borde de los botones para personalizar su apariencia.
        /// </summary>
        /// <param name="flat">Estilo de los botones (FlatStyle)</param>
        /// <param name="colorin">Color del borde</param>
        /// <param name="tamaño">Grosor del borde en píxeles</param>
        /// <param name="FrmCRUD1">Primer botón a configurar</param>
        /// <param name="FrmCRUD2">Segundo botón a configurar</param>
        /// <param name="FrmCRUD3">Tercer botón a configurar</param>
        /// <param name="FrmCRUD4">Cuarto botón a configurar</param>
        /// <param name="FrmCRUD5">Quinto botón a configurar</param>
        /// <param name="FrmCRUD6">Sexto botón a configurar</param>
        /// <param name="FrmCRUD7">Septimo botón a configurar</param>
        private void BordesBoton(FlatStyle flat, Color colorin, int tamaño, Button FrmCRUD1, Button FrmCRUD2, Button FrmCRUD3, Button FrmCRUD4, Button FrmCRUD5, Button FrmCRUD6, Button FrmCRUD7)
        {
            FrmCRUD1.FlatStyle = flat;
            FrmCRUD1.FlatAppearance.BorderColor = colorin; // Color del borde
            FrmCRUD1.FlatAppearance.BorderSize = tamaño; // Grosor del borde en píxeles
            FrmCRUD2.FlatStyle = flat;
            FrmCRUD2.FlatAppearance.BorderColor = colorin;
            FrmCRUD2.FlatAppearance.BorderSize = tamaño;
            FrmCRUD3.FlatStyle = flat;
            FrmCRUD3.FlatAppearance.BorderColor = colorin;
            FrmCRUD3.FlatAppearance.BorderSize = tamaño;
            FrmCRUD4.FlatStyle = flat;
            FrmCRUD4.FlatAppearance.BorderColor = colorin;
            FrmCRUD4.FlatAppearance.BorderSize = tamaño;
            FrmCRUD5.FlatStyle = flat;
            FrmCRUD5.FlatAppearance.BorderColor = colorin;
            FrmCRUD5.FlatAppearance.BorderSize = tamaño;
            FrmCRUD6.FlatStyle = flat;
            FrmCRUD6.FlatAppearance.BorderColor = colorin;
            FrmCRUD6.FlatAppearance.BorderSize = tamaño;
            FrmCRUD7.FlatStyle = flat;
            FrmCRUD7.FlatAppearance.BorderColor = colorin;
            FrmCRUD7.FlatAppearance.BorderSize = tamaño;
            btnCargarDatos.FlatStyle = flat;
            btnCargarDatos.FlatAppearance.BorderColor = colorin;
            btnCargarDatos.FlatAppearance.BorderSize = tamaño;
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ActualizarRegistro<T>(List<T> registro) where T: PersonalEquipoSeleccion
        {
            this.lstPersonal.Items.Clear();

            foreach (PersonalEquipoSeleccion personal in registro)
            {
                lstPersonal.Items.Add(personal.ToString());
            }
        }
        #endregion

        #region Metodos Modificar
        /// <summary>
        /// Estos tres metodos abreb un formulario de edición para modificar el personal
        /// seleccionado y actualiza la lista con los cambios realizados.
        /// </summary>
        /// <param name="lst">ListBox que contiene la lista de jugadores</param>
        /// <param name="personal">Lista de jugadores</param>
        private void ModificarList<T>(ListBox lst, List<T> personal) where T : PersonalEquipoSeleccion
        {
            int selectedIndex = lst.SelectedIndex;

            // Verifica si el índice es válido
            if (selectedIndex >= 0 && selectedIndex < personal.Count)
            {
                T personalSeleccionado = personal[selectedIndex];

                if (personalSeleccionado is Jugador)
                {
                    // Utiliza directamente T en lugar de Jugador
                    ConvocarJugador editarJugadorForm = new ConvocarJugador((Jugador)(object)personalSeleccionado);

                    editarJugadorForm.JugadorParaEditar = (Jugador)(object)personalSeleccionado;

                    editarJugadorForm.ShowDialog();

                    if (editarJugadorForm.DialogResult == DialogResult.OK)
                    {
                        // Utiliza directamente T en lugar de Jugador
                        T jugadorModificado = (T)(object)editarJugadorForm.NuevoJugador;

                        // Realiza la asignación y modificación de la lista
                        personal[selectedIndex] = jugadorModificado;
                        lst.Items[selectedIndex] = jugadorModificado;
                        sql.ModificarDato((Jugador)(object)jugadorModificado);
                    }
                }
                else if (personalSeleccionado is Entrenador)
                {
                    ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador((Entrenador)(object)personalSeleccionado);

                    editarEntrenadorForm.EntrenadorParaEditar = (Entrenador)(object)personalSeleccionado;

                    editarEntrenadorForm.ShowDialog();

                    if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                    {
                        // Utiliza directamente T en lugar de Jugador
                        T entrenadorModificado = (T)(object)editarEntrenadorForm.NuevoEntrenador;

                        // Realiza la asignación y modificación de la lista
                        personal[selectedIndex] = entrenadorModificado;
                        lst.Items[selectedIndex] = entrenadorModificado;
                        sql.ModificarDato((Entrenador)(object)entrenadorModificado);
                    }
                }
                else if (personalSeleccionado is Masajista)
                {
                    ConvocarMasajista editarEntrenadorForm = new ConvocarMasajista((Masajista)(object)personalSeleccionado);

                    editarEntrenadorForm.MasajistaParaEditar = (Masajista)(object)personalSeleccionado;

                    editarEntrenadorForm.ShowDialog();

                    if (editarEntrenadorForm.DialogResult == DialogResult.OK)
                    {
                        // Utiliza directamente T en lugar de Jugador
                        T entrenadorModificado = (T)(object)editarEntrenadorForm.NuevoMasajista;

                        // Realiza la asignación y modificación de la lista
                        personal[selectedIndex] = entrenadorModificado;
                        lst.Items[selectedIndex] = entrenadorModificado;
                        sql.ModificarDato((Masajista)(object)entrenadorModificado);
                    }
                }
            }
        }

        /// <summary>
        /// Estos tres metodos abren un formulario de edición para el elemento seleccionado en la ListBox 
        /// y lo modifica en la lista llamando a el metodo ModificarList().
        /// </summary>
        /// <param name="listBox">ListBox que contiene el elemento a modificar</param>
        /// <param name="lista">Lista de elementos del mismo tipo</param
        public void ModificarElemento<T>(ListBox listBox, List<T> lista) where T : PersonalEquipoSeleccion
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                sql.CargarDatosDesdeBaseDeDatos(this.registro.ListaPesonal);
                ActualizarRegistro(this.registro.ListaPesonal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde la base de datos: " + ex.Message);
            }
        }
        #endregion


        #region Añadir
        public void Añadir<T>(List<T> lista, T personal, ListBox lst) where T : PersonalEquipoSeleccion
        {
            bool elementoRepetido = lista.Any(item => item.Equals(personal));

            if (elementoRepetido)
            {
                MessageBox.Show("El elemento ya existe en la lista.");
            }
            else
            {
                lista.Add(personal);
                lst.Items.Add(personal);
            }
        }
        #endregion

        #region guardarManualmenteSqlData

        public void GuardarArchivo<T>(List<T> lista) where T : PersonalEquipoSeleccion
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos SQL (*.sql)|*.sql";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaCompleta = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(rutaCompleta))
                    {
                        foreach (var item in lista)
                        {
                            string scriptSql = GenerarScriptSql(item);
                            writer.WriteLine(scriptSql);
                        }
                    }

                    Console.WriteLine("Archivo SQL guardado exitosamente en: " + rutaCompleta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
            }
        }

        private string GenerarScriptSql(PersonalEquipoSeleccion item)
        {
            if (item is Jugador jugador)
            {
                return $"INSERT INTO jugador (nombre, apellido, edad, pais, dorsal, posicion) VALUES ('{jugador.Nombre}', '{jugador.Apellido}', {jugador.Edad}, {(int)jugador.Pais}, {jugador.Dorsal}, {(int)jugador.Posicion});";
            }
            else if (item is Entrenador entrenador)
            {
                return $"INSERT INTO entrenador (nombre, apellido, edad, pais, tactica) VALUES ('{entrenador.Nombre}', '{entrenador.Apellido}', {entrenador.Edad}, {(int)entrenador.Pais}, '{entrenador.Tactica}');";
            }
            else if (item is Masajista masajista)
            {
                return $"INSERT INTO masajists (nombre, apellido, edad, pais, lugarDeEstudio) VALUES ('{masajista.Nombre}', '{masajista.Apellido}', {masajista.Edad}, {(int)masajista.Pais}, '{masajista.CertificadoMasaje}');";
            }
            else
            {
                // Manejar otro tipo de PersonalEquipoSeleccion si es necesario
                return string.Empty;
            }
        }
        #endregion

    }
}