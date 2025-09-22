namespace BeanDesktop
{
    partial class frmIAML
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
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            textBox2 = new TextBox();
            label4 = new Label();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            dataGridView1 = new DataGridView();
            IdCliente = new DataGridViewTextBoxColumn();
            NombreCompleto = new DataGridViewTextBoxColumn();
            FrecuenciaDeCompra = new DataGridViewTextBoxColumn();
            Segmento = new DataGridViewTextBoxColumn();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(480, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 30);
            label1.TabIndex = 2;
            label1.Text = "Segmentación de Clientes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(166, 21);
            label3.TabIndex = 4;
            label3.Text = "Cargar Datos Clientes";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 23);
            textBox1.TabIndex = 5;
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 25;
            iconButton1.Location = new Point(220, 37);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(80, 34);
            iconButton1.TabIndex = 6;
            iconButton1.Text = "Cargar";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(12, 73);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(151, 36);
            iconButton2.TabIndex = 7;
            iconButton2.Text = "Segmentar Clientes";
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 365);
            label2.Name = "label2";
            label2.Size = new Size(156, 21);
            label2.TabIndex = 8;
            label2.Text = "Cargar Datos Ventas";
            // 
            // iconButton3
            // 
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.Location = new Point(12, 428);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(142, 48);
            iconButton3.TabIndex = 11;
            iconButton3.Text = "Recomendación de productos";
            iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton4
            // 
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 25;
            iconButton4.Location = new Point(220, 392);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(80, 34);
            iconButton4.TabIndex = 10;
            iconButton4.Text = "Cargar";
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 399);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(202, 23);
            textBox2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(480, 365);
            label4.Name = "label4";
            label4.Size = new Size(299, 30);
            label4.TabIndex = 12;
            label4.Text = "Recomendación de Productos";
            // 
            // iconButton5
            // 
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            iconButton5.IconColor = Color.Black;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.IconSize = 25;
            iconButton5.Location = new Point(712, 324);
            iconButton5.Name = "iconButton5";
            iconButton5.Size = new Size(115, 38);
            iconButton5.TabIndex = 13;
            iconButton5.Text = "Descargar Documento";
            iconButton5.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton5.UseVisualStyleBackColor = true;
            // 
            // iconButton6
            // 
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.FileArrowDown;
            iconButton6.IconColor = Color.Black;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.IconSize = 25;
            iconButton6.Location = new Point(712, 611);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(115, 38);
            iconButton6.TabIndex = 14;
            iconButton6.Text = "Descargar Documento";
            iconButton6.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton6.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdCliente, NombreCompleto, FrecuenciaDeCompra, Segmento });
            dataGridView1.Location = new Point(12, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(443, 208);
            dataGridView1.TabIndex = 15;
            // 
            // IdCliente
            // 
            IdCliente.HeaderText = "Id Cliente";
            IdCliente.Name = "IdCliente";
            // 
            // NombreCompleto
            // 
            NombreCompleto.HeaderText = "Nombre";
            NombreCompleto.Name = "NombreCompleto";
            // 
            // FrecuenciaDeCompra
            // 
            FrecuenciaDeCompra.HeaderText = "Frecuencia";
            FrecuenciaDeCompra.Name = "FrecuenciaDeCompra";
            // 
            // Segmento
            // 
            Segmento.HeaderText = "Segmento";
            Segmento.Name = "Segmento";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // frmIAML
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(839, 661);
            Controls.Add(dataGridView1);
            Controls.Add(iconButton6);
            Controls.Add(iconButton5);
            Controls.Add(label4);
            Controls.Add(iconButton3);
            Controls.Add(iconButton4);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(iconButton2);
            Controls.Add(iconButton1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "frmIAML";
            Text = "frmIAML";
            Load += frmIAML_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private TextBox textBox2;
        private Label label4;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdCliente;
        private DataGridViewTextBoxColumn NombreCompleto;
        private DataGridViewTextBoxColumn FrecuenciaDeCompra;
        private DataGridViewTextBoxColumn Segmento;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}