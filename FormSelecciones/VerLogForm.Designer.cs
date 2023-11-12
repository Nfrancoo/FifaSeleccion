namespace FormSelecciones
{
    partial class VerLogForm
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
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(12, 12);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(463, 274);
            lstLog.TabIndex = 0;
            // 
            // VerLogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 307);
            Controls.Add(lstLog);
            Name = "VerLogForm";
            Text = "VerLogForm";
            Load += VerLogForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstLog;
    }
}