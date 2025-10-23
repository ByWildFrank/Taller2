using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmDetalleVenta : Form
    {
        // Guardará la lista completa de ventas para filtrar en memoria
        private List<VentaInfo> _listaCompletaVentas;

        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            // --- Damos estilo a los campos de solo lectura ---
            EstiloTextBoxLectura(txtTipoDocumento);
            EstiloTextBoxLectura(txtNumeroDocumentoMostrar);
            EstiloTextBoxLectura(txtDescuento);
            EstiloTextBoxLectura(txtDocumentoCliente);
            EstiloTextBoxLectura(txtIdVenta);
            EstiloTextBoxLectura(txtCliente);
            EstiloTextBoxLectura(txtMontoTotal);

            ConfigurarGrillaVentas();
            CargarListaDeVentas();

            // Conecta el evento TextChanged para el filtro dinámico
            txtNumeroDocumento.TextChanged += txtNumeroDocumento_TextChanged;

            // ✅ CAMBIO: Conectamos el evento de Doble Clic a su método
            dgvDetalleVenta.CellDoubleClick += dgvDetalleVenta_CellDoubleClick;

            // Limpiamos los campos al inicio
            LimpiarCamposDetalle();
        }

        private void LimpiarCamposDetalle()
        {
            txtIdVenta.Text = "";
            txtTipoDocumento.Text = "";
            txtNumeroDocumentoMostrar.Text = "";
            txtMontoTotal.Text = "";
            txtDescuento.Text = "";
            txtCliente.Text = "";
            txtDocumentoCliente.Text = "";
        }

        // ✅ MÉTODO MODIFICADO: Ahora usa LimpiarCamposDetalle
        private void LimpiarCampos()
        {
            txtNumeroDocumento.Clear();
            LimpiarCamposDetalle(); // Limpia los campos de texto
            ConfigurarGrillaVentas(); // Reconfigura la grilla al modo "lista"
            CargarListaDeVentas(); // Recarga la lista de ventas
        }

        private void ConfigurarGrillaVentas()
        {
            dgvDetalleVenta.AutoGenerateColumns = false;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.Columns.Clear();

            dgvDetalleVenta.Columns.Add("FechaRegistro", "Fecha");
            dgvDetalleVenta.Columns.Add("TipoDocumento", "Tipo Doc.");
            dgvDetalleVenta.Columns.Add("NumeroDocumento", "Número Doc.");
            dgvDetalleVenta.Columns.Add("NombreCliente", "Cliente");
            dgvDetalleVenta.Columns.Add("NombreUsuario", "Vendedor");
            dgvDetalleVenta.Columns.Add("MontoTotal", "Monto Total");
            dgvDetalleVenta.Columns["MontoTotal"].DefaultCellStyle.Format = "C2";

            // Ocultamos la columna IdVenta pero la necesitamos para hacer doble clic
            dgvDetalleVenta.Columns.Add("IdVenta", "IdVenta");
            dgvDetalleVenta.Columns["IdVenta"].Visible = false;
        }

        private void CargarListaDeVentas()
        {
            _listaCompletaVentas = new CN_Venta().ListarVentas();

            dgvDetalleVenta.Rows.Clear();
            foreach (var v in _listaCompletaVentas)
            {
                dgvDetalleVenta.Rows.Add(new object[]
                {
                    v.FechaRegistro,
                    v.TipoDocumento,
                    v.NumeroDocumento,
                    v.NombreCliente,
                    v.NombreUsuario,
                    v.MontoTotal,
                    v.IdVenta // Añadimos el ID
                });
            }
        }

        // Evento que filtra la grilla en tiempo real
        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtNumeroDocumento.Text.Trim().ToUpper();

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;

                // Buscamos en la columna NumeroDocumento (índice 2)
                bool coincide = row.Cells["NumeroDocumento"].Value.ToString().ToUpper().Contains(textoBusqueda);
                row.Visible = coincide;
            }
        }

        // Este botón ya no es necesario para buscar, pero puedes usarlo para LIMPIAR
        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            // Opcional: puedes cambiar este botón para que sea "Limpiar"
            LimpiarCampos();
        }

        // Este método ahora mostrará los detalles de la venta SELECCIONADA
        private void MostrarDetalleDeVenta(string numeroDocumento)
        {
            // 1. Obtener la venta USANDO EL NÚMERO DE DOCUMENTO
            Venta venta = new CN_Venta().ObtenerPorNumeroDocumento(numeroDocumento);

            if (venta == null)
            {
                MessageBox.Show("No se pudieron cargar los detalles de la venta.");
                return;
            }

            // 2. Mostrar la info en los TextBoxes (¡ESTO AHORA FUNCIONARÁ!)
            txtIdVenta.Text = venta.IdVenta.ToString();
            txtTipoDocumento.Text = venta.TipoDocumento;
            txtNumeroDocumentoMostrar.Text = venta.NumeroDocumento;
            txtMontoTotal.Text = venta.MontoTotal.ToString("C2");
            txtDescuento.Text = venta.DescuentoAplicado.ToString("C2");

            if (venta.oCliente != null)
            {
                txtCliente.Text = venta.oCliente.NombreCompleto;
                txtDocumentoCliente.Text = venta.oCliente.Documento;
            }
            else
            {
                txtCliente.Text = "Consumidor Final";
                txtDocumentoCliente.Text = "---";
            }

            // 3. Cargar la grilla con los DETALLES
            ConfigurarGrillaDetalles(); // Cambiamos las columnas
            List<Detalle_Venta> detalles = new CN_Venta().ListarDetallePorVenta(venta.IdVenta);

            dgvDetalleVenta.Rows.Clear();
            foreach (var d in detalles)
            {
                dgvDetalleVenta.Rows.Add(new object[]
                {
            d.NombreProducto,
            d.PrecioVenta,
            d.Cantidad,
            d.SubTotal
                });
            }
        }

        // NUEVO: Método para configurar la grilla para ver detalles
        private void ConfigurarGrillaDetalles()
        {
            dgvDetalleVenta.Columns.Clear();
            dgvDetalleVenta.Columns.Add("NombreProducto", "Producto");
            dgvDetalleVenta.Columns.Add("PrecioVenta", "Precio");
            dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            dgvDetalleVenta.Columns.Add("SubTotal", "SubTotal");
            dgvDetalleVenta.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvDetalleVenta.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
        }

        // NUEVO: Evento para ver el detalle al hacer doble clic
        private void dgvDetalleVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Se hizo clic en el encabezado

            // Obtenemos el NumeroDocumento de la fila seleccionada
            string numDoc = dgvDetalleVenta.Rows[e.RowIndex].Cells["NumeroDocumento"].Value.ToString();

            // Llamamos al método que muestra los detalles
            MostrarDetalleDeVenta(numDoc);
        }
        private void EstiloTextBoxLectura(TextBox txt)
        {
            txt.ReadOnly = true;
            txt.BackColor = Color.WhiteSmoke;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}