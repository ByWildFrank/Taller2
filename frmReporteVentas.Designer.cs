namespace BeanDesktop
{
    partial class frmReporteVentas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            btnLimpiarBuscador = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            txtbusqueda = new TextBox();

            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();

            // --- Evita que el diseñador ejecute eventos ---
            bool enDiseño = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");

            // dtpInicio
            dtpInicio.CustomFormat = "dd/MM/yyyy";
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(105, 77);
            dtpInicio.Margin = new Padding(3, 4, 3, 4);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(156, 27);
            dtpInicio.TabIndex = 0;
          
                dtpInicio.ValueChanged += dtpInicio_ValueChanged;
   

            // dtpFin
            dtpFin.CustomFormat = "dd/MM/yyyy";
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(350, 77);
            dtpFin.Margin = new Padding(3, 4, 3, 4);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(156, 27);
            dtpFin.TabIndex = 1;
            
                dtpFin.ValueChanged += dtpFin_ValueChanged;
     
            // color
            color.BackColor = Color.WhiteSmoke;
            color.ForeColor = Color.WhiteSmoke;
            color.Location = new Point(-1, -3);
            color.Name = "color";
            color.Size = new Size(1296, 237);
            color.TabIndex = 2;

            // label1
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(239, 37);
            label1.TabIndex = 3;
            label1.Text = "Reporte de Ventas";

            // label2
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Location = new Point(18, 83);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 4;
            label2.Text = "Fecha Inicio";

            // label3
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Location = new Point(278, 83);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Fecha Fin";

            // label4
            label4.BackColor = Color.WhiteSmoke;
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(-1, 255);
            label4.Name = "label4";
            label4.Size = new Size(1296, 607);
            label4.TabIndex = 6;

            // dgvdata
            dgvdata.AllowUserToDeleteRows = false;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] {
                FechaRegistro, HoraRegistro, TipoDocumento, NumeroDocumento, DocumentoCliente,
                NombreCliente, MontoTotal, MontoPago, MontoCambio, DescuentoAplicado, UsuarioRegistro,
                CodigoProducto, NombreProducto, Categoria, PrecioVenta, Cantidad, Subtotal,
                GananciaBruta, CostoUnitario
            });
            dgvdata.Location = new Point(-1, 231);
            dgvdata.Margin = new Padding(3, 4, 3, 4);
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(1296, 781);
            dgvdata.TabIndex = 7;

            // exportarExelButton
            exportarExelButton.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            exportarExelButton.IconColor = Color.Green;
            exportarExelButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            exportarExelButton.IconSize = 35;
            exportarExelButton.Location = new Point(18, 170);
            exportarExelButton.Margin = new Padding(3, 4, 3, 4);
            exportarExelButton.Name = "exportarExelButton";
            exportarExelButton.Size = new Size(161, 53);
            exportarExelButton.TabIndex = 8;
            exportarExelButton.Text = "Exportar en Exel";
            exportarExelButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            exportarExelButton.UseVisualStyleBackColor = true;
            
                exportarExelButton.Click += exportarExelButton_Click;
          
            // label5
            label5.AutoSize = true;
            label5.BackColor = Color.WhiteSmoke;
            label5.Location = new Point(579, 186);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 9;
            label5.Text = "Buscar por:";

            // cbobusqueda
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(667, 184);
            cbobusqueda.Margin = new Padding(3, 4, 3, 4);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(138, 28);
            cbobusqueda.TabIndex = 10;

            // btnLimpiarBuscador
            btnLimpiarBuscador.BackColor = Color.AliceBlue;
            btnLimpiarBuscador.Cursor = Cursors.Hand;
            btnLimpiarBuscador.FlatAppearance.BorderColor = Color.Black;
            btnLimpiarBuscador.FlatStyle = FlatStyle.Flat;
            btnLimpiarBuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnLimpiarBuscador.IconColor = Color.Black;
            btnLimpiarBuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiarBuscador.IconSize = 16;
            btnLimpiarBuscador.Location = new Point(1191, 180);
            btnLimpiarBuscador.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarBuscador.Name = "btnLimpiarBuscador";
            btnLimpiarBuscador.Size = new Size(48, 31);
            btnLimpiarBuscador.TabIndex = 28;
            btnLimpiarBuscador.UseVisualStyleBackColor = false;
            
            btnLimpiarBuscador.Click += btnLimpiarBuscador_Click;
 

            // btnBuscar
            btnBuscar.BackColor = Color.LightCyan;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderColor = Color.Black;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 16;
            btnBuscar.Location = new Point(1137, 181);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(48, 31);
            btnBuscar.TabIndex = 27;
            btnBuscar.UseVisualStyleBackColor = false;
            
            btnBuscar.Click += btnBuscar_Click;
     

            // txtbusqueda
            txtbusqueda.Location = new Point(828, 183);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.Size = new Size(189, 27);
            txtbusqueda.TabIndex = 25;
      

            // frmReporteVentas
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 1015);
            Controls.Add(txtbusqueda);
            Controls.Add(btnLimpiarBuscador);
            Controls.Add(btnBuscar);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmReporteVentas";
            Text = "frmReporteVentas";

         
                Load += frmReporteVentas_Load;

            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbusqueda;
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
        private FontAwesome.Sharp.IconButton btnLimpiarBuscador;
        private FontAwesome.Sharp.IconButton btnBuscar;
    }
}
