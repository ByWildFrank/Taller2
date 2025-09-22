using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using CapaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroDocumento.Text))
            {
                MessageBox.Show("Ingrese un número de documento para buscar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Venta venta = new CN_Venta().ObtenerPorNumeroDocumento(txtNumeroDocumento.Text);

            if (venta != null)
            {
                CargarVenta(venta);
            }
            else
            {
                MessageBox.Show("No se encontró la venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarVenta(Venta venta)
        {
            // Mostrar cabecera
            txtIdVenta.Text = venta.IdVenta.ToString();
            txtCliente.Text = venta.NombreCliente;
            txtDocumentoCliente.Text = venta.DocumentoCliente;
            txtTipoDocumento.Text = venta.TipoDocumento;
            txtNumeroDocumentoMostrar.Text = venta.NumeroDocumento;
            txtMontoTotal.Text = venta.MontoTotal.ToString("0.00");
            txtDescuento.Text = venta.DescuentoAplicado.ToString("0.00");

            // Cargar detalles
            dgvDetalleVenta.Rows.Clear();
            List<DetalleVenta> detalles = new CN_Venta().ListarDetallePorVenta(venta.IdVenta);

            foreach (var d in detalles)
            {
                dgvDetalleVenta.Rows.Add(new object[]
                {
                    d.IdDetalleVenta,
                    d.IdProducto,
                    d.PrecioVenta,
                    d.Cantidad,
                    d.SubTotal,
                    d.FechaRegistro
                });
            }
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
