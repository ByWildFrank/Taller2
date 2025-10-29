using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeEntidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace BeanDesktop
{
    public partial class cajaRegistradora : Form
    {
        private DataTable detalleVenta;
        private int idClienteSeleccionado = 0;
        private Usuario usuarioLogueado;

        // ✅ Guardamos la lista completa de productos para filtrar en memoria
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
            detalleVenta.Columns.Add("NombreProducto", typeof(string)); // ✅ Añadir nombre para la grilla
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
        }

        private void CargarSugerenciasClientes()
        {
            List<Cliente> listaClientes = new CN_Cliente().ListarActivos();
            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var cliente in listaClientes)
            {
                autoCompleteCollection.Add(cliente.Documento);
                autoCompleteCollection.Add(cliente.NombreCompleto);
            }
            txtDocumentoCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDocumentoCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDocumentoCliente.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void CargarProductos()
        {
            CN_Producto objProducto = new CN_Producto();
            // Obtenemos la lista UNA SOLA VEZ y la guardamos
            _listaProductosCompleta = objProducto.Listar();

            // Filtramos solo los activos para mostrar en la venta
            var productosActivos = _listaProductosCompleta.Where(p => p.Estado).ToList();

            dgvProductos.DataSource = null; // Desenlazar primero
            dgvProductos.DataSource = productosActivos;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ocultar columnas que no interesan en la venta
            if (dgvProductos.Columns.Contains("IdProducto"))
                dgvProductos.Columns["IdProducto"].Visible = false;

            if (dgvProductos.Columns.Contains("oCategoria"))
                dgvProductos.Columns["oCategoria"].Visible = false;

            if (dgvProductos.Columns.Contains("IdCategoria"))
                dgvProductos.Columns["IdCategoria"].Visible = false;

            if (dgvProductos.Columns.Contains("PrecioFabricacion"))
                dgvProductos.Columns["PrecioFabricacion"].Visible = false;

            if (dgvProductos.Columns.Contains("Estado"))
                dgvProductos.Columns["Estado"].Visible = false;

        }

        // --- MÉTODOS DE FILTRADO DINÁMICO (NUEVOS) ---

        private void FiltrarProductosGrid()
        {
            if (_listaProductosCompleta == null) return;

            // Empezamos con la lista de productos activos
            IEnumerable<Producto> productosFiltrados = _listaProductosCompleta.Where(p => p.Estado);

            // 1. Obtener valores de filtro
            string textoBusqueda = txtBuscarProducto.Text.Trim().ToUpper();
            int idCategoria = 0;
            try
            {
                idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            }
            catch
            {
                if (cboCategoria.SelectedValue is Categoria cat)
                    idCategoria = cat.IdCategoria;
            }

            // 2. Aplicar filtro de categoría (si no es "Todas")
            if (idCategoria > 0)
            {
                productosFiltrados = productosFiltrados.Where(p => p.oCategoria.IdCategoria == idCategoria);
            }

            // 3. Aplicar filtro de texto (si no está vacío)
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                productosFiltrados = productosFiltrados.Where(p =>
                    (p.Nombre != null && p.Nombre.ToUpper().Contains(textoBusqueda)) ||
                    (p.codigo != null && p.codigo.ToUpper().Contains(textoBusqueda))
                );
            }

            // 4. Asignar la nueva lista filtrada a la grilla
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

        // --- FIN DE MÉTODOS DE FILTRADO ---


        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos el producto directamente de la fuente de datos
                var productoSeleccionado = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

                int idProducto = productoSeleccionado.IdProducto;
                string nombreProducto = productoSeleccionado.Nombre;
                decimal precioVenta = productoSeleccionado.PrecioVenta;
                int stock = productoSeleccionado.stock;

                if (stock <= 0)
                {
                    MessageBox.Show("Este producto no tiene stock disponible.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow filaExistente = detalleVenta.AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("IdProducto") == idProducto);

                if (filaExistente != null)
                {
                    int nuevaCantidad = filaExistente.Field<int>("Cantidad") + 1;
                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show("No hay suficiente stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    filaExistente["Cantidad"] = nuevaCantidad;
                    filaExistente["SubTotal"] = precioVenta * nuevaCantidad;
                }
                else
                {
                    // ✅ Añadimos el nombre del producto al carrito
                    detalleVenta.Rows.Add(idProducto, nombreProducto, precioVenta, 1, precioVenta);
                }

                CalcularTotales();
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

            decimal.TryParse(txtDescuento.Text, out decimal descuento);
            txtTotal.Text = total.ToString("0.00");
            txtDescuentoAplicado.Text = descuento.ToString("0.00");
            txtTotalFinal.Text = (total - descuento).ToString("0.00");
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtDocumentoCliente.Text.Trim();
            if (string.IsNullOrEmpty(textoBusqueda)) { /* ... mensaje ... */ return; }

            CN_Cliente objCliente = new CN_Cliente();
            Cliente clienteEncontrado = objCliente.ListarActivos()
                .FirstOrDefault(c =>
                    c.Documento.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    c.NombreCompleto.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase)
                );

            if (clienteEncontrado != null)
            {
                idClienteSeleccionado = clienteEncontrado.IdCliente;
                txtDocumentoCliente.Text = clienteEncontrado.Documento;
                txtNombreCliente.Text = clienteEncontrado.NombreCompleto;
            }
            else
            {
                idClienteSeleccionado = 0;
                txtNombreCliente.Text = "Cliente no encontrado";
                MessageBox.Show("Cliente no registrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (detalleVenta.Rows.Count == 0) { /* ... mensaje ... */ return; }
            if (idClienteSeleccionado == 0) { /* ... mensaje ... */ return; }

            decimal.TryParse(txtPago.Text, out decimal montoPago);
            decimal.TryParse(txtTotalFinal.Text, out decimal montoTotal);
            decimal.TryParse(txtDescuentoAplicado.Text, out decimal descuentoAplicado);

            decimal montoCambio = montoPago - montoTotal;
            if (montoCambio < 0) { /* ... mensaje ... */ return; }

            Venta objVenta = new Venta()
            {
                IdUsuario = usuarioLogueado.IdUsuario,
                TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem)?.Texto ?? "Boleta",
                NumeroDocumento = txtDocumentoCliente.Text.Trim(), // Considera generar un correlativo
                IdCliente = idClienteSeleccionado,
                MontoPago = montoPago,
                MontoCambio = montoCambio,
                MontoTotal = montoTotal,
                DescuentoAplicado = descuentoAplicado
            };

            string mensaje = string.Empty;
            CN_Venta objVentaCN = new CN_Venta();
            int idVentaGenerada = objVentaCN.Registrar(objVenta, detalleVenta, out mensaje);

            if (idVentaGenerada > 0)
            {
                MessageBox.Show("Venta registrada correctamente. ID Venta: " + idVentaGenerada, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarProductos(); // Recargar productos para actualizar stock
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

            // Limpiar filtros de producto
            txtBuscarProducto.Clear();
            cboCategoria.SelectedIndex = 0;
            FiltrarProductosGrid(); // Recarga la grilla
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtPago.Text, out decimal montoPago);
            decimal.TryParse(txtTotalFinal.Text, out decimal montoTotal);
            decimal cambio = montoPago - montoTotal;
            txtCambio.Text = cambio >= 0 ? cambio.ToString("0.00") : "0.00";
        }
    }
}