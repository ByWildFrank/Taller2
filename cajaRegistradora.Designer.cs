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
            lblTitulo = new Label();
            gbCliente = new GroupBox();
            btnBuscarCliente = new FontAwesome.Sharp.IconButton();
            lblDocumentoCliente = new Label();
            txtDocumentoCliente = new TextBox();
            lblNombreCliente = new Label();
            txtNombreCliente = new TextBox();
            gbProducto = new GroupBox();
            txtIdProducto = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            btnAgregarProducto = new Button();
            btnEliminarProducto = new Button();
            dgvCarrito = new DataGridView();
            lblTipoDocumento = new Label();
            cboTipoDocumento = new ComboBox();
            lblPago = new Label();
            txtPago = new TextBox();
            lblCambio = new Label();
            txtCambio = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblDescuento = new Label();
            txtDescuento = new TextBox();
            lblDescuentoAplicado = new Label();
            txtDescuentoAplicado = new TextBox();
            lblTotalFinal = new Label();
            txtTotalFinal = new TextBox();
            btnRegistrarVenta = new Button();
            dgvProductos = new DataGridView();
            txtBuscarProducto = new TextBox();
            cboCategoria = new ComboBox();
            btnBuscar = new Button();
            gbCliente.SuspendLayout();
            gbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(196, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Caja Registradora";
            // 
            // gbCliente
            // 
            gbCliente.Controls.Add(btnBuscarCliente);
            gbCliente.Controls.Add(lblDocumentoCliente);
            gbCliente.Controls.Add(txtDocumentoCliente);
            gbCliente.Controls.Add(lblNombreCliente);
            gbCliente.Controls.Add(txtNombreCliente);
            gbCliente.Location = new Point(20, 70);
            gbCliente.Name = "gbCliente";
            gbCliente.Size = new Size(428, 100);
            gbCliente.TabIndex = 1;
            gbCliente.TabStop = false;
            gbCliente.Text = "Datos del Cliente";
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscarCliente.IconColor = Color.Black;
            btnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscarCliente.IconSize = 18;
            btnBuscarCliente.Location = new Point(335, 30);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(75, 23);
            btnBuscarCliente.TabIndex = 4;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.Location = new Point(20, 30);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(100, 23);
            lblDocumentoCliente.TabIndex = 0;
            lblDocumentoCliente.Text = "Documento:";
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Location = new Point(120, 30);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.Size = new Size(200, 23);
            txtDocumentoCliente.TabIndex = 1;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.Location = new Point(20, 60);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(100, 23);
            lblNombreCliente.TabIndex = 2;
            lblNombreCliente.Text = "Nombre:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(120, 60);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(200, 23);
            txtNombreCliente.TabIndex = 3;
            // 
            // gbProducto
            // 
            gbProducto.Controls.Add(txtIdProducto);
            gbProducto.Controls.Add(txtDescripcion);
            gbProducto.Controls.Add(txtPrecio);
            gbProducto.Controls.Add(txtCantidad);
            gbProducto.Controls.Add(btnAgregarProducto);
            gbProducto.Controls.Add(btnEliminarProducto);
            gbProducto.Location = new Point(20, 180);
            gbProducto.Name = "gbProducto";
            gbProducto.Size = new Size(600, 120);
            gbProducto.TabIndex = 2;
            gbProducto.TabStop = false;
            gbProducto.Text = "Producto";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(20, 30);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.PlaceholderText = "ID";
            txtIdProducto.Size = new Size(50, 23);
            txtIdProducto.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(80, 30);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripción";
            txtDescripcion.Size = new Size(150, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(240, 30);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Size = new Size(80, 23);
            txtPrecio.TabIndex = 2;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(330, 30);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.PlaceholderText = "Cantidad";
            txtCantidad.Size = new Size(80, 23);
            txtCantidad.TabIndex = 3;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(430, 30);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(75, 23);
            btnAgregarProducto.TabIndex = 4;
            btnAgregarProducto.Text = "Agregar";
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Location = new Point(510, 30);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(75, 23);
            btnEliminarProducto.TabIndex = 5;
            btnEliminarProducto.Text = "Eliminar";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.Location = new Point(20, 310);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(600, 200);
            dgvCarrito.TabIndex = 3;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.Location = new Point(0, 0);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(100, 23);
            lblTipoDocumento.TabIndex = 0;
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.Location = new Point(0, 0);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(121, 23);
            cboTipoDocumento.TabIndex = 0;
            // 
            // lblPago
            // 
            lblPago.Location = new Point(650, 430);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(100, 23);
            lblPago.TabIndex = 12;
            lblPago.Text = "Pago:";
            // 
            // txtPago
            // 
            txtPago.Location = new Point(750, 430);
            txtPago.Name = "txtPago";
            txtPago.Size = new Size(100, 23);
            txtPago.TabIndex = 13;
            // 
            // lblCambio
            // 
            lblCambio.Location = new Point(650, 460);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(100, 23);
            lblCambio.TabIndex = 14;
            lblCambio.Text = "Cambio:";
            // 
            // txtCambio
            // 
            txtCambio.Location = new Point(750, 460);
            txtCambio.Name = "txtCambio";
            txtCambio.ReadOnly = true;
            txtCambio.Size = new Size(100, 23);
            txtCambio.TabIndex = 15;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(650, 310);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(750, 310);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 5;
            // 
            // lblDescuento
            // 
            lblDescuento.Location = new Point(650, 340);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(100, 23);
            lblDescuento.TabIndex = 6;
            lblDescuento.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(750, 340);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(100, 23);
            txtDescuento.TabIndex = 7;
            // 
            // lblDescuentoAplicado
            // 
            lblDescuentoAplicado.Location = new Point(650, 370);
            lblDescuentoAplicado.Name = "lblDescuentoAplicado";
            lblDescuentoAplicado.Size = new Size(100, 23);
            lblDescuentoAplicado.TabIndex = 8;
            lblDescuentoAplicado.Text = "Desc. Aplicado:";
            // 
            // txtDescuentoAplicado
            // 
            txtDescuentoAplicado.Location = new Point(750, 370);
            txtDescuentoAplicado.Name = "txtDescuentoAplicado";
            txtDescuentoAplicado.ReadOnly = true;
            txtDescuentoAplicado.Size = new Size(100, 23);
            txtDescuentoAplicado.TabIndex = 9;
            // 
            // lblTotalFinal
            // 
            lblTotalFinal.Location = new Point(650, 400);
            lblTotalFinal.Name = "lblTotalFinal";
            lblTotalFinal.Size = new Size(100, 23);
            lblTotalFinal.TabIndex = 10;
            lblTotalFinal.Text = "Total Final:";
            // 
            // txtTotalFinal
            // 
            txtTotalFinal.Location = new Point(750, 400);
            txtTotalFinal.Name = "txtTotalFinal";
            txtTotalFinal.ReadOnly = true;
            txtTotalFinal.Size = new Size(100, 23);
            txtTotalFinal.TabIndex = 11;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegistrarVenta.Location = new Point(650, 500);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(200, 40);
            btnRegistrarVenta.TabIndex = 16;
            btnRegistrarVenta.Text = "Registrar Venta";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Location = new Point(20, 520);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(600, 200);
            dgvProductos.TabIndex = 17;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(20, 730);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.PlaceholderText = "Buscar producto...";
            txtBuscarProducto.Size = new Size(200, 23);
            txtBuscarProducto.TabIndex = 18;
            // 
            // cboCategoria
            // 
            cboCategoria.Location = new Point(230, 730);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(150, 23);
            cboCategoria.TabIndex = 19;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(390, 730);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 20;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cajaRegistradora
            // 
            ClientSize = new Size(997, 703);
            Controls.Add(lblTitulo);
            Controls.Add(gbCliente);
            Controls.Add(gbProducto);
            Controls.Add(dgvCarrito);
            Controls.Add(lblTotal);
            Controls.Add(txtTotal);
            Controls.Add(lblDescuento);
            Controls.Add(txtDescuento);
            Controls.Add(lblDescuentoAplicado);
            Controls.Add(txtDescuentoAplicado);
            Controls.Add(lblTotalFinal);
            Controls.Add(txtTotalFinal);
            Controls.Add(lblPago);
            Controls.Add(txtPago);
            Controls.Add(lblCambio);
            Controls.Add(txtCambio);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(dgvProductos);
            Controls.Add(txtBuscarProducto);
            Controls.Add(cboCategoria);
            Controls.Add(btnBuscar);
            Name = "cajaRegistradora";
            Text = "Caja Registradora";
            Load += cajaRegistradora_Load;
            gbCliente.ResumeLayout(false);
            gbCliente.PerformLayout();
            gbProducto.ResumeLayout(false);
            gbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private FontAwesome.Sharp.IconButton btnBuscarCliente;
    }
}
