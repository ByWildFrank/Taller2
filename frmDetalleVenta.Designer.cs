namespace BeanDesktop
{
    partial class frmDetalleVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.btnBuscarVenta = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.txtIdVenta = new System.Windows.Forms.TextBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.lblNumeroDocMostrar = new System.Windows.Forms.Label();
            this.txtNumeroDocumentoMostrar = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblDocumentoCliente = new System.Windows.Forms.Label();
            this.txtDocumentoCliente = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 20);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(121, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Número de documento:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumeroDocumento.Location = new System.Drawing.Point(150, 17);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(180, 23);
            this.txtNumeroDocumento.TabIndex = 1;
            // 
            // btnBuscarVenta
            // 
            this.btnBuscarVenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscarVenta.Location = new System.Drawing.Point(340, 15);
            this.btnBuscarVenta.Name = "btnBuscarVenta";
            this.btnBuscarVenta.Size = new System.Drawing.Size(90, 27);
            this.btnBuscarVenta.TabIndex = 2;
            this.btnBuscarVenta.Text = "Buscar";
            this.btnBuscarVenta.UseVisualStyleBackColor = true;
            this.btnBuscarVenta.Click += new System.EventHandler(this.btnBuscarVenta_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.Location = new System.Drawing.Point(440, 15);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 27);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler((s, e) => LimpiarCampos());
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            this.dgvDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                | System.Windows.Forms.AnchorStyles.Left)
                                                                                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(20, 210);
            this.dgvDetalleVenta.MultiSelect = false;
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ReadOnly = true;
            this.dgvDetalleVenta.RowTemplate.Height = 25;
            this.dgvDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(820, 340);
            this.dgvDetalleVenta.TabIndex = 4;
            this.dgvDetalleVenta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellDoubleClick);
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdVenta.Location = new System.Drawing.Point(20, 60);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(55, 15);
            this.lblIdVenta.TabIndex = 5;
            this.lblIdVenta.Text = "ID Venta:";
            // 
            // txtIdVenta
            // 
            this.txtIdVenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdVenta.Location = new System.Drawing.Point(150, 57);
            this.txtIdVenta.Name = "txtIdVenta";
            this.txtIdVenta.ReadOnly = true;
            this.txtIdVenta.Size = new System.Drawing.Size(100, 23);
            this.txtIdVenta.TabIndex = 6;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoDocumento.Location = new System.Drawing.Point(270, 60);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(106, 15);
            this.lblTipoDocumento.TabIndex = 7;
            this.lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTipoDocumento.Location = new System.Drawing.Point(380, 57);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(150, 23);
            this.txtTipoDocumento.TabIndex = 8;
            // 
            // lblNumeroDocMostrar
            // 
            this.lblNumeroDocMostrar.AutoSize = true;
            this.lblNumeroDocMostrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroDocMostrar.Location = new System.Drawing.Point(550, 60);
            this.lblNumeroDocMostrar.Name = "lblNumeroDocMostrar";
            this.lblNumeroDocMostrar.Size = new System.Drawing.Size(94, 15);
            this.lblNumeroDocMostrar.TabIndex = 9;
            this.lblNumeroDocMostrar.Text = "N° Documento:";
            // 
            // txtNumeroDocumentoMostrar
            // 
            this.txtNumeroDocumentoMostrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumeroDocumentoMostrar.Location = new System.Drawing.Point(650, 57);
            this.txtNumeroDocumentoMostrar.Name = "txtNumeroDocumentoMostrar";
            this.txtNumeroDocumentoMostrar.ReadOnly = true;
            this.txtNumeroDocumentoMostrar.Size = new System.Drawing.Size(150, 23);
            this.txtNumeroDocumentoMostrar.TabIndex = 10;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.Location = new System.Drawing.Point(20, 100);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 15);
            this.lblCliente.TabIndex = 11;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCliente.Location = new System.Drawing.Point(150, 97);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(280, 23);
            this.txtCliente.TabIndex = 12;
            // 
            // lblDocumentoCliente
            // 
            this.lblDocumentoCliente.AutoSize = true;
            this.lblDocumentoCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDocumentoCliente.Location = new System.Drawing.Point(450, 100);
            this.lblDocumentoCliente.Name = "lblDocumentoCliente";
            this.lblDocumentoCliente.Size = new System.Drawing.Size(118, 15);
            this.lblDocumentoCliente.TabIndex = 13;
            this.lblDocumentoCliente.Text = "Documento (cliente):";
            // 
            // txtDocumentoCliente
            // 
            this.txtDocumentoCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDocumentoCliente.Location = new System.Drawing.Point(580, 97);
            this.txtDocumentoCliente.Name = "txtDocumentoCliente";
            this.txtDocumentoCliente.ReadOnly = true;
            this.txtDocumentoCliente.Size = new System.Drawing.Size(220, 23);
            this.txtDocumentoCliente.TabIndex = 14;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescuento.Location = new System.Drawing.Point(20, 140);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(69, 15);
            this.lblDescuento.TabIndex = 15;
            this.lblDescuento.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescuento.Location = new System.Drawing.Point(150, 137);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(100, 23);
            this.txtDescuento.TabIndex = 16;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoTotal.Location = new System.Drawing.Point(270, 140);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(74, 15);
            this.lblMontoTotal.TabIndex = 17;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontoTotal.Location = new System.Drawing.Point(350, 137);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(120, 23);
            this.txtMontoTotal.TabIndex = 18;
            // 
            // frmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 570);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.txtDocumentoCliente);
            this.Controls.Add(this.lblDocumentoCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtNumeroDocumentoMostrar);
            this.Controls.Add(this.lblNumeroDocMostrar);
            this.Controls.Add(this.txtTipoDocumento);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.txtIdVenta);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscarVenta);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.lblBuscar);
            this.Name = "frmDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Ventas";
            this.Load += new System.EventHandler(this.frmDetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Button btnBuscarVenta;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Label lblIdVenta;
        private System.Windows.Forms.TextBox txtIdVenta;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Label lblNumeroDocMostrar;
        private System.Windows.Forms.TextBox txtNumeroDocumentoMostrar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
    }
}
