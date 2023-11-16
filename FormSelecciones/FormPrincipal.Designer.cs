namespace FormSelecciones
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            label1 = new Label();
            btnConvocar = new Button();
            lstPersonal = new ListBox();
            btnEliminar = new Button();
            label5 = new Label();
            label6 = new Label();
            btnModificar = new Button();
            groupBox1 = new GroupBox();
            rdoDescendentePosicion = new RadioButton();
            rdoAscendentePosicion = new RadioButton();
            label8 = new Label();
            btnOrdenar = new Button();
            rdoDescendenteEdad = new RadioButton();
            label7 = new Label();
            rdoAscendenteEdad = new RadioButton();
            btnGuardarManualmente = new Button();
            label9 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            btnMostrar = new Button();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            btnAccion = new Button();
            groupBox6 = new GroupBox();
            btnCargarDatos = new Button();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 44);
            label1.Name = "label1";
            label1.Size = new Size(275, 24);
            label1.TabIndex = 0;
            label1.Text = "Convocar Personal a la Seleccion";
            // 
            // btnConvocar
            // 
            btnConvocar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnConvocar.ForeColor = SystemColors.ActiveCaptionText;
            btnConvocar.Location = new Point(77, 71);
            btnConvocar.Name = "btnConvocar";
            btnConvocar.Size = new Size(152, 58);
            btnConvocar.TabIndex = 3;
            btnConvocar.Text = "Convocar Personal";
            btnConvocar.UseVisualStyleBackColor = true;
            btnConvocar.Click += btnConvocar_Click;
            // 
            // lstPersonal
            // 
            lstPersonal.FormattingEnabled = true;
            lstPersonal.ItemHeight = 15;
            lstPersonal.Location = new Point(320, 37);
            lstPersonal.Name = "lstPersonal";
            lstPersonal.Size = new Size(567, 439);
            lstPersonal.TabIndex = 17;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.ActiveCaptionText;
            btnEliminar.Location = new Point(77, 206);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(152, 58);
            btnEliminar.TabIndex = 22;
            btnEliminar.Text = "Eliminar Personal";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 179);
            label5.Name = "label5";
            label5.Size = new Size(275, 24);
            label5.TabIndex = 23;
            label5.Text = "Convocar Personal a la Seleccion";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(7, 318);
            label6.Name = "label6";
            label6.Size = new Size(243, 24);
            label6.TabIndex = 24;
            label6.Text = "Modificar datos del personal";
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.ForeColor = SystemColors.ActiveCaptionText;
            btnModificar.Location = new Point(77, 345);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(152, 58);
            btnModificar.TabIndex = 25;
            btnModificar.Text = "Modificar Personal";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdoDescendentePosicion);
            groupBox1.Controls.Add(rdoAscendentePosicion);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(btnOrdenar);
            groupBox1.Controls.Add(rdoDescendenteEdad);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(rdoAscendenteEdad);
            groupBox1.Location = new Point(12, 482);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(432, 121);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Orden";
            // 
            // rdoDescendentePosicion
            // 
            rdoDescendentePosicion.AutoSize = true;
            rdoDescendentePosicion.Location = new Point(278, 82);
            rdoDescendentePosicion.Name = "rdoDescendentePosicion";
            rdoDescendentePosicion.Size = new Size(93, 19);
            rdoDescendentePosicion.TabIndex = 39;
            rdoDescendentePosicion.TabStop = true;
            rdoDescendentePosicion.Text = "Descendente";
            rdoDescendentePosicion.UseVisualStyleBackColor = true;
            // 
            // rdoAscendentePosicion
            // 
            rdoAscendentePosicion.AutoSize = true;
            rdoAscendentePosicion.Location = new Point(278, 49);
            rdoAscendentePosicion.Name = "rdoAscendentePosicion";
            rdoAscendentePosicion.Size = new Size(87, 19);
            rdoAscendentePosicion.TabIndex = 38;
            rdoAscendentePosicion.TabStop = true;
            rdoAscendentePosicion.Text = "Ascendente";
            rdoAscendentePosicion.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(278, 27);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 37;
            label8.Text = "Por posicion";
            // 
            // btnOrdenar
            // 
            btnOrdenar.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnOrdenar.Location = new Point(150, 49);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(89, 40);
            btnOrdenar.TabIndex = 36;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // rdoDescendenteEdad
            // 
            rdoDescendenteEdad.AutoSize = true;
            rdoDescendenteEdad.Location = new Point(18, 82);
            rdoDescendenteEdad.Name = "rdoDescendenteEdad";
            rdoDescendenteEdad.Size = new Size(93, 19);
            rdoDescendenteEdad.TabIndex = 35;
            rdoDescendenteEdad.TabStop = true;
            rdoDescendenteEdad.Text = "Descendente";
            rdoDescendenteEdad.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 27);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 34;
            label7.Text = "Por edad";
            // 
            // rdoAscendenteEdad
            // 
            rdoAscendenteEdad.AutoSize = true;
            rdoAscendenteEdad.Location = new Point(18, 52);
            rdoAscendenteEdad.Name = "rdoAscendenteEdad";
            rdoAscendenteEdad.Size = new Size(87, 19);
            rdoAscendenteEdad.TabIndex = 33;
            rdoAscendenteEdad.TabStop = true;
            rdoAscendenteEdad.Text = "Ascendente";
            rdoAscendenteEdad.UseVisualStyleBackColor = true;
            // 
            // btnGuardarManualmente
            // 
            btnGuardarManualmente.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardarManualmente.ForeColor = SystemColors.ActiveCaptionText;
            btnGuardarManualmente.Location = new Point(75, 31);
            btnGuardarManualmente.Name = "btnGuardarManualmente";
            btnGuardarManualmente.Size = new Size(152, 58);
            btnGuardarManualmente.TabIndex = 33;
            btnGuardarManualmente.Text = "Guardar";
            btnGuardarManualmente.UseVisualStyleBackColor = true;
            btnGuardarManualmente.Click += btnGuardarManualmente_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(919, 461);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 34;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnModificar);
            groupBox2.Controls.Add(btnConvocar);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Location = new Point(12, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(302, 463);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Personal";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnGuardarManualmente);
            groupBox3.Location = new Point(773, 482);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(298, 121);
            groupBox3.TabIndex = 41;
            groupBox3.TabStop = false;
            groupBox3.Text = "Guardar json manualmente";
            // 
            // btnMostrar
            // 
            btnMostrar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMostrar.ForeColor = SystemColors.ActiveCaptionText;
            btnMostrar.Location = new Point(14, 22);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(152, 58);
            btnMostrar.TabIndex = 34;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += button1_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnMostrar);
            groupBox4.Location = new Point(893, 219);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(178, 100);
            groupBox4.TabIndex = 42;
            groupBox4.TabStop = false;
            groupBox4.Text = "Registro de usuarios";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnAccion);
            groupBox5.Location = new Point(893, 358);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(178, 100);
            groupBox5.TabIndex = 43;
            groupBox5.TabStop = false;
            groupBox5.Text = "Realizar accion";
            // 
            // btnAccion
            // 
            btnAccion.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAccion.ForeColor = SystemColors.ActiveCaptionText;
            btnAccion.Location = new Point(14, 22);
            btnAccion.Name = "btnAccion";
            btnAccion.Size = new Size(152, 58);
            btnAccion.TabIndex = 34;
            btnAccion.Text = "Accion";
            btnAccion.UseVisualStyleBackColor = true;
            btnAccion.Click += btnAccion_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnCargarDatos);
            groupBox6.Location = new Point(450, 482);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(298, 121);
            groupBox6.TabIndex = 45;
            groupBox6.TabStop = false;
            groupBox6.Text = "Cargar Base de Datos";
            // 
            // btnCargarDatos
            // 
            btnCargarDatos.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCargarDatos.ForeColor = SystemColors.ActiveCaptionText;
            btnCargarDatos.Location = new Point(75, 31);
            btnCargarDatos.Name = "btnCargarDatos";
            btnCargarDatos.Size = new Size(152, 58);
            btnCargarDatos.TabIndex = 33;
            btnCargarDatos.Text = "Cargar Datos";
            btnCargarDatos.UseVisualStyleBackColor = true;
            btnCargarDatos.Click += btnCargarDatos_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(893, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 46;
            pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 615);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label9);
            Controls.Add(groupBox1);
            Controls.Add(lstPersonal);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            FormClosing += FormPrincipal_FormClosing;
            Load += FormPrincipal_Load;
            Click += FormPrincipal_Click;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstArgentina;
        private Button btnConvocar;
        private ListBox lstAlemania;
        private ListBox lstItalia;
        private ListBox lstBrasil;
        private ListBox lstFrancia;
        private ListBox lstArgentinaEntrenador;
        private Label label2;
        private Label label3;
        private ListBox lstItaliaEntrenador;
        private ListBox lstAlemaniaEntrenador;
        private ListBox lstFranciaEntrenador;
        private ListBox lstBrasilEntrenador;
        private Label label4;
        private ListBox lstPersonal;
        private ListBox lstBrasilMasajeador;
        private ListBox lstFranciaMasajeador;
        private ListBox lstItaliaMasajeador;
        private ListBox lstAlemaniaMasajeador;
        private Button btnEliminar;
        private Label label5;
        private Label label6;
        private Button btnModificar;
        private GroupBox groupBox1;
        private RadioButton rdoAscendenteEdad;
        private Label label7;
        private RadioButton rdoDescendentePosicion;
        private RadioButton rdoAscendentePosicion;
        private Label label8;
        private Button btnOrdenar;
        private RadioButton rdoDescendenteEdad;
        private Button btnGuardarManualmente;
        private Label label9;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnMostrar;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button btnAccion;
        private GroupBox groupBox6;
        private Button btnCargarDatos;
        private PictureBox pictureBox1;
    }
}