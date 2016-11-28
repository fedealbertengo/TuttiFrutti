namespace CPresentacion.Pantallas
{
    partial class Lobby
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
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbLlenas = new System.Windows.Forms.CheckBox();
            this.cbVacias = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tbNombreSala = new System.Windows.Forms.TextBox();
            this.tbProp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalas
            // 
            this.dgvSalas.AllowUserToAddRows = false;
            this.dgvSalas.AllowUserToDeleteRows = false;
            this.dgvSalas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalas.Location = new System.Drawing.Point(12, 97);
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.ReadOnly = true;
            this.dgvSalas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalas.Size = new System.Drawing.Size(561, 168);
            this.dgvSalas.TabIndex = 0;
            this.dgvSalas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSalas_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.tbNombreSala);
            this.panel1.Controls.Add(this.tbProp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 79);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbLlenas);
            this.panel2.Controls.Add(this.cbVacias);
            this.panel2.Location = new System.Drawing.Point(362, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 64);
            this.panel2.TabIndex = 6;
            // 
            // cbLlenas
            // 
            this.cbLlenas.AutoSize = true;
            this.cbLlenas.Location = new System.Drawing.Point(18, 35);
            this.cbLlenas.Name = "cbLlenas";
            this.cbLlenas.Size = new System.Drawing.Size(70, 17);
            this.cbLlenas.TabIndex = 7;
            this.cbLlenas.Text = "No llenas";
            this.cbLlenas.UseVisualStyleBackColor = true;
            // 
            // cbVacias
            // 
            this.cbVacias.AutoSize = true;
            this.cbVacias.Location = new System.Drawing.Point(18, 12);
            this.cbVacias.Name = "cbVacias";
            this.cbVacias.Size = new System.Drawing.Size(60, 17);
            this.cbVacias.TabIndex = 6;
            this.cbVacias.Text = "Vacías";
            this.cbVacias.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(473, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tbNombreSala
            // 
            this.tbNombreSala.Location = new System.Drawing.Point(99, 46);
            this.tbNombreSala.Name = "tbNombreSala";
            this.tbNombreSala.Size = new System.Drawing.Size(231, 20);
            this.tbNombreSala.TabIndex = 3;
            // 
            // tbProp
            // 
            this.tbProp.Location = new System.Drawing.Point(99, 15);
            this.tbProp.Name = "tbProp";
            this.tbProp.Size = new System.Drawing.Size(144, 20);
            this.tbProp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NombreSala";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Propietario";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCrear);
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Location = new System.Drawing.Point(12, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(560, 49);
            this.panel3.TabIndex = 2;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(330, 13);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 1;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(133, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 329);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSalas);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Lobby_FormClosed);
            this.Load += new System.EventHandler(this.Lobby_Load);
            this.VisibleChanged += new System.EventHandler(this.Lobby_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbLlenas;
        private System.Windows.Forms.CheckBox cbVacias;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox tbNombreSala;
        private System.Windows.Forms.TextBox tbProp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEliminar;
    }
}