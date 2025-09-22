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

        public frmVerStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            CargarComboCategorias();
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
            List<Producto> lista = CN_Producto.Listar();

            // Filtrar por categoría
            int categoriaId = 0;
            int.TryParse(cmbCategoria.SelectedValue?.ToString(), out categoriaId);

            if (categoriaId != 0)
                lista = lista.Where(p => p.oCategoria.IdCategoria == categoriaId).ToList();

            // Filtrar por nombre
            string nombre = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(nombre))
                lista = lista.Where(p => p.Nombre.ToLower().Contains(nombre)).ToList();

            // Cargar DataGridView
            dgvStock.DataSource = lista.Select(p => new
            {
                p.IdProducto,
                p.Nombre,
                p.Descripcion,
                Categoria = p.oCategoria.Descripcion,
                p.stock,
                p.PrecioVenta
            }).ToList();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarStock();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarStock();
        }
    }
}
