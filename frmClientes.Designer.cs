namespace BeanDesktop
{
    partial class frmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            lblDocumento = new Label();
            lblNombreCompleto = new Label();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblEstado = new Label();
            txtDocumento = new TextBox();
            txtNombreCompleto = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            cboEstado = new ComboBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvClientes = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            IdCliente = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            NombreCompleto = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            groupBoxDatos = new GroupBox();
            txtid = new TextBox();
            txtindice = new TextBox();
            groupBoxBusqueda = new GroupBox();
            cboBusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnLimpiarBuscador = new Button();
            btnLimpiar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            groupBoxDatos.SuspendLayout();
            groupBoxBusqueda.SuspendLayout();
            SuspendLayout();
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(20, 33);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(81, 15);
            lblDocumento.TabIndex = 0;
            lblDocumento.Text = "Documento *:";
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Location = new Point(6, 70);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(118, 15);
            lblNombreCompleto.TabIndex = 2;
            lblNombreCompleto.Text = "Nombre Completo *:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(40, 110);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(54, 15);
            lblCorreo.TabIndex = 4;
            lblCorreo.Text = "Correo *:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(40, 150);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(63, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono *:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(40, 190);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 8;
            lblEstado.Text = "Estado:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(158, 27);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(200, 23);
            txtDocumento.TabIndex = 1;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(158, 67);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(200, 23);
            txtNombreCompleto.TabIndex = 3;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(158, 103);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 23);
            txtCorreo.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(158, 147);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 7;
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(158, 187);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(200, 23);
            cboEstado.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.SeaGreen;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(40, 230);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Firebrick;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(180, 230);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, IdCliente, Documento, NombreCompleto, Correo, Telefono, EstadoValor, Estado });
            dgvClientes.Location = new Point(390, 100);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(700, 300);
            dgvClientes.TabIndex = 12;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.MinimumWidth = 6;
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.ReadOnly = true;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseColumnTextForButtonValue = true;
            btnSeleccionar.Width = 80;
            // 
            // IdCliente
            // 
            IdCliente.HeaderText = "IdCliente";
            IdCliente.MinimumWidth = 6;
            IdCliente.Name = "IdCliente";
            IdCliente.ReadOnly = true;
            IdCliente.Visible = false;
            IdCliente.Width = 125;
            // 
            // Documento
            // 
            Documento.HeaderText = "Documento";
            Documento.MinimumWidth = 6;
            Documento.Name = "Documento";
            Documento.ReadOnly = true;
            Documento.Width = 125;
            // 
            // NombreCompleto
            // 
            NombreCompleto.HeaderText = "Nombre Completo";
            NombreCompleto.MinimumWidth = 6;
            NombreCompleto.Name = "NombreCompleto";
            NombreCompleto.ReadOnly = true;
            NombreCompleto.Width = 125;
            // 
            // Correo
            // 
            Correo.HeaderText = "Correo";
            Correo.MinimumWidth = 6;
            Correo.Name = "Correo";
            Correo.ReadOnly = true;
            Correo.Width = 125;
            // 
            // Telefono
            // 
            Telefono.HeaderText = "Teléfono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            Telefono.Width = 125;
            // 
            // EstadoValor
            // 
            EstadoValor.HeaderText = "EstadoValor";
            EstadoValor.MinimumWidth = 6;
            EstadoValor.Name = "EstadoValor";
            EstadoValor.ReadOnly = true;
            EstadoValor.Visible = false;
            EstadoValor.Width = 125;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            Estado.Width = 125;
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.BackColor = SystemColors.ButtonFace;
            groupBoxDatos.Controls.Add(lblDocumento);
            groupBoxDatos.Controls.Add(txtDocumento);
            groupBoxDatos.Controls.Add(lblNombreCompleto);
            groupBoxDatos.Controls.Add(txtNombreCompleto);
            groupBoxDatos.Controls.Add(lblCorreo);
            groupBoxDatos.Controls.Add(txtCorreo);
            groupBoxDatos.Controls.Add(lblTelefono);
            groupBoxDatos.Controls.Add(txtTelefono);
            groupBoxDatos.Controls.Add(lblEstado);
            groupBoxDatos.Controls.Add(cboEstado);
            groupBoxDatos.Controls.Add(btnGuardar);
            groupBoxDatos.Controls.Add(btnEliminar);
            groupBoxDatos.Location = new Point(20, 20);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(364, 300);
            groupBoxDatos.TabIndex = 0;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "Datos del Cliente";
            // 
            // txtid
            // 
            txtid.Location = new Point(0, 0);
            txtid.Name = "txtid";
            txtid.Size = new Size(100, 23);
            txtid.TabIndex = 14;
            txtid.Text = "0";
            txtid.Visible = false;
            // 
            // txtindice
            // 
            txtindice.Location = new Point(0, 0);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(100, 23);
            txtindice.TabIndex = 15;
            txtindice.Text = "-1";
            txtindice.Visible = false;
            // 
            // groupBoxBusqueda
            // 
            groupBoxBusqueda.Controls.Add(cboBusqueda);
            groupBoxBusqueda.Controls.Add(txtBusqueda);
            groupBoxBusqueda.Controls.Add(btnBuscar);
            groupBoxBusqueda.Controls.Add(btnLimpiarBuscador);
            groupBoxBusqueda.Location = new Point(390, 20);
            groupBoxBusqueda.Name = "groupBoxBusqueda";
            groupBoxBusqueda.Size = new Size(700, 70);
            groupBoxBusqueda.TabIndex = 13;
            groupBoxBusqueda.TabStop = false;
            groupBoxBusqueda.Text = "Búsqueda";
            // 
            // cboBusqueda
            // 
            cboBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBusqueda.Location = new Point(20, 30);
            cboBusqueda.Name = "cboBusqueda";
            cboBusqueda.Size = new Size(150, 23);
            cboBusqueda.TabIndex = 0;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(180, 30);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(200, 23);
            txtBusqueda.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(400, 28);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 25);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiarBuscador
            // 
            btnLimpiarBuscador.Location = new Point(490, 28);
            btnLimpiarBuscador.Name = "btnLimpiarBuscador";
            btnLimpiarBuscador.Size = new Size(80, 25);
            btnLimpiarBuscador.TabIndex = 3;
            btnLimpiarBuscador.Text = "Limpiar";
            btnLimpiarBuscador.UseVisualStyleBackColor = true;
            btnLimpiarBuscador.Click += btnLimpiarBuscador_Click;
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
            btnLimpiar.Location = new Point(131, 326);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 26);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // frmClientes
            // 
            ClientSize = new Size(1120, 420);
            Controls.Add(btnLimpiar);
            Controls.Add(groupBoxDatos);
            Controls.Add(groupBoxBusqueda);
            Controls.Add(dgvClientes);
            Controls.Add(txtid);
            Controls.Add(txtindice);
            Name = "frmClientes";
            Text = "Gestión de Clientes";
            Load += frmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            groupBoxBusqueda.ResumeLayout(false);
            groupBoxBusqueda.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEstado;

        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;

        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;

        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.GroupBox groupBoxBusqueda;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarBuscador;

        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtindice;
        private FontAwesome.Sharp.IconButton btnLimpiar;
    }
}
