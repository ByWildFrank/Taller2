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
            cmbCategoriaBusqueda = new ComboBox();
            gbAjusteStock = new GroupBox();
            btnAnadirStock = new Button();
            numStockAnadir = new NumericUpDown();
            txtStockActual = new TextBox();
            numStockInicial = new NumericUpDown();
            cboBusqueda = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
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
            dgvProductos.Location = new Point(12, 368);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 24;
            dgvProductos.Size = new Size(1110, 372);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(546, 49);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(546, 79);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 27);
            txtDescripcion.TabIndex = 2;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(546, 109);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 27);
            txtCodigo.TabIndex = 3;
            // 
            // txtPrecioFabricacion
            // 
            txtPrecioFabricacion.Location = new Point(546, 203);
            txtPrecioFabricacion.Name = "txtPrecioFabricacion";
            txtPrecioFabricacion.Size = new Size(100, 27);
            txtPrecioFabricacion.TabIndex = 5;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(546, 232);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 27);
            txtPrecioVenta.TabIndex = 6;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Location = new Point(546, 140);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(200, 28);
            cmbCategoria.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DarkSeaGreen;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(773, 112);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(773, 153);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(426, 52);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(426, 82);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 12;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblCodigo
            // 
            lblCodigo.Location = new Point(426, 112);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 23);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código:";
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(426, 143);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(100, 23);
            lblCategoria.TabIndex = 14;
            lblCategoria.Text = "Categoría:";
            // 
            // lblStock
            // 
            lblStock.Location = new Point(426, 173);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 15;
            lblStock.Text = "Stock:";
            // 
            // lblPrecioFabricacion
            // 
            lblPrecioFabricacion.Location = new Point(426, 206);
            lblPrecioFabricacion.Name = "lblPrecioFabricacion";
            lblPrecioFabricacion.Size = new Size(114, 23);
            lblPrecioFabricacion.TabIndex = 16;
            lblPrecioFabricacion.Text = "Precio Fabricación:";
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.Location = new Point(426, 235);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(100, 23);
            lblPrecioVenta.TabIndex = 17;
            lblPrecioVenta.Text = "Precio Venta:";
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(773, 49);
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
            btnLimpiar.Location = new Point(773, 200);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 30);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cboEstado
            // 
            cboEstado.Location = new Point(836, 46);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(157, 28);
            cboEstado.TabIndex = 20;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(12, 324);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(366, 27);
            txtBusqueda.TabIndex = 21;
            // 
            // txtid
            // 
            txtid.Location = new Point(1022, 14);
            txtid.Name = "txtid";
            txtid.Size = new Size(100, 27);
            txtid.TabIndex = 22;
            txtid.Visible = false;
            // 
            // cmbCategoriaBusqueda
            // 
            cmbCategoriaBusqueda.FormattingEnabled = true;
            cmbCategoriaBusqueda.Location = new Point(574, 324);
            cmbCategoriaBusqueda.Name = "cmbCategoriaBusqueda";
            cmbCategoriaBusqueda.Size = new Size(184, 28);
            cmbCategoriaBusqueda.TabIndex = 23;
            // 
            // gbAjusteStock
            // 
            gbAjusteStock.Controls.Add(btnAnadirStock);
            gbAjusteStock.Controls.Add(numStockAnadir);
            gbAjusteStock.Location = new Point(901, 112);
            gbAjusteStock.Name = "gbAjusteStock";
            gbAjusteStock.Size = new Size(142, 117);
            gbAjusteStock.TabIndex = 25;
            gbAjusteStock.TabStop = false;
            gbAjusteStock.Text = "Añadir Stock:";
            // 
            // btnAnadirStock
            // 
            btnAnadirStock.Location = new Point(6, 61);
            btnAnadirStock.Name = "btnAnadirStock";
            btnAnadirStock.Size = new Size(86, 35);
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
            numStockAnadir.Size = new Size(86, 27);
            numStockAnadir.TabIndex = 0;
            numStockAnadir.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(646, 168);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.ReadOnly = true;
            txtStockActual.Size = new Size(100, 27);
            txtStockActual.TabIndex = 2;
            // 
            // numStockInicial
            // 
            numStockInicial.Location = new Point(546, 169);
            numStockInicial.Name = "numStockInicial";
            numStockInicial.Size = new Size(94, 27);
            numStockInicial.TabIndex = 24;
            numStockInicial.Visible = false;
            // 
            // cboBusqueda
            // 
            cboBusqueda.FormattingEnabled = true;
            cboBusqueda.Location = new Point(384, 324);
            cboBusqueda.Name = "cboBusqueda";
            cboBusqueda.Size = new Size(184, 28);
            cboBusqueda.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(574, 306);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 27;
            label1.Text = "Categoría:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(384, 306);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 28;
            label2.Text = "Buscar por:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 306);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 29;
            label3.Text = "Filtrar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 252);
            label4.Name = "label4";
            label4.Size = new Size(370, 54);
            label4.TabIndex = 30;
            label4.Text = "Lista de Productos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(36, 32);
            label5.Name = "label5";
            label5.Size = new Size(362, 46);
            label5.TabIndex = 31;
            label5.Text = "Gestión de Productos";
            // 
            // frmProducto
            // 
            ClientSize = new Size(1134, 761);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboBusqueda);
            Controls.Add(txtStockActual);
            Controls.Add(gbAjusteStock);
            Controls.Add(numStockInicial);
            Controls.Add(cmbCategoriaBusqueda);
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
        private ComboBox cmbCategoriaBusqueda;
        private GroupBox gbAjusteStock;
        private Button btnAnadirStock;
        private NumericUpDown numStockAnadir;
        private TextBox txtStockActual;
        private NumericUpDown numStockInicial;
        private ComboBox cmbCategoria;
        private ComboBox cboBusqueda;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
