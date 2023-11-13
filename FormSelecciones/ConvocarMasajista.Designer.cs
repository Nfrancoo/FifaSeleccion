namespace FormSelecciones
{
    partial class ConvocarMasajista
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
            txtNombre = new TextBox();
            label1 = new Label();
            txtApellido = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtEdad = new TextBox();
            label4 = new Label();
            txtTitulo = new TextBox();
            label5 = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            cmbPaises = new ComboBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(32, 63);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(255, 23);
            txtNombre.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 40);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 18;
            label1.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(32, 121);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(255, 23);
            txtApellido.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 98);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 20;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(32, 160);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 21;
            label3.Text = "Edad";
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(32, 183);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(255, 23);
            txtEdad.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(32, 223);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 18;
            label4.Text = "Pais";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(32, 307);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(255, 23);
            txtTitulo.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(30, 284);
            label5.Name = "label5";
            label5.Size = new Size(120, 20);
            label5.TabIndex = 25;
            label5.Text = "Lugar de Estudio";
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.Location = new Point(10, 364);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(141, 70);
            btnAceptar.TabIndex = 18;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(165, 364);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(141, 70);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbPaises
            // 
            cmbPaises.Items.AddRange(new object[] { "Italia", "Francia", "Brasil", "Argentina", "Alemania" });
            cmbPaises.Location = new Point(32, 246);
            cmbPaises.Name = "cmbPaises";
            cmbPaises.Size = new Size(255, 23);
            cmbPaises.TabIndex = 36;
            // 
            // ConvocarMasajista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 468);
            Controls.Add(cmbPaises);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label5);
            Controls.Add(txtTitulo);
            Controls.Add(label4);
            Controls.Add(txtEdad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtApellido);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Name = "ConvocarMasajista";
            Text = "Convocar Masajista";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label label1;
        private TextBox txtApellido;
        private Label label2;
        private Label label3;
        private TextBox txtEdad;
        private Label label4;
        private TextBox txtTitulo;
        private Label label5;
        private Button btnAceptar;
        private Button btnCancelar;
        private ComboBox cmbPaises;
    }
}