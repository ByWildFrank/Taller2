namespace BeanDesktop
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private OxyPlot.WindowsForms.PlotView chartVentas;
        private OxyPlot.WindowsForms.PlotView chartGanancias;
        private OxyPlot.WindowsForms.PlotView chartClientes;
        private OxyPlot.WindowsForms.PlotView chartUsuarios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartVentas = new OxyPlot.WindowsForms.PlotView();
            this.chartGanancias = new OxyPlot.WindowsForms.PlotView();
            this.chartClientes = new OxyPlot.WindowsForms.PlotView();
            this.chartUsuarios = new OxyPlot.WindowsForms.PlotView();

            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(this.chartVentas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartGanancias, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartClientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartUsuarios, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;

            // 
            // chartVentas
            // 
            this.chartVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVentas.Location = new System.Drawing.Point(3, 3);
            this.chartVentas.Name = "chartVentas";
            this.chartVentas.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.chartVentas.Size = new System.Drawing.Size(394, 294);
            this.chartVentas.TabIndex = 0;

            // 
            // chartGanancias
            // 
            this.chartGanancias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGanancias.Location = new System.Drawing.Point(403, 3);
            this.chartGanancias.Name = "chartGanancias";
            this.chartGanancias.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.chartGanancias.Size = new System.Drawing.Size(394, 294);
            this.chartGanancias.TabIndex = 1;

            // 
            // chartClientes
            // 
            this.chartClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartClientes.Location = new System.Drawing.Point(3, 303);
            this.chartClientes.Name = "chartClientes";
            this.chartClientes.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.chartClientes.Size = new System.Drawing.Size(394, 294);
            this.chartClientes.TabIndex = 2;

            // 
            // chartUsuarios
            // 
            this.chartUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartUsuarios.Location = new System.Drawing.Point(403, 303);
            this.chartUsuarios.Name = "chartUsuarios";
            this.chartUsuarios.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.chartUsuarios.Size = new System.Drawing.Size(394, 294);
            this.chartUsuarios.TabIndex = 3;

            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);

            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
