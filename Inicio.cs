using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeanDesktop
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        // Constructor
        public Inicio(Usuario objusuario)
        {
            InitializeComponent();
            usuarioActual = objusuario;

            // Configuración de la región redondeada ya puede ir acá
            Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, Width, Height, 25, 25)
            );

            this.Load += Inicio_Load;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

            if (BtnDashboard != null && PnlNav != null)
            {
                PnlNav.Height = BtnDashboard.Height;
                PnlNav.Top = BtnDashboard.Top;
                PnlNav.Left = BtnDashboard.Left;
                PnlNav.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            }

            if (usuarioActual != null)
            {
                LblUserNameInicio.Text = usuarioActual.NombreCompleto;
                LblTipoUser.Text = usuarioActual.oRol?.Descripcion ?? "";
            }

            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                iconmenu.Visible = encontrado;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        //A PARTIR DE ACA LO MÁS IMPORTANTE
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            }
            menu.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }


        private void iconMenuItem4_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmUsuarios());
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario((menuStock), new frmCategoria());
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario((menuStock), new frmProducto(usuarioActual));
        }

        private void subMenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario((menuCajaRegistradora), new cajaRegistradora(usuarioActual));
        }

        private void subMenuVerDetalles_Click(object sender, EventArgs e)
        {
            AbrirFormulario((menuCajaRegistradora), new frmDetalleVenta());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuIAML_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmIAML());
        }



        private void verStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario((menuStock), new frmVerStock());
        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmAcercaDe());
        }

        private void menuBackUp_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmBackUp());
        }

        private void reporteEstadisticasSubMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReporte, new FrmReportes());
        }

        private void reporteVentasSubMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReporte, new frmReporteVentas());
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        private void menuDescuentos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmDescuentos());
        }
    }
}
