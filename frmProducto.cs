using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmProducto : Form
    {
        private Producto objProducto = null;
        private CN_Producto CN_Producto = new CN_Producto();

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            ListarProductos();
            CargarComboCategorias();
            this.BackColor = Color.LightGray;
            this.Refresh(); // fuerza el redibujado
        }

        private void ListarProductos()
        {
            dgvProductos.DataSource = CN_Producto.Listar(); // Debes crear este método en tu CN_Producto
        }

        private void CargarComboCategorias()
        {
            CN_Categoria cnCategoria = new CN_Categoria();
            cmbCategoria.DataSource = cnCategoria.Listar();
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "IdCategoria";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objProducto == null) objProducto = new Producto();

            objProducto.Nombre = txtNombre.Text;
            objProducto.Descripcion = txtDescripcion.Text;
            objProducto.codigo = txtCodigo.Text;
            objProducto.oCategoria = new Categoria
            {
                IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
            };
            objProducto.stock = Convert.ToInt32(txtStock.Text);
            objProducto.PrecioFabricacion = Convert.ToDecimal(txtPrecioFabricacion.Text);
            objProducto.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            objProducto.Estado = chkEstado.Checked;

            string mensaje = CN_Producto.Guardar(objProducto); // Crear método Guardar en CN_Producto
            MessageBox.Show(mensaje);
            ListarProductos();
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCodigo.Clear();
            txtStock.Clear();
            txtPrecioFabricacion.Clear();
            txtPrecioVenta.Clear();
            chkEstado.Checked = false;
            cmbCategoria.SelectedIndex = 0;
            objProducto = null;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);
                objProducto = CN_Producto.ObtenerPorId(idProducto); // Crear método ObtenerPorId en CN_Producto

                if (objProducto != null)
                {
                    txtNombre.Text = objProducto.Nombre;
                    txtDescripcion.Text = objProducto.Descripcion;
                    txtCodigo.Text = objProducto.codigo;
                    txtStock.Text = objProducto.stock.ToString();
                    txtPrecioFabricacion.Text = objProducto.PrecioFabricacion.ToString();
                    txtPrecioVenta.Text = objProducto.PrecioVenta.ToString();
                    chkEstado.Checked = objProducto.Estado;
                    cmbCategoria.SelectedValue = objProducto.oCategoria.IdCategoria;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (objProducto != null)
            {
                string mensaje = CN_Producto.Eliminar(objProducto.IdProducto); // Crear método Eliminar en CN_Producto
                MessageBox.Show(mensaje);
                ListarProductos();
                Limpiar();
            }
        }
    }
}
