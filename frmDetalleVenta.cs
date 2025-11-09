using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Fonts;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmDetalleVenta : Form
    {
        private List<VentaInfo> _listaCompletaVentas;
        private System.Windows.Forms.Timer _busquedaTimer;

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

            // Configurar debounce (evita que se dispare en cada letra)
            _busquedaTimer = new System.Windows.Forms.Timer();
            _busquedaTimer.Interval = 300; // milisegundos
            _busquedaTimer.Tick += (s, ev) =>
            {
                _busquedaTimer.Stop();
                FiltrarVentas(txtNumeroDocumento.Text.Trim());
            };

            txtNumeroDocumento.TextChanged += (s, ev) =>
            {
                _busquedaTimer.Stop();
                _busquedaTimer.Start();
            };

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

            dgvDetalleVenta.Columns.Add("IdVenta", "IdVenta");
            dgvDetalleVenta.Columns["IdVenta"].Visible = false;

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

        private void FiltrarVentas(string texto)
        {
            if (_listaCompletaVentas == null || _listaCompletaVentas.Count == 0)
                return;

            texto = texto.ToUpper();

            var filtradas = _listaCompletaVentas
                .Where(v => v.NumeroDocumento.ToUpper().Contains(texto))
                .ToList();
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

        private void dgvDetalleVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Solo ejecutar si la grilla tiene la columna "NumeroDocumento"
            if (!dgvDetalleVenta.Columns.Contains("NumeroDocumento"))
                return;

            string numDoc = dgvDetalleVenta.Rows[e.RowIndex].Cells["NumeroDocumento"].Value.ToString();
            MostrarDetalleDeVenta(numDoc);
        }


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

        private void DgvDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evita clicks en encabezados o el selector de fila
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvDetalleVenta.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int idVenta = Convert.ToInt32(dgvDetalleVenta.Rows[e.RowIndex].Cells["IdVenta"].Value);
                GenerarPDFVenta(idVenta);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        // ✅ Generar PDF con PdfSharp
        private void GenerarPDFVenta(int idVenta)
        {
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;
            Venta venta = new CN_Venta().ObtenerPorId(idVenta);
            List<Detalle_Venta> detalles = new CN_Venta().ListarDetallePorVenta(idVenta);

            if (venta == null)
            {
                MessageBox.Show("No se pudo encontrar la venta.");
                return;
            }

            try
            {
          
                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string carpetaTickets = Path.Combine(documentosPath, "Tickets");

                if (!Directory.Exists(carpetaTickets))
                    Directory.CreateDirectory(carpetaTickets);

                string nombreArchivo = $"Detalle_Venta_{venta.NumeroDocumento}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string ruta = Path.Combine(carpetaTickets, nombreArchivo);

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = $"Detalle de Venta #{venta.IdVenta}";
                PdfPage page = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Fuentes refinadas
                XFont fontTitle = new XFont("Arial", 20, XFontStyleEx.Bold);
                XFont fontSection = new XFont("Arial", 13, XFontStyleEx.Bold);
                XFont fontNormal = new XFont("Arial", 11, XFontStyleEx.Regular);
                XFont fontFooter = new XFont("Arial", 9, XFontStyleEx.Italic);

                double marginLeft = 50;
                double yPoint = 60;

                // Logo institucional
                try
                {
                    using (var ms = new MemoryStream(Properties.Resources.MarcaPNGreducida))
                    {
                        XImage logo = XImage.FromStream(ms);
                        double logoWidth = 70;
                        double logoHeight = (logo.PixelHeight / (double)logo.PixelWidth) * logoWidth;
                        gfx.DrawImage(logo, page.Width - logoWidth - marginLeft, yPoint - 30, logoWidth, logoHeight);
                    }
                }
                catch { }

                // Título principal
                gfx.DrawString($"Detalle de Venta Nº {venta.IdVenta}", fontTitle, XBrushes.Black,
                    new XRect(0, yPoint, page.Width, 30), XStringFormats.TopCenter);
                yPoint += 50;

                // Línea decorativa
                gfx.DrawLine(new XPen(XColors.DarkGray, 1.5), marginLeft, yPoint, page.Width - marginLeft, yPoint);
                yPoint += 25;

                // Información del cliente
                // Información del cliente
                string[] infoVenta = {
                        $"Cliente: {venta.oCliente?.NombreCompleto ?? "Consumidor Final"}",
                        $"Documento del Cliente: {venta.oCliente?.Documento ?? "---"}",
                        $"Tipo de Comprobante: {venta.TipoDocumento}",
                        $"Número de {venta.TipoDocumento}: {venta.IdVenta}",
                        $"Monto Total: {venta.MontoTotal:C2}",
                        $"Descuento Aplicado: {venta.DescuentoAplicado:C2}"
                    };


                foreach (var info in infoVenta)
                {
                    gfx.DrawString(info, fontNormal, XBrushes.Black,
                        new XRect(marginLeft, yPoint, page.Width - marginLeft * 2, 20), XStringFormats.TopLeft);
                    yPoint += 18;
                }

                yPoint += 30;

                // Sección de productos
                gfx.DrawString("Detalle de Productos", fontSection, XBrushes.Black,
                    new XRect(marginLeft, yPoint, page.Width, 20), XStringFormats.TopLeft);
                yPoint += 25;

                // Encabezado de tabla
                gfx.DrawRectangle(XBrushes.LightSteelBlue, marginLeft - 5, yPoint - 3, page.Width - marginLeft * 2 + 10, 22);
                gfx.DrawString("Producto", fontSection, XBrushes.Black, marginLeft, yPoint);
                gfx.DrawString("Precio", fontSection, XBrushes.Black, marginLeft + 220, yPoint);
                gfx.DrawString("Cantidad", fontSection, XBrushes.Black, marginLeft + 320, yPoint);
                gfx.DrawString("Subtotal", fontSection, XBrushes.Black, marginLeft + 420, yPoint);
                yPoint += 25;

                // Filas de productos
                foreach (var d in detalles)
                {
                    gfx.DrawString(d.NombreProducto, fontNormal, XBrushes.Black, marginLeft, yPoint);
                    gfx.DrawString(d.PrecioVenta.ToString("C2"), fontNormal, XBrushes.Black, marginLeft + 220, yPoint);
                    gfx.DrawString(d.Cantidad.ToString(), fontNormal, XBrushes.Black, marginLeft + 320, yPoint);
                    gfx.DrawString(d.SubTotal.ToString("C2"), fontNormal, XBrushes.Black, marginLeft + 420, yPoint);
                    yPoint += 20;

                    gfx.DrawLine(XPens.LightGray, marginLeft - 5, yPoint, page.Width - marginLeft + 5, yPoint);

                    if (yPoint > page.Height - 80)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPoint = 60;
                    }
                }

                yPoint += 30;
                gfx.DrawLine(new XPen(XColors.DarkGray, 1.5), marginLeft, yPoint, page.Width - marginLeft, yPoint);
                yPoint += 30;

                // Pie de página
                gfx.DrawString("Documento generado automáticamente por BeanDesktop", fontFooter, XBrushes.Gray,
                    new XRect(0, page.Height - 40, page.Width, 20), XStringFormats.Center);

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
