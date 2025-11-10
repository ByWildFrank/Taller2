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

            _listaCompletaProductos = CN_Producto.Listar();

            CargarSugerenciasBusqueda();

            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            ListarStock();

        }

        private void CargarSugerenciasBusqueda()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            if (_listaCompletaProductos != null)
            {
                foreach (var producto in _listaCompletaProductos)
                {
                    if (producto.Nombre != null)
                        autoCompleteCollection.Add(producto.Nombre);
                    if (producto.codigo != null)
                        autoCompleteCollection.Add(producto.codigo);
                }
            }

            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBuscar.AutoCompleteCustomSource = autoCompleteCollection;
        }

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

        private void ListarStock()
        {
            if (_listaCompletaProductos == null) return;

            IEnumerable<Producto> listaFiltrada = _listaCompletaProductos;

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
            // NUEVA LÓGICA DE ORDENAMIENTO
            if (chkOrdenarPorStock.Checked)
            {
                listaFiltrada = listaFiltrada.OrderBy(p => p.stock);
            }
            else
            {
                listaFiltrada = listaFiltrada.OrderBy(p => p.Nombre);
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

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarStock();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarStock();
        }

        private void chkOrdenarPorStock_CheckedChanged(object sender, EventArgs e)
        {
            ListarStock();
        }
    }
}