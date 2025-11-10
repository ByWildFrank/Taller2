using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeEntidades;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Fonts;

namespace BeanDesktop
{
    public partial class cajaRegistradora : Form
    {
        private DataTable detalleVenta;
        private int idClienteSeleccionado = 0;
        private Usuario usuarioLogueado;
        private decimal _descuentoPorcentajeCliente = 0;
        private List<Cliente> _listaClientesActivos;

        // Guardamos la lista completa de productos para filtrar en memoria
        private List<Producto> _listaProductosCompleta;

        public cajaRegistradora(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
            pnlCliente.BackColor = Color.White;
            pnlProductos.BackColor = Color.White;
            pnlCarrito.BackColor = Color.White;
            pnlTotales.BackColor = Color.White;
        }

        private void cajaRegistradora_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
            pnlCliente.BackColor = Color.White;
            pnlProductos.BackColor = Color.White;
            pnlCarrito.BackColor = Color.White;
            pnlTotales.BackColor = Color.White;

            // Inicializar DataTable para el carrito
            detalleVenta = new DataTable();
            detalleVenta.Columns.Add("IdProducto", typeof(int));
            detalleVenta.Columns.Add("NombreProducto", typeof(string));
            detalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
            detalleVenta.Columns.Add("Cantidad", typeof(int));
            detalleVenta.Columns.Add("SubTotal", typeof(decimal));

            dgvCarrito.DataSource = detalleVenta;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Ocultar IdProducto en el carrito
            dgvCarrito.Columns["IdProducto"].Visible = false;

            // Cargar tipos de documento
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;


            _listaClientesActivos = new CN_Cliente().ListarActivos();

            CargarSugerenciasClientes();
            CargarProductos(); // Carga la lista _listaProductosCompleta

            // Cargar categorías activas
            CN_Categoria objCategoria = new CN_Categoria();
            var listaCategorias = objCategoria.Listar().Where(c => c.Estado).ToList();
            listaCategorias.Insert(0, new Categoria { IdCategoria = 0, Descripcion = "Todas" });
            cboCategoria.DataSource = listaCategorias;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "IdCategoria";
            cboCategoria.SelectedIndex = 0;

            // Conectar eventos para filtros dinámicos
            txtPago.TextChanged += txtPago_TextChanged;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            cboCategoria.SelectedIndexChanged += cboCategoria_SelectedIndexChanged;

            dgvProductos.DataBindingComplete += dgvProductos_DataBindingComplete;

            txtDescuento.TextChanged += txtDescuento_TextChanged;
        }

        private void CargarSugerenciasClientes()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var cliente in _listaClientesActivos)
            {
                autoCompleteCollection.Add($"{cliente.Documento} - {cliente.NombreCompleto}");
            }

            txtDocumentoCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDocumentoCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDocumentoCliente.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void CargarProductos()
        {
            CN_Producto objProducto = new CN_Producto();
            _listaProductosCompleta = objProducto.Listar();

            // Filtramos solo los activos y con stock > 0
            var productosActivos = _listaProductosCompleta
                                    .Where(p => p.Estado && p.stock > 0)
                                    .ToList();

            dgvProductos.DataSource = null; // Desenlazar primero
            dgvProductos.DataSource = productosActivos;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Verificamos que la grilla tenga columnas
            if (dgvProductos.Columns.Count == 0) return;

            try
            {
                // Ocultar columnas que no interesan en la venta
                if (dgvProductos.Columns["IdProducto"] != null)
                    dgvProductos.Columns["IdProducto"].Visible = false;

                if (dgvProductos.Columns["oCategoria"] != null)
                    dgvProductos.Columns["oCategoria"].Visible = true;

                if (dgvProductos.Columns["PrecioFabricacion"] != null)
                    dgvProductos.Columns["PrecioFabricacion"].Visible = false;

                if (dgvProductos.Columns["Estado"] != null)
                    dgvProductos.Columns["Estado"].Visible = false;

                if (dgvProductos.Columns["Descripcion"] != null)
                    dgvProductos.Columns["Descripcion"].Visible = false;

                if (dgvProductos.Columns["codigo"] != null)
                    dgvProductos.Columns["codigo"].Visible = true;

                if (dgvProductos.Columns["stock"] != null)
                    dgvProductos.Columns["stock"].Visible = true;

                if (dgvProductos.Columns["FechaRegistro"] != null)
                    dgvProductos.Columns["FechaRegistro"].Visible = false;
            }
            catch (Exception ex)
            {
                // Esto es útil para depurar si un nombre de columna está mal escrito
                Console.WriteLine("Error al ocultar columnas: " + ex.Message);
            }
        }

        private void FiltrarProductosGrid()
        {
            if (_listaProductosCompleta == null) return;

            // ✅ Filtramos productos activos con stock > 0
            IEnumerable<Producto> productosFiltrados = _listaProductosCompleta
                                                       .Where(p => p.Estado && p.stock > 0);

            string textoBusqueda = txtBuscarProducto.Text.Trim().ToUpper();

            int idCategoria = 0;
            if (cboCategoria.SelectedItem != null)
            {
                Categoria categoriaSeleccionada = (Categoria)cboCategoria.SelectedItem;
                idCategoria = categoriaSeleccionada.IdCategoria;
            }

            if (idCategoria > 0)
            {
                productosFiltrados = productosFiltrados.Where(p => p.oCategoria.IdCategoria == idCategoria);
            }

            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                productosFiltrados = productosFiltrados.Where(p =>
                    (p.Nombre != null && p.Nombre.ToUpper().Contains(textoBusqueda)) ||
                    (p.codigo != null && p.codigo.ToUpper().Contains(textoBusqueda))
                );
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productosFiltrados.ToList();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductosGrid();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductosGrid();
        }



        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var productoSeleccionado = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

                int idProducto = productoSeleccionado.IdProducto;
                string nombreProducto = productoSeleccionado.Nombre;
                decimal precioVenta = productoSeleccionado.PrecioVenta;
                int stock = productoSeleccionado.stock;

                // CAMBIO: Obtener la cantidad deseada desde el NumericUpDown
                int cantidadAAgregar = (int)numCantidad.Value;

                if (stock <= 0 || cantidadAAgregar > stock)
                {
                    MessageBox.Show($"Stock insuficiente. Stock disponible: {stock}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow filaExistente = detalleVenta.AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("IdProducto") == idProducto);

                if (filaExistente != null)
                {
                    int cantidadActual = filaExistente.Field<int>("Cantidad");
                    int nuevaCantidad = cantidadActual + cantidadAAgregar;

                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show($"Stock insuficiente. Ya tiene {cantidadActual} en el carrito y el stock total es {stock}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    filaExistente["Cantidad"] = nuevaCantidad;
                    filaExistente["SubTotal"] = precioVenta * nuevaCantidad;
                }
                else
                {
                    detalleVenta.Rows.Add(idProducto, nombreProducto, precioVenta, cantidadAAgregar, precioVenta * cantidadAAgregar);
                }

                CalcularTotales();

                numCantidad.Value = 1;
                txtBuscarProducto.Focus();
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                dgvCarrito.Rows.RemoveAt(dgvCarrito.CurrentRow.Index);
                CalcularTotales();
            }
        }

        private void CalcularTotales()
        {
            decimal total = 0;
            if (detalleVenta.Rows.Count > 0)
            {
                total = detalleVenta.AsEnumerable().Sum(r => r.Field<decimal>("SubTotal"));
            }

            txtTotal.Text = total.ToString("0.00");

            // --- LÓGICA DE DESCUENTO ---
            decimal descuentoCalculado = total * (_descuentoPorcentajeCliente / 100);

            txtDescuento.Text = descuentoCalculado.ToString("0.00"); 
            txtDescuentoAplicado.Text = descuentoCalculado.ToString("0.00"); 
            txtTotalFinal.Text = (total - descuentoCalculado).ToString("0.00");

            // Actualizamos el campo de cambio automáticamente
            txtPago_TextChanged(null, null);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtDocumentoCliente.Text.Trim();
            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Ingrese un documento o nombre para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string documentoBusqueda = textoBusqueda.Split(' ')[0];
            
            Cliente clienteEncontrado = null;

            clienteEncontrado = _listaClientesActivos.FirstOrDefault(c => c.Documento.Equals(documentoBusqueda, StringComparison.OrdinalIgnoreCase));

            if (clienteEncontrado == null)
            {
                clienteEncontrado = _listaClientesActivos.FirstOrDefault(c => c.NombreCompleto.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase));
            }

            if (clienteEncontrado != null)
            {
                idClienteSeleccionado = clienteEncontrado.IdCliente;
                txtDocumentoCliente.Text = clienteEncontrado.Documento;
                txtNombreCliente.Text = clienteEncontrado.NombreCompleto;

                _descuentoPorcentajeCliente = clienteEncontrado.DescuentoPorcent;
                lblSegmentoCliente.Text = $"({clienteEncontrado.Segmento} - {clienteEncontrado.DescuentoPorcent}%)";
                lblSegmentoCliente.ForeColor = Color.RoyalBlue;

                // Forzamos el recálculo de totales
                CalcularTotales();
            }
            else
            {
                idClienteSeleccionado = 0;
                txtNombreCliente.Text = "Cliente no encontrado";
                lblSegmentoCliente.Text = "(Consumidor Final)";
                txtDescuento.Text = "0.00";
                CalcularTotales();
                MessageBox.Show("Cliente no registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CalcularTotales();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {


            if (detalleVenta.Rows.Count == 0) { MessageBox.Show("No hay productos en el carrito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (idClienteSeleccionado == 0) { MessageBox.Show("Seleccione un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            decimal.TryParse(txtPago.Text, out decimal montoPago);
            decimal.TryParse(txtTotalFinal.Text, out decimal montoTotal);
            decimal.TryParse(txtDescuentoAplicado.Text, out decimal descuentoAplicado);

            decimal montoCambio = montoPago - montoTotal;
            if (montoCambio < 0) { MessageBox.Show("El pago es insuficiente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            CN_Venta objVentaCN = new CN_Venta();

            string tipoDoc = ((OpcionCombo)cboTipoDocumento.SelectedItem)?.Texto ?? "Boleta";
            string nuevoNumeroDoc = objVentaCN.GenerarSiguienteNumeroDocumento(tipoDoc);

            Venta objVenta = new Venta()
            {
                IdUsuario = usuarioLogueado.IdUsuario,
                IdCliente = idClienteSeleccionado,
                TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem)?.Texto ?? "Boleta",
                NumeroDocumento = nuevoNumeroDoc, // <-- Usamos el número generado
                MontoPago = montoPago,
                MontoCambio = montoCambio,
                MontoTotal = montoTotal,
                DescuentoAplicado = descuentoAplicado
            };

            DataTable dtDetalleParaSQL = detalleVenta.Copy();

            if (dtDetalleParaSQL.Columns.Contains("NombreProducto"))
                dtDetalleParaSQL.Columns.Remove("NombreProducto");

            string mensaje = string.Empty;
            

            int idVentaGenerada = objVentaCN.Registrar(objVenta, dtDetalleParaSQL, out mensaje);

            if (idVentaGenerada > 0)
            {
                MessageBox.Show("Venta registrada correctamente. ID Venta: " + idVentaGenerada, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Generar PDF automáticamente
                GenerarPDFVenta(idVentaGenerada);

                LimpiarFormulario();
                CargarProductos();
            }
            else
            {
                MessageBox.Show(mensaje, "Error al registrar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarFormulario()
        {
            txtDocumentoCliente.Clear();
            txtNombreCliente.Clear();
            txtPago.Clear();
            txtCambio.Clear();
            txtDescuento.Clear();
            txtDescuentoAplicado.Clear();
            txtTotal.Clear();
            txtTotalFinal.Clear();
            detalleVenta.Rows.Clear();
            idClienteSeleccionado = 0;
            cboTipoDocumento.SelectedIndex = 0;

            _descuentoPorcentajeCliente = 0;
            lblSegmentoCliente.Text = "";
            txtDescuento.Text = "0.00";

            txtBuscarProducto.Clear();
            cboCategoria.SelectedIndex = 0;
            FiltrarProductosGrid();
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtPago.Text, out decimal montoPago);
            decimal.TryParse(txtTotalFinal.Text, out decimal montoTotal);
            decimal cambio = montoPago - montoTotal;
            txtCambio.Text = cambio >= 0 ? cambio.ToString("0.00") : "0.00";
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmClientes formularioClientes = new frmClientes();
            formularioClientes.ShowDialog();

            CargarSugerenciasClientes();

            txtDocumentoCliente.Focus();
        }

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
                XFont fontTotal = new XFont("Arial", 12, XFontStyleEx.Bold);

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
                decimal montoTotalCalculado = 0;

                foreach (var d in detalles)
                {
                    gfx.DrawString(d.NombreProducto, fontNormal, XBrushes.Black, marginLeft, yPoint);
                    gfx.DrawString(d.PrecioVenta.ToString("C2"), fontNormal, XBrushes.Black, marginLeft + 220, yPoint);
                    gfx.DrawString(d.Cantidad.ToString(), fontNormal, XBrushes.Black, marginLeft + 320, yPoint);
                    gfx.DrawString(d.SubTotal.ToString("C2"), fontNormal, XBrushes.Black, marginLeft + 420, yPoint);
                    yPoint += 20;

                    montoTotalCalculado += d.SubTotal;

                    gfx.DrawLine(XPens.LightGray, marginLeft - 5, yPoint, page.Width - marginLeft + 5, yPoint);

                    // Salto de página automático
                    if (yPoint > page.Height - 100)
                    {
                        page = pdf.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPoint = 60;
                    }
                }

                // Línea final de separación
                yPoint += 20;
                gfx.DrawLine(new XPen(XColors.DarkGray, 1.2), marginLeft, yPoint, page.Width - marginLeft, yPoint);
                yPoint += 15;

                // Mostrar el monto total al final
                gfx.DrawString("TOTAL GENERAL:", fontTotal, XBrushes.Black, marginLeft + 320, yPoint);
                gfx.DrawString(montoTotalCalculado.ToString("C2"), fontTotal, XBrushes.Black, marginLeft + 420, yPoint);
                yPoint += 30;

                // Línea decorativa final
                gfx.DrawLine(new XPen(XColors.DarkGray, 1.5), marginLeft, yPoint, page.Width - marginLeft, yPoint);

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

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }
    }
}