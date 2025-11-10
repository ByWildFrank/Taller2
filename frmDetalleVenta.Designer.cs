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
            lblBuscar = new Label();
            txtNumeroDocumento = new TextBox();
            btnBuscarVenta = new Button();
            btnLimpiar = new Button();
            dgvDetalleVenta = new DataGridView();
            lblIdVenta = new Label();
            txtIdVenta = new TextBox();
            lblTipoDocumento = new Label();
            txtTipoDocumento = new TextBox();
            lblNumeroDocMostrar = new Label();
            txtNumeroDocumentoMostrar = new TextBox();
            lblCliente = new Label();
            txtCliente = new TextBox();
            lblDocumentoCliente = new Label();
            txtDocumentoCliente = new TextBox();
            lblDescuento = new Label();
            txtDescuento = new TextBox();
            lblMontoTotal = new Label();
            txtMontoTotal = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F);
            lblBuscar.Location = new Point(38, 33);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(135, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Número de documento:";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Font = new Font("Segoe UI", 9F);
            txtNumeroDocumento.Location = new Point(183, 31);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Size = new Size(180, 23);
            txtNumeroDocumento.TabIndex = 1;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarVenta.Location = new Point(383, 27);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(90, 27);
            btnBuscarVenta.TabIndex = 2;
            btnBuscarVenta.Text = "Buscar";
            btnBuscarVenta.UseVisualStyleBackColor = true;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 9F);
            btnLimpiar.Location = new Point(478, 27);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 27);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.BackgroundColor = Color.White;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(20, 210);
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.RowHeadersWidth = 51;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.Size = new Size(1094, 531);
            dgvDetalleVenta.TabIndex = 4;
            dgvDetalleVenta.CellDoubleClick += dgvDetalleVenta_CellDoubleClick;
            // 
            // lblIdVenta
            // 
            lblIdVenta.AutoSize = true;
            lblIdVenta.Font = new Font("Segoe UI", 9F);
            lblIdVenta.Location = new Point(38, 73);
            lblIdVenta.Name = "lblIdVenta";
            lblIdVenta.Size = new Size(53, 15);
            lblIdVenta.TabIndex = 5;
            lblIdVenta.Text = "ID Venta:";
            // 
            // txtIdVenta
            // 
            txtIdVenta.Font = new Font("Segoe UI", 9F);
            txtIdVenta.Location = new Point(168, 70);
            txtIdVenta.Name = "txtIdVenta";
            txtIdVenta.ReadOnly = true;
            txtIdVenta.Size = new Size(100, 23);
            txtIdVenta.TabIndex = 6;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Font = new Font("Segoe UI", 9F);
            lblTipoDocumento.Location = new Point(288, 73);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(114, 15);
            lblTipoDocumento.TabIndex = 7;
            lblTipoDocumento.Text = "Tipo de documento:";
            // 
            // txtTipoDocumento
            // 
            txtTipoDocumento.Font = new Font("Segoe UI", 9F);
            txtTipoDocumento.Location = new Point(419, 70);
            txtTipoDocumento.Name = "txtTipoDocumento";
            txtTipoDocumento.ReadOnly = true;
            txtTipoDocumento.Size = new Size(150, 23);
            txtTipoDocumento.TabIndex = 8;
            // 
            // lblNumeroDocMostrar
            // 
            lblNumeroDocMostrar.AutoSize = true;
            lblNumeroDocMostrar.Font = new Font("Segoe UI", 9F);
            lblNumeroDocMostrar.Location = new Point(574, 72);
            lblNumeroDocMostrar.Name = "lblNumeroDocMostrar";
            lblNumeroDocMostrar.Size = new Size(90, 15);
            lblNumeroDocMostrar.TabIndex = 9;
            lblNumeroDocMostrar.Text = "N° Documento:";
            // 
            // txtNumeroDocumentoMostrar
            // 
            txtNumeroDocumentoMostrar.Font = new Font("Segoe UI", 9F);
            txtNumeroDocumentoMostrar.Location = new Point(684, 68);
            txtNumeroDocumentoMostrar.Name = "txtNumeroDocumentoMostrar";
            txtNumeroDocumentoMostrar.ReadOnly = true;
            txtNumeroDocumentoMostrar.Size = new Size(150, 23);
            txtNumeroDocumentoMostrar.TabIndex = 10;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F);
            lblCliente.Location = new Point(38, 113);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 11;
            lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            txtCliente.Font = new Font("Segoe UI", 9F);
            txtCliente.Location = new Point(168, 110);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(280, 23);
            txtCliente.TabIndex = 12;
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Font = new Font("Segoe UI", 9F);
            lblDocumentoCliente.Location = new Point(468, 113);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(119, 15);
            lblDocumentoCliente.TabIndex = 13;
            lblDocumentoCliente.Text = "Documento (cliente):";
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Font = new Font("Segoe UI", 9F);
            txtDocumentoCliente.Location = new Point(598, 110);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.ReadOnly = true;
            txtDocumentoCliente.Size = new Size(220, 23);
            txtDocumentoCliente.TabIndex = 14;
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Font = new Font("Segoe UI", 9F);
            lblDescuento.Location = new Point(38, 153);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(66, 15);
            lblDescuento.TabIndex = 15;
            lblDescuento.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            txtDescuento.Font = new Font("Segoe UI", 9F);
            txtDescuento.Location = new Point(168, 150);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.ReadOnly = true;
            txtDescuento.Size = new Size(100, 23);
            txtDescuento.TabIndex = 16;
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new Font("Segoe UI", 9F);
            lblMontoTotal.Location = new Point(288, 153);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(74, 15);
            lblMontoTotal.TabIndex = 17;
            lblMontoTotal.Text = "Monto Total:";
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Font = new Font("Segoe UI", 9F);
            txtMontoTotal.Location = new Point(368, 150);
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.ReadOnly = true;
            txtMontoTotal.Size = new Size(120, 23);
            txtMontoTotal.TabIndex = 18;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 761);
            Controls.Add(txtMontoTotal);
            Controls.Add(lblMontoTotal);
            Controls.Add(txtDescuento);
            Controls.Add(lblDescuento);
            Controls.Add(txtDocumentoCliente);
            Controls.Add(lblDocumentoCliente);
            Controls.Add(txtCliente);
            Controls.Add(lblCliente);
            Controls.Add(txtNumeroDocumentoMostrar);
            Controls.Add(lblNumeroDocMostrar);
            Controls.Add(txtTipoDocumento);
            Controls.Add(lblTipoDocumento);
            Controls.Add(txtIdVenta);
            Controls.Add(lblIdVenta);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscarVenta);
            Controls.Add(txtNumeroDocumento);
            Controls.Add(lblBuscar);
            Name = "frmDetalleVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Ventas";
            Load += frmDetalleVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
