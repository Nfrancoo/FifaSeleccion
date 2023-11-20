namespace FormSelecciones
{
    partial class RecuperarContraseña
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
            txtCorreo = new TextBox();
            Correo = new Label();
            btnRecuperarContraseña = new Button();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(59, 103);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(172, 23);
            txtCorreo.TabIndex = 1;
            // 
            // Correo
            // 
            Correo.AutoSize = true;
            Correo.Location = new Point(21, 73);
            Correo.Name = "Correo";
            Correo.Size = new Size(93, 15);
            Correo.TabIndex = 3;
            Correo.Text = "Ponga su correo";
            // 
            // btnRecuperarContraseña
            // 
            btnRecuperarContraseña.Location = new Point(73, 145);
            btnRecuperarContraseña.Name = "btnRecuperarContraseña";
            btnRecuperarContraseña.Size = new Size(148, 49);
            btnRecuperarContraseña.TabIndex = 5;
            btnRecuperarContraseña.Text = "Recuperar Contraseña";
            btnRecuperarContraseña.UseVisualStyleBackColor = true;
            btnRecuperarContraseña.Click += btnRecuperarContraseña_Click;
            // 
            // RecuperarContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 299);
            Controls.Add(btnRecuperarContraseña);
            Controls.Add(Correo);
            Controls.Add(txtCorreo);
            Name = "RecuperarContraseña";
            Text = "RecuperarContraseña";
            Load += RecuperarContraseña_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCorreo;
        private Label Correo;
        private Button btnRecuperarContraseña;
    }
}