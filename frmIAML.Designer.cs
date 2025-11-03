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
            btnSegmentar = new FontAwesome.Sharp.IconButton();
            btnDescargarCsv = new FontAwesome.Sharp.IconButton();
            dgvResultados = new DataGridView();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            pltGraficoClusters = new OxyPlot.WindowsForms.PlotView();
            numClusters = new NumericUpDown();
            lblStatusML = new Label();
            txtInsights = new TextBox();
            IdCliente = new DataGridViewTextBoxColumn();
            NombreCompleto = new DataGridViewTextBoxColumn();
            FrecuenciaDeCompra = new DataGridViewTextBoxColumn();
            Segmento = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numClusters).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(674, 24);
            label1.Name = "label1";
            label1.Size = new Size(259, 30);
            label1.TabIndex = 2;
            label1.Text = "Segmentación de Clientes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 33);
            label3.Name = "label3";
            label3.Size = new Size(114, 21);
            label3.TabIndex = 4;
            label3.Text = "Datos Clientes";
            // 
            // btnSegmentar
            // 
            btnSegmentar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSegmentar.IconColor = Color.Black;
            btnSegmentar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSegmentar.Location = new Point(12, 73);
            btnSegmentar.Name = "btnSegmentar";
            btnSegmentar.Size = new Size(151, 36);
            btnSegmentar.TabIndex = 7;
            btnSegmentar.Text = "Segmentar Clientes";
            btnSegmentar.UseVisualStyleBackColor = true;
            btnSegmentar.Click += btnSegmentar_Click;
            // 
            // btnDescargarCsv
            // 
            btnDescargarCsv.BackColor = Color.DarkGreen;
            btnDescargarCsv.FlatStyle = FlatStyle.Flat;
            btnDescargarCsv.ForeColor = SystemColors.ButtonHighlight;
            btnDescargarCsv.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            btnDescargarCsv.IconColor = Color.White;
            btnDescargarCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDescargarCsv.IconSize = 25;
            btnDescargarCsv.Location = new Point(-1, -1);
            btnDescargarCsv.Name = "btnDescargarCsv";
            btnDescargarCsv.Size = new Size(123, 38);
            btnDescargarCsv.TabIndex = 13;
            btnDescargarCsv.Text = "Descargar CSV";
            btnDescargarCsv.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDescargarCsv.UseVisualStyleBackColor = false;
            btnDescargarCsv.Click += btnDescargarCsv_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { IdCliente, NombreCompleto, FrecuenciaDeCompra, Segmento });
            dgvResultados.Location = new Point(12, 115);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(1110, 208);
            dgvResultados.TabIndex = 15;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // pltGraficoClusters
            // 
            pltGraficoClusters.Location = new Point(498, 344);
            pltGraficoClusters.Name = "pltGraficoClusters";
            pltGraficoClusters.PanCursor = Cursors.Hand;
            pltGraficoClusters.Size = new Size(624, 390);
            pltGraficoClusters.TabIndex = 20;
            pltGraficoClusters.Text = "plotView1";
            pltGraficoClusters.ZoomHorizontalCursor = Cursors.SizeWE;
            pltGraficoClusters.ZoomRectangleCursor = Cursors.SizeNWSE;
            pltGraficoClusters.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // numClusters
            // 
            numClusters.Location = new Point(169, 82);
            numClusters.Name = "numClusters";
            numClusters.Size = new Size(66, 23);
            numClusters.TabIndex = 21;
            numClusters.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblStatusML
            // 
            lblStatusML.AutoSize = true;
            lblStatusML.Location = new Point(21, 326);
            lblStatusML.Name = "lblStatusML";
            lblStatusML.Size = new Size(55, 15);
            lblStatusML.TabIndex = 22;
            lblStatusML.Text = "feedback";
            // 
            // txtInsights
            // 
            txtInsights.Location = new Point(21, 426);
            txtInsights.Multiline = true;
            txtInsights.Name = "txtInsights";
            txtInsights.ReadOnly = true;
            txtInsights.ScrollBars = ScrollBars.Vertical;
            txtInsights.Size = new Size(434, 308);
            txtInsights.TabIndex = 23;
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
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(btnDescargarCsv);
            panel1.Location = new Point(311, 344);
            panel1.Name = "panel1";
            panel1.Size = new Size(125, 40);
            panel1.TabIndex = 24;
            // 
            // frmIAML
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1134, 761);
            Controls.Add(txtInsights);
            Controls.Add(lblStatusML);
            Controls.Add(numClusters);
            Controls.Add(pltGraficoClusters);
            Controls.Add(dgvResultados);
            Controls.Add(btnSegmentar);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "frmIAML";
            Text = "frmIAML";
            Load += frmIAML_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ((System.ComponentModel.ISupportInitialize)numClusters).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnSegmentar;
        private FontAwesome.Sharp.IconButton btnDescargarCsv;
        private DataGridView dgvResultados;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private OxyPlot.WindowsForms.PlotView pltGraficoClusters;
        private NumericUpDown numClusters;
        private Label lblStatusML;
        private TextBox txtInsights;
        private DataGridViewTextBoxColumn IdCliente;
        private DataGridViewTextBoxColumn NombreCompleto;
        private DataGridViewTextBoxColumn FrecuenciaDeCompra;
        private DataGridViewTextBoxColumn Segmento;
        private Panel panel1;
    }
}