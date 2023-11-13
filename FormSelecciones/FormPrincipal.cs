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
            //JUGADORES
            Deserializar("JugadorArgentina.json", ref jugadoresArgentina);
            ActualizarVisor(jugadoresArgentina, lstArgentina);
            Deserializar("JugadorBrasil.json", ref jugadoresBrasil);
            ActualizarVisor(jugadoresBrasil, lstBrasil);
            Deserializar("JugadorItalia.json", ref jugadoresItalia);
            ActualizarVisor(jugadoresItalia, lstItalia);
            Deserializar("JugadorFrancia.json", ref jugadoresFrancia);
            ActualizarVisor(jugadoresFrancia, lstFrancia);
            Deserializar("JugadorAlemania.json", ref jugadoresAlemania);
            ActualizarVisor(jugadoresAlemania, lstAlemania);

            //ENTRENADORES
            Deserializar("EntrenadorArgentina.json", ref entrenadorArgentina);
            ActualizarVisor(entrenadorArgentina, lstArgentinaEntrenador);
            Deserializar("EntrenadorBrasil.json", ref entrenadorBrasil);
            ActualizarVisor(entrenadorBrasil, lstBrasilEntrenador);
            Deserializar("EntrenadorItalia.json", ref entrenadorItalia);
            ActualizarVisor(entrenadorItalia, lstItaliaEntrenador);
            Deserializar("EntrenadorFrancia.json", ref entrenadorFrancia);
            ActualizarVisor(entrenadorFrancia, lstFranciaEntrenador);
            Deserializar("EntrenadorAlemania.json", ref entrenadorAlemania);
            ActualizarVisor(entrenadorAlemania, lstAlemaniaEntrenador);

            //MASAJISTAS
            Deserializar("MasajistaArgentina.json", ref masajeadoresArgentina);
            ActualizarVisor(masajeadoresArgentina, lstArgentinaMasajeador);
            Deserializar("MasajistaBrasil.json", ref masajeadoresBrasil);
            ActualizarVisor(masajeadoresBrasil, lstBrasilMasajeador);
            Deserializar("MasajistaItalia.json", ref masajeadoresItalia);
            ActualizarVisor(masajeadoresItalia, lstItaliaMasajeador);
            Deserializar("MasajistaFrancia.json", ref masajeadoresFrancia);
            ActualizarVisor(masajeadoresFrancia, lstFranciaMasajeador);
            Deserializar("MasajistaFrancia.json", ref masajeadoresFrancia);
            ActualizarVisor(masajeadoresAlemania, lstAlemaniaMasajeador);
        }

        /// <summary>
        /// Manejador de eventos para el botón de convocar.
        /// Abre el formulario de creación de personal y agrega el nuevo personal a las listas correspondientes.
        /// </summary>
        private void btnConvocar_Click(object sender, EventArgs e)
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
            ////JUGADORES
            //Serializar("JugadorArgentina.json", jugadoresArgentina);
            //Serializar("JugadorBrasil.json", jugadoresBrasil);
            //Serializar("JugadorItalia.json", jugadoresItalia);
            //Serializar("JugadorFrancia.json", jugadoresFrancia);
            //Serializar("JugadorAlemania.json", jugadoresAlemania);

            ////ENTRENADORES
            //Serializar("EntrenadorArgentina.json", entrenadorArgentina);
            //Serializar("EntrenadorBrasil.json", entrenadorBrasil);
            //Serializar("EntrenadorItalia.json", entrenadorItalia);
            //Serializar("EntrenadorFrancia.json", entrenadorFrancia);
            //Serializar("EntrenadorAlemania.json", entrenadorAlemania);

            ////MASAJISTAS
            //Serializar("MasajistaArgentina.json", masajeadoresArgentina);
            //Serializar("MasajistaBrasil.json", masajeadoresBrasil);
            //Serializar("MasajistaItalia.json", masajeadoresItalia);
            //Serializar("MasajistaFrancia.json", masajeadoresFrancia);
            //Serializar("MasajistaAlemania.json", masajeadoresAlemania);
            try
{
                SQL sql = new SQL();
                // Recorrer las listas y agregar los elementos a la base de datos
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

                // Hacer lo mismo para entrenadores y masajistas
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

                // Repite el proceso para las otras listas y tipos de personal

                // Cierra la conexión después de agregar todos los elementos
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
            if (cmbPaises.SelectedItem != null)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                // Verifica si se ha seleccionado un elemento en el ListBox correspondiente al país seleccionado
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
                    return; // No se hace nada si no se selecciona ningún elemento
                }

                // Muestra un cuadro de diálogo de confirmación
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

        /// <summary>
        /// Método que maneja el evento Click del botón "Modificar". 
        /// Modifica un elemento seleccionado en la lista correspondiente 
        /// (jugadores, entrenadores o masajistas) según el país seleccionado.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
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
                        OrdenarEdadAs(lstArgentina, jugadoresArgentina);
                        OrdenarEdadAs(lstArgentinaEntrenador, entrenadorArgentina);
                        OrdenarEdadAs(lstArgentinaMasajeador, masajeadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarEdadAs(lstBrasil, jugadoresBrasil);
                        OrdenarEdadAs(lstBrasilEntrenador, entrenadorBrasil);
                        OrdenarEdadAs(lstBrasilMasajeador, masajeadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarEdadAs(lstItalia, jugadoresItalia);
                        OrdenarEdadAs(lstItaliaEntrenador, entrenadorItalia);
                        OrdenarEdadAs(lstItaliaMasajeador, masajeadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarEdadAs(lstFrancia, jugadoresFrancia);
                        OrdenarEdadAs(lstFranciaEntrenador, entrenadorFrancia);
                        OrdenarEdadAs(lstFranciaMasajeador, masajeadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarEdadAs(lstAlemania, jugadoresAlemania);
                        OrdenarEdadAs(lstAlemaniaEntrenador, entrenadorAlemania);
                        OrdenarEdadAs(lstAlemaniaMasajeador, masajeadoresAlemania);
                        break;
                }
            }
            else if (rdoDescendenteEdad.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarEdadDes(lstArgentina, jugadoresArgentina);
                        OrdenarEdadDes(lstArgentinaEntrenador, entrenadorArgentina);
                        OrdenarEdadDes(lstArgentinaMasajeador, masajeadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarEdadDes(lstBrasil, jugadoresBrasil);
                        OrdenarEdadDes(lstBrasilEntrenador, entrenadorBrasil);
                        OrdenarEdadDes(lstBrasilMasajeador, masajeadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarEdadDes(lstItalia, jugadoresItalia);
                        OrdenarEdadDes(lstItaliaEntrenador, entrenadorItalia);
                        OrdenarEdadDes(lstItaliaMasajeador, masajeadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarEdadDes(lstFrancia, jugadoresFrancia);
                        OrdenarEdadDes(lstFranciaEntrenador, entrenadorFrancia);
                        OrdenarEdadDes(lstFranciaMasajeador, masajeadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarEdadDes(lstAlemania, jugadoresAlemania);
                        OrdenarEdadDes(lstAlemaniaEntrenador, entrenadorAlemania);
                        OrdenarEdadDes(lstAlemaniaMasajeador, masajeadoresAlemania);
                        break;
                }
            }
            else if (rdoAscendentePosicion.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarPosicionAs(lstArgentina, jugadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarPosicionAs(lstBrasil, jugadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarPosicionAs(lstItalia, jugadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarPosicionAs(lstFrancia, jugadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarPosicionAs(lstAlemania, jugadoresAlemania);
                        break;
                }
            }
            else if (rdoDescendentePosicion.Checked)
            {
                EPaises paisSeleccionado = (EPaises)cmbPaises.SelectedItem;

                switch (paisSeleccionado)
                {
                    case EPaises.Argentina:
                        OrdenarPosicionDes(lstArgentina, jugadoresArgentina);
                        break;
                    case EPaises.Brasil:
                        OrdenarPosicionDes(lstBrasil, jugadoresBrasil);
                        break;
                    case EPaises.Italia:
                        OrdenarPosicionDes(lstItalia, jugadoresItalia);
                        break;
                    case EPaises.Francia:
                        OrdenarPosicionDes(lstFrancia, jugadoresFrancia);
                        break;
                    case EPaises.Alemania:
                        OrdenarPosicionDes(lstAlemania, jugadoresAlemania);
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
                listBox.Items.RemoveAt(selectedIndex);

            }
        }
        private void EliminarElemento(ListBox listBox, List<Entrenador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;
                listBox.Items.RemoveAt(selectedIndex);
                lista.RemoveAt(selectedIndex);
            }
        }
        private void EliminarElemento(ListBox listBox, List<Masajista> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                int selectedIndex = listBox.SelectedIndex;
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
        private void ModificarList(ListBox lst, List<Jugador> personal)
        {
            // Abre un formulario de edición para el jugador seleccionado

            Jugador jugadorSeleccionado = (Jugador)lst.SelectedItem;
            ConvocarJugador editarJugadorForm = new ConvocarJugador(jugadorSeleccionado);

            // Pasa el jugador seleccionado al formulario de edición
            editarJugadorForm.JugadorParaEditar = jugadorSeleccionado;

            editarJugadorForm.ShowDialog();

            if (editarJugadorForm.DialogResult == DialogResult.OK)
            {
                // Obtén el jugador modificado del formulario de edición
                Jugador jugadorModificado = editarJugadorForm.NuevoJugador;

                // Actualiza la lista con los cambios realizados por el usuario
                int selectedIndex = lst.SelectedIndex;

                // Actualiza el jugador en la lista y la ListBox
                personal[selectedIndex] = jugadorModificado;
                lst.Items[selectedIndex] = jugadorModificado;
            }
        }

        private void ModificarList(ListBox lst, List<Entrenador> personal)
        {
            Entrenador entrenadorSeleccionado = (Entrenador)lst.SelectedItem;
            ConvocarEntrenador editarEntrenadorForm = new ConvocarEntrenador(entrenadorSeleccionado);

            editarEntrenadorForm.EntrendorParaEditar = entrenadorSeleccionado;

            editarEntrenadorForm.ShowDialog();

            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
            {
                Entrenador entrenadorModificado = editarEntrenadorForm.NuevoEntrenador;

                int selectedIndex = lst.SelectedIndex;

                personal[selectedIndex] = entrenadorModificado;
                lst.Items[selectedIndex] = entrenadorModificado;
            }
        }

        private void ModificarList(ListBox lst, List<Masajista> personal)
        {
            // Abre un formulario de edición para el jugador seleccionado

            Masajista masajistaSeleccionado = (Masajista)lst.SelectedItem;
            ConvocarMasajista editarEntrenadorForm = new ConvocarMasajista(masajistaSeleccionado);

            // Pasa el jugador seleccionado al formulario de edición
            editarEntrenadorForm.MasajeadorParaEditar = masajistaSeleccionado;

            editarEntrenadorForm.ShowDialog();

            if (editarEntrenadorForm.DialogResult == DialogResult.OK)
            {
                // Obtén el jugador modificado del formulario de edición
                Masajista entrenadorModificado = editarEntrenadorForm.NuevoMasajista;

                // Actualiza la lista con los cambios realizados por el usuario
                int selectedIndex = lst.SelectedIndex;

                // Actualiza el jugador en la lista y la ListBox
                personal[selectedIndex] = entrenadorModificado;
                lst.Items[selectedIndex] = entrenadorModificado;
            }
        }

        /// <summary>
        /// Estos tres metodos abren un formulario de edición para el elemento seleccionado en la ListBox 
        /// y lo modifica en la lista llamando a el metodo ModificarList().
        /// </summary>
        /// <param name="listBox">ListBox que contiene el elemento a modificar</param>
        /// <param name="lista">Lista de elementos del mismo tipo</param
        public void ModificarElemento(ListBox listBox, List<Jugador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }
        public void ModificarElemento(ListBox listBox, List<Masajista> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }
        public void ModificarElemento(ListBox listBox, List<Entrenador> lista)
        {
            if (listBox.SelectedIndex != -1)
            {
                ModificarList(listBox, lista);
            }
        }


        #endregion

        #region Metodos para Serializar y Deserializar
        /// <summary>
        /// los tres metodos Serializan una lista (Jugadores, Entrenador, Masajista)
        /// y la guarda en un archivo JSON.
        /// </summary>
        /// <param name="path">Ruta del archivo JSON</param>
        /// <param name="listJugador">Lista de jugadores a serializar</param>
        public void Serializar<T>(string path, List<T> lista)
        {
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;

            string objJson = System.Text.Json.JsonSerializer.Serialize(lista, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }

        /// <summary>
        /// estos tres metodos Deserializa un archivo JSON en una lista dependiendo
        /// que typo de lista le pases por parametro(Jugador, Entrenador, Masajista).
        /// </summary>
        /// <param name="path">Ruta del archivo JSON</param>
        /// <param name="listJugadores">Referencia a la lista de jugadores donde se almacenarán los datos deserializados</param>
        public void Deserializar<T>(string path, ref List<T> lista)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    lista = System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonString);
                }
            }
        }

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



        /// <summary>
        /// los 3 metodos ordenan una lista (puede ser Juagador, Masajista o Entrenador)
        /// por edad en orden ascendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>
        public void OrdenarEdadAs(ListBox lst, List<Jugador> lista)
        {

            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadAs(ListBox lst, List<Entrenador> lista)
        {

            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }

            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadAs(ListBox lst, List<Masajista> lista)
        {

            if (rdoAscendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j1.Edad.CompareTo(j2.Edad));
            }

            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }

        /// <summary>
        /// los 3 metodos ordenan una lista (puede ser Juagador, Masajista o Entrenador)
        /// por edad en orden descendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>
        public void OrdenarEdadDes(ListBox lst, List<Jugador> lista)
        {
            if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadDes(ListBox lst, List<Entrenador> lista)
        {
            if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        public void OrdenarEdadDes(ListBox lst, List<Masajista> lista)
        {
            if (rdoDescendenteEdad.Checked)
            {
                lista.Sort((j1, j2) => j2.Edad.CompareTo(j1.Edad));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }

        /// <summary>
        /// Ordena solamente una lista de jugadores por posición en orden ascendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>
        public void OrdenarPosicionAs(ListBox lst, List<Jugador> lista)
        {
            if (rdoAscendentePosicion.Checked)
            {
                lista.Sort((j1, j2) => j1.Posicion.CompareTo(j2.Posicion));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }

        /// <summary>
        /// Ordena solamente una lista de jugadores por posición en orden descendente y actualiza una ListBox.
        /// </summary>
        /// <param name="lst">ListBox que se actualizará con la lista ordenada</param>
        /// <param name="lista">Lista de jugadores que se ordenará</param>

        public void OrdenarPosicionDes(ListBox lst, List<Jugador> lista)
        {
            if (rdoDescendentePosicion.Checked)
            {
                lista.Sort((j1, j2) => j2.Posicion.CompareTo(j1.Posicion));
            }
            lst.Items.Clear();

            foreach (var jugador in lista)
            {
                lst.Items.Add(jugador);
            }
        }
        #endregion

        #region Añadir
        public void Añadir(List<Jugador> lista, Jugador personal, ListBox lst)
        {
            bool jugadorRepetido = lista.Any(j => j.Equals(personal));
            if (jugadorRepetido)
            {
                // Aquí puedes mostrar un mensaje de error o tomar alguna otra acción.
                MessageBox.Show("El jugador ya existe en la lista.");
            }
            else
            {
                // Si el jugador no existe en la lista, agrégalo.
                lista = lista + personal;
                lst.Items.Add(personal);
            }
        }

        public void Añadir(List<Entrenador> lista, Entrenador personal, ListBox lst)
        {
            //metodo para añadir jugador a la lista y a la listaBox
            bool jugadorRepetido = lista.Any(j => j.Equals(personal));
            if (jugadorRepetido)
            {
                // Aquí puedes mostrar un mensaje de error o tomar alguna otra acción.
                MessageBox.Show("El jugador ya existe en la lista.");
            }
            else
            {
                // Si el jugador no existe en la lista, agrégalo.
                lista = lista + personal;
                lst.Items.Add(personal);
            }
        }

        public void Añadir(List<Masajista> lista, Masajista personal, ListBox lst)
        {
            bool jugadorRepetido = lista.Any(j => j.Equals(personal));
            if (jugadorRepetido)
            {
                // Aquí puedes mostrar un mensaje de error o tomar alguna otra acción.
                MessageBox.Show("El jugador ya existe en la lista.");
            }
            else
            {
                // Si el jugador no existe en la lista, agrégalo.
                lista = lista + personal;
                lst.Items.Add(personal);
            }
        }
        #endregion

        #region
        private void AccionJugador(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {
                // Verifica si el objeto seleccionado es de tipo Jugador.
                if (listBox.SelectedItem is Jugador jugador)
                {
                    // Llama al método RealizarAccion del jugador seleccionado.
                    string accion = jugador.RealizarAccion();

                    // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                    MessageBox.Show(accion, "Acción del Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AccionEntrenador(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {
                // Verifica si el objeto seleccionado es de tipo Jugador.
                if (listBox.SelectedItem is Entrenador entrenador)
                {
                    // Llama al método RealizarAccion del jugador seleccionado.
                    string accion = entrenador.RealizarAccion();

                    // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                    MessageBox.Show(accion, "Acción del Entrenador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void AccionMasajista(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {
                // Verifica si el objeto seleccionado es de tipo Jugador.
                if (listBox.SelectedItem is Masajista masajista)
                {
                    // Llama al método RealizarAccion del jugador seleccionado.
                    string accion = masajista.RealizarAccion();

                    // Puedes mostrar la acción en un MessageBox o en otro lugar según tus necesidades.
                    MessageBox.Show(accion, "Acción del Masajeador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
    }
}