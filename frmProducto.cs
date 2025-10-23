using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeEntidades;
using DocumentFormat.OpenXml.Wordprocessing;
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

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Cargar estado
            cboEstado.Items.Add(new OpcionCombo() { Valor = true, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = false, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            CargarComboCategorias();

            // Cargar columnas de búsqueda
            cboBusqueda.Items.Add(new OpcionCombo { Valor = "Codigo", Texto = "Código" });
            cboBusqueda.Items.Add(new OpcionCombo { Valor = "Nombre", Texto = "Nombre" });
            cboBusqueda.Items.Add(new OpcionCombo { Valor = "Descripcion", Texto = "Descripción" });
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            CargarGrilla();
            CargarSugerenciasBusqueda();

            // Conectar filtros dinámicos
            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
            cmbCategoriaBusqueda.SelectedIndexChanged += CmbCategoriaBusqueda_SelectedIndexChanged;
            // (Asumo que tienes un cboCategoriaBusqueda en el panel de búsqueda)
        }

        private void CargarGrilla()
        {
            _listaCompletaProductos = CN_Producto.Listar();
            dgvProductos.DataSource = _listaCompletaProductos.Where(p => p.Estado == true).ToList(); // Mostrar solo activos por defecto
        }

        private void CargarComboCategorias()
        {
            CN_Categoria cnCategoria = new CN_Categoria();
            var categorias = cnCategoria.Listar().Where(c => c.Estado).ToList(); // Solo activas

            // Para el ComboBox de edición
            cmbCategoriaBusqueda.DataSource = categorias;
            cmbCategoriaBusqueda.DisplayMember = "Descripcion";
            cmbCategoriaBusqueda.ValueMember = "IdCategoria";

            // Para el ComboBox de búsqueda (con "Todas")
            var categoriasBusqueda = new List<Categoria>(categorias);
            categoriasBusqueda.Insert(0, new Categoria { IdCategoria = 0, Descripcion = "Todas" });
            cmbCategoriaBusqueda.DataSource = categoriasBusqueda; // Asumo que tienes este ComboBox
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

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void CmbCategoriaBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void FiltrarGrilla()
        {
            if (_listaCompletaProductos == null) return;

            IEnumerable<Producto> listaFiltrada = _listaCompletaProductos;

            // 1. Filtrar por categoría
            int idCategoria = 0;
            if (cmbCategoriaBusqueda.SelectedValue != null)
            {
                int.TryParse(cmbCategoriaBusqueda.SelectedValue.ToString(), out idCategoria);
            }
            if (idCategoria > 0)
            {
                listaFiltrada = listaFiltrada.Where(p => p.oCategoria.IdCategoria == idCategoria);
            }

            // 2. Filtrar por texto
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                listaFiltrada = listaFiltrada.Where(p =>
                    (columnaFiltro == "Nombre" && p.Nombre != null && p.Nombre.ToUpper().Contains(textoBusqueda)) ||
                    (columnaFiltro == "Codigo" && p.codigo != null && p.codigo.ToUpper().Contains(textoBusqueda)) ||
                    (columnaFiltro == "Descripcion" && p.Descripcion != null && p.Descripcion.ToUpper().Contains(textoBusqueda))
                );
            }

            // 3. Ocultar inactivos (a menos que se busquen)
            // Si la búsqueda está vacía, solo mostrar activos
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

            Producto objProducto = new Producto
            {
                // Si txtid.Text es 0, es nuevo. Si no, es edición.
                IdProducto = string.IsNullOrEmpty(txtid.Text) ? 0 : Convert.ToInt32(txtid.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                codigo = txtCodigo.Text,
                oCategoria = new Categoria { IdCategoria = Convert.ToInt32(cmbCategoriaBusqueda.SelectedValue) },
                stock = Convert.ToInt32(txtStock.Text), // Añadir validación TryParse
                PrecioFabricacion = Convert.ToDecimal(txtPrecioFabricacion.Text), // Añadir validación TryParse
                PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text), // Añadir validación TryParse
                Estado = (bool)((OpcionCombo)cboEstado.SelectedItem).Valor
            };

            bool resultado = CN_Producto.Guardar(objProducto, out mensaje);

            if (resultado)
            {
                MessageBox.Show("¡Guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtener el ID del producto de la fila seleccionada
            int idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);

            // Buscar el producto en la lista completa que ya tenemos en memoria
            Producto productoSeleccionado = _listaCompletaProductos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (productoSeleccionado != null)
            {
                txtid.Text = productoSeleccionado.IdProducto.ToString();
                txtNombre.Text = productoSeleccionado.Nombre;
                txtDescripcion.Text = productoSeleccionado.Descripcion;
                txtCodigo.Text = productoSeleccionado.codigo;
                txtStock.Text = productoSeleccionado.stock.ToString();
                txtPrecioFabricacion.Text = productoSeleccionado.PrecioFabricacion.ToString();
                txtPrecioVenta.Text = productoSeleccionado.PrecioVenta.ToString();

                // Seleccionar el estado correcto en el ComboBox
                cboEstado.SelectedValue = productoSeleccionado.Estado;

                // Seleccionar la categoría correcta
                if (productoSeleccionado.oCategoria != null)
                {
                    cmbCategoriaBusqueda.SelectedValue = productoSeleccionado.oCategoria.IdCategoria;
                }
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
                    CargarGrilla(); // Recarga la grilla, los inactivos desaparecerán
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Limpiar()
        {
            txtid.Text = "0";
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCodigo.Clear();
            txtStock.Clear();
            txtPrecioFabricacion.Clear();
            txtPrecioVenta.Clear();
            cboEstado.SelectedIndex = 0;
            cmbCategoriaBusqueda.SelectedIndex = 0;

            // Limpia la selección de la grilla
            dgvProductos.ClearSelection();
        }
    }
}