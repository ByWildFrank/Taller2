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
            txtStock = new TextBox();
            txtPrecioFabricacion = new TextBox();
            txtPrecioVenta = new TextBox();
            cmbCategoria = new ComboBox();
            chkEstado = new CheckBox();
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
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            txtNombre.Location = new Point(120, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 42);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(120, 72);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 23);
            txtCodigo.TabIndex = 3;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(120, 132);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 4;
            // 
            // txtPrecioFabricacion
            // 
            txtPrecioFabricacion.Location = new Point(120, 162);
            txtPrecioFabricacion.Name = "txtPrecioFabricacion";
            txtPrecioFabricacion.Size = new Size(100, 23);
            txtPrecioFabricacion.TabIndex = 5;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(120, 192);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(100, 23);
            txtPrecioVenta.TabIndex = 6;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Location = new Point(120, 102);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(200, 23);
            cmbCategoria.TabIndex = 7;
            // 
            // chkEstado
            // 
            chkEstado.Location = new Point(375, 12);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(104, 24);
            chkEstado.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(280, 135);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(280, 188);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(12, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(12, 45);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 12;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblCodigo
            // 
            lblCodigo.Location = new Point(12, 75);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 23);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código:";
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(12, 105);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(100, 23);
            lblCategoria.TabIndex = 14;
            lblCategoria.Text = "Categoría:";
            // 
            // lblStock
            // 
            lblStock.Location = new Point(12, 135);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 15;
            lblStock.Text = "Stock:";
            // 
            // lblPrecioFabricacion
            // 
            lblPrecioFabricacion.Location = new Point(12, 165);
            lblPrecioFabricacion.Name = "lblPrecioFabricacion";
            lblPrecioFabricacion.Size = new Size(100, 23);
            lblPrecioFabricacion.TabIndex = 16;
            lblPrecioFabricacion.Text = "Precio Fabricación:";
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.Location = new Point(12, 195);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(100, 23);
            lblPrecioVenta.TabIndex = 17;
            lblPrecioVenta.Text = "Precio Venta:";
            // 
            // lblEstado
            // 
            lblEstado.Location = new Point(326, 15);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(100, 23);
            lblEstado.TabIndex = 18;
            lblEstado.Text = "Estado:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // frmProducto
            // 
            ClientSize = new Size(974, 562);
            Controls.Add(dgvProductos);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(txtCodigo);
            Controls.Add(txtStock);
            Controls.Add(txtPrecioFabricacion);
            Controls.Add(txtPrecioVenta);
            Controls.Add(cmbCategoria);
            Controls.Add(chkEstado);
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
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.CheckBox chkEstado;
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
    }
}
