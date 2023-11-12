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
            lstArgentina = new ListBox();
            btnConvocar = new Button();
            lstAlemania = new ListBox();
            lstItalia = new ListBox();
            lstBrasil = new ListBox();
            lstFrancia = new ListBox();
            cmbPaises = new ComboBox();
            lstArgentinaEntrenador = new ListBox();
            label2 = new Label();
            label3 = new Label();
            lstItaliaEntrenador = new ListBox();
            lstAlemaniaEntrenador = new ListBox();
            lstFranciaEntrenador = new ListBox();
            lstBrasilEntrenador = new ListBox();
            label4 = new Label();
            lstArgentinaMasajeador = new ListBox();
            lstBrasilMasajeador = new ListBox();
            lstFranciaMasajeador = new ListBox();
            lstItaliaMasajeador = new ListBox();
            lstAlemaniaMasajeador = new ListBox();
            btnEliminar = new Button();
            label5 = new Label();
            label6 = new Label();
            btnModificar = new Button();
            pctArgentina = new PictureBox();
            pctItalia = new PictureBox();
            pctBrasil = new PictureBox();
            pctAlemania = new PictureBox();
            pctFrancia = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)pctArgentina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctItalia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctBrasil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctAlemania).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctFrancia).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(275, 24);
            label1.TabIndex = 0;
            label1.Text = "Convocar Personal a la Seleccion";
            // 
            // lstArgentina
            // 
            lstArgentina.FormattingEnabled = true;
            lstArgentina.ItemHeight = 15;
            lstArgentina.Location = new Point(349, 43);
            lstArgentina.Name = "lstArgentina";
            lstArgentina.Size = new Size(538, 124);
            lstArgentina.TabIndex = 2;
            // 
            // btnConvocar
            // 
            btnConvocar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnConvocar.ForeColor = SystemColors.ActiveCaptionText;
            btnConvocar.Location = new Point(77, 57);
            btnConvocar.Name = "btnConvocar";
            btnConvocar.Size = new Size(152, 58);
            btnConvocar.TabIndex = 3;
            btnConvocar.Text = "Convocar Personal";
            btnConvocar.UseVisualStyleBackColor = true;
            btnConvocar.Click += btnConvocar_Click;
            // 
            // lstAlemania
            // 
            lstAlemania.FormattingEnabled = true;
            lstAlemania.ItemHeight = 15;
            lstAlemania.Location = new Point(349, 43);
            lstAlemania.Name = "lstAlemania";
            lstAlemania.Size = new Size(538, 124);
            lstAlemania.TabIndex = 4;
            // 
            // lstItalia
            // 
            lstItalia.FormattingEnabled = true;
            lstItalia.ItemHeight = 15;
            lstItalia.Location = new Point(349, 43);
            lstItalia.Name = "lstItalia";
            lstItalia.Size = new Size(538, 124);
            lstItalia.TabIndex = 5;
            // 
            // lstBrasil
            // 
            lstBrasil.FormattingEnabled = true;
            lstBrasil.ItemHeight = 15;
            lstBrasil.Location = new Point(349, 43);
            lstBrasil.Name = "lstBrasil";
            lstBrasil.Size = new Size(538, 124);
            lstBrasil.TabIndex = 6;
            // 
            // lstFrancia
            // 
            lstFrancia.FormattingEnabled = true;
            lstFrancia.ItemHeight = 15;
            lstFrancia.Location = new Point(349, 43);
            lstFrancia.Name = "lstFrancia";
            lstFrancia.Size = new Size(538, 124);
            lstFrancia.TabIndex = 7;
            // 
            // cmbPaises
            // 
            cmbPaises.FormattingEnabled = true;
            cmbPaises.Items.AddRange(new object[] { "Italia", "Francia", "Brasil", "Argentina", "Alemania" });
            cmbPaises.Location = new Point(378, 12);
            cmbPaises.Name = "cmbPaises";
            cmbPaises.Size = new Size(121, 23);
            cmbPaises.TabIndex = 8;
            cmbPaises.SelectedIndexChanged += cmbPaises_SelectedIndexChanged;
            // 
            // lstArgentinaEntrenador
            // 
            lstArgentinaEntrenador.FormattingEnabled = true;
            lstArgentinaEntrenador.ItemHeight = 15;
            lstArgentinaEntrenador.Location = new Point(349, 195);
            lstArgentinaEntrenador.Name = "lstArgentinaEntrenador";
            lstArgentinaEntrenador.Size = new Size(538, 124);
            lstArgentinaEntrenador.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(798, 18);
            label2.Name = "label2";
            label2.Size = new Size(89, 24);
            label2.TabIndex = 10;
            label2.Text = "Jugadores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(768, 170);
            label3.Name = "label3";
            label3.Size = new Size(119, 24);
            label3.TabIndex = 11;
            label3.Text = "Entrenadores";
            // 
            // lstItaliaEntrenador
            // 
            lstItaliaEntrenador.FormattingEnabled = true;
            lstItaliaEntrenador.ItemHeight = 15;
            lstItaliaEntrenador.Location = new Point(349, 195);
            lstItaliaEntrenador.Name = "lstItaliaEntrenador";
            lstItaliaEntrenador.Size = new Size(538, 124);
            lstItaliaEntrenador.TabIndex = 12;
            // 
            // lstAlemaniaEntrenador
            // 
            lstAlemaniaEntrenador.FormattingEnabled = true;
            lstAlemaniaEntrenador.ItemHeight = 15;
            lstAlemaniaEntrenador.Location = new Point(349, 195);
            lstAlemaniaEntrenador.Name = "lstAlemaniaEntrenador";
            lstAlemaniaEntrenador.Size = new Size(538, 124);
            lstAlemaniaEntrenador.TabIndex = 13;
            // 
            // lstFranciaEntrenador
            // 
            lstFranciaEntrenador.FormattingEnabled = true;
            lstFranciaEntrenador.ItemHeight = 15;
            lstFranciaEntrenador.Location = new Point(349, 195);
            lstFranciaEntrenador.Name = "lstFranciaEntrenador";
            lstFranciaEntrenador.Size = new Size(538, 124);
            lstFranciaEntrenador.TabIndex = 14;
            // 
            // lstBrasilEntrenador
            // 
            lstBrasilEntrenador.FormattingEnabled = true;
            lstBrasilEntrenador.ItemHeight = 15;
            lstBrasilEntrenador.Location = new Point(349, 195);
            lstBrasilEntrenador.Name = "lstBrasilEntrenador";
            lstBrasilEntrenador.Size = new Size(538, 124);
            lstBrasilEntrenador.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(766, 325);
            label4.Name = "label4";
            label4.Size = new Size(121, 24);
            label4.TabIndex = 16;
            label4.Text = "Masajeadores";
            // 
            // lstArgentinaMasajeador
            // 
            lstArgentinaMasajeador.FormattingEnabled = true;
            lstArgentinaMasajeador.ItemHeight = 15;
            lstArgentinaMasajeador.Location = new Point(349, 352);
            lstArgentinaMasajeador.Name = "lstArgentinaMasajeador";
            lstArgentinaMasajeador.Size = new Size(538, 124);
            lstArgentinaMasajeador.TabIndex = 17;
            // 
            // lstBrasilMasajeador
            // 
            lstBrasilMasajeador.FormattingEnabled = true;
            lstBrasilMasajeador.ItemHeight = 15;
            lstBrasilMasajeador.Location = new Point(349, 352);
            lstBrasilMasajeador.Name = "lstBrasilMasajeador";
            lstBrasilMasajeador.Size = new Size(538, 124);
            lstBrasilMasajeador.TabIndex = 18;
            // 
            // lstFranciaMasajeador
            // 
            lstFranciaMasajeador.FormattingEnabled = true;
            lstFranciaMasajeador.ItemHeight = 15;
            lstFranciaMasajeador.Location = new Point(349, 352);
            lstFranciaMasajeador.Name = "lstFranciaMasajeador";
            lstFranciaMasajeador.Size = new Size(538, 124);
            lstFranciaMasajeador.TabIndex = 19;
            // 
            // lstItaliaMasajeador
            // 
            lstItaliaMasajeador.FormattingEnabled = true;
            lstItaliaMasajeador.ItemHeight = 15;
            lstItaliaMasajeador.Location = new Point(349, 352);
            lstItaliaMasajeador.Name = "lstItaliaMasajeador";
            lstItaliaMasajeador.Size = new Size(538, 124);
            lstItaliaMasajeador.TabIndex = 20;
            // 
            // lstAlemaniaMasajeador
            // 
            lstAlemaniaMasajeador.FormattingEnabled = true;
            lstAlemaniaMasajeador.ItemHeight = 15;
            lstAlemaniaMasajeador.Location = new Point(349, 352);
            lstAlemaniaMasajeador.Name = "lstAlemaniaMasajeador";
            lstAlemaniaMasajeador.Size = new Size(538, 124);
            lstAlemaniaMasajeador.TabIndex = 21;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.ActiveCaptionText;
            btnEliminar.Location = new Point(77, 179);
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
            label5.Location = new Point(0, 152);
            label5.Name = "label5";
            label5.Size = new Size(275, 24);
            label5.TabIndex = 23;
            label5.Text = "Convocar Personal a la Seleccion";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Small", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 293);
            label6.Name = "label6";
            label6.Size = new Size(243, 24);
            label6.TabIndex = 24;
            label6.Text = "Modificar datos del personal";
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.ForeColor = SystemColors.ActiveCaptionText;
            btnModificar.Location = new Point(77, 320);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(152, 58);
            btnModificar.TabIndex = 25;
            btnModificar.Text = "Modificar Personal";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // pctArgentina
            // 
            pctArgentina.Image = (Image)resources.GetObject("pctArgentina.Image");
            pctArgentina.Location = new Point(907, 12);
            pctArgentina.Name = "pctArgentina";
            pctArgentina.Size = new Size(164, 182);
            pctArgentina.SizeMode = PictureBoxSizeMode.StretchImage;
            pctArgentina.TabIndex = 26;
            pctArgentina.TabStop = false;
            // 
            // pctItalia
            // 
            pctItalia.Image = (Image)resources.GetObject("pctItalia.Image");
            pctItalia.Location = new Point(907, 12);
            pctItalia.Name = "pctItalia";
            pctItalia.Size = new Size(131, 182);
            pctItalia.SizeMode = PictureBoxSizeMode.StretchImage;
            pctItalia.TabIndex = 27;
            pctItalia.TabStop = false;
            // 
            // pctBrasil
            // 
            pctBrasil.Image = (Image)resources.GetObject("pctBrasil.Image");
            pctBrasil.Location = new Point(907, 12);
            pctBrasil.Name = "pctBrasil";
            pctBrasil.Size = new Size(164, 182);
            pctBrasil.SizeMode = PictureBoxSizeMode.StretchImage;
            pctBrasil.TabIndex = 28;
            pctBrasil.TabStop = false;
            // 
            // pctAlemania
            // 
            pctAlemania.Image = (Image)resources.GetObject("pctAlemania.Image");
            pctAlemania.Location = new Point(907, 12);
            pctAlemania.Name = "pctAlemania";
            pctAlemania.Size = new Size(164, 182);
            pctAlemania.SizeMode = PictureBoxSizeMode.StretchImage;
            pctAlemania.TabIndex = 29;
            pctAlemania.TabStop = false;
            // 
            // pctFrancia
            // 
            pctFrancia.Image = (Image)resources.GetObject("pctFrancia.Image");
            pctFrancia.Location = new Point(907, 12);
            pctFrancia.Name = "pctFrancia";
            pctFrancia.Size = new Size(164, 195);
            pctFrancia.SizeMode = PictureBoxSizeMode.StretchImage;
            pctFrancia.TabIndex = 30;
            pctFrancia.TabStop = false;
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
            groupBox2.Location = new Point(12, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(302, 445);
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
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 615);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label9);
            Controls.Add(groupBox1);
            Controls.Add(pctFrancia);
            Controls.Add(pctAlemania);
            Controls.Add(pctBrasil);
            Controls.Add(pctItalia);
            Controls.Add(pctArgentina);
            Controls.Add(lstAlemaniaMasajeador);
            Controls.Add(lstItaliaMasajeador);
            Controls.Add(lstFranciaMasajeador);
            Controls.Add(lstBrasilMasajeador);
            Controls.Add(lstArgentinaMasajeador);
            Controls.Add(label4);
            Controls.Add(lstFranciaEntrenador);
            Controls.Add(lstBrasilEntrenador);
            Controls.Add(lstAlemaniaEntrenador);
            Controls.Add(lstItaliaEntrenador);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lstArgentinaEntrenador);
            Controls.Add(cmbPaises);
            Controls.Add(lstFrancia);
            Controls.Add(lstBrasil);
            Controls.Add(lstItalia);
            Controls.Add(lstAlemania);
            Controls.Add(lstArgentina);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            FormClosing += FormPrincipal_FormClosing;
            Load += FormPrincipal_Load;
            Click += FormPrincipal_Click;
            ((System.ComponentModel.ISupportInitialize)pctArgentina).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctItalia).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctBrasil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctAlemania).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctFrancia).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
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
        private ComboBox cmbPaises;
        private ListBox lstArgentinaEntrenador;
        private Label label2;
        private Label label3;
        private ListBox lstItaliaEntrenador;
        private ListBox lstAlemaniaEntrenador;
        private ListBox lstFranciaEntrenador;
        private ListBox lstBrasilEntrenador;
        private Label label4;
        private ListBox lstArgentinaMasajeador;
        private ListBox lstBrasilMasajeador;
        private ListBox lstFranciaMasajeador;
        private ListBox lstItaliaMasajeador;
        private ListBox lstAlemaniaMasajeador;
        private Button btnEliminar;
        private Label label5;
        private Label label6;
        private Button btnModificar;
        private PictureBox pctArgentina;
        private PictureBox pctItalia;
        private PictureBox pctBrasil;
        private PictureBox pctAlemania;
        private PictureBox pctFrancia;
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
    }
}