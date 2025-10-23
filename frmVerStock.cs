using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeDatos;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmVerStock : Form
    {
        private CN_Producto CN_Producto = new CN_Producto();
        private List<Producto> _listaCompletaProductos;

        public frmVerStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;

            CargarComboCategorias();

            // ✅ PASO 2: Cargamos la lista de productos UNA SOLA VEZ
            _listaCompletaProductos = CN_Producto.Listar();

            // ✅ PASO 3: Cargamos las sugerencias de autocompletado
            CargarSugerenciasBusqueda();

            // ✅ PASO 4: Conectamos el evento TextChanged para el filtro en tiempo real
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // Cargamos la grilla por primera vez (mostrará todo)
            ListarStock();
        }

        // ✅ NUEVO MÉTODO: Carga las sugerencias en el TextBox
        private void CargarSugerenciasBusqueda()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            if (_listaCompletaProductos != null)
            {
                foreach (var producto in _listaCompletaProductos)
                {
                    // Añadimos el nombre y el código a las sugerencias
                    if (producto.Nombre != null)
                        autoCompleteCollection.Add(producto.Nombre);
                    if (producto.codigo != null) // Usamos 'codigo' minúscula como en tu clase
                        autoCompleteCollection.Add(producto.codigo);
                }
            }

            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBuscar.AutoCompleteCustomSource = autoCompleteCollection;
        }

        // ✅ NUEVO MÉTODO: El evento que se dispara al escribir en el TextBox
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarStock();
        }

        private void CargarComboCategorias()

        {
            CN_Categoria cnCategoria = new CN_Categoria();
            var categorias = cnCategoria.Listar();
            categorias.Insert(0, new Categoria { IdCategoria = 0, Descripcion = "Todas" });

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "IdCategoria";

        }

        // ✅ MÉTODO MODIFICADO: Ahora filtra la lista en memoria, no consulta la BD
        private void ListarStock()
        {
            // Si la lista no está cargada, no hace nada.
            if (_listaCompletaProductos == null) return;

            // Empezamos con la lista completa
            IEnumerable<Producto> listaFiltrada = _listaCompletaProductos;

            // Filtrar por categoría
            int categoriaId = 0;
            int.TryParse(cmbCategoria.SelectedValue?.ToString(), out categoriaId);

            if (categoriaId != 0)
                listaFiltrada = listaFiltrada.Where(p => p.oCategoria.IdCategoria == categoriaId);

            // Filtrar por nombre o código
            string textoBusqueda = txtBuscar.Text.Trim().ToUpper();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                listaFiltrada = listaFiltrada.Where(p =>
                    (p.Nombre != null && p.Nombre.ToUpper().Contains(textoBusqueda)) ||
                    (p.codigo != null && p.codigo.ToUpper().Contains(textoBusqueda)) // Usamos 'codigo' minúscula
                );
            }

            // Cargar DataGridView
            dgvStock.DataSource = null; // Forzar refresco
            dgvStock.DataSource = listaFiltrada.Select(p => new
            {
                p.IdProducto,
                p.Nombre,
                p.Descripcion,
                Categoria = p.oCategoria.Descripcion,
                p.stock,
                p.PrecioVenta
            }).ToList();
        }

        // ✅ MÉTODO MODIFICADO: Ahora solo llama a ListarStock
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarStock();
        }

         private void btnBuscar_Click(object sender, EventArgs e)
        {
             ListarStock();
         }
    }
}