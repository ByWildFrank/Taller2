namespace BeanDesktop
{
    partial class frmAcercaDe
    {
        /// <summary>
        ///  Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Form

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
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(324, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(580, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "BeanDesktop";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            lblVersion.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblVersion.Location = new Point(324, 85);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(580, 25);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Versión 1.0.0";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 10F);
            lblDescripcion.Location = new Point(367, 110);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(500, 70);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Proyecto académico de aplicación de escritorio con sistema CRUD, segmentación de clientes y recomendaciones en ventas.";
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstAutores
            // 
            lstAutores.BorderStyle = BorderStyle.None;
            lstAutores.Font = new Font("Segoe UI", 10F);
            lstAutores.FormattingEnabled = true;
            lstAutores.ItemHeight = 23;
            lstAutores.Location = new Point(487, 183);
            lstAutores.Name = "lstAutores";
            lstAutores.Size = new Size(280, 46);
            lstAutores.TabIndex = 0;
            // 
            // lnkGitHub
            // 
            lnkGitHub.Font = new Font("Segoe UI", 10F);
            lnkGitHub.Location = new Point(324, 300);
            lnkGitHub.Name = "lnkGitHub";
            lnkGitHub.Size = new Size(580, 25);
            lnkGitHub.TabIndex = 1;
            lnkGitHub.TabStop = true;
            lnkGitHub.Text = "📦 Repositorio en GitHub";
            lnkGitHub.TextAlign = ContentAlignment.MiddleCenter;
            lnkGitHub.LinkClicked += lnkGitHub_LinkClicked;
            // 
            // lnkLinkedIn1
            // 
            lnkLinkedIn1.Font = new Font("Segoe UI", 10F);
            lnkLinkedIn1.Location = new Point(324, 330);
            lnkLinkedIn1.Name = "lnkLinkedIn1";
            lnkLinkedIn1.Size = new Size(580, 25);
            lnkLinkedIn1.TabIndex = 2;
            lnkLinkedIn1.TabStop = true;
            lnkLinkedIn1.Text = "💼 LinkedIn - Franco Varela";
            lnkLinkedIn1.TextAlign = ContentAlignment.MiddleCenter;
            lnkLinkedIn1.LinkClicked += lnkLinkedIn1_LinkClicked;
            // 
            // lnkLinkedIn2
            // 
            lnkLinkedIn2.Font = new Font("Segoe UI", 10F);
            lnkLinkedIn2.Location = new Point(324, 355);
            lnkLinkedIn2.Name = "lnkLinkedIn2";
            lnkLinkedIn2.Size = new Size(580, 25);
            lnkLinkedIn2.TabIndex = 3;
            lnkLinkedIn2.TabStop = true;
            lnkLinkedIn2.Text = "💼 LinkedIn - Santiago Scetti";
            lnkLinkedIn2.TextAlign = ContentAlignment.MiddleCenter;
            lnkLinkedIn2.LinkClicked += lnkLinkedIn2_LinkClicked;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(324, 250);
            label1.Name = "label1";
            label1.Size = new Size(580, 25);
            label1.TabIndex = 3;
            label1.Text = "Conectá con nosotros:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmAcercaDe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 704);
            Controls.Add(lblTitulo);
            Controls.Add(lblVersion);
            Controls.Add(lblDescripcion);
            Controls.Add(lstAutores);
            Controls.Add(label1);
            Controls.Add(lnkGitHub);
            Controls.Add(lnkLinkedIn1);
            Controls.Add(lnkLinkedIn2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmAcercaDe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acerca de BeanDesktop";
            Load += frmAcercaDe_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ListBox lstAutores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkGitHub;
        private System.Windows.Forms.LinkLabel lnkLinkedIn1;
        private System.Windows.Forms.LinkLabel lnkLinkedIn2;
    }
}
