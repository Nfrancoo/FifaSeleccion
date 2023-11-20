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
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            lblHoraActual = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(84, 98);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(172, 23);
            txtCorreo.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(84, 170);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(172, 23);
            txtContraseña.TabIndex = 1;
            // 
            // Correo
            // 
            Correo.AutoSize = true;
            Correo.Location = new Point(34, 79);
            Correo.Name = "Correo";
            Correo.Size = new Size(43, 15);
            Correo.TabIndex = 2;
            Correo.Text = "Correo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 146);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 3;
            label1.Text = "Contraseña";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(104, 199);
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
            lblMostrar.Location = new Point(271, 175);
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
            lblOcultar.Location = new Point(273, 174);
            lblOcultar.Name = "lblOcultar";
            lblOcultar.Size = new Size(46, 15);
            lblOcultar.TabIndex = 11;
            lblOcultar.Text = "Ocultar";
            lblOcultar.Click += lblOcultar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.klipartz_com;
            pictureBox1.Location = new Point(349, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 210);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(105, 258);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(132, 15);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "¿Perdiste la contraseña?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(52, 27);
            label2.Name = "label2";
            label2.Size = new Size(551, 28);
            label2.TabIndex = 14;
            label2.Text = "Fédération Internationale de Football Association";
            label2.Click += label2_Click;
            // 
            // lblHoraActual
            // 
            lblHoraActual.AutoSize = true;
            lblHoraActual.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHoraActual.Location = new Point(557, 318);
            lblHoraActual.Name = "lblHoraActual";
            lblHoraActual.Size = new Size(0, 21);
            lblHoraActual.TabIndex = 15;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 347);
            Controls.Add(lblHoraActual);
            Controls.Add(label2);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label lblHoraActual;
    }
}