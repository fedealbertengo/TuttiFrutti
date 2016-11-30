namespace CPresentacion.Pantallas
{
    partial class Sala
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
            this.pnFotoUs1 = new System.Windows.Forms.Panel();
            this.pnUs1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnUs1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFotoUs1
            // 
            this.pnFotoUs1.BackColor = System.Drawing.Color.Black;
            this.pnFotoUs1.BackgroundImage = global::CPresentacion.Properties.Resources.Foto1;
            this.pnFotoUs1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnFotoUs1.ForeColor = System.Drawing.Color.Red;
            this.pnFotoUs1.Location = new System.Drawing.Point(5, 5);
            this.pnFotoUs1.Name = "pnFotoUs1";
            this.pnFotoUs1.Size = new System.Drawing.Size(100, 100);
            this.pnFotoUs1.TabIndex = 0;
            this.pnFotoUs1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnUs1
            // 
            this.pnUs1.BackColor = System.Drawing.Color.Red;
            this.pnUs1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnUs1.Controls.Add(this.pnFotoUs1);
            this.pnUs1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnUs1.ForeColor = System.Drawing.Color.White;
            this.pnUs1.Location = new System.Drawing.Point(50, 50);
            this.pnUs1.Name = "pnUs1";
            this.pnUs1.Size = new System.Drawing.Size(115, 133);
            this.pnUs1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 405);
            this.Controls.Add(this.pnUs1);
            this.Name = "Sala";
            this.Text = "Sala";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sala_FormClosed);
            this.Load += new System.EventHandler(this.Sala_Load);
            this.pnUs1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFotoUs1;
        private System.Windows.Forms.Panel pnUs1;
        private System.Windows.Forms.Timer timer1;
    }
}