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
using System.Security.Principal;
using System.Xml.Serialization;
using System.Xml;

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
        private int segundosTranscurridos;
        private int minutosTranscurridos;
        private CancellationToken cancelarFlujo;
        public delegate void DelegadoFecha(DateTime fecha);

        private SQL sql;

        /// <summary>
        /// Constructor del formulario principal.
        /// </summary>
        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            InicializarCronometro();
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
                this.Text = $"Operador: {usuario.Nombre} - fecha actual: {DateTime.Now.ToShortDateString()}";
            }

            string rutaArchivoLog = "usuarios.log";
            try
            {
                using (StreamWriter sw = File.AppendText(rutaArchivoLog))
                {
                    sw.WriteLine($"Nombre: {usuario.Nombre} - Apellido: {usuario.Apellido} - Horario de entrada: {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo crear el archivo .log" + ex.Message);
            }

            this.Click += FormPrincipal_Click;
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Ver Log". 
        /// Abre el formulario para visualizar el log de usuarios.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            VerLogForm archivo = new VerLogForm();
            archivo.ShowDialog();
        }

        /// <summary>
        /// Manejador de eventos al cargar el formulario.
        /// Carga datos de jugadores, entrenadores y masajistas.
        /// Tambien usando task para mostrar la hira
        /// </summary>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                sql.CargarDatosDesdeBaseDeDatos(this.registro.ListaPesonal);
                ActualizarRegistro();
            }
            catch { throw new ExcepSql("Error modificando objeto de base de datos"); }


            Task taskFecha = Task.Run(() => this.Hora());
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Convocar". 
        /// Abre el formulario de creación de personal y agrega el nuevo personal a las listas correspondientes.
        /// </summary>
        private void btnConvocar_Click(object sender, EventArgs e)
        {
            if (usuarioLog != null && (usuarioLog.Perfil == "administrador" || usuarioLog.Perfil == "supervisor"))
            {
                try
                {
                    Personal personalForm = new Personal();
                    personalForm.ShowDialog();

                    if (personalForm.DialogResult == DialogResult.OK)
                    {
                        if (personalForm.esJugador)
                        {
                            Jugador jugador = personalForm.nuevoJugador;

                            // Verificar si el jugador ya existe en la lista
                            if (!ExistePersonal(jugador))
                            {
                                sql.AgregarJugador(jugador, this.registro);
                                ActualizarRegistro();
                            }
                            else
                            {
                                throw new ExcepIguales("Este jugador ya existe en la base de datos.");
                            }
                        }
                        else if (personalForm.esEntrenador)
                        {
                            Entrenador entrenador = personalForm.nuevoEntrenador;

                            // Verificar si el entrenador ya existe en la lista
                            if (!ExistePersonal(entrenador))
                            {
                                sql.AgregarEntrenador(entrenador, this.registro);
                                ActualizarRegistro();
                            }
                            else
                            {
                                throw new ExcepIguales("Este entrenador ya existe en la base de datos.");
                            }
                        }
                        else if (personalForm.esMasajista)
                        {
                            Masajista masajista = personalForm.nuevoMasajista;

                            // Verificar si el masajista ya existe en la lista
                            if (!ExistePersonal(masajista))
                            {
                                sql.AgregarMasajista(masajista, this.registro);
                                ActualizarRegistro();
                            }
                            else
                            {
                                throw new ExcepIguales("Este masajista ya existe en la base de datos.");
                            }
                        }
                    }
                }
                catch (ExcepIguales ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                usuarioLog.NotificarAccesoNoPermitido += MostrarMensaje;
                usuarioLog.NotificarAcceso("No tienes permitido utilizar esta opción.");
                usuarioLog.NotificarAccesoNoPermitido -= MostrarMensaje;
                return;
            }
        }

        /// <summary>
        /// Método que maneja el evento FormClosed del formulario de recuperación de contraseña.
        /// Realiza la acción correspondiente al cerrar el formulario de recuperación de contraseña.
        /// </summary>
        private void RecuperarContraseñaFormClosed(object sender, EventArgs e)
        {
            // Realizar la acción correspondiente al cerrar el formulario de recuperación de contraseña
            // Por ejemplo, habilitar los controles que estaban deshabilitados.
            // Puedes implementar tu lógica aquí.
        }

        /// <summary>
        /// Método que maneja el evento FormClosed del formulario de ver log de usuarios.
        /// Realiza la acción correspondiente al cerrar el formulario de ver log de usuarios.
        /// </summary>
        private void VerLogFormClosed(object sender, EventArgs e)
        {
            // Realizar la acción correspondiente al cerrar el formulario de ver log de usuarios
            // Por ejemplo, habilitar los controles que estaban deshabilitados.
            // Puedes implementar tu lógica aquí.
        }

        /// <summary>
        /// Método que maneja el evento FormClosed del formulario de creación de personal.
        /// Realiza la acción correspondiente al cerrar el formulario de creación de personal.
        /// </summary>
        private void PersonalFormClosed(object sender, EventArgs e)
        {
            // Realizar la acción correspondiente al cerrar el formulario de creación de personal
            // Por ejemplo, habilitar los controles que estaban deshabilitados.
            // Puedes implementar tu lógica aquí.
        }

        /// <summary>
        /// Método que maneja el evento FormClosed del formulario principal.
        /// Realiza la acción correspondiente al cerrar el formulario principal.
        /// </summary>
        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Realizar la acción correspondiente al cerrar el formulario principal
            // Por ejemplo, guardar los datos antes de cerrar la aplicación.
            // Puedes implementar tu lógica aquí.
        }

        /// <summary>
        /// Método que maneja el evento FormClosing del formulario principal.
        /// Realiza la acción correspondiente antes de cerrar el formulario principal.
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
        /// Método que maneja el evento Click del botón "Eliminar". 
        /// Elimina el elemento seleccionado en el ListBox correspondiente al país seleccionado.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioLog != null)
            {
                if (usuarioLog.Perfil == "vendedor" || usuarioLog.Perfil == "supervisor")
                {
                    usuarioLog.NotificarAccesoNoPermitido += MostrarMensaje;
                    usuarioLog.NotificarAcceso("No tienes permitido utilizar esta opción.");
                    usuarioLog.NotificarAccesoNoPermitido -= MostrarMensaje;
                    return;
                }
                else if (usuarioLog.Perfil == "administrador")
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
                            this.ActualizarRegistro();
                        }
                        else if (personal is Entrenador)
                        {
                            Entrenador entrenador = (Entrenador)personal;
                            this.sql.BorrarDato(entrenador, this.registro);
                            this.ActualizarRegistro();
                        }
                        else if (personal is Masajista)
                        {
                            Masajista masajista = (Masajista)personal;
                            this.sql.BorrarDato(masajista, this.registro);
                            this.ActualizarRegistro();
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
                if (usuarioLog.Perfil == "vendedor")
                {
                    usuarioLog.NotificarAccesoNoPermitido += MostrarMensaje;
                    usuarioLog.NotificarAcceso("No tienes permitido utilizar esta opción.");
                    usuarioLog.NotificarAccesoNoPermitido -= MostrarMensaje;
                    return;
                }

                else if (usuarioLog.Perfil == "administrador" || usuarioLog.Perfil == "supervisor")
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

        /// <summary>
        /// Manejador de eventos para el botón "Realizar Acción". 
        /// Realiza una acción específica según el tipo de personal seleccionado (jugador, entrenador, masajista).
        /// </summary>
        private void btnAccion_Click(object sender, EventArgs e)
        {
            int indice = this.lstPersonal.SelectedIndex;

            if (indice == -1)
            {
                return;
            }

            PersonalEquipoSeleccion personalSeleccionado = this.registro.ListaPesonal[indice];

            // Verifica si el objeto seleccionado es de tipo Jugador.
            if (personalSeleccionado is Jugador jugador)
            {
                // Llama al método RealizarAccion del jugador seleccionado.
                string accion = jugador.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (personalSeleccionado is Entrenador entrenador)
            {
                string accion = entrenador.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (personalSeleccionado is Masajista masajista)
            {
                // Llama al método RealizarAccion del masajista seleccionado.
                string accion = masajista.RealizarAccion();

                // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                MessageBox.Show(accion, "Acción del Masajeador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Manejador de eventos para el clic en el formulario principal. 
        /// Deselecciona todos los elementos en las listas.
        /// </summary>
        private void FormPrincipal_Click(object sender, EventArgs e)
        {
            lstPersonal.ClearSelected();
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Ordenar". 
        /// Ordena los elementos de la lista correspondiente (jugadores, entrenadores o masajistas) 
        /// en función de la opción seleccionada (ascendente o descendente)
        /// esta se va a poder ordenar en cuanto a pais o edad
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.rdoAscendenteEdad.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorEdadAS);
                ActualizarRegistro();
            }
            else if (this.rdoDescendenteEdad.Checked)
            {
                this.registro.ListaPesonal.Sort(Equipo.OrdenarPorEdadDes);
                ActualizarRegistro();
            }
            else if (this.rdoAscendentePosicion.Checked)
            {
                // Verifica si la lista contiene al menos un jugador para poder ordenar por posición.
                if (this.registro.ListaPesonal.Any(p => p is Jugador))
                {
                    this.registro.ListaPesonal.Sort(Equipo.OrdenarPorPaisAs);
                    ActualizarRegistro();
                }
                else
                {
                    MessageBox.Show("No hay jugadores en la lista para ordenar por posición.", "Sin jugadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Verifica si la lista contiene al menos un jugador para poder ordenar por posición.
                if (this.registro.ListaPesonal.Any(p => p is Jugador))
                {
                    this.registro.ListaPesonal.Sort(Equipo.OrdenarPorPaisDes);
                    ActualizarRegistro();
                }
                else
                {
                    MessageBox.Show("No hay jugadores en la lista para ordenar por posición.", "Sin jugadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Manejador de eventos para el clic en el botón "Guardar Manualmente".
        /// Guarda manualmente los datos en algún almacenamiento, según la lógica implementada en el método GuardarDatosManualmente().
        /// </summary>
        private void btnGuardarManualmente_Click(object sender, EventArgs e)
        {
            GuardarDatosManualmente();
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

        }

        /// <summary>
        /// Muestra un mensaje de advertencia en un cuadro de diálogo.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Actualiza el contenido del ListBox con los elementos de la lista de personal del equipo.
        /// </summary>
        private void ActualizarRegistro()
        {
            this.lstPersonal.Items.Clear();

            // Recorre la lista de personal y agrega sus representaciones de cadena al ListBox.
            foreach (PersonalEquipoSeleccion personal in this.registro.ListaPesonal)
            {
                lstPersonal.Items.Add(personal.ToString());
            }
        }

        #endregion

        #region Metodos Modificar

        /// <summary>
        /// Modifica un elemento seleccionado en el ListBox según su tipo (Jugador, Entrenador, Masajista).
        /// Abre un formulario de edición correspondiente y actualiza la lista y la base de datos según los cambios.
        /// </summary>
        /// <typeparam name="T">Tipo de personal (Jugador, Entrenador, Masajista).</typeparam>
        /// <param name="lst">ListBox que contiene la lista de personal.</param>
        /// <param name="personal">Lista de personal del equipo.</param>
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
        /// Modifica el elemento seleccionado en el ListBox de acuerdo con su tipo (Jugador, Entrenador, Masajista).
        /// </summary>
        /// <typeparam name="T">Tipo de personal (Jugador, Entrenador, Masajista).</typeparam>
        /// <param name="listBox">ListBox que contiene la lista de personal.</param>
        /// <param name="lista">Lista de personal del equipo.</param>

        public void ModificarElemento<T>(ListBox listBox, List<T> lista) where T : PersonalEquipoSeleccion
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }
        #endregion


        #region Cronómetro y Hora

        /// <summary>
        /// Actualiza el cronómetro sumando un segundo al tiempo transcurrido y actualiza la etiqueta correspondiente.
        /// </summary>
        private void ActualizarCronometro()
        {
            segundosTranscurridos++;

            if (segundosTranscurridos == 60)
            {
                segundosTranscurridos = 0;
                minutosTranscurridos++;
            }

            labelTiempo.Text = $"Tiempo transcurrido: {minutosTranscurridos} minutos {segundosTranscurridos} segundos";
        }

        /// <summary>
        /// Inicializa el cronómetro mediante una tarea que se ejecuta en segundo plano.
        /// </summary>
        private async void InicializarCronometro()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();

                    this.Invoke(new Action(ActualizarCronometro));
                }
            });
        }

        /// <summary>
        /// Actualiza la hora mostrada en la etiqueta lblHora utilizando un hilo separado.
        /// </summary>
        private void Hora()
        {
            do
            {
                if (this.cancelarFlujo.IsCancellationRequested) break;

                this.ActualizarFecha(DateTime.Now);
                Thread.Sleep(1000);

            } while (true);
        }

        /// <summary>
        /// Actualiza la etiqueta de fecha con la fecha proporcionada.
        /// </summary>
        /// <param name="fecha">Fecha a mostrar.</param>
        private void ActualizarFecha(DateTime fecha)
        {
            if (this.lblHora.InvokeRequired)
            {
                DelegadoFecha d = new DelegadoFecha(ActualizarFecha);
                object[] arrayParametro = { fecha };

                this.lblHora.Invoke(d, fecha);
            }
            else this.lblHora.Text = fecha.ToString();
        }

        #endregion

        #region Funciones XML y Verificación de Existencia de Personal

        /// <summary>
        /// Guarda los datos manualmente en un archivo XML seleccionado por el usuario.
        /// </summary>
        public void GuardarDatosManualmente()
        {
            try
            {
                SaveFileDialog guardarDatos = new SaveFileDialog();

                if (guardarDatos.ShowDialog() == DialogResult.OK)
                {
                    string filePath = guardarDatos.FileName;
                    using (XmlTextWriter escritorxml = new XmlTextWriter(filePath, Encoding.UTF8))
                    {
                        XmlSerializer serializador = new XmlSerializer(typeof(List<PersonalEquipoSeleccion>));
                        serializador.Serialize(escritorxml, this.registro.ListaPesonal);
                        MessageBox.Show("Se pudieron guardar los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Verifica si un nuevo personal ya existe en la lista del equipo.
        /// </summary>
        /// <typeparam name="T">Tipo de personal (Jugador, Entrenador, Masajista).</typeparam>
        /// <param name="nuevoPersonal">Nuevo personal a verificar.</param>
        /// <returns>True si el personal ya existe, False si no.</returns>
        private bool ExistePersonal<T>(T nuevoPersonal) where T : PersonalEquipoSeleccion
        {
            // Verificar si el personal ya existe en la lista
            foreach (PersonalEquipoSeleccion personal in this.registro.ListaPesonal)
            {
                if (personal is T personalExistente && personalExistente == nuevoPersonal)
                {
                    return true; // El personal ya existe en la lista
                }
            }
            return false; // El personal no existe en la lista
        }

        #endregion
    }
}