using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeDatos;
using CapaDeEntidades;
using CapaDeNegocio;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class cajaRegistradora : Form
    {
        private DataTable detalleVenta;

        public cajaRegistradora()
        {
            InitializeComponent();
        }

        private void cajaRegistradora_Load(object sender, EventArgs e)
        {
            // Inicializa carrito (ya lo tenías)
            detalleVenta = new DataTable();
            detalleVenta.Columns.Add("IdProducto", typeof(int));
            detalleVenta.Columns.Add("Descripcion", typeof(string));
            detalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
            detalleVenta.Columns.Add("Cantidad", typeof(int));
            detalleVenta.Columns.Add("SubTotal", typeof(decimal));
            dgvCarrito.DataSource = detalleVenta;

            // Documentos
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            // ✅ Cargar productos
            CargarProductos();

            // ✅ Cargar categorías
            CN_Categoria objCategoria = new CN_Categoria();
            cboCategoria.DataSource = objCategoria.Listar();
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "IdCategoria";
            this.BackColor = Color.LightGray;
            this.Refresh(); // fuerza el redibujado
        }


        // Botón agregar producto al carrito
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProducto.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe seleccionar un producto y la cantidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(txtIdProducto.Text);
            string descripcion = txtDescripcion.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal subTotal = precio * cantidad;

            detalleVenta.Rows.Add(idProducto, descripcion, precio, cantidad, subTotal);
            CalcularTotales();
            LimpiarProducto();
        }

        // Eliminar producto del carrito
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                dgvCarrito.Rows.RemoveAt(dgvCarrito.CurrentRow.Index);
                CalcularTotales();
            }
        }

        // Calcular totales de la venta
        private void CalcularTotales()
        {
            decimal total = detalleVenta.AsEnumerable().Sum(r => r.Field<decimal>("SubTotal"));
            decimal descuento = string.IsNullOrWhiteSpace(txtDescuento.Text) ? 0 : Convert.ToDecimal(txtDescuento.Text);

            txtTotal.Text = total.ToString("0.00");
            txtDescuentoAplicado.Text = descuento.ToString("0.00");
            txtTotalFinal.Text = (total - descuento).ToString("0.00");
        }

        // Registrar venta
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (detalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos al carrito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Venta objVenta = new Venta()
            {
                IdUsuario = 1, // ⚠️ Deberías traerlo de la sesión
                TipoDocumento = ((OpcionCombo)cboTipoDocumento.SelectedItem).Valor.ToString(),
                NumeroDocumento = "0001", // ⚠️ Podrías generar correlativo
                DocumentoCliente = txtDocumentoCliente.Text,
                NombreCliente = txtNombreCliente.Text,
                MontoPago = Convert.ToDecimal(txtPago.Text),
                MontoCambio = Convert.ToDecimal(txtCambio.Text),
                MontoTotal = Convert.ToDecimal(txtTotalFinal.Text),
                DescuentoAplicado = Convert.ToDecimal(txtDescuentoAplicado.Text)
            };

            string mensaje = string.Empty;
            int idVentaGenerada = new CN_Venta().Registrar(objVenta, detalleVenta, out mensaje);

            if (idVentaGenerada != 0)
            {
                MessageBox.Show("Venta registrada correctamente. ID Venta: " + idVentaGenerada, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtTotal.Clear();
            txtDescuento.Clear();
            txtDescuentoAplicado.Clear();
            txtTotalFinal.Clear();
            detalleVenta.Rows.Clear();
        }

        private void LimpiarProducto()
        {
            txtIdProducto.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void CargarProductos()
        {
            CN_Producto objProducto = new CN_Producto();
            dgvProductos.DataSource = objProducto.Listar();
        }

        private void BuscarProductoPorNombre(string nombre)
        {
            CN_Producto objProducto = new CN_Producto();
            dgvProductos.DataSource = objProducto.BuscarPorNombre(nombre);
        }

        private void FiltrarPorCategoria(int idCategoria)
        {
            CN_Producto objProducto = new CN_Producto();
            dgvProductos.DataSource = objProducto.ListarPorCategoria(idCategoria);
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                int idProducto = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                string descripcion = fila.Cells["Descripcion"].Value.ToString();
                decimal precio = Convert.ToDecimal(fila.Cells["PrecioVenta"].Value);

                // Por defecto cantidad = 1
                int cantidad = 1;
                decimal subTotal = precio * cantidad;

                detalleVenta.Rows.Add(idProducto, descripcion, precio, cantidad, subTotal);
                CalcularTotales();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscarProducto.Text))
            {
                BuscarProductoPorNombre(txtBuscarProducto.Text);
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
    }
}
