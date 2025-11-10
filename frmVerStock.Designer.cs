namespace BeanDesktop
{
    partial class frmVerStock
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblBuscar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStock = new DataGridView();
            cmbCategoria = new ComboBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            lblCategoria = new Label();
            lblBuscar = new Label();
            chkOrdenarPorStock = new CheckBox();
            exportarExelButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(12, 70);
            dgvStock.MultiSelect = false;
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersWidth = 51;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(1110, 680);
            dgvStock.TabIndex = 0;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(103, 23);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(180, 23);
            cmbCategoria.TabIndex = 1;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(347, 24);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(180, 23);
            txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(547, 23);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 25);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(30, 27);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoría:";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(287, 27);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(54, 15);
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "Nombre:";
            // 
            // chkOrdenarPorStock
            // 
            chkOrdenarPorStock.AutoSize = true;
            chkOrdenarPorStock.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkOrdenarPorStock.Location = new Point(637, 26);
            chkOrdenarPorStock.Name = "chkOrdenarPorStock";
            chkOrdenarPorStock.Size = new Size(285, 21);
            chkOrdenarPorStock.TabIndex = 6;
            chkOrdenarPorStock.Text = "Mostrar productos con bajo stock primero";
            chkOrdenarPorStock.UseVisualStyleBackColor = true;
            chkOrdenarPorStock.CheckedChanged += chkOrdenarPorStock_CheckedChanged;
            // 
            // exportarExelButton
            // 
            exportarExelButton.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            exportarExelButton.IconColor = Color.Green;
            exportarExelButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            exportarExelButton.IconSize = 35;
            exportarExelButton.Location = new Point(958, 15);
            exportarExelButton.Name = "exportarExelButton";
            exportarExelButton.Size = new Size(141, 40);
            exportarExelButton.TabIndex = 9;
            exportarExelButton.Text = "Exportar en Exel";
            exportarExelButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            exportarExelButton.UseVisualStyleBackColor = true;
            exportarExelButton.Click += exportarExelButton_Click;
            // 
            // frmVerStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1134, 761);
            Controls.Add(exportarExelButton);
            Controls.Add(chkOrdenarPorStock);
            Controls.Add(lblBuscar);
            Controls.Add(lblCategoria);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(cmbCategoria);
            Controls.Add(dgvStock);
            Name = "frmVerStock";
            Text = "Ver Stock de Productos";
            Load += frmStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private CheckBox chkOrdenarPorStock;
        private FontAwesome.Sharp.IconButton exportarExelButton;
    }
}
