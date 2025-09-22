namespace BeanDesktop
{
    partial class cajaRegistradora
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;

        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;

        private System.Windows.Forms.DataGridView dgvCarrito;

        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.ComboBox cboTipoDocumento;

        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDescuentoAplicado;
        private System.Windows.Forms.TextBox txtDescuentoAplicado;
        private System.Windows.Forms.Label lblTotalFinal;
        private System.Windows.Forms.TextBox txtTotalFinal;

        private System.Windows.Forms.Button btnRegistrarVenta;

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Button btnBuscar;


        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.lblDocumentoCliente = new System.Windows.Forms.Label();
            this.txtDocumentoCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();

            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();

            this.dgvCarrito = new System.Windows.Forms.DataGridView();

            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();

            this.lblPago = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblDescuentoAplicado = new System.Windows.Forms.Label();
            this.txtDescuentoAplicado = new System.Windows.Forms.TextBox();
            this.lblTotalFinal = new System.Windows.Forms.Label();
            this.txtTotalFinal = new System.Windows.Forms.TextBox();

            this.btnRegistrarVenta = new System.Windows.Forms.Button();

            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Caja Registradora";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);

            // 
            // gbCliente
            // 
            this.gbCliente.Text = "Datos del Cliente";
            this.gbCliente.Location = new System.Drawing.Point(20, 70);
            this.gbCliente.Size = new System.Drawing.Size(400, 100);

            this.lblDocumentoCliente.Text = "Documento:";
            this.lblDocumentoCliente.Location = new System.Drawing.Point(20, 30);
            this.txtDocumentoCliente.Location = new System.Drawing.Point(120, 30);
            this.txtDocumentoCliente.Width = 200;

            this.lblNombreCliente.Text = "Nombre:";
            this.lblNombreCliente.Location = new System.Drawing.Point(20, 60);
            this.txtNombreCliente.Location = new System.Drawing.Point(120, 60);
            this.txtNombreCliente.Width = 200;

            this.gbCliente.Controls.Add(this.lblDocumentoCliente);
            this.gbCliente.Controls.Add(this.txtDocumentoCliente);
            this.gbCliente.Controls.Add(this.lblNombreCliente);
            this.gbCliente.Controls.Add(this.txtNombreCliente);

            // 
            // gbProducto
            // 
            this.gbProducto.Text = "Producto";
            this.gbProducto.Location = new System.Drawing.Point(20, 180);
            this.gbProducto.Size = new System.Drawing.Size(600, 120);

            this.txtIdProducto.PlaceholderText = "ID";
            this.txtIdProducto.Location = new System.Drawing.Point(20, 30);
            this.txtIdProducto.Width = 50;

            this.txtDescripcion.PlaceholderText = "Descripción";
            this.txtDescripcion.Location = new System.Drawing.Point(80, 30);
            this.txtDescripcion.Width = 150;

            this.txtPrecio.PlaceholderText = "Precio";
            this.txtPrecio.Location = new System.Drawing.Point(240, 30);
            this.txtPrecio.Width = 80;

            this.txtCantidad.PlaceholderText = "Cantidad";
            this.txtCantidad.Location = new System.Drawing.Point(330, 30);
            this.txtCantidad.Width = 80;

            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.Location = new System.Drawing.Point(430, 30);

            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.Location = new System.Drawing.Point(510, 30);

            this.gbProducto.Controls.Add(this.txtIdProducto);
            this.gbProducto.Controls.Add(this.txtDescripcion);
            this.gbProducto.Controls.Add(this.txtPrecio);
            this.gbProducto.Controls.Add(this.txtCantidad);
            this.gbProducto.Controls.Add(this.btnAgregarProducto);
            this.gbProducto.Controls.Add(this.btnEliminarProducto);

            // 
            // dgvCarrito
            // 
            this.dgvCarrito.Location = new System.Drawing.Point(20, 310);
            this.dgvCarrito.Size = new System.Drawing.Size(600, 200);
            this.dgvCarrito.AllowUserToAddRows = false;

            // 
            // Totales
            // 
            this.lblTotal.Text = "Total:";
            this.lblTotal.Location = new System.Drawing.Point(650, 310);
            this.txtTotal.Location = new System.Drawing.Point(750, 310);
            this.txtTotal.ReadOnly = true;

            this.lblDescuento.Text = "Descuento:";
            this.lblDescuento.Location = new System.Drawing.Point(650, 340);
            this.txtDescuento.Location = new System.Drawing.Point(750, 340);

            this.lblDescuentoAplicado.Text = "Desc. Aplicado:";
            this.lblDescuentoAplicado.Location = new System.Drawing.Point(650, 370);
            this.txtDescuentoAplicado.Location = new System.Drawing.Point(750, 370);
            this.txtDescuentoAplicado.ReadOnly = true;

            this.lblTotalFinal.Text = "Total Final:";
            this.lblTotalFinal.Location = new System.Drawing.Point(650, 400);
            this.txtTotalFinal.Location = new System.Drawing.Point(750, 400);
            this.txtTotalFinal.ReadOnly = true;

            this.lblPago.Text = "Pago:";
            this.lblPago.Location = new System.Drawing.Point(650, 430);
            this.txtPago.Location = new System.Drawing.Point(750, 430);

            this.lblCambio.Text = "Cambio:";
            this.lblCambio.Location = new System.Drawing.Point(650, 460);
            this.txtCambio.Location = new System.Drawing.Point(750, 460);
            this.txtCambio.ReadOnly = true;

            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.Location = new System.Drawing.Point(650, 500);
            this.btnRegistrarVenta.Size = new System.Drawing.Size(200, 40);

            // 
            // cajaRegistradora
            // 
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbProducto);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblDescuentoAplicado);
            this.Controls.Add(this.txtDescuentoAplicado);
            this.Controls.Add(this.lblTotalFinal);
            this.Controls.Add(this.txtTotalFinal);
            this.Controls.Add(this.lblPago);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.btnRegistrarVenta);

            this.Text = "Caja Registradora";
            this.Load += new System.EventHandler(this.cajaRegistradora_Load);




            // dgvProductos
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvProductos.Location = new System.Drawing.Point(20, 520);
            this.dgvProductos.Size = new System.Drawing.Size(600, 200);
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.AllowUserToAddRows = false;

            // txtBuscarProducto
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.txtBuscarProducto.PlaceholderText = "Buscar producto...";
            this.txtBuscarProducto.Location = new System.Drawing.Point(20, 730);
            this.txtBuscarProducto.Width = 200;

            // cboCategoria
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.cboCategoria.Location = new System.Drawing.Point(230, 730);
            this.cboCategoria.Width = 150;

            // btnBuscar
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(390, 730);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.btnBuscar);

        }





    }
}
