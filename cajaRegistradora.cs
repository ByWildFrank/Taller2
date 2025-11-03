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
        }

        private void CargarSugerenciasClientes()
        {
            List<Cliente> listaClientes = new CN_Cliente().ListarActivos();
            var autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (var cliente in listaClientes)
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

                // ✅ CAMBIO: Obtener la cantidad deseada desde el NumericUpDown
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

            decimal.TryParse(txtDescuento.Text, out decimal descuento);
            txtTotal.Text = total.ToString("0.00");
            txtDescuentoAplicado.Text = descuento.ToString("0.00");
            txtTotalFinal.Text = (total - descuento).ToString("0.00");
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

            CN_Cliente objCliente = new CN_Cliente();
            Cliente clienteEncontrado = null;

            clienteEncontrado = objCliente.ListarActivos()
                .FirstOrDefault(c => c.Documento.Equals(documentoBusqueda, StringComparison.OrdinalIgnoreCase));

            if (clienteEncontrado == null)
            {
                clienteEncontrado = objCliente.ListarActivos()
                    .FirstOrDefault(c => c.NombreCompleto.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase));
            }

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
                NumeroDocumento = txtDocumentoCliente.Text.Trim(),
                IdCliente = idClienteSeleccionado,
                MontoPago = montoPago,
                MontoCambio = montoCambio,
                MontoTotal = montoTotal,
                DescuentoAplicado = descuentoAplicado
            };

            DataTable dtDetalleParaSQL = detalleVenta.Copy();

            if (dtDetalleParaSQL.Columns.Contains("NombreProducto"))
            {
                dtDetalleParaSQL.Columns.Remove("NombreProducto");
            }

            string mensaje = string.Empty;
            CN_Venta objVentaCN = new CN_Venta();

            int idVentaGenerada = objVentaCN.Registrar(objVenta, dtDetalleParaSQL, out mensaje);

            if (idVentaGenerada > 0)
            {
                MessageBox.Show("Venta registrada correctamente. ID Venta: " + idVentaGenerada, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}