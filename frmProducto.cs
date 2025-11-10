using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmProducto : Form
    {
        private CN_Producto CN_Producto = new CN_Producto();
        private List<Producto> _listaCompletaProductos;
        private Usuario _usuarioLogueado;

        // Asumo que el constructor recibe el usuario
        public frmProducto(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogueado = usuario;
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;

            // --- Configuración Panel Izquierdo (Edición) ---
            cboEstado.Items.Add(new OpcionCombo() { Valor = true, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = false, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            // --- Configuración Panel Derecho (Búsqueda) ---
            cboBusqueda.Items.Add(new OpcionCombo { Valor = "codigo", Texto = "Código" }); // 'codigo' en minúscula
            cboBusqueda.Items.Add(new OpcionCombo { Valor = "Nombre", Texto = "Nombre" });
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            CargarComboCategorias(); // Carga cmbCategoria y cmbCategoriaBusqueda
            CargarGrilla();
            CargarSugerenciasBusqueda();

            // Conectar filtros dinámicos
            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
            cmbCategoriaBusqueda.SelectedIndexChanged += CmbCategoriaBusqueda_SelectedIndexChanged;

            // Conectar botones
            btnAnadirStock.Click += btnAnadirStock_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEliminar.Click += btnEliminar_Click;

            // Conectar clic de la grilla
            dgvProductos.CellClick += dgvProductos_CellClick;

            Limpiar(); // Establece el estado inicial
        }

        private void CargarGrilla()
        {
            _listaCompletaProductos = new CN_Producto().ListarTodos();
            FiltrarGrilla();
        }

        private void CargarComboCategorias()
        {
            CN_Categoria cnCategoria = new CN_Categoria();
            var categorias = cnCategoria.Listar().Where(c => c.Estado).ToList();

            //  Asigna la lista de categorías (sin "Todas") al combo de edición
            cmbCategoria.DataSource = new List<Categoria>(categorias);
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "IdCategoria";

            //  Crea una nueva lista con "Todas" para el combo de búsqueda
            var categoriasBusqueda = new List<Categoria>(categorias);
            categoriasBusqueda.Insert(0, new Categoria { IdCategoria = 0, Descripcion = "Todas" });
            cmbCategoriaBusqueda.DataSource = categoriasBusqueda;
            cmbCategoriaBusqueda.DisplayMember = "Descripcion";
            cmbCategoriaBusqueda.ValueMember = "IdCategoria";
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

            // ✅ CORRECCIÓN: Leer del ComboBox de BÚSQUEDA
            if (cmbCategoriaBusqueda.SelectedValue != null)
                int.TryParse(cmbCategoriaBusqueda.SelectedValue.ToString(), out idCategoria);

            if (idCategoria > 0)
            {
                listaFiltrada = listaFiltrada.Where(p => p.oCategoria != null && p.oCategoria.IdCategoria == idCategoria);
            }

            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                listaFiltrada = listaFiltrada.Where(p =>
                    (columnaFiltro == "Nombre" && p.Nombre != null && p.Nombre.ToUpper().Contains(textoBusqueda)) ||
                    (columnaFiltro == "codigo" && p.codigo != null && p.codigo.ToUpper().Contains(textoBusqueda)) // 'codigo' minúscula
                );
            }

            // Filtro por defecto: Ocultar inactivos si no se está buscando nada
            if (string.IsNullOrEmpty(textoBusqueda) && idCategoria == 0)
            {
                listaFiltrada = listaFiltrada.Where(p => p.Estado == true);
            }
            // NUEVA LÓGICA DE ORDENAMIENTO
            if (chkOrdenarStockProd.Checked)
            {
                // Si está marcado, ordena por stock ascendente
                listaFiltrada = listaFiltrada.OrderBy(p => p.stock);
            }
            else
            {
                // Orden por defecto (ej: por nombre)
                listaFiltrada = listaFiltrada.OrderBy(p => p.Nombre);
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // --- Validaciones ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioFabricacion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validaciones numéricas
            if (!decimal.TryParse(txtPrecioFabricacion.Text, out decimal precioFab))
            {
                MessageBox.Show("El Precio de Fabricación debe ser un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
            {
                MessageBox.Show("El Precio de Venta debe ser un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // --- Fin Validaciones ---

            int idProducto = string.IsNullOrEmpty(txtid.Text) ? 0 : Convert.ToInt32(txtid.Text);

            var objProducto = new Producto
            {
                IdProducto = idProducto,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                codigo = txtCodigo.Text,
                oCategoria = new Categoria { IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue) },
                PrecioFabricacion = precioFab,
                PrecioVenta = precioVenta,
                Estado = (bool)((OpcionCombo)cboEstado.SelectedItem).Valor,
                stock = 0
            };

            // Lógica de Stock: Solo se define el stock al CREAR. Al editar, se usa el SP_AnadirStock.
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

        private void btnAnadirStock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text) || txtid.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un producto de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(txtid.Text);
            int cantidad = (int)numStockAnadir.Value;

            string mensaje = string.Empty;
            bool respuesta = CN_Producto.AnadirStock(idProducto, cantidad, _usuarioLogueado.IdUsuario, out mensaje);

            if (respuesta)
            {
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizamos la lista en memoria
                var productoEnLista = _listaCompletaProductos.FirstOrDefault(p => p.IdProducto == idProducto);
                if (productoEnLista != null)
                {
                    productoEnLista.stock += cantidad;
                }

                FiltrarGrilla(); // Refrescamos la grilla

                txtStockActual.Text = (Convert.ToInt32(txtStockActual.Text) + cantidad).ToString();
                numStockAnadir.Value = 1;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtener el ID del producto de la fila seleccionada
            // Es más seguro obtenerlo de la celda "IdProducto"
            int idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);
            Producto p = _listaCompletaProductos.FirstOrDefault(prod => prod.IdProducto == idProducto);

            if (p != null)
            {
                txtid.Text = p.IdProducto.ToString();
                txtNombre.Text = p.Nombre;
                txtDescripcion.Text = p.Descripcion;
                txtCodigo.Text = p.codigo;
                txtPrecioFabricacion.Text = p.PrecioFabricacion.ToString("0.00");
                txtPrecioVenta.Text = p.PrecioVenta.ToString("0.00");
                cboEstado.SelectedValue = p.Estado;
                if (p.oCategoria != null)
                {
                    cmbCategoria.SelectedValue = p.oCategoria.IdCategoria;
                }

                // LÓGICA DE UI PARA STOCK
                numStockInicial.Visible = false; // Ocultamos el stock inicial
                txtStockActual.Visible = true; // Mostramos el stock actual
                txtStockActual.Text = p.stock.ToString();
                gbAjusteStock.Enabled = true; // Habilitamos el panel de ajuste

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
            cmbCategoriaBusqueda.SelectedIndex = 0;
            dgvProductos.ClearSelection();
            FiltrarGrilla(); // Muestra solo activos

            // Resetea la lógica de Stock
            numStockInicial.Value = 0;
            numStockInicial.Visible = true;
            txtStockActual.Visible = false;
            numStockAnadir.Value = 1;
            gbAjusteStock.Enabled = false;

            btnEliminar.Enabled = false;
        }

        private void chkOrdenarStockProd_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }
    }
}