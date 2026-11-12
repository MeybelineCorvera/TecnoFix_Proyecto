namespace TecnoFix.Formularios
{
    partial class frmUsuarios
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
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
            this.lblTitulo.Text = "Usuarios del sistema";
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(20, 73);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            this.txtUsuario.Location = new System.Drawing.Point(110, 70);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(230, 22);
            this.txtUsuario.TabIndex = 2;
            //
            // lblClave
            //
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(20, 113);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(60, 17);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave";
            //
            // txtClave
            //
            this.txtClave.Location = new System.Drawing.Point(110, 110);
            this.txtClave.MaxLength = 50;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(230, 22);
            this.txtClave.TabIndex = 4;
            //
            // lblRol
            //
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(20, 153);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(60, 17);
            this.lblRol.TabIndex = 5;
            this.lblRol.Text = "Rol";
            //
            // cboRol
            //
            this.cboRol.Location = new System.Drawing.Point(110, 150);
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Items.AddRange(new object[] {
            "Administrador",
            "Tecnico"});
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(230, 24);
            this.cboRol.TabIndex = 6;
            //
            // lblNota
            //
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(20, 195);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(60, 17);
            this.lblNota.TabIndex = 7;
            this.lblNota.Text = "Al editar, deje la clave vacia para conservarla.";
            //
            // btnGuardar
            //
            this.btnGuardar.Location = new System.Drawing.Point(20, 235);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 34);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnNuevo
            //
            this.btnNuevo.Location = new System.Drawing.Point(130, 235);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.Location = new System.Drawing.Point(240, 235);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 34);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            //
            // dgvUsuarios
            //
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(370, 70);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.Size = new System.Drawing.Size(510, 430);
            this.dgvUsuarios.TabIndex = 11;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            //
            // frmUsuarios
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cboRol);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}
