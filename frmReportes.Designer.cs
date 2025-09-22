namespace BeanDesktop
{
    partial class FrmReportes
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
            tableLayoutPanel1 = new TableLayoutPanel();
            chartVentas = new OxyPlot.WindowsForms.PlotView();
            chartGanancias = new OxyPlot.WindowsForms.PlotView();
            chartClientes = new OxyPlot.WindowsForms.PlotView();
            chartUsuarios = new OxyPlot.WindowsForms.PlotView();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(chartVentas, 0, 0);
            tableLayoutPanel1.Controls.Add(chartGanancias, 1, 0);
            tableLayoutPanel1.Controls.Add(chartClientes, 0, 1);
            tableLayoutPanel1.Controls.Add(chartUsuarios, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 750);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // chartVentas
            // 
            chartVentas.BackColor = SystemColors.AppWorkspace;
            chartVentas.Dock = DockStyle.Fill;
            chartVentas.Location = new Point(3, 4);
            chartVentas.Margin = new Padding(3, 4, 3, 4);
            chartVentas.Name = "chartVentas";
            chartVentas.PanCursor = Cursors.Hand;
            chartVentas.Size = new Size(394, 367);
            chartVentas.TabIndex = 0;
            chartVentas.ZoomHorizontalCursor = Cursors.SizeWE;
            chartVentas.ZoomRectangleCursor = Cursors.SizeNWSE;
            chartVentas.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // chartGanancias
            // 
            chartGanancias.BackColor = SystemColors.AppWorkspace;
            chartGanancias.Dock = DockStyle.Fill;
            chartGanancias.Location = new Point(403, 4);
            chartGanancias.Margin = new Padding(3, 4, 3, 4);
            chartGanancias.Name = "chartGanancias";
            chartGanancias.PanCursor = Cursors.Hand;
            chartGanancias.Size = new Size(394, 367);
            chartGanancias.TabIndex = 1;
            chartGanancias.ZoomHorizontalCursor = Cursors.SizeWE;
            chartGanancias.ZoomRectangleCursor = Cursors.SizeNWSE;
            chartGanancias.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // chartClientes
            // 
            chartClientes.BackColor = SystemColors.AppWorkspace;
            chartClientes.Dock = DockStyle.Fill;
            chartClientes.Location = new Point(3, 379);
            chartClientes.Margin = new Padding(3, 4, 3, 4);
            chartClientes.Name = "chartClientes";
            chartClientes.PanCursor = Cursors.Hand;
            chartClientes.Size = new Size(394, 367);
            chartClientes.TabIndex = 2;
            chartClientes.ZoomHorizontalCursor = Cursors.SizeWE;
            chartClientes.ZoomRectangleCursor = Cursors.SizeNWSE;
            chartClientes.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // chartUsuarios
            // 
            chartUsuarios.BackColor = SystemColors.AppWorkspace;
            chartUsuarios.Dock = DockStyle.Fill;
            chartUsuarios.ForeColor = SystemColors.ControlText;
            chartUsuarios.Location = new Point(403, 379);
            chartUsuarios.Margin = new Padding(3, 4, 3, 4);
            chartUsuarios.Name = "chartUsuarios";
            chartUsuarios.PanCursor = Cursors.Hand;
            chartUsuarios.Size = new Size(394, 367);
            chartUsuarios.TabIndex = 3;
            chartUsuarios.ZoomHorizontalCursor = Cursors.SizeWE;
            chartUsuarios.ZoomRectangleCursor = Cursors.SizeNWSE;
            chartUsuarios.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 750);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmReportes";
            Text = "Dashboard";
            Load += FrmDashboard_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
