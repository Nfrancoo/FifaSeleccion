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
            lblHoraActual = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(38, 82);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(172, 23);
            txtCorreo.TabIndex = 1;
            // 
            // Correo
            // 
            Correo.AutoSize = true;
            Correo.Location = new Point(12, 64);
            Correo.Name = "Correo";
            Correo.Size = new Size(93, 15);
            Correo.TabIndex = 3;
            Correo.Text = "Ponga su correo";
            // 
            // btnRecuperarContraseña
            // 
            btnRecuperarContraseña.Location = new Point(51, 111);
            btnRecuperarContraseña.Name = "btnRecuperarContraseña";
            btnRecuperarContraseña.Size = new Size(148, 49);
            btnRecuperarContraseña.TabIndex = 5;
            btnRecuperarContraseña.Text = "Recuperar Contraseña";
            btnRecuperarContraseña.UseVisualStyleBackColor = true;
            btnRecuperarContraseña.Click += btnRecuperarContraseña_Click;
            // 
            // lblHoraActual
            // 
            lblHoraActual.AutoSize = true;
            lblHoraActual.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHoraActual.Location = new Point(348, 269);
            lblHoraActual.Name = "lblHoraActual";
            lblHoraActual.Size = new Size(0, 21);
            lblHoraActual.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.fifa_logo;
            pictureBox1.Location = new Point(230, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(195, 156);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // RecuperarContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 299);
            Controls.Add(lblHoraActual);
            Controls.Add(btnRecuperarContraseña);
            Controls.Add(Correo);
            Controls.Add(txtCorreo);
            Controls.Add(pictureBox1);
            Name = "RecuperarContraseña";
            Text = "RecuperarContraseña";
            Load += RecuperarContraseña_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCorreo;
        private Label Correo;
        private Button btnRecuperarContraseña;
        private Label lblHoraActual;
        private PictureBox pictureBox1;
    }
}