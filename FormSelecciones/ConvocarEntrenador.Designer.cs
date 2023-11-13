namespace FormSelecciones
{
    partial class ConvocarEntrenador
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
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtTactica = new TextBox();
            txtEdad = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblNombre = new Label();
            cmbPaises = new ComboBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(166, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 70);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.Location = new Point(12, 322);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(141, 70);
            btnAceptar.TabIndex = 33;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtTactica
            // 
            txtTactica.Location = new Point(33, 264);
            txtTactica.Name = "txtTactica";
            txtTactica.Size = new Size(240, 23);
            txtTactica.TabIndex = 31;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(33, 148);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(240, 23);
            txtEdad.TabIndex = 29;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(33, 90);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(240, 23);
            txtApellido.TabIndex = 28;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(33, 36);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 23);
            txtNombre.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 304);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(33, 241);
            label6.Name = "label6";
            label6.Size = new Size(157, 20);
            label6.TabIndex = 24;
            label6.Text = "Tactica a implementar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(33, 125);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 23;
            label5.Text = "Edad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(33, 180);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 22;
            label4.Text = "Pais";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 67);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 21;
            label1.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(127, 208);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 62);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 19;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(33, 13);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 18;
            lblNombre.Text = "Nombre";
            // 
            // cmbPaises
            // 
            cmbPaises.Items.AddRange(new object[] { "Italia", "Francia", "Brasil", "Argentina", "Alemania" });
            cmbPaises.Location = new Point(33, 203);
            cmbPaises.Name = "cmbPaises";
            cmbPaises.Size = new Size(240, 23);
            cmbPaises.TabIndex = 36;
            // 
            // ConvocarEntrenador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 422);
            Controls.Add(cmbPaises);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtTactica);
            Controls.Add(txtEdad);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblNombre);
            Name = "ConvocarEntrenador";
            Text = "ConvocarEntrenador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtTactica;
        private TextBox txtEdad;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label lblNombre;
        private ComboBox cmbPaises;
    }
}