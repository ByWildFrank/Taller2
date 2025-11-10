namespace BeanDesktop
{
    partial class frmDescuentos
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
            dgvSegmentos = new DataGridView();
            Segmento = new DataGridViewTextBoxColumn();
            DescuentoPorcent = new DataGridViewTextBoxColumn();
            txtSegmento = new TextBox();
            numDescuento = new NumericUpDown();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvSegmentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDescuento).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSegmentos
            // 
            dgvSegmentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSegmentos.Columns.AddRange(new DataGridViewColumn[] { Segmento, DescuentoPorcent });
            dgvSegmentos.Location = new Point(104, 311);
            dgvSegmentos.Margin = new Padding(3, 4, 3, 4);
            dgvSegmentos.Name = "dgvSegmentos";
            dgvSegmentos.RowHeadersWidth = 51;
            dgvSegmentos.Size = new Size(569, 557);
            dgvSegmentos.TabIndex = 0;
            dgvSegmentos.CellClick += dgvSegmentos_CellClick;
            // 
            // Segmento
            // 
            Segmento.DataPropertyName = "Segmento";
            Segmento.HeaderText = "Segmento";
            Segmento.MinimumWidth = 150;
            Segmento.Name = "Segmento";
            Segmento.ReadOnly = true;
            Segmento.Width = 275;
            // 
            // DescuentoPorcent
            // 
            DescuentoPorcent.DataPropertyName = "DescuentoPorcent";
            DescuentoPorcent.HeaderText = "Descuento (%)";
            DescuentoPorcent.MinimumWidth = 6;
            DescuentoPorcent.Name = "DescuentoPorcent";
            DescuentoPorcent.ReadOnly = true;
            DescuentoPorcent.Width = 180;
            // 
            // txtSegmento
            // 
            txtSegmento.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSegmento.Location = new Point(0, -1);
            txtSegmento.Margin = new Padding(3, 4, 3, 4);
            txtSegmento.Name = "txtSegmento";
            txtSegmento.ReadOnly = true;
            txtSegmento.Size = new Size(241, 34);
            txtSegmento.TabIndex = 1;
            // 
            // numDescuento
            // 
            numDescuento.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numDescuento.Location = new Point(0, 0);
            numDescuento.Margin = new Padding(3, 4, 3, 4);
            numDescuento.Name = "numDescuento";
            numDescuento.Size = new Size(137, 34);
            numDescuento.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 30;
            btnGuardar.Location = new Point(546, 208);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(127, 48);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 84);
            label1.Name = "label1";
            label1.Size = new Size(542, 41);
            label1.TabIndex = 4;
            label1.Text = "Editar Descuentos a Tipos de Clientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(104, 187);
            label2.Name = "label2";
            label2.Size = new Size(92, 23);
            label2.TabIndex = 5;
            label2.Text = "Segmento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(375, 187);
            label3.Name = "label3";
            label3.Size = new Size(144, 23);
            label3.TabIndex = 6;
            label3.Text = "Editar Descuento:";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonShadow;
            panel3.Location = new Point(546, 208);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(129, 51);
            panel3.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(txtSegmento);
            panel1.Location = new Point(104, 213);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(243, 41);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Controls.Add(numDescuento);
            panel2.Location = new Point(375, 213);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(139, 41);
            panel2.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonShadow;
            panel4.Location = new Point(97, 77);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(549, 63);
            panel4.TabIndex = 16;
            // 
            // frmDescuentos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 1015);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnGuardar);
            Controls.Add(dgvSegmentos);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDescuentos";
            Text = "frmDescuentos";
            Load += frmDescuentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSegmentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDescuento).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSegmentos;
        private TextBox txtSegmento;
        private NumericUpDown numDescuento;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label1;
        private DataGridViewTextBoxColumn Segmento;
        private DataGridViewTextBoxColumn DescuentoPorcent;
        private Label label2;
        private Label label3;
        private Panel panel3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
    }
}