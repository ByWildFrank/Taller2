namespace BeanDesktop
{
    partial class frmProducto
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
            dgvProductos = new DataGridView();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtCodigo = new TextBox();
            txtPrecioFabricacion = new TextBox();
            txtPrecioVenta = new TextBox();
            cmbCategoria = new ComboBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblCodigo = new Label();
            lblCategoria = new Label();
            lblStock = new Label();
            lblPrecioFabricacion = new Label();
            lblPrecioVenta = new Label();
            lblEstado = new Label();
            btnLimpiar = new FontAwesome.Sharp.IconButton();
            cboEstado = new ComboBox();
            txtBusqueda = new TextBox();
            txtid = new TextBox();
            cboBusqueda = new ComboBox();
            gbAjusteStock = new GroupBox();
            btnAnadirStock = new Button();
            numStockAnadir = new NumericUpDown();
            txtStockActual = new TextBox();
            numStockInicial = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            gbAjusteStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStockAnadir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockInicial).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 250);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 24;
            dgvProductos.Size = new Size(950, 300);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 11);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(150, 41);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(150, 71);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 23);
            txtCodigo.TabIndex = 3;
            // 
            // txtPrecioFabricacion
            // 
            txtPrecioFabricacion.Location = new Point(150, 162);
            txtPrecioFabricacion.Name = "txtPrecioFabricacion";
            txtPrecioFabricacion.Size = new Size(100, 23);
            txtPrecioFabricacion.TabIndex = 5;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(150, 192);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 6;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Location = new Point(150, 102);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(200, 23);
            cmbCategoria.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(377, 74);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(377, 115);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(30, 14);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(30, 44);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 12;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblCodigo
            // 
            lblCodigo.Location = new Point(30, 74);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 23);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código:";
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(30, 105);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(100, 23);
            lblCategoria.TabIndex = 14;
            lblCategoria.Text = "Categoría:";
            // 
            // lblStock
            // 
            lblStock.Location = new Point(30, 135);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 15;
            lblStock.Text = "Stock:";
            // 
            // lblPrecioFabricacion
            // 
            lblPrecioFabricacion.Location = new Point(30, 165);
            lblPrecioFabricacion.Name = "lblPrecioFabricacion";
            lblPrecioFabricacion.Size = new Size(100, 23);
            lblPrecioFabricacion.TabIndex = 16;
            lblPrecioFabricacion.Text = "Precio Fabricación:";
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.Location = new Point(30, 192);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(100, 23);
            lblPrecioVenta.TabIndex = 17;
            lblPrecioVenta.Text = "Precio Venta:";
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(377, 11);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 20);
            lblEstado.TabIndex = 18;
            lblEstado.Text = "Estado:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.RoyalBlue;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = Color.Black;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            btnLimpiar.IconColor = Color.White;
            btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiar.IconSize = 16;
            btnLimpiar.Location = new Point(377, 162);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 23);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cboEstado
            // 
            cboEstado.Location = new Point(440, 8);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(157, 23);
            cboEstado.TabIndex = 20;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(377, 202);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(334, 23);
            txtBusqueda.TabIndex = 21;
            // 
            // txtid
            // 
            txtid.Location = new Point(611, 8);
            txtid.Name = "txtid";
            txtid.Size = new Size(100, 23);
            txtid.TabIndex = 22;
            // 
            // cboBusqueda
            // 
            cboBusqueda.FormattingEnabled = true;
            cboBusqueda.Location = new Point(749, 202);
            cboBusqueda.Name = "cboBusqueda";
            cboBusqueda.Size = new Size(121, 23);
            cboBusqueda.TabIndex = 23;
            // 
            // gbAjusteStock
            // 
            gbAjusteStock.Controls.Add(btnAnadirStock);
            gbAjusteStock.Controls.Add(numStockAnadir);
            gbAjusteStock.Location = new Point(505, 74);
            gbAjusteStock.Name = "gbAjusteStock";
            gbAjusteStock.Size = new Size(206, 111);
            gbAjusteStock.TabIndex = 25;
            gbAjusteStock.TabStop = false;
            gbAjusteStock.Text = "Añadir Stock:";
            // 
            // btnAnadirStock
            // 
            btnAnadirStock.Location = new Point(6, 61);
            btnAnadirStock.Name = "btnAnadirStock";
            btnAnadirStock.Size = new Size(75, 23);
            btnAnadirStock.TabIndex = 1;
            btnAnadirStock.Text = "Añadir";
            btnAnadirStock.UseVisualStyleBackColor = true;
            btnAnadirStock.Click += btnAnadirStock_Click;
            // 
            // numStockAnadir
            // 
            numStockAnadir.Location = new Point(6, 22);
            numStockAnadir.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStockAnadir.Name = "numStockAnadir";
            numStockAnadir.Size = new Size(86, 23);
            numStockAnadir.TabIndex = 0;
            numStockAnadir.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(150, 160);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.ReadOnly = true;
            txtStockActual.Size = new Size(107, 23);
            txtStockActual.TabIndex = 2;
            // 
            // numStockInicial
            // 
            numStockInicial.Location = new Point(150, 131);
            numStockInicial.Name = "numStockInicial";
            numStockInicial.Size = new Size(94, 23);
            numStockInicial.TabIndex = 24;
            numStockInicial.Visible = false;
            // 
            // label1
            // 
            label1.Location = new Point(150, 163);
            label1.Name = "label1";
            label1.Size = new Size(107, 23);
            label1.TabIndex = 26;
            // 
            // frmProducto
            // 
            ClientSize = new Size(974, 562);
            Controls.Add(txtStockActual);
            Controls.Add(label1);
            Controls.Add(gbAjusteStock);
            Controls.Add(numStockInicial);
            Controls.Add(cboBusqueda);
            Controls.Add(txtid);
            Controls.Add(txtBusqueda);
            Controls.Add(cboEstado);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvProductos);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(txtCodigo);
            Controls.Add(txtPrecioFabricacion);
            Controls.Add(txtPrecioVenta);
            Controls.Add(cmbCategoria);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(lblNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(lblCodigo);
            Controls.Add(lblCategoria);
            Controls.Add(lblStock);
            Controls.Add(lblPrecioFabricacion);
            Controls.Add(lblPrecioVenta);
            Controls.Add(lblEstado);
            Name = "frmProducto";
            Text = "Gestión de Productos";
            Load += frmProducto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            gbAjusteStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numStockAnadir).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockInicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecioFabricacion;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecioFabricacion;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblEstado;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private ComboBox cboEstado;
        private TextBox txtBusqueda;
        private TextBox txtid;
        private ComboBox cboBusqueda;
        private GroupBox gbAjusteStock;
        private Button btnAnadirStock;
        private NumericUpDown numStockAnadir;
        private TextBox txtStockActual;
        private NumericUpDown numStockInicial;
        private Label label1;
        private ComboBox cmbCategoria;
    }
}
