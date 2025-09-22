namespace BeanDesktop
{
    partial class frmAcercaDe
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
            lblTitulo = new Label();
            lblVersion = new Label();
            lblDescripcion = new Label();
            lstAutores = new ListBox();
            lnkGitHub = new LinkLabel();
            lnkLinkedIn1 = new LinkLabel();
            lnkLinkedIn2 = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(415, 37);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(205, 40);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "BeanDesktop";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 12F);
            lblVersion.Location = new Point(468, 89);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(99, 21);
            lblVersion.TabIndex = 4;
            lblVersion.Text = "Versión 1.0.0";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F);
            lblDescripcion.Location = new Point(98, 130);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(856, 21);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Proyecto académico de Aplicación de escritorio con sistema CRUD, segmentación de clientes y recomendaciones en ventas";
            // 
            // lstAutores
            // 
            lstAutores.BackColor = Color.WhiteSmoke;
            lstAutores.BorderStyle = BorderStyle.None;
            lstAutores.FormattingEnabled = true;
            lstAutores.ItemHeight = 21;
            lstAutores.Location = new Point(98, 179);
            lstAutores.Margin = new Padding(4);
            lstAutores.Name = "lstAutores";
            lstAutores.Size = new Size(404, 84);
            lstAutores.TabIndex = 0;
            // 
            // lnkGitHub
            // 
            lnkGitHub.ActiveLinkColor = Color.Maroon;
            lnkGitHub.AutoSize = true;
            lnkGitHub.Font = new Font("Segoe UI", 12F);
            lnkGitHub.Location = new Point(98, 359);
            lnkGitHub.Margin = new Padding(4, 0, 4, 0);
            lnkGitHub.Name = "lnkGitHub";
            lnkGitHub.Size = new Size(283, 21);
            lnkGitHub.TabIndex = 6;
            lnkGitHub.TabStop = true;
            lnkGitHub.Text = "https://github.com/ByWildFrank/Taller2";
            // 
            // lnkLinkedIn1
            // 
            lnkLinkedIn1.ActiveLinkColor = Color.Maroon;
            lnkLinkedIn1.AutoSize = true;
            lnkLinkedIn1.Font = new Font("Segoe UI", 12F);
            lnkLinkedIn1.Location = new Point(98, 439);
            lnkLinkedIn1.Margin = new Padding(4, 0, 4, 0);
            lnkLinkedIn1.Name = "lnkLinkedIn1";
            lnkLinkedIn1.Size = new Size(263, 21);
            lnkLinkedIn1.TabIndex = 7;
            lnkLinkedIn1.TabStop = true;
            lnkLinkedIn1.Text = "www.linkedin.com/in/santiago-scetti";
            // 
            // lnkLinkedIn2
            // 
            lnkLinkedIn2.ActiveLinkColor = Color.Maroon;
            lnkLinkedIn2.AutoSize = true;
            lnkLinkedIn2.Font = new Font("Segoe UI", 12F);
            lnkLinkedIn2.Location = new Point(98, 471);
            lnkLinkedIn2.Margin = new Padding(4, 0, 4, 0);
            lnkLinkedIn2.Name = "lnkLinkedIn2";
            lnkLinkedIn2.Size = new Size(255, 21);
            lnkLinkedIn2.TabIndex = 8;
            lnkLinkedIn2.TabStop = true;
            lnkLinkedIn2.Text = "www.linkedin.com/in/varela_franco";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 338);
            label1.Name = "label1";
            label1.Size = new Size(142, 21);
            label1.TabIndex = 9;
            label1.Text = "Link al Repositorio:";
            // 
            // frmAcercaDe
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1034, 661);
            Controls.Add(label1);
            Controls.Add(lnkLinkedIn2);
            Controls.Add(lnkLinkedIn1);
            Controls.Add(lnkGitHub);
            Controls.Add(lstAutores);
            Controls.Add(lblDescripcion);
            Controls.Add(lblVersion);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "frmAcercaDe";
            Text = "frmAcercaDe";
            Load += frmAcercaDe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblVersion;
        private Label lblDescripcion;
        private ListBox lstAutores;
        private LinkLabel lnkGitHub;
        private LinkLabel lnkLinkedIn1;
        private LinkLabel lnkLinkedIn2;
        private Label label1;
    }
}