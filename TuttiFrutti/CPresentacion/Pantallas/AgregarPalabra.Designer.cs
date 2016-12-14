namespace CPresentacion.Pantallas
{
    partial class AgregarPalabra
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
            this.btnAgregarPalabras = new System.Windows.Forms.Button();
            this.dgvPalabrasDudosas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabrasDudosas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarPalabras
            // 
            this.btnAgregarPalabras.Location = new System.Drawing.Point(196, 336);
            this.btnAgregarPalabras.Name = "btnAgregarPalabras";
            this.btnAgregarPalabras.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarPalabras.TabIndex = 1;
            this.btnAgregarPalabras.Text = "Aceptar";
            this.btnAgregarPalabras.UseVisualStyleBackColor = true;
            this.btnAgregarPalabras.Click += new System.EventHandler(this.btnAgregarPalabras_Click);
            // 
            // dgvPalabrasDudosas
            // 
            this.dgvPalabrasDudosas.AllowUserToAddRows = false;
            this.dgvPalabrasDudosas.AllowUserToDeleteRows = false;
            this.dgvPalabrasDudosas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPalabrasDudosas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabrasDudosas.Location = new System.Drawing.Point(12, 12);
            this.dgvPalabrasDudosas.Name = "dgvPalabrasDudosas";
            this.dgvPalabrasDudosas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPalabrasDudosas.Size = new System.Drawing.Size(460, 304);
            this.dgvPalabrasDudosas.TabIndex = 2;
            // 
            // AgregarPalabra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 371);
            this.Controls.Add(this.dgvPalabrasDudosas);
            this.Controls.Add(this.btnAgregarPalabras);
            this.Name = "AgregarPalabra";
            this.Text = "AgregarPalabra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AgregarPalabra_FormClosed);
            this.Load += new System.EventHandler(this.AgregarPalabra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabrasDudosas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAgregarPalabras;
        private System.Windows.Forms.DataGridView dgvPalabrasDudosas;
    }
}