namespace FormSelecciones
{
    partial class Personal
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
            btnJugador = new Button();
            btnEntrenador = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnJugador
            // 
            btnJugador.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnJugador.Location = new Point(35, 12);
            btnJugador.Name = "btnJugador";
            btnJugador.Size = new Size(144, 57);
            btnJugador.TabIndex = 0;
            btnJugador.Text = "Convocar Jugador";
            btnJugador.UseVisualStyleBackColor = true;
            btnJugador.Click += btnJugador_Click;
            // 
            // btnEntrenador
            // 
            btnEntrenador.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnEntrenador.Location = new Point(35, 105);
            btnEntrenador.Name = "btnEntrenador";
            btnEntrenador.Size = new Size(144, 57);
            btnEntrenador.TabIndex = 1;
            btnEntrenador.Text = "Agregar Entrenador";
            btnEntrenador.UseVisualStyleBackColor = true;
            btnEntrenador.Click += btnEntrenador_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button2.Location = new Point(35, 197);
            button2.Name = "button2";
            button2.Size = new Size(144, 57);
            button2.TabIndex = 2;
            button2.Text = "Llamar Masajista";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Personal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(214, 266);
            Controls.Add(button2);
            Controls.Add(btnEntrenador);
            Controls.Add(btnJugador);
            Name = "Personal";
            Text = "Convocar";
            ResumeLayout(false);
        }

        #endregion

        private Button btnJugador;
        private Button btnEntrenador;
        private Button button2;
    }
}