namespace FormSelecciones
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            Correo = new Label();
            label1 = new Label();
            btnIniciarSesion = new Button();
            lblMostrar = new Label();
            lblOcultar = new Label();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(86, 56);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(172, 23);
            txtCorreo.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(86, 129);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(172, 23);
            txtContraseña.TabIndex = 1;
            // 
            // Correo
            // 
            Correo.AutoSize = true;
            Correo.Location = new Point(44, 38);
            Correo.Name = "Correo";
            Correo.Size = new Size(43, 15);
            Correo.TabIndex = 2;
            Correo.Text = "Correo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 111);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 3;
            label1.Text = "Contraseña";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(95, 199);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(148, 49);
            btnIniciarSesion.TabIndex = 4;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // lblMostrar
            // 
            lblMostrar.AutoSize = true;
            lblMostrar.BackColor = SystemColors.ButtonHighlight;
            lblMostrar.Location = new Point(262, 132);
            lblMostrar.Name = "lblMostrar";
            lblMostrar.Size = new Size(48, 15);
            lblMostrar.TabIndex = 10;
            lblMostrar.Text = "Mostrar";
            lblMostrar.Click += lblMostrar_Click;
            // 
            // lblOcultar
            // 
            lblOcultar.AutoSize = true;
            lblOcultar.BackColor = SystemColors.ButtonHighlight;
            lblOcultar.Location = new Point(264, 132);
            lblOcultar.Name = "lblOcultar";
            lblOcultar.Size = new Size(46, 15);
            lblOcultar.TabIndex = 11;
            lblOcultar.Text = "Ocultar";
            lblOcultar.Click += lblOcultar_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 296);
            Controls.Add(lblMostrar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(label1);
            Controls.Add(Correo);
            Controls.Add(txtCorreo);
            Controls.Add(txtContraseña);
            Controls.Add(lblOcultar);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private Label Correo;
        private Label label1;
        private Button btnIniciarSesion;
        private Label lblMostrar;
        private Label lblOcultar;
    }
}