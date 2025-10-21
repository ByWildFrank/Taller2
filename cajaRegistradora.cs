using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeEntidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace BeanDesktop

{
    public partial class cajaRegistradora : Form
    {
        private DataTable detalleVenta;
        private int idClienteSeleccionado = 0;

        private Usuario usuarioLogueado; // propiedad para guardar el usuario

        public cajaRegistradora(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario; // guardamos el usuario logueado
            pnlCliente.BackColor = Color.White;
            pnlProductos.BackColor = Color.White;
            pnlCarrito.BackColor = Color.White;
            pnlTotales.BackColor = Color.White;
        }


        private void cajaRegistradora_Load(object sender, EventArgs e)
        {
            // Configurar fondo y estética
            this.BackColor = Color.WhiteSmoke;
            pnlCliente.BackColor = Color.White;
            pnlProductos.BackColor = Color.White;
            pnlCarrito.BackColor = Color.White;
            pnlTotales.BackColor = Color.White;

            // Inicializar DataTable para el carrito
            detalleVenta = new DataTable();
            detalleVenta.Columns.Add("IdProducto", typeof(int));
            detalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
            detalleVenta.Columns.Add("Cantidad", typeof(int));
            detalleVenta.Columns.Add("SubTotal", typeof(decimal));

            dgvCarrito.DataSource = detalleVenta;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvCarrito.DataSource = detalleVenta;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargar tipos de documento
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            // Cargar productos
            CargarProductos();

            // Cargar categorías activas
            CN_Categoria objCategoria = new CN_Categoria();
            var listaCategorias = objCategoria.Listar().Where(c => c.Estado).ToList(); // Solo activas

            // Insertar opción “Todas” al inicio
            listaCategorias.Insert(0, new Categoria { IdCategoria = 0, Descripcion = "Todas" });

            cboCategoria.DataSource = listaCategorias;
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "IdCategoria";
            cboCategoria.SelectedIndex = 0;
            txtPago.TextChanged += txtPago_TextChanged;
        }


        private void CargarProductos()
        {
            CN_Producto objProducto = new CN_Producto();
            dgvProductos.DataSource = objProducto.Listar();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BuscarProducto(string texto)
        {
            CN_Producto objProducto = new CN_Producto();

            // Buscar por cualquier campo (nombre, descripción o código)
            DataTable tabla = objProducto.BuscarPorNombre(texto);
            dgvProductos.DataSource = tabla;
        }

        private void FiltrarPorCategoria(int idCategoria)
        {
            CN_Producto objProducto = new CN_Producto();
            dgvProductos.DataSource = objProducto.ListarPorCategoria(idCategoria);
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscarProducto.Text))
            {
                BuscarProducto(txtBuscarProducto.Text.Trim());
            }
            else if (cboCategoria.SelectedValue != null)
            {
                int idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                FiltrarPorCategoria(idCategoria);
            }
            else
            {
                CargarProductos();
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                int idProducto = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                string codigo = fila.Cells["Codigo"].Value.ToString();
                string nombre = fila.Cells["Nombre"].Value.ToString();
                decimal precioVenta = Convert.ToDecimal(fila.Cells["PrecioVenta"].Value);
                int stock = Convert.ToInt32(fila.Cells["Stock"].Value);

                if (stock <= 0)
                {
                    MessageBox.Show("Este producto no tiene stock disponible.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si ya existe en el carrito, aumenta cantidad
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
                    detalleVenta.Rows.Add(idProducto, precioVenta, 1, precioVenta);
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

            foreach (DataRow row in detalleVenta.Rows)
                total += row.Field<decimal>("SubTotal");

            decimal descuento = 0;
            decimal.TryParse(txtDescuento.Text, out descuento);

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

            CN_Cliente objCliente = new CN_Cliente();
            Cliente cliente = objCliente.Listar()
                .FirstOrDefault(c =>
                    c.Documento.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    c.NombreCompleto.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);

            if (cliente != null)
            {
                idClienteSeleccionado = cliente.IdCliente;
                txtNombreCliente.Text = cliente.NombreCompleto;
            }
            else
            {
                idClienteSeleccionado = 0;
                txtNombreCliente.Text = "Cliente no encontrado";
                MessageBox.Show("Cliente no registrado. Puede continuar la venta como consumidor final o registrarlo en el módulo de clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscarProducto.Text))
            {
                BuscarProducto(txtBuscarProducto.Text.Trim());
            }
            else if (cboCategoria.SelectedValue != null)
            {
                int idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                FiltrarPorCategoria(idCategoria);
            }
            else
            {
                CargarProductos();
            }
        }


        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (detalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos al carrito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Busque y seleccione un cliente válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Validaciones y conversiones seguras ---
            decimal montoPago = 0;
            decimal montoTotal = 0;
            decimal descuentoAplicado = 0;

            decimal.TryParse(txtPago.Text, out montoPago);
            decimal.TryParse(txtTotalFinal.Text, out montoTotal);
            decimal.TryParse(txtDescuentoAplicado.Text, out descuentoAplicado);

            // --- Cálculo automático del cambio ---
            decimal montoCambio = montoPago - montoTotal;
            if (montoCambio < 0)
            {
                MessageBox.Show("El pago es insuficiente para cubrir el total.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Crear objeto venta ---
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

            string mensaje = string.Empty;
            CN_Venta objVentaCN = new CN_Venta();
            int idVentaGenerada = objVentaCN.Registrar(objVenta, detalleVenta, out mensaje);

            if (idVentaGenerada > 0)
            {
                MessageBox.Show("Venta registrada correctamente. ID Venta: " + idVentaGenerada, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
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
        }
        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            decimal montoPago, montoTotal;
            decimal.TryParse(txtPago.Text, out montoPago);
            decimal.TryParse(txtTotalFinal.Text, out montoTotal);

            decimal cambio = montoPago - montoTotal;
            txtCambio.Text = cambio >= 0 ? cambio.ToString("0.00") : "0.00";
        }

    }
}
