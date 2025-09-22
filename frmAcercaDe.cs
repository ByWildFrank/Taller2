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
            lblTitulo.Text = "BeanDesktop";
            lblVersion.Text = "Versión 1.0.0";
            lblDescripcion.Text = "Proyecto académico de Aplicación de escritorio con sistema CRUD, segmentación de clientes y recomendaciones en ventas";

            // Autores
            lstAutores.Items.Add("👤 Franco Varela - Desarrollador Backend");
            lstAutores.Items.Add("👤 Santiago Scetti - Analista de Datos");
            // Configurar fondo con gradiente
            SetGradientBackground();
            this.Refresh(); // fuerza el redibujado

            // Hacer los controles transparentes y ajustar colores de texto
            lblTitulo.BackColor = Color.LightGray;
            lblTitulo.ForeColor = Color.Black; 

            lblVersion.BackColor = Color.LightGray;
            lblVersion.ForeColor = Color.Gray; 

            lblDescripcion.BackColor = Color.LightGray;
            lblDescripcion.ForeColor = Color.Black;

            lstAutores.BackColor = Color.LightGray;
            lstAutores.ForeColor = Color.Black;

            lnkGitHub.BackColor = Color.LightGray;
            lnkLinkedIn1.BackColor = Color.LightGray;
            lnkLinkedIn2.BackColor = Color.LightGray;
            label1.BackColor = Color.LightGray;
        }
        // Abrir links externos
        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirLink("https://github.com/ByWildFrank/Taller2");
        }

        private void lnkLinkedIn1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirLink("https://www.linkedin.com/in/santiago-scetti");
        }

        private void lnkLinkedIn2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirLink("https://www.linkedin.com/in/santiago-scetti");
        }


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
                MessageBox.Show("No se pudo abrir el link: " + ex.Message);
            }
        }
        private void SetGradientBackground()
        {
            LinearGradientBrush gradient = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(220, 220, 220), // Gris claro
                Color.FromArgb(150, 150, 150), // Gris medio oscuro
                LinearGradientMode.Vertical
            );
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(this.BackgroundImage))
            {
                g.FillRectangle(gradient, this.ClientRectangle);
            }
        }
    }
}