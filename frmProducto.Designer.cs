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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecioFabricacion = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecioFabricacion = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 250);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(950, 300);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // 
            // Labels y TextBoxes
            // 
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(12, 15);
            this.txtNombre.Location = new System.Drawing.Point(120, 12);
            this.txtNombre.Size = new System.Drawing.Size(200, 22);

            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Location = new System.Drawing.Point(12, 45);
            this.txtDescripcion.Location = new System.Drawing.Point(120, 42);
            this.txtDescripcion.Size = new System.Drawing.Size(200, 22);

            this.lblCodigo.Text = "Código:";
            this.lblCodigo.Location = new System.Drawing.Point(12, 75);
            this.txtCodigo.Location = new System.Drawing.Point(120, 72);
            this.txtCodigo.Size = new System.Drawing.Size(200, 22);

            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.Location = new System.Drawing.Point(12, 105);
            this.cmbCategoria.Location = new System.Drawing.Point(120, 102);
            this.cmbCategoria.Size = new System.Drawing.Size(200, 24);

            this.lblStock.Text = "Stock:";
            this.lblStock.Location = new System.Drawing.Point(12, 135);
            this.txtStock.Location = new System.Drawing.Point(120, 132);
            this.txtStock.Size = new System.Drawing.Size(100, 22);

            this.lblPrecioFabricacion.Text = "Precio Fabricación:";
            this.lblPrecioFabricacion.Location = new System.Drawing.Point(12, 165);
            this.txtPrecioFabricacion.Location = new System.Drawing.Point(150, 162);
            this.txtPrecioFabricacion.Size = new System.Drawing.Size(100, 22);

            this.lblPrecioVenta.Text = "Precio Venta:";
            this.lblPrecioVenta.Location = new System.Drawing.Point(12, 195);
            this.txtPrecioVenta.Location = new System.Drawing.Point(120, 192);
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 22);

            this.lblEstado.Text = "Estado:";
            this.lblEstado.Location = new System.Drawing.Point(300, 12);
            this.chkEstado.Location = new System.Drawing.Point(350, 10);

            // 
            // Buttons
            // 
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(300, 50);
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(300, 90);
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // 
            // frmProducto
            // 
            this.ClientSize = new System.Drawing.Size(974, 562);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrecioFabricacion);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrecioFabricacion);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblEstado);

            this.Name = "frmProducto";
            this.Text = "Gestión de Productos";
            this.Load += new System.EventHandler(this.frmProducto_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}
