namespace enumerator
{
    partial class form_console
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
            this.components = new System.ComponentModel.Container();
            this.textbox_console = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textbox_console
            // 
            this.textbox_console.BackColor = System.Drawing.Color.Black;
            this.textbox_console.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_console.ForeColor = System.Drawing.SystemColors.Info;
            this.textbox_console.Location = new System.Drawing.Point(0, 0);
            this.textbox_console.Margin = new System.Windows.Forms.Padding(0);
            this.textbox_console.Multiline = true;
            this.textbox_console.Name = "textbox_console";
            this.textbox_console.ReadOnly = true;
            this.textbox_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox_console.Size = new System.Drawing.Size(659, 316);
            this.textbox_console.TabIndex = 0;
            this.textbox_console.TextChanged += new System.EventHandler(this.textbox_console_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // form_console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 328);
            this.Controls.Add(this.textbox_console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(675, 350);
            this.Name = "form_console";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Консоль";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_console_FormClosing);
            this.Load += new System.EventHandler(this.form_console_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_console;
        private System.Windows.Forms.Timer timer1;
    }
}