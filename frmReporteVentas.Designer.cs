namespace BeanDesktop
{
    partial class frmReporteVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            color = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dgvdata = new DataGridView();
            FechaRegistro = new DataGridViewTextBoxColumn();
            HoraRegistro = new DataGridViewTextBoxColumn();
            TipoDocumento = new DataGridViewTextBoxColumn();
            NumeroDocumento = new DataGridViewTextBoxColumn();
            DocumentoCliente = new DataGridViewTextBoxColumn();
            NombreCliente = new DataGridViewTextBoxColumn();
            MontoTotal = new DataGridViewTextBoxColumn();
            MontoPago = new DataGridViewTextBoxColumn();
            MontoCambio = new DataGridViewTextBoxColumn();
            DescuentoAplicado = new DataGridViewTextBoxColumn();
            UsuarioRegistro = new DataGridViewTextBoxColumn();
            CodigoProducto = new DataGridViewTextBoxColumn();
            NombreProducto = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            GananciaBruta = new DataGridViewTextBoxColumn();
            CostoUnitario = new DataGridViewTextBoxColumn();
            exportarExelButton = new FontAwesome.Sharp.IconButton();
            label5 = new Label();
            cbobusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            btnLimpiarBuscador = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // dtpInicio
            // 
            dtpInicio.CustomFormat = "dd/MM/yyyy";
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(92, 58);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(137, 23);
            dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            dtpFin.CustomFormat = "dd/MM/yyyy";
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(306, 58);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(137, 23);
            dtpFin.TabIndex = 1;
            // 
            // color
            // 
            color.BackColor = Color.WhiteSmoke;
            color.ForeColor = Color.WhiteSmoke;
            color.Location = new Point(-1, -2);
            color.Name = "color";
            color.Size = new Size(1134, 102);
            color.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(189, 30);
            label1.TabIndex = 3;
            label1.Text = "Reporte de Ventas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Location = new Point(16, 62);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 4;
            label2.Text = "Fecha Inicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Location = new Point(243, 62);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Fecha Fin";
            // 
            // label4
            // 
            label4.BackColor = Color.WhiteSmoke;
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(-1, 149);
            label4.Name = "label4";
            label4.Size = new Size(1134, 497);
            label4.TabIndex = 6;
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToDeleteRows = false;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { FechaRegistro, HoraRegistro, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoTotal, MontoPago, MontoCambio, DescuentoAplicado, UsuarioRegistro, CodigoProducto, NombreProducto, Categoria, PrecioVenta, Cantidad, Subtotal, GananciaBruta, CostoUnitario });
            dgvdata.Location = new Point(-1, 220);
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.Size = new Size(1134, 539);
            dgvdata.TabIndex = 7;
            // 
            // FechaRegistro
            // 
            FechaRegistro.HeaderText = "FechaRegistro";
            FechaRegistro.Name = "FechaRegistro";
            FechaRegistro.ReadOnly = true;
            // 
            // HoraRegistro
            // 
            HoraRegistro.HeaderText = "HoraRegistro";
            HoraRegistro.Name = "HoraRegistro";
            HoraRegistro.ReadOnly = true;
            HoraRegistro.Visible = false;
            // 
            // TipoDocumento
            // 
            TipoDocumento.HeaderText = "Tipo Documento";
            TipoDocumento.Name = "TipoDocumento";
            TipoDocumento.ReadOnly = true;
            // 
            // NumeroDocumento
            // 
            NumeroDocumento.HeaderText = "Numero Documento";
            NumeroDocumento.Name = "NumeroDocumento";
            NumeroDocumento.ReadOnly = true;
            // 
            // DocumentoCliente
            // 
            DocumentoCliente.HeaderText = "Documento Cliente";
            DocumentoCliente.Name = "DocumentoCliente";
            DocumentoCliente.ReadOnly = true;
            DocumentoCliente.Visible = false;
            // 
            // NombreCliente
            // 
            NombreCliente.HeaderText = "Nombre Cliente";
            NombreCliente.Name = "NombreCliente";
            NombreCliente.ReadOnly = true;
            // 
            // MontoTotal
            // 
            MontoTotal.HeaderText = "Monto Total";
            MontoTotal.Name = "MontoTotal";
            MontoTotal.ReadOnly = true;
            // 
            // MontoPago
            // 
            MontoPago.HeaderText = "Monto Pago";
            MontoPago.Name = "MontoPago";
            MontoPago.ReadOnly = true;
            MontoPago.Visible = false;
            // 
            // MontoCambio
            // 
            MontoCambio.HeaderText = "Monto Cambio";
            MontoCambio.Name = "MontoCambio";
            MontoCambio.ReadOnly = true;
            MontoCambio.Visible = false;
            // 
            // DescuentoAplicado
            // 
            DescuentoAplicado.HeaderText = "Descuento Aplicado";
            DescuentoAplicado.Name = "DescuentoAplicado";
            DescuentoAplicado.ReadOnly = true;
            DescuentoAplicado.Visible = false;
            // 
            // UsuarioRegistro
            // 
            UsuarioRegistro.HeaderText = "Usuario a cargo";
            UsuarioRegistro.Name = "UsuarioRegistro";
            UsuarioRegistro.ReadOnly = true;
            // 
            // CodigoProducto
            // 
            CodigoProducto.HeaderText = "Codigo Producto";
            CodigoProducto.Name = "CodigoProducto";
            CodigoProducto.ReadOnly = true;
            // 
            // NombreProducto
            // 
            NombreProducto.HeaderText = "Nombre Producto";
            NombreProducto.Name = "NombreProducto";
            NombreProducto.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoria";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            PrecioVenta.HeaderText = "PrecioVenta";
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            // 
            // GananciaBruta
            // 
            GananciaBruta.HeaderText = "Ganancia Bruta";
            GananciaBruta.Name = "GananciaBruta";
            GananciaBruta.ReadOnly = true;
            // 
            // CostoUnitario
            // 
            CostoUnitario.HeaderText = "Costo Unitario";
            CostoUnitario.Name = "CostoUnitario";
            CostoUnitario.ReadOnly = true;
            // 
            // exportarExelButton
            // 
            exportarExelButton.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            exportarExelButton.IconColor = Color.Green;
            exportarExelButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            exportarExelButton.IconSize = 35;
            exportarExelButton.Location = new Point(16, 162);
            exportarExelButton.Name = "exportarExelButton";
            exportarExelButton.Size = new Size(141, 40);
            exportarExelButton.TabIndex = 8;
            exportarExelButton.Text = "Exportar en Exel";
            exportarExelButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            exportarExelButton.UseVisualStyleBackColor = true;
            exportarExelButton.Click += exportarExelButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.WhiteSmoke;
            label5.Location = new Point(598, 176);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 9;
            label5.Text = "Buscar por:";
            // 
            // cbobusqueda
            // 
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(670, 172);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(121, 23);
            cbobusqueda.TabIndex = 10;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(797, 171);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(189, 23);
            txtBusqueda.TabIndex = 25;
            // 
            // btnLimpiarBuscador
            // 
            btnLimpiarBuscador.BackColor = Color.AliceBlue;
            btnLimpiarBuscador.Cursor = Cursors.Hand;
            btnLimpiarBuscador.FlatAppearance.BorderColor = Color.Black;
            btnLimpiarBuscador.FlatStyle = FlatStyle.Flat;
            btnLimpiarBuscador.ForeColor = Color.White;
            btnLimpiarBuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnLimpiarBuscador.IconColor = Color.Black;
            btnLimpiarBuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiarBuscador.IconSize = 16;
            btnLimpiarBuscador.Location = new Point(1040, 171);
            btnLimpiarBuscador.Name = "btnLimpiarBuscador";
            btnLimpiarBuscador.Size = new Size(42, 23);
            btnLimpiarBuscador.TabIndex = 28;
            btnLimpiarBuscador.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiarBuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiarBuscador.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.LightCyan;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderColor = Color.Black;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 16;
            btnBuscar.Location = new Point(992, 171);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(42, 23);
            btnBuscar.TabIndex = 27;
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // frmReporteVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 761);
            Controls.Add(btnLimpiarBuscador);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label5);
            Controls.Add(exportarExelButton);
            Controls.Add(dgvdata);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(color);
            Name = "frmReporteVentas";
            Text = "frmReporteVentas";
            Load += frmReporteVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Label color;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvdata;
        private DataGridViewTextBoxColumn FechaRegistro;
        private DataGridViewTextBoxColumn HoraRegistro;
        private DataGridViewTextBoxColumn TipoDocumento;
        private DataGridViewTextBoxColumn NumeroDocumento;
        private DataGridViewTextBoxColumn DocumentoCliente;
        private DataGridViewTextBoxColumn NombreCliente;
        private DataGridViewTextBoxColumn MontoTotal;
        private DataGridViewTextBoxColumn MontoPago;
        private DataGridViewTextBoxColumn MontoCambio;
        private DataGridViewTextBoxColumn DescuentoAplicado;
        private DataGridViewTextBoxColumn UsuarioRegistro;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn NombreProducto;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn GananciaBruta;
        private DataGridViewTextBoxColumn CostoUnitario;
        private FontAwesome.Sharp.IconButton exportarExelButton;
        private Label label5;
        private ComboBox cbobusqueda;
        private TextBox txtBusqueda;
        private FontAwesome.Sharp.IconButton btnLimpiarBuscador;
        private FontAwesome.Sharp.IconButton btnBuscar;
    }
}