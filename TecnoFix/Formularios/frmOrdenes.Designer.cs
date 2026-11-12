namespace TecnoFix.Formularios
{
    partial class frmOrdenes
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
            this.lblEquipo = new System.Windows.Forms.Label();
            this.cboEquipo = new System.Windows.Forms.ComboBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblFalla = new System.Windows.Forms.Label();
            this.txtFalla = new System.Windows.Forms.TextBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
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
            this.lblTitulo.Text = "Ordenes de servicio";
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
            this.cboCliente.Size = new System.Drawing.Size(250, 24);
            this.cboCliente.TabIndex = 2;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            //
            // lblEquipo
            //
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(20, 113);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(60, 17);
            this.lblEquipo.TabIndex = 3;
            this.lblEquipo.Text = "Equipo";
            //
            // cboEquipo
            //
            this.cboEquipo.Location = new System.Drawing.Point(110, 110);
            this.cboEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(250, 24);
            this.cboEquipo.TabIndex = 4;
            //
            // lblTecnico
            //
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Location = new System.Drawing.Point(20, 153);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(60, 17);
            this.lblTecnico.TabIndex = 5;
            this.lblTecnico.Text = "Tecnico";
            //
            // cboTecnico
            //
            this.cboTecnico.Location = new System.Drawing.Point(110, 150);
            this.cboTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(250, 24);
            this.cboTecnico.TabIndex = 6;
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 193);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(60, 17);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            //
            // cboEstado
            //
            this.cboEstado.Location = new System.Drawing.Point(110, 190);
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(250, 24);
            this.cboEstado.TabIndex = 8;
            //
            // lblFalla
            //
            this.lblFalla.AutoSize = true;
            this.lblFalla.Location = new System.Drawing.Point(20, 233);
            this.lblFalla.Name = "lblFalla";
            this.lblFalla.Size = new System.Drawing.Size(60, 17);
            this.lblFalla.TabIndex = 9;
            this.lblFalla.Text = "Falla";
            //
            // txtFalla
            //
            this.txtFalla.Location = new System.Drawing.Point(110, 230);
            this.txtFalla.MaxLength = 300;
            this.txtFalla.Multiline = true;
            this.txtFalla.Name = "txtFalla";
            this.txtFalla.Size = new System.Drawing.Size(250, 22);
            this.txtFalla.TabIndex = 10;
            //
            // lblDiagnostico
            //
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(20, 313);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(60, 17);
            this.lblDiagnostico.TabIndex = 11;
            this.lblDiagnostico.Text = "Diagnostico";
            //
            // txtDiagnostico
            //
            this.txtDiagnostico.Location = new System.Drawing.Point(110, 310);
            this.txtDiagnostico.MaxLength = 300;
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(250, 22);
            this.txtDiagnostico.TabIndex = 12;
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(20, 400);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnNuevo
            //
            this.btnNuevo.Location = new System.Drawing.Point(130, 400);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.Location = new System.Drawing.Point(240, 400);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 34);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            //
            // lblFiltro
            //
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(400, 25);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(60, 17);
            this.lblFiltro.TabIndex = 16;
            this.lblFiltro.Text = "Filtrar por estado";
            //
            // cboFiltro
            //
            this.cboFiltro.Location = new System.Drawing.Point(540, 22);
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(200, 24);
            this.cboFiltro.TabIndex = 17;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            //
            // dgvOrdenes
            //
            this.dgvOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(400, 70);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.RowHeadersWidth = 51;
            this.dgvOrdenes.RowTemplate.Height = 24;
            this.dgvOrdenes.Size = new System.Drawing.Size(780, 530);
            this.dgvOrdenes.TabIndex = 18;
            this.dgvOrdenes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellDoubleClick);
            //
            // frmOrdenes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 620);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.cboEquipo);
            this.Controls.Add(this.lblTecnico);
            this.Controls.Add(this.cboTecnico);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.lblFalla);
            this.Controls.Add(this.txtFalla);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.dgvOrdenes);
            this.Name = "frmOrdenes";
            this.Text = "Ordenes de servicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOrdenes_FormClosed);
            this.Load += new System.EventHandler(this.frmOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cboEquipo;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblFalla;
        private System.Windows.Forms.TextBox txtFalla;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.DataGridView dgvOrdenes;
    }
}
