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
        private List<Jugador> jugadoresArgentina = new List<Jugador>();
        private List<Jugador> jugadoresBrasil = new List<Jugador>();
        private List<Jugador> jugadoresAlemania = new List<Jugador>();
        private List<Jugador> jugadoresItalia = new List<Jugador>();
        private List<Jugador> jugadoresFrancia = new List<Jugador>();

        //ENTRENADORES
        private List<Entrenador> entrenadorArgentina = new List<Entrenador>();
        private List<Entrenador> entrenadorBrasil = new List<Entrenador>();
        private List<Entrenador> entrenadorAlemania = new List<Entrenador>();
        private List<Entrenador> entrenadorItalia = new List<Entrenador>();
        private List<Entrenador> entrenadorFrancia = new List<Entrenador>();

        //MASAJEADORES
        private List<Masajista> masajeadoresArgentina = new List<Masajista>();
        private List<Masajista> masajeadoresBrasil = new List<Masajista>();
        private List<Masajista> masajeadoresItalia = new List<Masajista>();
        private List<Masajista> masajeadoresAlemania = new List<Masajista>();
        private List<Masajista> masajeadoresFrancia = new List<Masajista>();

        private Usuario usuarioLog;
        private SQL sql;

        /// <summary>
        /// Constructor del formulario principal.
        /// </summary>
        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
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

            cmbPaises.DataSource = Enum.GetValues(typeof(EPaises));
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
            try
            {

                // JUGADORES
                sql.CargarDatosDesdeBaseDeDatosJug(1, ref jugadoresArgentina);
                ActualizarVisor(jugadoresArgentina, lstArgentina);
                sql.CargarDatosDesdeBaseDeDatosJug(2, ref jugadoresBrasil);
                ActualizarVisor(jugadoresBrasil, lstBrasil);
                sql.CargarDatosDesdeBaseDeDatosJug(3, ref jugadoresAlemania);
                ActualizarVisor(jugadoresAlemania, lstAlemania);
                sql.CargarDatosDesdeBaseDeDatosJug(4, ref jugadoresItalia);
                ActualizarVisor(jugadoresItalia, lstItalia);
                sql.CargarDatosDesdeBaseDeDatosJug(0, ref jugadoresFrancia);
                ActualizarVisor(jugadoresFrancia, lstFrancia);

                //ENTRENADORES
                sql.CargarDatosDesdeBaseDeDatosEntre(1, ref entrenadorArgentina);
                ActualizarVisor(entrenadorArgentina, lstArgentinaEntrenador);
                sql.CargarDatosDesdeBaseDeDatosEntre(2, ref entrenadorBrasil);
                ActualizarVisor(entrenadorBrasil, lstBrasilEntrenador);
                sql.CargarDatosDesdeBaseDeDatosEntre(3, ref entrenadorAlemania);
                ActualizarVisor(entrenadorAlemania, lstAlemaniaEntrenador);
                sql.CargarDatosDesdeBaseDeDatosEntre(4, ref entrenadorItalia);
                ActualizarVisor(entrenadorItalia, lstItaliaEntrenador);
                sql.CargarDatosDesdeBaseDeDatosEntre(0, ref entrenadorFrancia);
                ActualizarVisor(entrenadorFrancia, lstFranciaEntrenador);

                //MASAJISTA
                sql.CargarDatosDesdeBaseDeDatosMasaj(1, ref masajeadoresArgentina);
                ActualizarVisor(masajeadoresArgentina, lstArgentinaMasajeador);
                sql.CargarDatosDesdeBaseDeDatosMasaj(2, ref masajeadoresBrasil);
                ActualizarVisor(masajeadoresBrasil, lstBrasilMasajeador);
                sql.CargarDatosDesdeBaseDeDatosMasaj(3, ref masajeadoresAlemania);
                ActualizarVisor(masajeadoresAlemania, lstAlemaniaMasajeador);
                sql.CargarDatosDesdeBaseDeDatosMasaj(4, ref masajeadoresItalia);
                ActualizarVisor(masajeadoresItalia, lstItaliaMasajeador);
                sql.CargarDatosDesdeBaseDeDatosMasaj(0, ref masajeadoresFrancia);
                ActualizarVisor(masajeadoresFrancia, lstFranciaMasajeador);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos desde la base de datos: " + ex.Message);
            }
        }

        /// <summary>
        /// Manejador de eventos para el botón de convocar.
        /// Abre el formulario de creación de personal y agrega el nuevo personal a las listas correspondientes.
        /// </summary>
        private void btnConvocar_Click(object sender, EventArgs e)
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

                else if(usuarioLog.perfil == "administrador" || usuarioLog.perfil == "supervisor")
                {
                    Personal personalForm = new Personal();
                    personalForm.ShowDialog();

                    if (personalForm.DialogResult == DialogResult.OK)
                    {
                        if (personalForm.nuevoJugador is Jugador jugador)
                        {

                            // Es un jugador
                            // Agregar el nuevo jugador al ListBox y a la lista correspondiente
                            switch (jugador.Pais)
                            {
                                case EPaises.Brasil:
                                    Añadir(jugadoresBrasil, jugador, lstBrasil);
                                    break;
                                case EPaises.Argentina:
                                    Añadir(jugadoresArgentina, jugador, lstArgentina);
                                    break;
                                case EPaises.Italia:
                                    Añadir(jugadoresItalia, jugador, lstItalia);
                                    break;
                                case EPaises.Alemania:
                                    Añadir(jugadoresAlemania, jugador, lstAlemania);
                                    break;
                                case EPaises.Francia:
                                    Añadir(jugadoresFrancia, jugador, lstFrancia);
                                    break;
                            }
                        }
                        else if (personalForm.nuevoEntrenador is Entrenador entrenador)
                        {
                            switch (entrenador.Pais)
                            {
                                case EPaises.Brasil:
                                    SoloUnEntrenador(entrenadorBrasil, lstBrasilEntrenador, entrenador);
                                    break;
                                case EPaises.Argentina:
                                    SoloUnEntrenador(entrenadorArgentina, lstArgentinaEntrenador, entrenador);
                                    break;
                                case EPaises.Italia:
                                    SoloUnEntrenador(entrenadorItalia, lstItaliaEntrenador, entrenador);
                                    break;
                                case EPaises.Alemania:
                                    SoloUnEntrenador(entrenadorAlemania, lstAlemaniaEntrenador, entrenador);
                                    break;
                                case EPaises.Francia:
                                    SoloUnEntrenador(entrenadorFrancia, lstFranciaEntrenador, entrenador);
                                    break;
                            }
                        }
                        else if (personalForm.nuevoMasajista is Masajista masajista)
                        {
                            switch (masajista.Pais)
                            {
                                case EPaises.Brasil:
                                    Añadir(masajeadoresFrancia, masajista, lstFranciaMasajeador);
                                    break;
                                case EPaises.Argentina:
                                    Añadir(masajeadoresArgentina, masajista, lstArgentinaMasajeador);
                                    break;
                                case EPaises.Italia:
                                    Añadir(masajeadoresItalia, masajista, lstItaliaMasajeador);
                                    break;
                                case EPaises.Alemania:
                                    Añadir(masajeadoresAlemania, masajista, lstAlemaniaMasajeador);
                                    break;
                                case EPaises.Francia:
                                    Añadir(masajeadoresFrancia, masajista, lstFranciaMasajeador);
                                    break;
                            }
                        }
                    }
                }
            }
        }

               
        /// <summary>
        /// Manejador de eventos para el cambio en la selección del país en el ComboBox.
        /// Muestra el ListBox correspondiente al país seleccionado y oculta los demás.
        /// </summary>
        private void cmbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                // Oculta todos los ListBox
                CambiarVisualizacion(lstArgentina, lstArgentinaEntrenador, lstArgentinaMasajeador, pctArgentina, false);
                CambiarVisualizacion(lstBrasil, lstBrasilEntrenador, lstBrasilMasajeador, pctBrasil, false);
                CambiarVisualizacion(lstAlemania, lstAlemaniaEntrenador, lstAlemaniaMasajeador, pctAlemania, false);
                CambiarVisualizacion(lstFrancia, lstFranciaEntrenador, lstFranciaMasajeador, pctFrancia, false);
                CambiarVisualizacion(lstItalia, lstItaliaEntrenador, lstItaliaMasajeador, pctItalia, false);

                // Muestra el ListBox correspondiente al país seleccionado
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;
                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        CambiarVisualizacion(lstArgentina, lstArgentinaEntrenador, lstArgentinaMasajeador, pctArgentina, true);
                        break;
                    case EPaises.Brasil:
                        CambiarVisualizacion(lstBrasil, lstBrasilEntrenador, lstBrasilMasajeador, pctBrasil, true);
                        break;
                    case EPaises.Italia:
                        CambiarVisualizacion(lstItalia, lstItaliaEntrenador, lstItaliaMasajeador, pctItalia, true);
                        break;
                    case EPaises.Francia:
                        CambiarVisualizacion(lstFrancia, lstFranciaEntrenador, lstFranciaMasajeador, pctFrancia, true);
                        break;
                    case EPaises.Alemania:
                        CambiarVisualizacion(lstAlemania, lstAlemaniaEntrenador, lstAlemaniaMasajeador, pctAlemania, true);
                        break;
                }
            }
        }

        /// <summary>
        /// Manejador de eventos al cerrar el formulario.
        /// Realiza la serialización de los datos de jugadores, entrenadores y masajistas.
        /// </summary>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            try
{
                SQL sql = new SQL();

                foreach (Jugador jugador in jugadoresArgentina)
                {
                    sql.AgregarJugador(jugador);
                }

                foreach (Jugador jugador in jugadoresBrasil)
                {
                    sql.AgregarJugador(jugador);
                }

                foreach (Jugador jugador in jugadoresAlemania)
                {
                    sql.AgregarJugador(jugador);
                }

                foreach (Jugador jugador in jugadoresItalia)
                {
                    sql.AgregarJugador(jugador);
                }
                foreach (Jugador jugador in jugadoresFrancia)
                {
                    sql.AgregarJugador(jugador);
                }

                foreach (Entrenador entrenador in entrenadorArgentina)
                {
                    sql.AgregarEntrenador(entrenador);
                }
                foreach (Entrenador entrenador in entrenadorBrasil)
                {
                    sql.AgregarEntrenador(entrenador);
                }
                foreach (Entrenador entrenador in entrenadorAlemania)
                {
                    sql.AgregarEntrenador(entrenador);
                }
                foreach (Entrenador entrenador in entrenadorItalia)
                {
                    sql.AgregarEntrenador(entrenador);
                }
                foreach (Entrenador entrenador in entrenadorFrancia)
                {
                    sql.AgregarEntrenador(entrenador);
                }
                foreach (Masajista masajista in masajeadoresArgentina)
                {
                    sql.AgregarMasajista(masajista);
                }
                foreach (Masajista masajista in masajeadoresBrasil)
                {
                    sql.AgregarMasajista(masajista);
                }
                foreach (Masajista masajista in masajeadoresAlemania)
                {
                    sql.AgregarMasajista(masajista);
                }
                foreach (Masajista masajista in masajeadoresItalia)
                {
                    sql.AgregarMasajista(masajista);
                }
                foreach (Masajista masajista in masajeadoresFrancia)
                {
                    sql.AgregarMasajista(masajista);
                }
                sql.CerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar datos en la base de datos: " + ex.Message);
            }
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
                    if (cmbPaises.SelectedItem != null)
                    {
                        EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                        bool elementoSeleccionado = false;

                        switch (paisSeleccionado)
                        {
                            case EPaises.Argentina:
                                elementoSeleccionado = lstArgentina.SelectedIndex != -1 || lstArgentinaEntrenador.SelectedIndex != -1 || lstArgentinaMasajeador.SelectedIndex != -1;
                                break;
                            case EPaises.Brasil:
                                elementoSeleccionado = lstBrasil.SelectedIndex != -1 || lstBrasilEntrenador.SelectedIndex != -1 || lstBrasilMasajeador.SelectedIndex != -1;
                                break;
                            case EPaises.Italia:
                                elementoSeleccionado = lstItalia.SelectedIndex != -1 || lstItaliaEntrenador.SelectedIndex != -1 || lstItaliaMasajeador.SelectedIndex != -1;
                                break;
                            case EPaises.Francia:
                                elementoSeleccionado = lstFrancia.SelectedIndex != -1 || lstFranciaEntrenador.SelectedIndex != -1 || lstFranciaMasajeador.SelectedIndex != -1;
                                break;
                            case EPaises.Alemania:
                                elementoSeleccionado = lstAlemania.SelectedIndex != -1 || lstAlemaniaEntrenador.SelectedIndex != -1 || lstAlemaniaMasajeador.SelectedIndex != -1;
                                break;
                        }

                        if (!elementoSeleccionado)
                        {
                            MessageBox.Show("Por favor, selecciona un elemento en la lista antes de intentar eliminarlo.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar estos elementos?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            switch (paisSeleccionado)
                            {
                                case EPaises.Argentina:
                                    EliminarElemento(lstArgentina, jugadoresArgentina);
                                    EliminarElemento(lstArgentinaEntrenador, entrenadorArgentina);
                                    EliminarElemento(lstArgentinaMasajeador, masajeadoresArgentina);
                                    break;
                                case EPaises.Brasil:
                                    EliminarElemento(lstBrasil, jugadoresBrasil);
                                    EliminarElemento(lstBrasilEntrenador, entrenadorBrasil);
                                    EliminarElemento(lstBrasilMasajeador, masajeadoresBrasil);
                                    break;
                                case EPaises.Italia:
                                    EliminarElemento(lstItalia, jugadoresItalia);
                                    EliminarElemento(lstItaliaEntrenador, entrenadorItalia);
                                    EliminarElemento(lstItaliaMasajeador, masajeadoresItalia);
                                    break;
                                case EPaises.Francia:
                                    EliminarElemento(lstFrancia, jugadoresFrancia);
                                    EliminarElemento(lstFranciaEntrenador, entrenadorFrancia);
                                    EliminarElemento(lstFranciaMasajeador, masajeadoresFrancia);
                                    break;
                                case EPaises.Alemania:
                                    EliminarElemento(lstAlemania, jugadoresAlemania);
                                    EliminarElemento(lstAlemaniaEntrenador, entrenadorAlemania);
                                    EliminarElemento(lstAlemaniaMasajeador, masajeadoresAlemania);
                                    break;
                            }
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
                    if (cmbPaises.SelectedItem != null)
                    {
                        EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                        switch (paisSeleccionado)
                        {
                            case EPaises.Argentina:
                                ModificarElemento(lstArgentina, jugadoresArgentina);
                                ModificarElemento(lstArgentinaEntrenador, entrenadorArgentina);
                                ModificarElemento(lstArgentinaMasajeador, masajeadoresArgentina);
                                break;
                            case EPaises.Brasil:
                                ModificarElemento(lstBrasil, jugadoresBrasil);
                                ModificarElemento(lstBrasilEntrenador, entrenadorBrasil);
                                ModificarElemento(lstBrasilMasajeador, masajeadoresBrasil);
                                break;
                            case EPaises.Italia:
                                ModificarElemento(lstItalia, jugadoresItalia);
                                ModificarElemento(lstItaliaEntrenador, entrenadorItalia);
                                ModificarElemento(lstItaliaMasajeador, masajeadoresItalia);
                                break;
                            case EPaises.Francia:
                                ModificarElemento(lstFrancia, jugadoresFrancia);
                                ModificarElemento(lstFranciaEntrenador, entrenadorFrancia);
                                ModificarElemento(lstFranciaMasajeador, masajeadoresFrancia);
                                break;
                            case EPaises.Alemania:
                                ModificarElemento(lstAlemania, jugadoresAlemania);
                                ModificarElemento(lstAlemaniaEntrenador, entrenadorAlemania);
                                ModificarElemento(lstAlemaniaMasajeador, masajeadoresAlemania);
                                break;
                        }
                    }
                }
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        AccionJugador(lstArgentina);
                        AccionEntrenador(lstArgentinaEntrenador);
                        AccionMasajista(lstArgentinaMasajeador);
                        break;
                    case EPaises.Brasil:
                        AccionJugador(lstBrasil);
                        AccionEntrenador(lstBrasilEntrenador);
                        AccionMasajista(lstBrasilMasajeador);
                        break;
                    case EPaises.Italia:
                        AccionJugador(lstItalia);
                        AccionEntrenador(lstItaliaEntrenador);
                        AccionMasajista(lstItaliaMasajeador);
                        break;
                    case EPaises.Francia:
                        AccionJugador(lstFrancia);
                        AccionEntrenador(lstFranciaEntrenador);
                        AccionMasajista(lstFranciaMasajeador); ;
                        break;
                    case EPaises.Alemania:
                        AccionJugador(lstAlemania);
                        AccionEntrenador(lstAlemaniaEntrenador);
                        AccionMasajista(lstAlemaniaMasajeador);
                        break;
                }
            }
        }

        /// <summary>
        /// Maneja el evento Click del formulario principal y deselecciona todos los elementos en las listas.
        /// </summary>
        private void FormPrincipal_Click(object sender, EventArgs e)
        {
            lstArgentina.ClearSelected();
            lstBrasil.ClearSelected();
            lstItalia.ClearSelected();
            lstFrancia.ClearSelected();
            lstAlemania.ClearSelected();
            lstArgentinaEntrenador.ClearSelected();
            lstBrasilEntrenador.ClearSelected();
            lstItaliaEntrenador.ClearSelected();
            lstFranciaEntrenador.ClearSelected();
            lstAlemaniaEntrenador.ClearSelected();
            lstArgentinaMasajeador.ClearSelected();
            lstBrasilMasajeador.ClearSelected();
            lstItaliaMasajeador.ClearSelected();
            lstFranciaMasajeador.ClearSelected();
            lstAlemaniaMasajeador.ClearSelected();
        }

        /// <summary>
        /// Método que maneja el evento Click del botón "Ordenar". 
        /// Ordena los elementos de la lista correspondiente (jugadores, entrenadores o masajistas) 
        /// en función de la opción seleccionada (ascendente o descendente) y el país seleccionado
        /// Los jugadores de van a poder ordenar en cuanto a posicion y edad y los entrenador y masajistas solo por edad
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (rdoAscendenteEdad.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarEdad(lstArgentina, jugadoresArgentina);
                        OrdenarEdad(lstArgentinaEntrenador, entrenadorArgentina);
                        OrdenarEdad(lstArgentinaMasajeador, masajeadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarEdad(lstBrasil, jugadoresBrasil);
                        OrdenarEdad(lstBrasilEntrenador, entrenadorBrasil);
                        OrdenarEdad(lstBrasilMasajeador, masajeadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarEdad(lstItalia, jugadoresItalia);
                        OrdenarEdad(lstItaliaEntrenador, entrenadorItalia);
                        OrdenarEdad(lstItaliaMasajeador, masajeadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarEdad(lstFrancia, jugadoresFrancia);
                        OrdenarEdad(lstFranciaEntrenador, entrenadorFrancia);
                        OrdenarEdad(lstFranciaMasajeador, masajeadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarEdad(lstAlemania, jugadoresAlemania);
                        OrdenarEdad(lstAlemaniaEntrenador, entrenadorAlemania);
                        OrdenarEdad(lstAlemaniaMasajeador, masajeadoresAlemania);
                        break;
                }
            }
            else if (rdoDescendenteEdad.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarEdad(lstArgentina, jugadoresArgentina);
                        OrdenarEdad(lstArgentinaEntrenador, entrenadorArgentina);
                        OrdenarEdad(lstArgentinaMasajeador, masajeadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarEdad(lstBrasil, jugadoresBrasil);
                        OrdenarEdad(lstBrasilEntrenador, entrenadorBrasil);
                        OrdenarEdad(lstBrasilMasajeador, masajeadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarEdad(lstItalia, jugadoresItalia);
                        OrdenarEdad(lstItaliaEntrenador, entrenadorItalia);
                        OrdenarEdad(lstItaliaMasajeador, masajeadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarEdad(lstFrancia, jugadoresFrancia);
                        OrdenarEdad(lstFranciaEntrenador, entrenadorFrancia);
                        OrdenarEdad(lstFranciaMasajeador, masajeadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarEdad(lstAlemania, jugadoresAlemania);
                        OrdenarEdad(lstAlemaniaEntrenador, entrenadorAlemania);
                        OrdenarEdad(lstAlemaniaMasajeador, masajeadoresAlemania);
                        break;
                }
            }
            else if (rdoAscendentePosicion.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarPosicion(lstArgentina, jugadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarPosicion(lstBrasil, jugadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarPosicion(lstItalia, jugadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarPosicion(lstFrancia, jugadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarPosicion(lstAlemania, jugadoresAlemania);
                        break;
                }
            }
            else if (rdoDescendentePosicion.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarPosicion(lstArgentina, jugadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarPosicion(lstBrasil, jugadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarPosicion(lstItalia, jugadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarPosicion(lstFrancia, jugadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarPosicion(lstAlemania, jugadoresAlemania);
                        break;
                }
            }

        }
        private void btnGuardarManualmente_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres guardar manualmente? Tendras que guardar absolutamente todas los json.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {

                SerializarManual("JugadorFrancia.json", this.jugadoresFrancia);
                SerializarManual("JugadorArgentina.json", this.jugadoresArgentina);
                SerializarManual("JugadorItalia.json", this.jugadoresItalia);
                SerializarManual("JugadorBrasil.json", this.jugadoresBrasil);
                SerializarManual("JugadorAlemania.json", this.jugadoresAlemania);

                SerializarManual("EntrenadorFrancia.json", this.entrenadorFrancia);
                SerializarManual("EntrenadorArgentina.json", this.entrenadorArgentina);
                SerializarManual("EntrenadorItalia.json", this.entrenadorItalia);
                SerializarManual("EntrenadorBrasil.json", this.entrenadorBrasil);
                SerializarManual("EntrenadorAlemania.json", this.entrenadorAlemania);

                SerializarManual("MasajistaFrancia.json", this.masajeadoresFrancia);
                SerializarManual("MasajistaArgentina.json", this.masajeadoresArgentina);
                SerializarManual("MasajistaItalia.json", this.masajeadoresItalia);
                SerializarManual("MasajistaBrasil.json", this.masajeadoresBrasil);
                SerializarManual("MasajistaAlemania.json", this.masajeadoresAlemania);
            }
            else
            {

            }
        }

        #region Serializacion Manual
        /// <summary>
        /// metodo en el que el usuario puede guardar manualmente los archivos json, lo que si cuando se cierra el program
        /// de igual manera se va a guardar manualmente
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="lista"></param>
        public void SerializarManual<T>(string path, List<T> lista)
        {
            try
            {
                string nombreArchivo = path;

                SaveFileDialog guardar = new SaveFileDialog();

                guardar.FileName = nombreArchivo;

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(guardar.FileName))
                    {
                        JsonSerializerOptions opciones = new JsonSerializerOptions();
                        opciones.WriteIndented = true;

                        string objJson = System.Text.Json.JsonSerializer.Serialize(lista, opciones);
                        sw.WriteLine(objJson);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Cambia la visibilidad de los controles ListBox y PictureBox.
        /// </summary>
        /// <param name="lst1">Primer ListBox a controlar</param>
        /// <param name="lst2">Segundo ListBox a controlar</param>
        /// <param name="lst3">Tercer ListBox a controlar</param>
        /// <param name="pictur">PictureBox a controlar</param>
        /// <param name="algo">Indica si se deben mostrar (true) o ocultar (false) los controles</param>
        private void CambiarVisualizacion(ListBox lst1, ListBox lst2, ListBox lst3, PictureBox pictur, bool algo)
        {
            lst1.Visible = algo;
            lst2.Visible = algo;
            lst3.Visible = algo;
            pictur.Visible = algo;
        }

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
        /// Agrega un entrenador a la lista correspondiente, asegurándose de que solo haya un entrenador por país.
        /// </summary>
        /// <param name="lista">Lista de entrenadores del país</param>
        /// <param name="lst">ListBox que muestra los entrenadores</param>
        /// <param name="entrenador">Entrenador a agregar</param>
        public void SoloUnEntrenador(List<Entrenador> lista, ListBox lst, Entrenador entrenador)
        {
            if (lista.Count > 0)
            {
                MessageBox.Show("Ya hay un entrenador para este país. Debes eliminar el entrenador existente antes de agregar uno nuevo.", "Error");
            }
            else
            {
                Añadir(lista, entrenador, lst);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Metodos Eliminar
        /// <summary>
        /// Estos tres metodos eliminan un elemento de la lista (jugador,entrenador,masajista)
        /// y de la ListBox correspondiente.
        /// </summary>
        /// <param name="listBox">ListBox que contiene la lista de jugadores</param>
        /// <param name="lista">Lista de jugadores</param>
        private void EliminarElemento(ListBox listBox, List<Jugador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;

                Jugador jugador = lista[selectedIndex];
                sql.BorrarDato(jugador);
                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);

            }
        }
        private void EliminarElemento(ListBox listBox, List<Entrenador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;

                Entrenador jugador = lista[selectedIndex];
                sql.BorrarDato(jugador);

                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
            }
        }
        private void EliminarElemento(ListBox listBox, List<Masajista> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;

                Masajista jugador = lista[selectedIndex];
                sql.BorrarDato(jugador);

                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
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
        #endregion

        #region Metodo para Actualizar Visor

        /// <summary>
        /// Actualiza la ListBox con una lista que le pase por parametro(Jugador,Masajista,Entrenador).
        /// </summary>
        /// <param name="listJugador">Lista de jugadores</param>
        /// <param name="lst">ListBox que se actualizará</param>
        private void ActualizarVisor<T>(List<T> lista, ListBox lst)
        {
            lst.Items.Clear();
            foreach (T item in lista)
            {
                lst.Items.Add(item);
            }
        }
        #endregion

        #region Metodos para Ordenar
        public void OrdenarEdad<T>(ListBox lst, List<T> lista) where T : PersonalEquipoSeleccion
        {
            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }
            else if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }

            ActualizarListBox(lst, lista);
        }

        public void OrdenarPosicion<T>(ListBox lst, List<T> lista) where T : Jugador
        {
            if (rdoAscendentePosicion.Checked)
            {
                lista.Sort((j1, j2) => ((Jugador)j1).Posicion.CompareTo(((Jugador)j2).Posicion));
            }
            else if (rdoDescendentePosicion.Checked)
            {
                lista.Sort((j1, j2) => ((Jugador)j2).Posicion.CompareTo(((Jugador)j1).Posicion));
            }

            ActualizarListBox(lst, lista);
        }

        private void ActualizarListBox<T>(ListBox lst, List<T> lista)
        {
            lst.Items.Clear();

            foreach (var elemento in lista)
            {
                lst.Items.Add(elemento);
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

        #region
        private void RealizarAccion<T>(ListBox listBox, string tituloAccion) where T : PersonalEquipoSeleccion
        {
            if (listBox.SelectedIndex != -1)
            {
                if (listBox.SelectedItem is T seleccionado)
                {
                    string accion = seleccionado.RealizarAccion();

                    MessageBox.Show(accion, $"Acción de {tituloAccion}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AccionJugador(ListBox listBox)
        {
            RealizarAccion<Jugador>(listBox, "Jugador");
        }

        private void AccionEntrenador(ListBox listBox)
        {
            RealizarAccion<Entrenador>(listBox, "Entrenador");
        }

        private void AccionMasajista(ListBox listBox)
        {
            RealizarAccion<Masajista>(listBox, "Masajeador");
        }

        #endregion

    }
}