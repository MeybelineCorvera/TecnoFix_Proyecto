namespace TecnoFix.Formularios
{
    partial class frmEquipos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(60, 17);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de equipos";
            //
            // lblCliente
            //
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 73);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente";
            //
            // cboCliente
            //
            this.cboCliente.Location = new System.Drawing.Point(110, 70);
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(230, 24);
            this.cboCliente.TabIndex = 2;
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 113);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(60, 17);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo";
            //
            // cboTipo
            //
            this.cboTipo.Location = new System.Drawing.Point(110, 110);
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Laptop",
            "Computadora de escritorio",
            "Impresora",
            "All in one",
            "Monitor",
            "Otro"});
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(230, 24);
            this.cboTipo.TabIndex = 4;
            //
            // lblMarca
            //
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(20, 153);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(60, 17);
            this.lblMarca.TabIndex = 5;
            this.lblMarca.Text = "Marca";
            //
            // txtMarca
            //
            this.txtMarca.Location = new System.Drawing.Point(110, 150);
            this.txtMarca.MaxLength = 50;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(230, 22);
            this.txtMarca.TabIndex = 6;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            //
            // lblModelo
            //
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(20, 193);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(60, 17);
            this.lblModelo.TabIndex = 7;
            this.lblModelo.Text = "Modelo";
            //
            // txtModelo
            //
            this.txtModelo.Location = new System.Drawing.Point(110, 190);
            this.txtModelo.MaxLength = 50;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(230, 22);
            this.txtModelo.TabIndex = 8;
            this.txtModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelo_KeyPress);
            //
            // lblSerie
            //
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(20, 233);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(60, 17);
            this.lblSerie.TabIndex = 9;
            this.lblSerie.Text = "Serie";
            //
            // txtSerie
            //
            this.txtSerie.Location = new System.Drawing.Point(110, 230);
            this.txtSerie.MaxLength = 50;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(230, 22);
            this.txtSerie.TabIndex = 10;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(20, 285);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnNuevo
            //
            this.btnNuevo.Location = new System.Drawing.Point(130, 285);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.Location = new System.Drawing.Point(240, 285);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 34);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            //
            // dgvEquipos
            //
            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Location = new System.Drawing.Point(370, 70);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.RowHeadersWidth = 51;
            this.dgvEquipos.RowTemplate.Height = 24;
            this.dgvEquipos.Size = new System.Drawing.Size(510, 430);
            this.dgvEquipos.TabIndex = 14;
            this.dgvEquipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellDoubleClick);
            //
            // frmEquipos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvEquipos);
            this.Name = "frmEquipos";
            this.Text = "Equipos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEquipos_FormClosed);
            this.Load += new System.EventHandler(this.frmEquipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvEquipos;
    }
}
