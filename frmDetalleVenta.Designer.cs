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

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtNumeroDocumento = new TextBox();
            btnBuscarVenta = new Button();
            dgvDetalleVenta = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            txtIdVenta = new TextBox();
            txtCliente = new TextBox();
            txtDocumentoCliente = new TextBox();
            txtTipoDocumento = new TextBox();
            txtNumeroDocumentoMostrar = new TextBox();
            txtMontoTotal = new TextBox();
            txtDescuento = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(156, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de Venta";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Location = new Point(25, 60);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.PlaceholderText = "Número de documento...";
            txtNumeroDocumento.Size = new Size(161, 23);
            txtNumeroDocumento.TabIndex = 1;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.Location = new Point(254, 59);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(75, 23);
            btnBuscarVenta.TabIndex = 2;
            btnBuscarVenta.Text = "Buscar";
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvDetalleVenta.Location = new Point(25, 220);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.Size = new Size(750, 250);
            dgvDetalleVenta.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id Detalle";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Precio";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Subtotal";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Fecha";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // txtIdVenta
            // 
            txtIdVenta.Location = new Point(310, 146);
            txtIdVenta.Name = "txtIdVenta";
            txtIdVenta.PlaceholderText = "IdVenta";
            txtIdVenta.ReadOnly = true;
            txtIdVenta.Size = new Size(151, 23);
            txtIdVenta.TabIndex = 4;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(497, 146);
            txtCliente.Name = "txtCliente";
            txtCliente.PlaceholderText = "Cliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(100, 23);
            txtCliente.TabIndex = 5;
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Location = new Point(145, 146);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.PlaceholderText = "Documento Cliente";
            txtDocumentoCliente.ReadOnly = true;
            txtDocumentoCliente.Size = new Size(139, 23);
            txtDocumentoCliente.TabIndex = 6;
            // 
            // txtTipoDocumento
            // 
            txtTipoDocumento.Location = new Point(25, 100);
            txtTipoDocumento.Name = "txtTipoDocumento";
            txtTipoDocumento.PlaceholderText = "Tipo Documento";
            txtTipoDocumento.ReadOnly = true;
            txtTipoDocumento.Size = new Size(100, 23);
            txtTipoDocumento.TabIndex = 7;
            // 
            // txtNumeroDocumentoMostrar
            // 
            txtNumeroDocumentoMostrar.Location = new Point(145, 100);
            txtNumeroDocumentoMostrar.Name = "txtNumeroDocumentoMostrar";
            txtNumeroDocumentoMostrar.PlaceholderText = "Número Documento";
            txtNumeroDocumentoMostrar.ReadOnly = true;
            txtNumeroDocumentoMostrar.Size = new Size(129, 23);
            txtNumeroDocumentoMostrar.TabIndex = 8;
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Location = new Point(636, 146);
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.PlaceholderText = "Monto Total";
            txtMontoTotal.ReadOnly = true;
            txtMontoTotal.Size = new Size(100, 23);
            txtMontoTotal.TabIndex = 9;
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(25, 146);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.PlaceholderText = "Descuento";
            txtDescuento.ReadOnly = true;
            txtDescuento.Size = new Size(100, 23);
            txtDescuento.TabIndex = 10;
            // 
            // frmDetalleVenta
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(lblTitulo);
            Controls.Add(txtNumeroDocumento);
            Controls.Add(btnBuscarVenta);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(txtIdVenta);
            Controls.Add(txtCliente);
            Controls.Add(txtDocumentoCliente);
            Controls.Add(txtTipoDocumento);
            Controls.Add(txtNumeroDocumentoMostrar);
            Controls.Add(txtMontoTotal);
            Controls.Add(txtDescuento);
            Name = "frmDetalleVenta";
            Text = "Detalle de Venta";
            Load += frmDetalleVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Button btnBuscarVenta;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;

        private System.Windows.Forms.TextBox txtIdVenta;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.TextBox txtNumeroDocumentoMostrar;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.TextBox txtDescuento;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
