namespace BeanDesktop
{
    partial class FrmReportes
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

        private void InitializeComponent()
        {
            pnlGanancias = new Panel();
            lblPorcentajeGanancias = new Label();
            lblValorGanancias = new Label();
            lblTituloGanancias = new Label();
            pnlNuevosClientes = new Panel();
            lblValorNuevosClientes = new Label();
            lblTituloNuevosClientes = new Label();
            lblPorcentajeNuevosClientes = new Label();
            lblValorSegmento = new Label();
            lblTituloSegmento = new Label();
            pnlBajoStock = new Panel();
            lblAlertaStock = new Label();
            lblValorBajoStock = new Label();
            lblTituloBajoStock = new Label();
            pnlTicketPromedio = new Panel();
            lblPorcentajeTicket = new Label();
            lblValorTicketPromedio = new Label();
            lblTituloTicketPromedio = new Label();
            cboTipoGrafico = new ComboBox();
            label1 = new Label();
            pltGraficos = new OxyPlot.WindowsForms.PlotView();
            pnlSegmento = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            pnlGanancias.SuspendLayout();
            pnlNuevosClientes.SuspendLayout();
            pnlBajoStock.SuspendLayout();
            pnlTicketPromedio.SuspendLayout();
            pnlSegmento.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGanancias
            // 
            pnlGanancias.BackColor = Color.WhiteSmoke;
            pnlGanancias.Controls.Add(lblPorcentajeGanancias);
            pnlGanancias.Controls.Add(lblValorGanancias);
            pnlGanancias.Controls.Add(lblTituloGanancias);
            pnlGanancias.ImeMode = ImeMode.NoControl;
            pnlGanancias.Location = new Point(12, 12);
            pnlGanancias.Name = "pnlGanancias";
            pnlGanancias.Size = new Size(550, 92);
            pnlGanancias.TabIndex = 0;
            // 
            // lblPorcentajeGanancias
            // 
            lblPorcentajeGanancias.AutoSize = true;
            lblPorcentajeGanancias.Location = new Point(199, 43);
            lblPorcentajeGanancias.Name = "lblPorcentajeGanancias";
            lblPorcentajeGanancias.Size = new Size(17, 15);
            lblPorcentajeGanancias.TabIndex = 2;
            lblPorcentajeGanancias.Text = "%";
            // 
            // lblValorGanancias
            // 
            lblValorGanancias.AutoSize = true;
            lblValorGanancias.Location = new Point(22, 43);
            lblValorGanancias.Name = "lblValorGanancias";
            lblValorGanancias.Size = new Size(13, 15);
            lblValorGanancias.TabIndex = 1;
            lblValorGanancias.Text = "0";
            // 
            // lblTituloGanancias
            // 
            lblTituloGanancias.AutoSize = true;
            lblTituloGanancias.Location = new Point(22, 15);
            lblTituloGanancias.Name = "lblTituloGanancias";
            lblTituloGanancias.Size = new Size(105, 15);
            lblTituloGanancias.TabIndex = 0;
            lblTituloGanancias.Text = "Ganancias del Mes";
            // 
            // pnlNuevosClientes
            // 
            pnlNuevosClientes.BackColor = Color.WhiteSmoke;
            pnlNuevosClientes.Controls.Add(lblValorNuevosClientes);
            pnlNuevosClientes.Controls.Add(lblTituloNuevosClientes);
            pnlNuevosClientes.Controls.Add(lblPorcentajeNuevosClientes);
            pnlNuevosClientes.ImeMode = ImeMode.NoControl;
            pnlNuevosClientes.Location = new Point(572, 12);
            pnlNuevosClientes.Name = "pnlNuevosClientes";
            pnlNuevosClientes.Size = new Size(270, 92);
            pnlNuevosClientes.TabIndex = 2;
            // 
            // lblValorNuevosClientes
            // 
            lblValorNuevosClientes.AutoSize = true;
            lblValorNuevosClientes.Location = new Point(31, 43);
            lblValorNuevosClientes.Name = "lblValorNuevosClientes";
            lblValorNuevosClientes.Size = new Size(13, 15);
            lblValorNuevosClientes.TabIndex = 6;
            lblValorNuevosClientes.Text = "0";
            // 
            // lblTituloNuevosClientes
            // 
            lblTituloNuevosClientes.AutoSize = true;
            lblTituloNuevosClientes.Location = new Point(31, 15);
            lblTituloNuevosClientes.Name = "lblTituloNuevosClientes";
            lblTituloNuevosClientes.Size = new Size(92, 15);
            lblTituloNuevosClientes.TabIndex = 5;
            lblTituloNuevosClientes.Text = "Nuevos Clientes";
            // 
            // lblPorcentajeNuevosClientes
            // 
            lblPorcentajeNuevosClientes.AutoSize = true;
            lblPorcentajeNuevosClientes.Location = new Point(61, 43);
            lblPorcentajeNuevosClientes.Name = "lblPorcentajeNuevosClientes";
            lblPorcentajeNuevosClientes.Size = new Size(17, 15);
            lblPorcentajeNuevosClientes.TabIndex = 4;
            lblPorcentajeNuevosClientes.Text = "%";
            // 
            // lblValorSegmento
            // 
            lblValorSegmento.AutoSize = true;
            lblValorSegmento.Location = new Point(20, 43);
            lblValorSegmento.Name = "lblValorSegmento";
            lblValorSegmento.Size = new Size(13, 15);
            lblValorSegmento.TabIndex = 1;
            lblValorSegmento.Text = "0";
            // 
            // lblTituloSegmento
            // 
            lblTituloSegmento.AutoSize = true;
            lblTituloSegmento.Location = new Point(20, 15);
            lblTituloSegmento.Name = "lblTituloSegmento";
            lblTituloSegmento.Size = new Size(123, 15);
            lblTituloSegmento.TabIndex = 0;
            lblTituloSegmento.Text = "Segmento Dominante";
            // 
            // pnlBajoStock
            // 
            pnlBajoStock.BackColor = Color.WhiteSmoke;
            pnlBajoStock.Controls.Add(lblAlertaStock);
            pnlBajoStock.Controls.Add(lblValorBajoStock);
            pnlBajoStock.Controls.Add(lblTituloBajoStock);
            pnlBajoStock.ImeMode = ImeMode.NoControl;
            pnlBajoStock.Location = new Point(12, 110);
            pnlBajoStock.Name = "pnlBajoStock";
            pnlBajoStock.Size = new Size(550, 92);
            pnlBajoStock.TabIndex = 2;
            // 
            // lblAlertaStock
            // 
            lblAlertaStock.AutoSize = true;
            lblAlertaStock.Location = new Point(267, 52);
            lblAlertaStock.Name = "lblAlertaStock";
            lblAlertaStock.Size = new Size(17, 15);
            lblAlertaStock.TabIndex = 3;
            lblAlertaStock.Text = "%";
            // 
            // lblValorBajoStock
            // 
            lblValorBajoStock.AutoSize = true;
            lblValorBajoStock.Location = new Point(22, 43);
            lblValorBajoStock.Name = "lblValorBajoStock";
            lblValorBajoStock.Size = new Size(12, 15);
            lblValorBajoStock.TabIndex = 1;
            lblValorBajoStock.Text = "?";
            // 
            // lblTituloBajoStock
            // 
            lblTituloBajoStock.AutoSize = true;
            lblTituloBajoStock.Location = new Point(22, 15);
            lblTituloBajoStock.Name = "lblTituloBajoStock";
            lblTituloBajoStock.Size = new Size(150, 15);
            lblTituloBajoStock.TabIndex = 0;
            lblTituloBajoStock.Text = "Productos en Bajo Stock ⚠️";
            // 
            // pnlTicketPromedio
            // 
            pnlTicketPromedio.BackColor = Color.WhiteSmoke;
            pnlTicketPromedio.Controls.Add(lblPorcentajeTicket);
            pnlTicketPromedio.Controls.Add(lblValorTicketPromedio);
            pnlTicketPromedio.Controls.Add(lblTituloTicketPromedio);
            pnlTicketPromedio.ImeMode = ImeMode.NoControl;
            pnlTicketPromedio.Location = new Point(572, 110);
            pnlTicketPromedio.Name = "pnlTicketPromedio";
            pnlTicketPromedio.Size = new Size(550, 92);
            pnlTicketPromedio.TabIndex = 2;
            // 
            // lblPorcentajeTicket
            // 
            lblPorcentajeTicket.AutoSize = true;
            lblPorcentajeTicket.Location = new Point(184, 52);
            lblPorcentajeTicket.Name = "lblPorcentajeTicket";
            lblPorcentajeTicket.Size = new Size(17, 15);
            lblPorcentajeTicket.TabIndex = 3;
            lblPorcentajeTicket.Text = "%";
            // 
            // lblValorTicketPromedio
            // 
            lblValorTicketPromedio.AutoSize = true;
            lblValorTicketPromedio.Location = new Point(22, 43);
            lblValorTicketPromedio.Name = "lblValorTicketPromedio";
            lblValorTicketPromedio.Size = new Size(13, 15);
            lblValorTicketPromedio.TabIndex = 1;
            lblValorTicketPromedio.Text = "0";
            // 
            // lblTituloTicketPromedio
            // 
            lblTituloTicketPromedio.AutoSize = true;
            lblTituloTicketPromedio.Location = new Point(22, 15);
            lblTituloTicketPromedio.Name = "lblTituloTicketPromedio";
            lblTituloTicketPromedio.Size = new Size(108, 15);
            lblTituloTicketPromedio.TabIndex = 0;
            lblTituloTicketPromedio.Text = "Ticket Promedio \U0001f6d2";
            // 
            // cboTipoGrafico
            // 
            cboTipoGrafico.FormattingEnabled = true;
            cboTipoGrafico.Location = new Point(12, 287);
            cboTipoGrafico.Name = "cboTipoGrafico";
            cboTipoGrafico.Size = new Size(204, 23);
            cboTipoGrafico.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 269);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 6;
            label1.Text = "Selección de Gráfica";
            // 
            // pltGraficos
            // 
            pltGraficos.Location = new Point(222, 223);
            pltGraficos.Name = "pltGraficos";
            pltGraficos.PanCursor = Cursors.Hand;
            pltGraficos.Size = new Size(902, 526);
            pltGraficos.TabIndex = 7;
            pltGraficos.Text = "plotView1";
            pltGraficos.ZoomHorizontalCursor = Cursors.SizeWE;
            pltGraficos.ZoomRectangleCursor = Cursors.SizeNWSE;
            pltGraficos.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // pnlSegmento
            // 
            pnlSegmento.BackColor = Color.WhiteSmoke;
            pnlSegmento.Controls.Add(lblValorSegmento);
            pnlSegmento.Controls.Add(lblTituloSegmento);
            pnlSegmento.ImeMode = ImeMode.NoControl;
            pnlSegmento.Location = new Point(852, 12);
            pnlSegmento.Name = "pnlSegmento";
            pnlSegmento.Size = new Size(270, 92);
            pnlSegmento.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(552, 95);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Location = new Point(12, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(552, 95);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonShadow;
            panel3.Location = new Point(572, 110);
            panel3.Name = "panel3";
            panel3.Size = new Size(552, 95);
            panel3.TabIndex = 10;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonShadow;
            panel4.Location = new Point(572, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(272, 94);
            panel4.TabIndex = 11;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonShadow;
            panel5.Location = new Point(850, 10);
            panel5.Name = "panel5";
            panel5.Size = new Size(272, 94);
            panel5.TabIndex = 12;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 761);
            Controls.Add(pnlBajoStock);
            Controls.Add(pnlSegmento);
            Controls.Add(pltGraficos);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(cboTipoGrafico);
            Controls.Add(pnlTicketPromedio);
            Controls.Add(pnlNuevosClientes);
            Controls.Add(pnlGanancias);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Name = "FrmReportes";
            Text = "Dashboard";
            Load += FrmReportes_Load;
            pnlGanancias.ResumeLayout(false);
            pnlGanancias.PerformLayout();
            pnlNuevosClientes.ResumeLayout(false);
            pnlNuevosClientes.PerformLayout();
            pnlBajoStock.ResumeLayout(false);
            pnlBajoStock.PerformLayout();
            pnlTicketPromedio.ResumeLayout(false);
            pnlTicketPromedio.PerformLayout();
            pnlSegmento.ResumeLayout(false);
            pnlSegmento.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlGanancias;
        private Label lblTituloGanancias;
        private Label lblValorGanancias;
        private Panel pnlNuevosClientes;
        private Label lblValorSegmento;
        private Label lblTituloSegmento;
        private Panel pnlBajoStock;
        private Label lblValorBajoStock;
        private Label lblTituloBajoStock;
        private Panel pnlTicketPromedio;
        private Label lblValorTicketPromedio;
        private Label lblTituloTicketPromedio;
        private ComboBox cboTipoGrafico;
        private Label label1;
        private OxyPlot.WindowsForms.PlotView pltGraficos;
        private Label lblPorcentajeGanancias;
        private Label lblPorcentajeTicket;
        private Label lblTituloNuevosClientes;
        private Label lblPorcentajeNuevosClientes;
        private Label lblAlertaStock;
        private Label lblValorNuevosClientes;
        private Panel pnlSegmento;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}
