using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeDatos;
using CapaDeEntidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace BeanDesktop
{
    public partial class frmProducto : Form
    {
        private CN_Producto CN_Producto = new CN_Producto();
        private List<Producto> _listaCompletaProductos;
        private Usuario _usuarioLogueado; // Asumimos que lo recibes

        public frmProducto(Usuario usuario) // Recibe el usuario que inició sesión
        {
            InitializeComponent();
            _usuarioLogueado = usuario;
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;

            cboEstado.Items.Add(new OpcionCombo() { Valor = true, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = false, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            CargarComboCategorias();

            cboBusqueda.Items.Add(new OpcionCombo { Valor = "Codigo", Texto = "Código" });
            cboBusqueda.Items.Add(new OpcionCombo { Valor = "Nombre", Texto = "Nombre" });
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            CargarGrilla();
            CargarSugerenciasBusqueda();

            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
            cmbCategoria.SelectedIndexChanged += CmbCategoriaBusqueda_SelectedIndexChanged;
            numStockInicial.Click += btnAnadirStock_Click;

            Limpiar(); // Establece el estado inicial
        }

        private void CargarGrilla()
        {
            // Carga TODOS los productos (activos e inactivos) a la memoria
            _listaCompletaProductos = new CN_Producto().ListarTodos();
            FiltrarGrilla(); // Aplica el filtro por defecto (solo activos)
        }

        private void CargarComboCategorias()
        {
            CN_Categoria cnCategoria = new CN_Categoria();
            var categorias = cnCategoria.Listar().Where(c => c.Estado).ToList();

            cmbCategoria.DataSource = new List<Categoria>(categorias);
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "IdCategoria";

            var categoriasBusqueda = new List<Categoria>(categorias);
            categoriasBusqueda.Insert(0, new Categoria { IdCategoria = 0, Descripcion = "Todas" });
            cmbCategoria.DataSource = categoriasBusqueda;
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "IdCategoria";
        }

        private void CargarSugerenciasBusqueda()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            foreach (var producto in _listaCompletaProductos)
            {
                if (producto.Nombre != null) autoCompleteCollection.Add(producto.Nombre);
                if (producto.codigo != null) autoCompleteCollection.Add(producto.codigo);
            }
            txtBusqueda.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBusqueda.AutoCompleteCustomSource = autoCompleteCollection;
        }

        // --- Eventos de Filtro Dinámico ---
        private void TxtBusqueda_TextChanged(object sender, EventArgs e) { FiltrarGrilla(); }
        private void CmbCategoriaBusqueda_SelectedIndexChanged(object sender, EventArgs e) { FiltrarGrilla(); }

        private void FiltrarGrilla()
        {
            if (_listaCompletaProductos == null) return;
            IEnumerable<Producto> listaFiltrada = _listaCompletaProductos;
            int idCategoria = 0;
            if (cmbCategoria.SelectedValue != null)
                int.TryParse(cmbCategoria.SelectedValue.ToString(), out idCategoria);

            if (idCategoria > 0)
                listaFiltrada = listaFiltrada.Where(p => p.oCategoria.IdCategoria == idCategoria);

            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                listaFiltrada = listaFiltrada.Where(p =>
                    (columnaFiltro == "Nombre" && p.Nombre != null && p.Nombre.ToUpper().Contains(textoBusqueda)) ||
                    (columnaFiltro == "Codigo" && p.codigo != null && p.codigo.ToUpper().Contains(textoBusqueda))
                );
            }

            // Filtro por defecto: Ocultar inactivos si no se está buscando nada
            if (string.IsNullOrEmpty(textoBusqueda) && idCategoria == 0)
            {
                listaFiltrada = listaFiltrada.Where(p => p.Estado == true);
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            int idProducto = string.IsNullOrEmpty(txtid.Text) ? 0 : Convert.ToInt32(txtid.Text);

            var objProducto = new Producto
            {
                IdProducto = idProducto,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                codigo = txtCodigo.Text,
                oCategoria = new Categoria { IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue) },
                PrecioFabricacion = Convert.ToDecimal(txtPrecioFabricacion.Text), // Añadir TryParse
                PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text), // Añadir TryParse
                Estado = (bool)((OpcionCombo)cboEstado.SelectedItem).Valor,
                stock = 0 // Por defecto
            };

            // ✅ LÓGICA DE STOCK: Solo se define el stock al CREAR un producto nuevo
            if (objProducto.IdProducto == 0)
            {
                objProducto.stock = (int)numStockInicial.Value;
            }

            bool resultado = CN_Producto.Guardar(objProducto, out mensaje);

            if (resultado)
            {
                MessageBox.Show("¡Guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                Limpiar();
            }
            else { MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        // ✅ NUEVO: Evento para el botón de añadir stock
        private void btnAnadirStock_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(txtid.Text);
            int cantidad = (int)numStockAnadir.Value;

            string mensaje = string.Empty;
            bool respuesta = CN_Producto.AnadirStock(idProducto, cantidad, _usuarioLogueado.IdUsuario, out mensaje);

            if (respuesta)
            {
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                // Actualizamos el stock en el txtStockActual
                txtStockActual.Text = (Convert.ToInt32(txtStockActual.Text) + cantidad).ToString();
                numStockAnadir.Value = 1; // Reseteamos el contador
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);
            Producto p = _listaCompletaProductos.FirstOrDefault(prod => prod.IdProducto == idProducto);

            if (p != null)
            {
                // Llenamos el formulario
                txtid.Text = p.IdProducto.ToString();
                txtNombre.Text = p.Nombre;
                txtDescripcion.Text = p.Descripcion;
                txtCodigo.Text = p.codigo;
                txtPrecioFabricacion.Text = p.PrecioFabricacion.ToString();
                txtPrecioVenta.Text = p.PrecioVenta.ToString();
                cboEstado.SelectedValue = p.Estado;
                if (p.oCategoria != null)
                {
                    cmbCategoria.SelectedValue = p.oCategoria.IdCategoria;
                }

                // ✅ LÓGICA DE UI PARA STOCK
                numStockInicial.Visible = false; // Ocultamos el stock inicial
                txtStockActual.Visible = true; // Mostramos el stock actual
                txtStockActual.Text = p.stock.ToString();
                gbAjusteStock.Enabled = true; // Habilitamos el panel de ajuste
                btnGuardar.Enabled = true; // Habilitamos editar
                btnEliminar.Enabled = true; // Habilitamos eliminar
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text) || txtid.Text == "0") return;

            if (MessageBox.Show("¿Desea desactivar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                int idProducto = Convert.ToInt32(txtid.Text);

                bool respuesta = CN_Producto.Eliminar(idProducto, out mensaje);

                if (respuesta)
                {
                    MessageBox.Show("Producto desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ✅ MÉTODO "LIMPIAR" ACTUALIZADO
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtid.Text = "0";
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCodigo.Clear();
            txtPrecioFabricacion.Clear();
            txtPrecioVenta.Clear();
            cboEstado.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;

            // Resetea la grilla y los filtros
            txtBusqueda.Clear();
            cmbCategoria.SelectedIndex = 0;
            dgvProductos.ClearSelection();

            // Resetea la lógica de Stock
            numStockInicial.Value = 0;
            numStockInicial.Visible = true; // Habilita campo de stock inicial
            txtStockActual.Visible = false; // Oculta campo de stock actual
            numStockAnadir.Value = 1;
            gbAjusteStock.Enabled = false; // Deshabilita el panel de ajuste

            // Habilita/deshabilita botones
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
        }
    }
}