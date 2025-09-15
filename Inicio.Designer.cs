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
            components = new System.ComponentModel.Container();
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
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            imageList1 = new ImageList(components);
            contenedor = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 900);
            panel1.TabIndex = 0;
            // 
            // PnlNav
            // 
            PnlNav.BackColor = Color.DodgerBlue;
            PnlNav.Location = new Point(3, 253);
            PnlNav.Margin = new Padding(3, 4, 3, 4);
            PnlNav.Name = "PnlNav";
            PnlNav.Size = new Size(5, 133);
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
            btnConfig.Location = new Point(0, 823);
            btnConfig.Margin = new Padding(3, 4, 3, 4);
            btnConfig.Name = "btnConfig";
            btnConfig.Padding = new Padding(29, 3, 29, 3);
            btnConfig.RightToLeft = RightToLeft.No;
            btnConfig.Size = new Size(263, 61);
            btnConfig.TabIndex = 6;
            btnConfig.Text = "Configuración";
            btnConfig.TextAlign = ContentAlignment.MiddleLeft;
            btnConfig.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnConfig.UseCompatibleTextRendering = true;
            btnConfig.UseVisualStyleBackColor = false;
            btnConfig.Click += btnConfig_Click;
            btnConfig.Leave += btnConfig_Leave;
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
            buttonAiMl.Location = new Point(0, 580);
            buttonAiMl.Margin = new Padding(3, 4, 3, 4);
            buttonAiMl.Name = "buttonAiMl";
            buttonAiMl.Padding = new Padding(6, 3, 6, 3);
            buttonAiMl.RightToLeft = RightToLeft.No;
            buttonAiMl.Size = new Size(263, 97);
            buttonAiMl.TabIndex = 5;
            buttonAiMl.Text = "IA / ML";
            buttonAiMl.TextAlign = ContentAlignment.MiddleLeft;
            buttonAiMl.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonAiMl.UseCompatibleTextRendering = true;
            buttonAiMl.UseVisualStyleBackColor = false;
            buttonAiMl.Click += buttonAiMl_Click;
            buttonAiMl.Leave += buttonAiMl_Leave;
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
            buttonCaja.Location = new Point(0, 483);
            buttonCaja.Margin = new Padding(3, 4, 3, 4);
            buttonCaja.Name = "buttonCaja";
            buttonCaja.Padding = new Padding(6, 3, 6, 3);
            buttonCaja.RightToLeft = RightToLeft.No;
            buttonCaja.Size = new Size(263, 97);
            buttonCaja.TabIndex = 4;
            buttonCaja.Text = "Caja Registradora";
            buttonCaja.TextAlign = ContentAlignment.MiddleLeft;
            buttonCaja.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonCaja.UseCompatibleTextRendering = true;
            buttonCaja.UseVisualStyleBackColor = false;
            buttonCaja.Click += buttonCaja_Click;
            buttonCaja.Leave += buttonCaja_Leave;
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
            buttonUsuarios.Location = new Point(0, 386);
            buttonUsuarios.Margin = new Padding(3, 4, 3, 4);
            buttonUsuarios.Name = "buttonUsuarios";
            buttonUsuarios.Padding = new Padding(6, 3, 6, 3);
            buttonUsuarios.RightToLeft = RightToLeft.No;
            buttonUsuarios.Size = new Size(263, 97);
            buttonUsuarios.TabIndex = 3;
            buttonUsuarios.Text = "Gestión de Usuarios";
            buttonUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            buttonUsuarios.TextImageRelation = TextImageRelation.TextBeforeImage;
            buttonUsuarios.UseCompatibleTextRendering = true;
            buttonUsuarios.UseVisualStyleBackColor = false;
            buttonUsuarios.Click += buttonUsuarios_Click;
            buttonUsuarios.Leave += buttonUsuarios_Leave;
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
            btnStock.Location = new Point(0, 289);
            btnStock.Margin = new Padding(3, 4, 3, 4);
            btnStock.Name = "btnStock";
            btnStock.Padding = new Padding(6, 3, 6, 3);
            btnStock.RightToLeft = RightToLeft.No;
            btnStock.Size = new Size(263, 97);
            btnStock.TabIndex = 2;
            btnStock.Text = "Gestión de Stock";
            btnStock.TextAlign = ContentAlignment.MiddleLeft;
            btnStock.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnStock.UseCompatibleTextRendering = true;
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            btnStock.Leave += btnStock_Leave;
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
            BtnDashboard.Location = new Point(0, 192);
            BtnDashboard.Margin = new Padding(3, 4, 3, 4);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Padding = new Padding(6, 3, 6, 3);
            BtnDashboard.RightToLeft = RightToLeft.No;
            BtnDashboard.Size = new Size(263, 97);
            BtnDashboard.TabIndex = 1;
            BtnDashboard.Text = "Dashboard";
            BtnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            BtnDashboard.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnDashboard.UseCompatibleTextRendering = true;
            BtnDashboard.UseVisualStyleBackColor = false;
            BtnDashboard.Click += BtnDashboard_Click;
            BtnDashboard.Leave += BtnDashboard_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(263, 192);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(14, 28);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(29, 33);
            button1.TabIndex = 3;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(79, 162);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 158, 255);
            label1.Location = new Point(85, 128);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 1;
            label1.Text = "User Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(97, 28);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // contenedor
            // 
            contenedor.Location = new Point(262, 0);
            contenedor.Margin = new Padding(3, 4, 3, 4);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(1109, 900);
            contenedor.TabIndex = 1;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1371, 900);
            Controls.Add(contenedor);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Button BtnDashboard;
        private Button buttonCaja;
        private Button buttonUsuarios;
        private Button btnStock;
        private Button buttonAiMl;
        private Button btnConfig;
        private FlowLayoutPanel PnlNav;
        private Button button1;
        private ImageList imageList1;
        private Panel contenedor;
    }
}
