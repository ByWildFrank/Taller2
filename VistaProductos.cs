using Microsoft.Data.SqlClient;
using System.Data;

namespace BeanDesktop
{
    public partial class VistaProductos : Form
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=DB_BEAN;Trusted_Connection=True;TrustServerCertificate=True;";

        public VistaProductos()
        {
            InitializeComponent();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdCategoria, Descripcion FROM CATEGORIA WHERE Estado = 1", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboCategoria.DataSource = dt;
                comboCategoria.DisplayMember = "Descripcion";
                comboCategoria.ValueMember = "IdCategoria";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado, FechaRegistroProducto)
                                 VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @Stock, @PrecioCompra, @PrecioVenta, @Estado, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@IdCategoria", comboCategoria.SelectedValue);
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@PrecioCompra", decimal.Parse(txtPrecioCompra.Text));
                cmd.Parameters.AddWithValue("@PrecioVenta", decimal.Parse(txtPrecioVenta.Text));
                cmd.Parameters.AddWithValue("@Estado", chkActivo.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto guardado correctamente");
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar un código de producto.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE PRODUCTO SET Estado = 0 WHERE Codigo = @Codigo";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Producto dado de baja correctamente");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            comboCategoria.SelectedIndex = -1; // Ninguna seleccionada
            chkActivo.Checked = true;          // Por defecto activo
        }

    }
}
