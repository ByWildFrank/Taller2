namespace BeanDesktop
{
    partial class cajaRegistradora
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
            pnlCliente = new GroupBox();
            lblDocumentoCliente = new Label();
            lblNombreCliente = new Label();
            txtDocumentoCliente = new TextBox();
            txtNombreCliente = new TextBox();
            btnBuscarCliente = new Button();
            pnlProductos = new GroupBox();
            lblBuscarProducto = new Label();
            txtBuscarProducto = new TextBox();
            btnBuscar = new Button();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            dgvProductos = new DataGridView();
            pnlCarrito = new GroupBox();
            dgvCarrito = new DataGridView();
            btnEliminarProducto = new Button();
            pnlTotales = new GroupBox();
            lblTipoDocumento = new Label();
            cboTipoDocumento = new ComboBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblDescuento = new Label();
            txtDescuento = new TextBox();
            lblDescuentoAplicado = new Label();
            txtDescuentoAplicado = new TextBox();
            lblTotalFinal = new Label();
            txtTotalFinal = new TextBox();
            lblPago = new Label();
            txtPago = new TextBox();
            lblCambio = new Label();
            txtCambio = new TextBox();
            btnRegistrarVenta = new Button();
            pnlCliente.SuspendLayout();
            pnlProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            pnlCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            pnlTotales.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCliente
            // 
            pnlCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCliente.Controls.Add(lblDocumentoCliente);
            pnlCliente.Controls.Add(lblNombreCliente);
            pnlCliente.Controls.Add(txtDocumentoCliente);
            pnlCliente.Controls.Add(txtNombreCliente);
            pnlCliente.Controls.Add(btnBuscarCliente);
            pnlCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pnlCliente.Location = new Point(20, 15);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.Size = new Size(1150, 70);
            pnlCliente.TabIndex = 0;
            pnlCliente.TabStop = false;
            pnlCliente.Text = "Datos del Cliente";
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Location = new Point(20, 30);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(76, 15);
            lblDocumentoCliente.TabIndex = 0;
            lblDocumentoCliente.Text = "Documento:";
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(400, 30);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(56, 15);
            lblNombreCliente.TabIndex = 1;
            lblNombreCliente.Text = "Nombre:";
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Location = new Point(100, 27);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.Size = new Size(180, 23);
            txtDocumentoCliente.TabIndex = 2;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(460, 27);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(250, 23);
            txtNombreCliente.TabIndex = 3;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(290, 25);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(75, 26);
            btnBuscarCliente.TabIndex = 4;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // pnlProductos
            // 
            pnlProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlProductos.Controls.Add(lblBuscarProducto);
            pnlProductos.Controls.Add(txtBuscarProducto);
            pnlProductos.Controls.Add(btnBuscar);
            pnlProductos.Controls.Add(lblCategoria);
            pnlProductos.Controls.Add(cboCategoria);
            pnlProductos.Controls.Add(dgvProductos);
            pnlProductos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pnlProductos.Location = new Point(20, 95);
            pnlProductos.Name = "pnlProductos";
            pnlProductos.Size = new Size(1110, 270);
            pnlProductos.TabIndex = 1;
            pnlProductos.TabStop = false;
            pnlProductos.Text = "Productos";
            // 
            // lblBuscarProducto
            // 
            lblBuscarProducto.AutoSize = true;
            lblBuscarProducto.Location = new Point(20, 25);
            lblBuscarProducto.Name = "lblBuscarProducto";
            lblBuscarProducto.Size = new Size(47, 15);
            lblBuscarProducto.TabIndex = 0;
            lblBuscarProducto.Text = "Buscar:";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(75, 22);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(200, 23);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(285, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 26);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(380, 25);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(63, 15);
            lblCategoria.TabIndex = 3;
            lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.Location = new Point(455, 22);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(200, 23);
            cboCategoria.TabIndex = 4;
            cboCategoria.TextChanged += cboCategoria_SelectedIndexChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(20, 60);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(1049, 190);
            dgvProductos.TabIndex = 5;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // pnlCarrito
            // 
            pnlCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCarrito.Controls.Add(dgvCarrito);
            pnlCarrito.Controls.Add(btnEliminarProducto);
            pnlCarrito.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pnlCarrito.Location = new Point(20, 375);
            pnlCarrito.Name = "pnlCarrito";
            pnlCarrito.Size = new Size(1110, 180);
            pnlCarrito.TabIndex = 2;
            pnlCarrito.TabStop = false;
            pnlCarrito.Text = "Carrito de Compras";
            // 
            // dgvCarrito
            // 
            dgvCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(20, 25);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(970, 130);
            dgvCarrito.TabIndex = 0;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Location = new Point(965, 80);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(60, 26);
            btnEliminarProducto.TabIndex = 1;
            btnEliminarProducto.Text = "X";
            btnEliminarProducto.UseVisualStyleBackColor = true;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
            // 
            // pnlTotales
            // 
            pnlTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTotales.Controls.Add(lblTipoDocumento);
            pnlTotales.Controls.Add(cboTipoDocumento);
            pnlTotales.Controls.Add(lblTotal);
            pnlTotales.Controls.Add(txtTotal);
            pnlTotales.Controls.Add(lblDescuento);
            pnlTotales.Controls.Add(txtDescuento);
            pnlTotales.Controls.Add(lblDescuentoAplicado);
            pnlTotales.Controls.Add(txtDescuentoAplicado);
            pnlTotales.Controls.Add(lblTotalFinal);
            pnlTotales.Controls.Add(txtTotalFinal);
            pnlTotales.Controls.Add(lblPago);
            pnlTotales.Controls.Add(txtPago);
            pnlTotales.Controls.Add(lblCambio);
            pnlTotales.Controls.Add(txtCambio);
            pnlTotales.Controls.Add(btnRegistrarVenta);
            pnlTotales.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pnlTotales.Location = new Point(20, 570);
            pnlTotales.Name = "pnlTotales";
            pnlTotales.Size = new Size(1110, 110);
            pnlTotales.TabIndex = 3;
            pnlTotales.TabStop = false;
            pnlTotales.Text = "Totales";
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(20, 30);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(103, 15);
            lblTipoDocumento.TabIndex = 0;
            lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // cboTipoDocumento
            // 
            cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDocumento.Location = new Point(130, 27);
            cboTipoDocumento.Name = "cboTipoDocumento";
            cboTipoDocumento.Size = new Size(150, 23);
            cboTipoDocumento.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(300, 30);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(37, 15);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(350, 27);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 3;
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Location = new Point(480, 30);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(37, 15);
            lblDescuento.TabIndex = 4;
            lblDescuento.Text = "Desc:";
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(530, 27);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(80, 23);
            txtDescuento.TabIndex = 5;
            // 
            // lblDescuentoAplicado
            // 
            lblDescuentoAplicado.AutoSize = true;
            lblDescuentoAplicado.Location = new Point(620, 30);
            lblDescuentoAplicado.Name = "lblDescuentoAplicado";
            lblDescuentoAplicado.Size = new Size(57, 15);
            lblDescuentoAplicado.TabIndex = 6;
            lblDescuentoAplicado.Text = "Aplicado:";
            // 
            // txtDescuentoAplicado
            // 
            txtDescuentoAplicado.Location = new Point(690, 27);
            txtDescuentoAplicado.Name = "txtDescuentoAplicado";
            txtDescuentoAplicado.ReadOnly = true;
            txtDescuentoAplicado.Size = new Size(80, 23);
            txtDescuentoAplicado.TabIndex = 7;
            // 
            // lblTotalFinal
            // 
            lblTotalFinal.AutoSize = true;
            lblTotalFinal.Location = new Point(790, 30);
            lblTotalFinal.Name = "lblTotalFinal";
            lblTotalFinal.Size = new Size(65, 15);
            lblTotalFinal.TabIndex = 8;
            lblTotalFinal.Text = "Total Final:";
            // 
            // txtTotalFinal
            // 
            txtTotalFinal.Location = new Point(870, 27);
            txtTotalFinal.Name = "txtTotalFinal";
            txtTotalFinal.ReadOnly = true;
            txtTotalFinal.Size = new Size(100, 23);
            txtTotalFinal.TabIndex = 9;
            // 
            // lblPago
            // 
            lblPago.AutoSize = true;
            lblPago.Location = new Point(300, 70);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(37, 15);
            lblPago.TabIndex = 10;
            lblPago.Text = "Pago:";
            // 
            // txtPago
            // 
            txtPago.Location = new Point(350, 67);
            txtPago.Name = "txtPago";
            txtPago.Size = new Size(80, 23);
            txtPago.TabIndex = 11;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Location = new Point(450, 70);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(51, 15);
            lblCambio.TabIndex = 12;
            lblCambio.Text = "Cambio:";
            // 
            // txtCambio
            // 
            txtCambio.Location = new Point(520, 67);
            txtCambio.Name = "txtCambio";
            txtCambio.ReadOnly = true;
            txtCambio.Size = new Size(80, 23);
            txtCambio.TabIndex = 13;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Location = new Point(870, 58);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(120, 40);
            btnRegistrarVenta.TabIndex = 14;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // cajaRegistradora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlCliente);
            Controls.Add(pnlProductos);
            Controls.Add(pnlCarrito);
            Controls.Add(pnlTotales);
            Name = "cajaRegistradora";
            Text = "Caja Registradora";
            Load += cajaRegistradora_Load;
            pnlCliente.ResumeLayout(false);
            pnlCliente.PerformLayout();
            pnlProductos.ResumeLayout(false);
            pnlProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            pnlCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            pnlTotales.ResumeLayout(false);
            pnlTotales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox pnlCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.Label lblNombreCliente;

        private System.Windows.Forms.GroupBox pnlProductos;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblBuscarProducto;

        private System.Windows.Forms.GroupBox pnlCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnEliminarProducto;

        private System.Windows.Forms.GroupBox pnlTotales;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDescuentoAplicado;
        private System.Windows.Forms.TextBox txtDescuentoAplicado;
        private System.Windows.Forms.Label lblTotalFinal;
        private System.Windows.Forms.TextBox txtTotalFinal;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Button btnRegistrarVenta;
    }
}
