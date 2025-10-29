using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;

namespace BeanDesktop
{
    public partial class frmDetalleVenta : Form
    {
        // Guardará la lista completa de ventas para filtrar en memoria
        private List<VentaInfo> _listaCompletaVentas;

        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;

            EstiloTextBoxLectura(txtTipoDocumento);
            EstiloTextBoxLectura(txtNumeroDocumentoMostrar);
            EstiloTextBoxLectura(txtDescuento);
            EstiloTextBoxLectura(txtDocumentoCliente);
            EstiloTextBoxLectura(txtIdVenta);
            EstiloTextBoxLectura(txtCliente);
            EstiloTextBoxLectura(txtMontoTotal);

            ConfigurarGrillaVentas();
            CargarListaDeVentas();

            txtNumeroDocumento.TextChanged += txtNumeroDocumento_TextChanged;
            LimpiarCamposDetalle();
        }

        private void LimpiarCamposDetalle()
        {
            txtIdVenta.Text = "";
            txtTipoDocumento.Text = "";
            txtNumeroDocumentoMostrar.Text = "";
            txtMontoTotal.Text = "";
            txtDescuento.Text = "";
            txtCliente.Text = "";
            txtDocumentoCliente.Text = "";
        }

        private void LimpiarCampos()
        {
            txtNumeroDocumento.Clear();
            LimpiarCamposDetalle();
            ConfigurarGrillaVentas();
            CargarListaDeVentas();
        }

        private void ConfigurarGrillaVentas()
        {
            dgvDetalleVenta.AutoGenerateColumns = false;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.Columns.Clear();

            dgvDetalleVenta.Columns.Add("FechaRegistro", "Fecha");
            dgvDetalleVenta.Columns.Add("TipoDocumento", "Tipo Doc.");
            dgvDetalleVenta.Columns.Add("NumeroDocumento", "Número Doc.");
            dgvDetalleVenta.Columns.Add("NombreCliente", "Cliente");
            dgvDetalleVenta.Columns.Add("NombreUsuario", "Vendedor");
            dgvDetalleVenta.Columns.Add("MontoTotal", "Monto Total");
            dgvDetalleVenta.Columns["MontoTotal"].DefaultCellStyle.Format = "C2";

            // Ocultamos IdVenta
            dgvDetalleVenta.Columns.Add("IdVenta", "IdVenta");
            dgvDetalleVenta.Columns["IdVenta"].Visible = false;

            // ✅ Columna de botón para PDF
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Acción";
            btnColumn.Text = "Generar PDF";
            btnColumn.UseColumnTextForButtonValue = true;
            btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalleVenta.Columns.Add(btnColumn);

            dgvDetalleVenta.CellClick += DgvDetalleVenta_CellClick;
        }

        private void CargarListaDeVentas()
        {
            _listaCompletaVentas = new CN_Venta().ListarVentas();

            dgvDetalleVenta.Rows.Clear();
            foreach (var v in _listaCompletaVentas)
            {
                dgvDetalleVenta.Rows.Add(new object[]
                {
                    v.FechaRegistro,
                    v.TipoDocumento,
                    v.NumeroDocumento,
                    v.NombreCliente,
                    v.NombreUsuario,
                    v.MontoTotal,
                    v.IdVenta
                });
            }
        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtNumeroDocumento.Text.Trim().ToUpper();

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;
                bool coincide = row.Cells["NumeroDocumento"].Value.ToString().ToUpper().Contains(textoBusqueda);
                row.Visible = coincide;
            }
        }

        private void MostrarDetalleDeVenta(string numeroDocumento)
        {
            Venta venta = new CN_Venta().ObtenerPorNumeroDocumento(numeroDocumento);

            if (venta == null)
            {
                MessageBox.Show("No se pudieron cargar los detalles de la venta.");
                return;
            }

            txtIdVenta.Text = venta.IdVenta.ToString();
            txtTipoDocumento.Text = venta.TipoDocumento;
            txtNumeroDocumentoMostrar.Text = venta.NumeroDocumento;
            txtMontoTotal.Text = venta.MontoTotal.ToString("C2");
            txtDescuento.Text = venta.DescuentoAplicado.ToString("C2");

            if (venta.oCliente != null)
            {
                txtCliente.Text = venta.oCliente.NombreCompleto;
                txtDocumentoCliente.Text = venta.oCliente.Documento;
            }
            else
            {
                txtCliente.Text = "Consumidor Final";
                txtDocumentoCliente.Text = "---";
            }

            ConfigurarGrillaDetalles();
            List<Detalle_Venta> detalles = new CN_Venta().ListarDetallePorVenta(venta.IdVenta);

            dgvDetalleVenta.Rows.Clear();
            foreach (var d in detalles)
            {
                dgvDetalleVenta.Rows.Add(new object[]
                {
                    d.NombreProducto,
                    d.PrecioVenta,
                    d.Cantidad,
                    d.SubTotal
                });
            }
        }

        private void ConfigurarGrillaDetalles()
        {
            dgvDetalleVenta.Columns.Clear();
            dgvDetalleVenta.Columns.Add("NombreProducto", "Producto");
            dgvDetalleVenta.Columns.Add("PrecioVenta", "Precio");
            dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("SubTotal", "SubTotal");
            dgvDetalleVenta.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvDetalleVenta.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
        }

        private void EstiloTextBoxLectura(TextBox txt)
        {
            txt.ReadOnly = true;
            txt.BackColor = System.Drawing.Color.White;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        // ✅ Doble clic para mostrar detalle
        private void dgvDetalleVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string numDoc = dgvDetalleVenta.Rows[e.RowIndex].Cells["NumeroDocumento"].Value.ToString();
            MostrarDetalleDeVenta(numDoc);
        }

        // ✅ Botón buscar (ya sin txtFecha ni dgvDetalles)
        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            string numeroDocumento = txtNumeroDocumento.Text.Trim();

            if (string.IsNullOrEmpty(numeroDocumento))
            {
                MessageBox.Show("Ingrese un número de documento para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = new CN_Venta().ObtenerPorNumeroDocumento(numeroDocumento);

            if (venta != null)
            {
                MostrarDetalleDeVenta(numeroDocumento);
            }
            else
            {
                MessageBox.Show("No se encontró ninguna venta con ese número de documento.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ✅ Click en botón de PDF
        private void DgvDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDetalleVenta.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int idVenta = Convert.ToInt32(dgvDetalleVenta.Rows[e.RowIndex].Cells["IdVenta"].Value);
                GenerarPDFVenta(idVenta);
            }
        }

        // ✅ Generar PDF con QuestPDF
        private void GenerarPDFVenta(int idVenta)
        {

            PdfSharp.Fonts.GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            Venta venta = new CN_Venta().ObtenerPorId(idVenta);
            List<Detalle_Venta> detalles = new CN_Venta().ListarDetallePorVenta(idVenta);

            if (venta == null)
            {
                MessageBox.Show("No se pudo encontrar la venta.");
                return;
            }

            try
            {
                // 📂 Carpeta "Tickets" dentro de "Documentos" del usuario
                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string carpetaTickets = Path.Combine(documentosPath, "Tickets");

                if (!Directory.Exists(carpetaTickets))
                    Directory.CreateDirectory(carpetaTickets);

                string nombreArchivo = $"Detalle_Venta_{venta.NumeroDocumento}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string ruta = Path.Combine(carpetaTickets, nombreArchivo);

                // Crear PDF
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = $"Detalle de Venta #{venta.IdVenta}";

                PdfPage page = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont fontBold = new XFont("Arial", 12, PdfSharp.Drawing.XFontStyleEx.Bold);
                XFont fontNormal = new XFont("Arial", 12, PdfSharp.Drawing.XFontStyleEx.Regular);


                double yPoint = 40;

                // Encabezado
                gfx.DrawString($"Detalle de Venta #{venta.IdVenta}", new XFont("Arial", 18, XFontStyleEx.Bold), XBrushes.Black, new XRect(0, yPoint, page.Width, 30), XStringFormats.TopCenter);
                yPoint += 40;

                // Datos del cliente y venta
                gfx.DrawString($"Cliente: {venta.oCliente?.NombreCompleto ?? "Consumidor Final"}", fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 20;
                gfx.DrawString($"Documento: {venta.oCliente?.Documento ?? "---"}", fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 20;
                gfx.DrawString($"Tipo de Documento: {venta.TipoDocumento}", fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 20;
                gfx.DrawString($"Número de Documento: {venta.NumeroDocumento}", fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 20;
                gfx.DrawString($"Monto Total: {venta.MontoTotal:C2}", fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 20;
                gfx.DrawString($"Descuento: {venta.DescuentoAplicado:C2}", fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 30;

                // Tabla de productos
                gfx.DrawString("Productos:", fontBold, XBrushes.Black, new XRect(40, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 25;

                // Encabezados de tabla
                gfx.DrawString("Producto", fontBold, XBrushes.Black, 40, yPoint);
                gfx.DrawString("Precio", fontBold, XBrushes.Black, 300, yPoint);
                gfx.DrawString("Cantidad", fontBold, XBrushes.Black, 380, yPoint);
                gfx.DrawString("Subtotal", fontBold, XBrushes.Black, 460, yPoint);
                yPoint += 20;

                foreach (var d in detalles)
                {
                    gfx.DrawString(d.NombreProducto, fontNormal, XBrushes.Black, 40, yPoint);
                    gfx.DrawString(d.PrecioVenta.ToString("C2"), fontNormal, XBrushes.Black, 300, yPoint);
                    gfx.DrawString(d.Cantidad.ToString(), fontNormal, XBrushes.Black, 380, yPoint);
                    gfx.DrawString(d.SubTotal.ToString("C2"), fontNormal, XBrushes.Black, 460, yPoint);
                    yPoint += 20;

                    // Salto de página si se pasa de la altura
                    if (yPoint > page.Height - 50)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPoint = 40;
                    }
                }

                // Footer
                gfx.DrawString("Generado automáticamente por BeanDesktop", new XFont("Arial", 10, XFontStyleEx.Regular), XBrushes.Gray, new XRect(0, page.Height - 40, page.Width, 20), XStringFormats.Center);

                pdf.Save(ruta);

                MessageBox.Show($"PDF generado correctamente en:\n{ruta}", "PDF generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
