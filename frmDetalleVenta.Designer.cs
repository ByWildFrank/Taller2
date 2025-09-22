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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.btnBuscarVenta = new System.Windows.Forms.Button();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();

            this.txtIdVenta = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtDocumentoCliente = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtNumeroDocumentoMostrar = new System.Windows.Forms.TextBox();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Text = "Detalle de Venta";

            // txtNumeroDocumento
            this.txtNumeroDocumento.Location = new System.Drawing.Point(25, 60);
            this.txtNumeroDocumento.PlaceholderText = "Número de documento...";

            // btnBuscarVenta
            this.btnBuscarVenta.Location = new System.Drawing.Point(250, 58);
            this.btnBuscarVenta.Text = "Buscar";
            this.btnBuscarVenta.Click += new System.EventHandler(this.btnBuscarVenta_Click);

            // dgvDetalleVenta
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            this.dgvDetalleVenta.ReadOnly = true;
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(25, 220);
            this.dgvDetalleVenta.Size = new System.Drawing.Size(750, 250);

            this.dgvDetalleVenta.Columns.Add("IdDetalleVenta", "Id Detalle");
            this.dgvDetalleVenta.Columns.Add("IdProducto", "Producto");
            this.dgvDetalleVenta.Columns.Add("PrecioVenta", "Precio");
            this.dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            this.dgvDetalleVenta.Columns.Add("SubTotal", "Subtotal");
            this.dgvDetalleVenta.Columns.Add("FechaRegistro", "Fecha");

            // Datos cabecera
            int y = 100;
            int offset = 30;

            this.txtIdVenta.Location = new System.Drawing.Point(25, y);
            this.txtIdVenta.ReadOnly = true;
            this.txtIdVenta.PlaceholderText = "IdVenta";

            this.txtCliente.Location = new System.Drawing.Point(25, y + offset);
            this.txtCliente.ReadOnly = true;
            this.txtCliente.PlaceholderText = "Cliente";

            this.txtDocumentoCliente.Location = new System.Drawing.Point(200, y + offset);
            this.txtDocumentoCliente.ReadOnly = true;
            this.txtDocumentoCliente.PlaceholderText = "Documento Cliente";

            this.txtTipoDocumento.Location = new System.Drawing.Point(25, y + offset * 2);
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.PlaceholderText = "Tipo Documento";

            this.txtNumeroDocumentoMostrar.Location = new System.Drawing.Point(200, y + offset * 2);
            this.txtNumeroDocumentoMostrar.ReadOnly = true;
            this.txtNumeroDocumentoMostrar.PlaceholderText = "Número Documento";

            this.txtMontoTotal.Location = new System.Drawing.Point(25, y + offset * 3);
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.PlaceholderText = "Monto Total";

            this.txtDescuento.Location = new System.Drawing.Point(200, y + offset * 3);
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.PlaceholderText = "Descuento";

            // frmDetalleVenta
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.btnBuscarVenta);
            this.Controls.Add(this.dgvDetalleVenta);

            this.Controls.Add(this.txtIdVenta);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtDocumentoCliente);
            this.Controls.Add(this.txtTipoDocumento);
            this.Controls.Add(this.txtNumeroDocumentoMostrar);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.txtDescuento);

            this.Text = "Detalle de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}
