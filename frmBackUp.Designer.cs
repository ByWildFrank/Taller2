namespace BeanDesktop
{
    partial class frmBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackUp));
            btnCrearBackup = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            label3 = new Label();
            radSchemaSolo = new RadioButton();
            radSchemaYDatos = new RadioButton();
            btnGenerarScript = new FontAwesome.Sharp.IconButton();
            txtScriptSQL = new TextBox();
            btnCopiarScript = new FontAwesome.Sharp.IconButton();
            lblStatus2 = new Label();
            progressBar2 = new ProgressBar();
            panel3 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // btnCrearBackup
            // 
            btnCrearBackup.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnCrearBackup.IconColor = Color.Black;
            btnCrearBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCrearBackup.IconSize = 30;
            btnCrearBackup.Location = new Point(785, 143);
            btnCrearBackup.Name = "btnCrearBackup";
            btnCrearBackup.Size = new Size(136, 44);
            btnCrearBackup.TabIndex = 0;
            btnCrearBackup.Text = "Descargar Datos";
            btnCrearBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCrearBackup.UseVisualStyleBackColor = true;
            btnCrearBackup.Click += btnCrearBackup_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 56);
            label1.Name = "label1";
            label1.Size = new Size(577, 40);
            label1.TabIndex = 1;
            label1.Text = "Copia de Seguridad de la Base de Datos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(61, 143);
            label2.Name = "label2";
            label2.Size = new Size(678, 51);
            label2.TabIndex = 2;
            label2.Text = resources.GetString("label2.Text");
            // 
            // progressBar
            // 
            progressBar.Location = new Point(785, 193);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(136, 16);
            progressBar.TabIndex = 3;
            progressBar.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(785, 212);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "lblStatus";
            lblStatus.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 368);
            label3.Name = "label3";
            label3.Size = new Size(202, 15);
            label3.TabIndex = 5;
            label3.Text = "Seleccione el tipo de script a generar:";
            // 
            // radSchemaSolo
            // 
            radSchemaSolo.AutoSize = true;
            radSchemaSolo.Location = new Point(93, 417);
            radSchemaSolo.Name = "radSchemaSolo";
            radSchemaSolo.Size = new Size(195, 19);
            radSchemaSolo.TabIndex = 6;
            radSchemaSolo.TabStop = true;
            radSchemaSolo.Text = "Solo Estructura (tablas, SPs, etc.)";
            radSchemaSolo.UseVisualStyleBackColor = true;
            // 
            // radSchemaYDatos
            // 
            radSchemaYDatos.AutoSize = true;
            radSchemaYDatos.Location = new Point(93, 442);
            radSchemaYDatos.Name = "radSchemaYDatos";
            radSchemaYDatos.Size = new Size(192, 19);
            radSchemaYDatos.TabIndex = 7;
            radSchemaYDatos.TabStop = true;
            radSchemaYDatos.Text = "Estructura y Datos (COMPLETO)";
            radSchemaYDatos.UseVisualStyleBackColor = true;
            // 
            // btnGenerarScript
            // 
            btnGenerarScript.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGenerarScript.IconColor = Color.Black;
            btnGenerarScript.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGenerarScript.Location = new Point(93, 467);
            btnGenerarScript.Name = "btnGenerarScript";
            btnGenerarScript.Size = new Size(101, 33);
            btnGenerarScript.TabIndex = 8;
            btnGenerarScript.Text = "Generar Script";
            btnGenerarScript.UseVisualStyleBackColor = true;
            btnGenerarScript.Click += btnGenerarScript_Click;
            // 
            // txtScriptSQL
            // 
            txtScriptSQL.Location = new Point(330, 365);
            txtScriptSQL.Multiline = true;
            txtScriptSQL.Name = "txtScriptSQL";
            txtScriptSQL.ReadOnly = true;
            txtScriptSQL.ScrollBars = ScrollBars.Vertical;
            txtScriptSQL.Size = new Size(792, 384);
            txtScriptSQL.TabIndex = 9;
            // 
            // btnCopiarScript
            // 
            btnCopiarScript.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCopiarScript.IconColor = Color.Black;
            btnCopiarScript.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCopiarScript.Location = new Point(231, 726);
            btnCopiarScript.Name = "btnCopiarScript";
            btnCopiarScript.Size = new Size(93, 23);
            btnCopiarScript.TabIndex = 10;
            btnCopiarScript.Text = "Copiar Script";
            btnCopiarScript.UseVisualStyleBackColor = true;
            btnCopiarScript.Click += btnCopiarScript_Click;
            // 
            // lblStatus2
            // 
            lblStatus2.AutoSize = true;
            lblStatus2.Location = new Point(93, 535);
            lblStatus2.Name = "lblStatus2";
            lblStatus2.Size = new Size(38, 15);
            lblStatus2.TabIndex = 12;
            lblStatus2.Text = "label4";
            lblStatus2.Visible = false;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(93, 516);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(136, 16);
            progressBar2.TabIndex = 11;
            progressBar2.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonShadow;
            panel3.Location = new Point(785, 144);
            panel3.Name = "panel3";
            panel3.Size = new Size(138, 46);
            panel3.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Location = new Point(93, 467);
            panel1.Name = "panel1";
            panel1.Size = new Size(103, 35);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Location = new Point(231, 726);
            panel2.Name = "panel2";
            panel2.Size = new Size(95, 25);
            panel2.TabIndex = 15;
            // 
            // frmBackUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1134, 761);
            Controls.Add(lblStatus2);
            Controls.Add(progressBar2);
            Controls.Add(btnCopiarScript);
            Controls.Add(txtScriptSQL);
            Controls.Add(btnGenerarScript);
            Controls.Add(radSchemaYDatos);
            Controls.Add(radSchemaSolo);
            Controls.Add(label3);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCrearBackup);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "frmBackUp";
            Text = "frmBackUp";
            Load += frmBackUp_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCrearBackup;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Label label3;
        private RadioButton radSchemaSolo;
        private RadioButton radSchemaYDatos;
        private FontAwesome.Sharp.IconButton btnGenerarScript;
        private TextBox txtScriptSQL;
        private FontAwesome.Sharp.IconButton btnCopiarScript;
        private Label lblStatus2;
        private ProgressBar progressBar2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel2;
    }
}