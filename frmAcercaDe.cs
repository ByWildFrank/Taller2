using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }

        private void frmAcercaDe_Load(object sender, EventArgs e)
        {
            ConfigurarTexto();
            ConfigurarColores();
            ConfigurarAutores();
            SetGradientBackground();
        }

        // ==============================
        // CONFIGURACIÓN DE INTERFAZ
        // ==============================

        private void ConfigurarTexto()
        {
            lblTitulo.Text = "BeanDesktop";
            lblVersion.Text = "Versión 1.0.0";
            lblDescripcion.Text =
                "Proyecto académico de aplicación de escritorio con sistema CRUD, " +
                "segmentación de clientes y recomendaciones en ventas.";
        }

        private void ConfigurarAutores()
        {
            lstAutores.Items.Clear();
            lstAutores.Items.Add("👤 Franco Varela — Desarrollador Backend");
            lstAutores.Items.Add("👤 Santiago Scetti — Analista de Datos");
        }

        private void ConfigurarColores()
        {
            // Colores base
            Color fondo = Color.FromArgb(240, 240, 240);
            Color textoPrincipal = Color.Black;
            Color textoSecundario = Color.DimGray;

            // Asignar colores coherentes
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is LinkLabel || ctrl is ListBox)
                {
                    ctrl.BackColor = fondo;
                    ctrl.ForeColor = textoPrincipal;
                }
            }

            lblVersion.ForeColor = textoSecundario;
        }

        // ==============================
        // EVENTOS DE LINKS
        // ==============================

        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => AbrirLink("https://github.com/ByWildFrank/Taller2");

        private void lnkLinkedIn1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => AbrirLink("https://www.linkedin.com/in/franco-varela"); // 👈 corregí para que no apunte al mismo LinkedIn

        private void lnkLinkedIn2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => AbrirLink("https://www.linkedin.com/in/santiago-scetti");

        private void AbrirLink(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el link:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================
        // FONDO CON GRADIENTE
        // ==============================

        private void SetGradientBackground()
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(245, 245, 245), // gris claro superior
                Color.FromArgb(200, 200, 200), // gris medio inferior
                LinearGradientMode.Vertical))
            {
                Bitmap bmp = new Bitmap(Width, Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(brush, ClientRectangle);
                }
                BackgroundImage = bmp;
            }

            Refresh();
        }
    }
}
