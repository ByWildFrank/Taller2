namespace BeanDesktop
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            panel1 = new Panel();
            PnlNav = new FlowLayoutPanel();
            btnConfig = new Button();
            buttonAiMl = new Button();
            buttonCaja = new Button();
            buttonUsuarios = new Button();
            btnStock = new Button();
            BtnDashboard = new Button();
            panel2 = new Panel();
            button1 = new Button();
            LblTipoUser = new Label();
            LblUserNameInicio = new Label();
            pictureBox1 = new PictureBox();
            contenedor = new Panel();
            panel3 = new Panel();
            menu = new MenuStrip();
            menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            menuReporte = new FontAwesome.Sharp.IconMenuItem();
            reporteVentasSubMenuItem = new ToolStripMenuItem();
            reporteEstadisticasSubMenuItem = new ToolStripMenuItem();
            menuCajaRegistradora = new FontAwesome.Sharp.IconMenuItem();
            subMenuRegistrarVenta = new ToolStripMenuItem();
            subMenuVerDetalles = new ToolStripMenuItem();
            menuStock = new FontAwesome.Sharp.IconMenuItem();
            agregarProductoToolStripMenuItem = new ToolStripMenuItem();
            categoríasToolStripMenuItem = new ToolStripMenuItem();
            verStockToolStripMenuItem = new ToolStripMenuItem();
            menuClientes = new FontAwesome.Sharp.IconMenuItem();
            menuIAML = new FontAwesome.Sharp.IconMenuItem();
            menuBackUp = new FontAwesome.Sharp.IconMenuItem();
            menuAcercaDe = new FontAwesome.Sharp.IconMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(PnlNav);
            panel1.Controls.Add(btnConfig);
            panel1.Controls.Add(buttonAiMl);
            panel1.Controls.Add(buttonCaja);
            panel1.Controls.Add(buttonUsuarios);
            panel1.Controls.Add(btnStock);
            panel1.Controls.Add(BtnDashboard);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(235, 184);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // PnlNav
            // 
            PnlNav.BackColor = Color.DodgerBlue;
            PnlNav.Location = new Point(3, 190);
            PnlNav.Name = "PnlNav";
            PnlNav.Size = new Size(4, 100);
            PnlNav.TabIndex = 1;
            // 
            // btnConfig
            // 
            btnConfig.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnConfig.BackgroundImageLayout = ImageLayout.None;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            btnConfig.ForeColor = Color.FromArgb(64, 158, 255);
            btnConfig.Image = (Image)resources.GetObject("btnConfig.Image");
            btnConfig.ImageAlign = ContentAlignment.MiddleRight;
            btnConfig.Location = new Point(0, 543);
            btnConfig.Name = "btnConfig";
            btnConfig.Padding = new Padding(25, 2, 25, 2);
            btnConfig.RightToLeft = RightToLeft.No;
            btnConfig.Size = new Size(230, 46);
            btnConfig.TabIndex = 6;
            btnConfig.Text = "Configuración";
            btnConfig.TextAlign = ContentAlignment.MiddleLeft;
            btnConfig.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnConfig.UseCompatibleTextRendering = true;
            btnConfig.UseVisualStyleBackColor = false;
            // 
            // buttonAiMl
            // 
            buttonAiMl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAiMl.BackgroundImageLayout = ImageLayout.None;
            buttonAiMl.Dock = DockStyle.Top;
            buttonAiMl.FlatAppearance.BorderSize = 0;
            buttonAiMl.FlatStyle = FlatStyle.Flat;
            buttonAiMl.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            buttonAiMl.ForeColor = Color.FromArgb(64, 158, 255);
            buttonAiMl.Image = (Image)resources.GetObject("buttonAiMl.Image");
            buttonAiMl.ImageAlign = ContentAlignment.MiddleRight;
            buttonAiMl.Location = new Point(0, 468);
            buttonAiMl.Name = "buttonAiMl";
            buttonAiMl.Padding = new Padding(5, 2, 5, 2);
            buttonAiMl.RightToLeft = RightToLeft.No;
            buttonAiMl.Size = new Size(235, 54);
            buttonAiMl.TabIndex = 5;
            buttonAiMl.Text = "IA / ML";
            buttonAiMl.TextAlign = ContentAlignment.MiddleLeft;
            buttonAiMl.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonAiMl.UseCompatibleTextRendering = true;
            buttonAiMl.UseVisualStyleBackColor = false;
            // 
            // buttonCaja
            // 
            buttonCaja.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCaja.BackgroundImageLayout = ImageLayout.None;
            buttonCaja.Dock = DockStyle.Top;
            buttonCaja.FlatAppearance.BorderSize = 0;
            buttonCaja.FlatStyle = FlatStyle.Flat;
            buttonCaja.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            buttonCaja.ForeColor = Color.FromArgb(64, 158, 255);
            buttonCaja.Image = (Image)resources.GetObject("buttonCaja.Image");
            buttonCaja.ImageAlign = ContentAlignment.MiddleRight;
            buttonCaja.Location = new Point(0, 387);
            buttonCaja.Name = "buttonCaja";
            buttonCaja.Padding = new Padding(5, 2, 5, 2);
            buttonCaja.RightToLeft = RightToLeft.No;
            buttonCaja.Size = new Size(235, 81);
            buttonCaja.TabIndex = 4;
            buttonCaja.Text = "Caja Registradora";
            buttonCaja.TextAlign = ContentAlignment.MiddleLeft;
            buttonCaja.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonCaja.UseCompatibleTextRendering = true;
            buttonCaja.UseVisualStyleBackColor = false;
            // 
            // buttonUsuarios
            // 
            buttonUsuarios.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonUsuarios.BackgroundImageLayout = ImageLayout.None;
            buttonUsuarios.Dock = DockStyle.Top;
            buttonUsuarios.FlatAppearance.BorderSize = 0;
            buttonUsuarios.FlatStyle = FlatStyle.Flat;
            buttonUsuarios.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            buttonUsuarios.ForeColor = Color.FromArgb(64, 158, 255);
            buttonUsuarios.Image = (Image)resources.GetObject("buttonUsuarios.Image");
            buttonUsuarios.ImageAlign = ContentAlignment.MiddleRight;
            buttonUsuarios.Location = new Point(0, 330);
            buttonUsuarios.Name = "buttonUsuarios";
            buttonUsuarios.Padding = new Padding(5, 2, 5, 2);
            buttonUsuarios.RightToLeft = RightToLeft.No;
            buttonUsuarios.Size = new Size(235, 57);
            buttonUsuarios.TabIndex = 3;
            buttonUsuarios.Text = "Gestión de Usuarios";
            buttonUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            buttonUsuarios.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonUsuarios.UseCompatibleTextRendering = true;
            buttonUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            btnStock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStock.BackgroundImageLayout = ImageLayout.None;
            btnStock.Dock = DockStyle.Top;
            btnStock.FlatAppearance.BorderSize = 0;
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            btnStock.ForeColor = Color.FromArgb(64, 158, 255);
            btnStock.Image = (Image)resources.GetObject("btnStock.Image");
            btnStock.ImageAlign = ContentAlignment.MiddleRight;
            btnStock.Location = new Point(0, 257);
            btnStock.Name = "btnStock";
            btnStock.Padding = new Padding(5, 2, 5, 2);
            btnStock.RightToLeft = RightToLeft.No;
            btnStock.Size = new Size(235, 73);
            btnStock.TabIndex = 2;
            btnStock.Text = "Gestión de Stock";
            btnStock.TextAlign = ContentAlignment.MiddleLeft;
            btnStock.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnStock.UseCompatibleTextRendering = true;
            btnStock.UseVisualStyleBackColor = false;
            // 
            // BtnDashboard
            // 
            BtnDashboard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnDashboard.BackgroundImageLayout = ImageLayout.None;
            BtnDashboard.Dock = DockStyle.Top;
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            BtnDashboard.ForeColor = Color.FromArgb(64, 158, 255);
            BtnDashboard.Image = (Image)resources.GetObject("BtnDashboard.Image");
            BtnDashboard.ImageAlign = ContentAlignment.MiddleRight;
            BtnDashboard.Location = new Point(0, 184);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Padding = new Padding(5, 2, 5, 2);
            BtnDashboard.RightToLeft = RightToLeft.No;
            BtnDashboard.Size = new Size(235, 73);
            BtnDashboard.TabIndex = 1;
            BtnDashboard.Text = "Dashboard";
            BtnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            BtnDashboard.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnDashboard.UseCompatibleTextRendering = true;
            BtnDashboard.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(LblTipoUser);
            panel2.Controls.Add(LblUserNameInicio);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(235, 184);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Tomato;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(29, 34);
            button1.TabIndex = 3;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LblTipoUser
            // 
            LblTipoUser.AutoSize = true;
            LblTipoUser.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTipoUser.ForeColor = Color.WhiteSmoke;
            LblTipoUser.Location = new Point(21, 113);
            LblTipoUser.Name = "LblTipoUser";
            LblTipoUser.Size = new Size(83, 12);
            LblTipoUser.TabIndex = 2;
            LblTipoUser.Text = "Tipo de Usuario";
            // 
            // LblUserNameInicio
            // 
            LblUserNameInicio.AutoSize = true;
            LblUserNameInicio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUserNameInicio.ForeColor = Color.FromArgb(64, 158, 255);
            LblUserNameInicio.Location = new Point(69, 87);
            LblUserNameInicio.Name = "LblUserNameInicio";
            LblUserNameInicio.Size = new Size(85, 16);
            LblUserNameInicio.TabIndex = 1;
            LblUserNameInicio.Text = "User Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(81, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // contenedor
            // 
            contenedor.BackColor = Color.FromArgb(24, 30, 54);
            contenedor.Location = new Point(241, 0);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(1150, 800);
            contenedor.TabIndex = 1;
            contenedor.Paint += contenedor_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 30, 54);
            panel3.Controls.Add(menu);
            panel3.ImeMode = ImeMode.NoControl;
            panel3.Location = new Point(0, 184);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 616);
            panel3.TabIndex = 2;
            // 
            // menu
            // 
            menu.BackColor = Color.FromArgb(24, 30, 54);
            menu.Dock = DockStyle.None;
            menu.ImageScalingSize = new Size(20, 20);
            menu.ImeMode = ImeMode.NoControl;
            menu.Items.AddRange(new ToolStripItem[] { menuUsuarios, menuReporte, menuCajaRegistradora, menuStock, menuClientes, menuIAML, menuBackUp, menuAcercaDe });
            menu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(241, 486);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            menuUsuarios.AutoSize = false;
            menuUsuarios.Font = new Font("Segoe UI", 12F);
            menuUsuarios.ForeColor = Color.WhiteSmoke;
            menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.User;
            menuUsuarios.IconColor = Color.White;
            menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuUsuarios.IconSize = 40;
            menuUsuarios.ImageScaling = ToolStripItemImageScaling.None;
            menuUsuarios.Name = "menuUsuarios";
            menuUsuarios.Size = new Size(235, 60);
            menuUsuarios.Text = "Usuarios";
            menuUsuarios.Click += iconMenuItem4_Click;
            // 
            // menuReporte
            // 
            menuReporte.AutoSize = false;
            menuReporte.DropDownItems.AddRange(new ToolStripItem[] { reporteVentasSubMenuItem, reporteEstadisticasSubMenuItem });
            menuReporte.Font = new Font("Segoe UI", 12F);
            menuReporte.ForeColor = Color.WhiteSmoke;
            menuReporte.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            menuReporte.IconColor = Color.White;
            menuReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuReporte.IconSize = 40;
            menuReporte.ImageScaling = ToolStripItemImageScaling.None;
            menuReporte.Name = "menuReporte";
            menuReporte.Size = new Size(235, 60);
            menuReporte.Text = "Dashboard";
            // 
            // reporteVentasSubMenuItem
            // 
            reporteVentasSubMenuItem.Name = "reporteVentasSubMenuItem";
            reporteVentasSubMenuItem.Size = new Size(159, 26);
            reporteVentasSubMenuItem.Text = "Ventas";
            reporteVentasSubMenuItem.Click += reporteVentasSubMenuItem_Click;
            // 
            // reporteEstadisticasSubMenuItem
            // 
            reporteEstadisticasSubMenuItem.Name = "reporteEstadisticasSubMenuItem";
            reporteEstadisticasSubMenuItem.Size = new Size(159, 26);
            reporteEstadisticasSubMenuItem.Text = "Estadísticas";
            reporteEstadisticasSubMenuItem.Click += reporteEstadisticasSubMenuItem_Click;
            // 
            // menuCajaRegistradora
            // 
            menuCajaRegistradora.AutoSize = false;
            menuCajaRegistradora.DropDownItems.AddRange(new ToolStripItem[] { subMenuRegistrarVenta, subMenuVerDetalles });
            menuCajaRegistradora.Font = new Font("Segoe UI", 12F);
            menuCajaRegistradora.ForeColor = Color.WhiteSmoke;
            menuCajaRegistradora.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            menuCajaRegistradora.IconColor = Color.White;
            menuCajaRegistradora.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuCajaRegistradora.IconSize = 40;
            menuCajaRegistradora.ImageScaling = ToolStripItemImageScaling.None;
            menuCajaRegistradora.Name = "menuCajaRegistradora";
            menuCajaRegistradora.Size = new Size(235, 60);
            menuCajaRegistradora.Text = "CajaRegistradora";
            // 
            // subMenuRegistrarVenta
            // 
            subMenuRegistrarVenta.Name = "subMenuRegistrarVenta";
            subMenuRegistrarVenta.Size = new Size(233, 26);
            subMenuRegistrarVenta.Text = "Registrar";
            subMenuRegistrarVenta.Click += subMenuRegistrarVenta_Click;
            // 
            // subMenuVerDetalles
            // 
            subMenuVerDetalles.Name = "subMenuVerDetalles";
            subMenuVerDetalles.Size = new Size(233, 26);
            subMenuVerDetalles.Text = "Ver Detalles de Ventas";
            subMenuVerDetalles.Click += subMenuVerDetalles_Click;
            // 
            // menuStock
            // 
            menuStock.AutoSize = false;
            menuStock.DropDownItems.AddRange(new ToolStripItem[] { agregarProductoToolStripMenuItem, categoríasToolStripMenuItem, verStockToolStripMenuItem });
            menuStock.Font = new Font("Segoe UI", 12F);
            menuStock.ForeColor = Color.WhiteSmoke;
            menuStock.IconChar = FontAwesome.Sharp.IconChar.BoxesPacking;
            menuStock.IconColor = Color.White;
            menuStock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuStock.IconSize = 40;
            menuStock.ImageScaling = ToolStripItemImageScaling.None;
            menuStock.Name = "menuStock";
            menuStock.Size = new Size(235, 60);
            menuStock.Text = "Gestión de Stock";
            // 
            // agregarProductoToolStripMenuItem
            // 
            agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            agregarProductoToolStripMenuItem.Size = new Size(203, 26);
            agregarProductoToolStripMenuItem.Text = "Agregar Producto";
            agregarProductoToolStripMenuItem.Click += agregarProductoToolStripMenuItem_Click;
            // 
            // categoríasToolStripMenuItem
            // 
            categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            categoríasToolStripMenuItem.Size = new Size(203, 26);
            categoríasToolStripMenuItem.Text = "Categorías";
            categoríasToolStripMenuItem.Click += categoríasToolStripMenuItem_Click;
            // 
            // verStockToolStripMenuItem
            // 
            verStockToolStripMenuItem.Name = "verStockToolStripMenuItem";
            verStockToolStripMenuItem.Size = new Size(203, 26);
            verStockToolStripMenuItem.Text = "Ver Stock";
            verStockToolStripMenuItem.Click += verStockToolStripMenuItem_Click;
            // 
            // menuClientes
            // 
            menuClientes.AutoSize = false;
            menuClientes.Font = new Font("Segoe UI", 12F);
            menuClientes.ForeColor = Color.WhiteSmoke;
            menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            menuClientes.IconColor = Color.White;
            menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuClientes.IconSize = 40;
            menuClientes.ImageScaling = ToolStripItemImageScaling.None;
            menuClientes.Name = "menuClientes";
            menuClientes.Size = new Size(235, 60);
            menuClientes.Text = "Clientes";
            menuClientes.Click += menuClientes_Click;
            // 
            // menuIAML
            // 
            menuIAML.AutoSize = false;
            menuIAML.Font = new Font("Segoe UI", 12F);
            menuIAML.ForeColor = Color.WhiteSmoke;
            menuIAML.IconChar = FontAwesome.Sharp.IconChar.Brain;
            menuIAML.IconColor = Color.White;
            menuIAML.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuIAML.IconSize = 40;
            menuIAML.ImageScaling = ToolStripItemImageScaling.None;
            menuIAML.Name = "menuIAML";
            menuIAML.Size = new Size(235, 60);
            menuIAML.Text = "IA/ML";
            menuIAML.Click += menuIAML_Click;
            // 
            // menuBackUp
            // 
            menuBackUp.AutoSize = false;
            menuBackUp.Font = new Font("Segoe UI", 12F);
            menuBackUp.ForeColor = Color.WhiteSmoke;
            menuBackUp.IconChar = FontAwesome.Sharp.IconChar.Save;
            menuBackUp.IconColor = Color.White;
            menuBackUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuBackUp.IconSize = 40;
            menuBackUp.ImageScaling = ToolStripItemImageScaling.None;
            menuBackUp.Name = "menuBackUp";
            menuBackUp.Size = new Size(235, 60);
            menuBackUp.Text = "BackUp";
            menuBackUp.Click += menuBackUp_Click;
            // 
            // menuAcercaDe
            // 
            menuAcercaDe.AutoSize = false;
            menuAcercaDe.Font = new Font("Segoe UI", 12F);
            menuAcercaDe.ForeColor = Color.WhiteSmoke;
            menuAcercaDe.IconChar = FontAwesome.Sharp.IconChar.Info;
            menuAcercaDe.IconColor = Color.White;
            menuAcercaDe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuAcercaDe.IconSize = 40;
            menuAcercaDe.ImageScaling = ToolStripItemImageScaling.None;
            menuAcercaDe.Name = "menuAcercaDe";
            menuAcercaDe.Size = new Size(235, 60);
            menuAcercaDe.Text = "Acerca De";
            menuAcercaDe.Click += menuAcercaDe_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1400, 800);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(contenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label LblTipoUser;
        private Label LblUserNameInicio;
        private Button BtnDashboard;
        private Button buttonCaja;
        private Button buttonUsuarios;
        private Button btnStock;
        private Button buttonAiMl;
        private Button btnConfig;
        private FlowLayoutPanel PnlNav;
        private Button button1;
        private Panel contenedor;
        private Panel panel3;
        private MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuReporte;
        private FontAwesome.Sharp.IconMenuItem menuCajaRegistradora;
        private FontAwesome.Sharp.IconMenuItem menuStock;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private ToolStripMenuItem agregarProductoToolStripMenuItem;
        private ToolStripMenuItem categoríasToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuIAML;
        private ToolStripMenuItem verStockToolStripMenuItem;
        private ToolStripMenuItem subMenuRegistrarVenta;
        private ToolStripMenuItem subMenuVerDetalles;
        private FontAwesome.Sharp.IconMenuItem menuAcercaDe;
        private FontAwesome.Sharp.IconMenuItem menuBackUp;
        private ToolStripMenuItem reporteVentasSubMenuItem;
        private ToolStripMenuItem reporteEstadisticasSubMenuItem;
    }
}
