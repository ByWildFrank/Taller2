using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace BeanDesktop
{
    public partial class frmReporteVentas : Form
    {
        private List<ReporteVenta> listaReporteActual = new List<ReporteVenta>();

        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            cbobusqueda.Items.Clear();
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "FechaRegistro", Texto = "Fecha" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "TipoDocumento", Texto = "Tipo Documento" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "NumeroDocumento", Texto = "Numero Documento" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "DocumentoCliente", Texto = "Documento Cliente" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "NombreCliente", Texto = "Nombre Cliente" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "UsuarioRegistro", Texto = "Vendedor" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "CodigoProducto", Texto = "Código Producto" });
            cbobusqueda.Items.Add(new OpcionCombo() { Valor = "NombreProducto", Texto = "Nombre Producto" });

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Configurar Fechas
            dtpInicio.Value = DateTime.Now.AddYears(-1);
            dtpFin.Value = DateTime.Now;

            // Conectar eventos
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarBuscador.Click += btnLimpiarBuscador_Click;
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;

            CargarReporte();
        }

        // 1. CargarReporte: Busca en la BD y guarda en la lista principal
        private void CargarReporte()
        {
            string fechaInicio = dtpInicio.Value.ToString("dd/MM/yyyy");
            string fechaFin = dtpFin.Value.ToString("dd/MM/yyyy");

            // Llama al SP, que filtra por fecha
            listaReporteActual = new CN_Reporte().Venta(fechaInicio, fechaFin);

            // Aplica el filtro de texto (si hay algo escrito)
            AplicarFiltroDeTexto();
        }

        // 2. AplicarFiltroDeTexto: Filtra la lista en memoria (rápido)
        private void AplicarFiltroDeTexto()
        {
            if (listaReporteActual == null) return;

            List<ReporteVenta> listaFiltrada = new List<ReporteVenta>(listaReporteActual);

            if (!string.IsNullOrWhiteSpace(txtbusqueda.Text))
            {
                try
                {
                    string columna = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
                    string valor = txtbusqueda.Text.Trim().ToLower();

                    listaFiltrada = listaReporteActual.Where(rv =>
                    {
                        // Usamos reflection para obtener el valor de la propiedad por su nombre
                        var prop = typeof(ReporteVenta).GetProperty(columna);
                        if (prop == null) return false;
                        var propValue = prop.GetValue(rv)?.ToString()?.ToLower();
                        return propValue != null && propValue.Contains(valor);
                    }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar: " + ex.Message);
                }
            }

            // 3. MostrarDatos: Pinta la grilla con la lista filtrada
            MostrarDatos(listaFiltrada);
        }

        // 4. MostrarDatos: Solo se encarga de dibujar
        private void MostrarDatos(List<ReporteVenta> lista)
        {
            dgvdata.Rows.Clear();
            foreach (ReporteVenta rv in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    rv.FechaRegistro, rv.HoraRegistro, rv.TipoDocumento,
                    rv.NumeroDocumento, rv.DocumentoCliente, rv.NombreCliente,
                    rv.MontoTotal, rv.MontoPago, rv.MontoCambio, rv.DescuentoAplicado,
                    rv.UsuarioRegistro, rv.CodigoProducto, rv.NombreProducto,
                    rv.Categoria, rv.PrecioVenta, rv.Cantidad, rv.Subtotal,
                    rv.GananciaBruta, rv.CostoUnitario
                });
            }
        }

        // --- EVENTOS DE CONTROLES ---

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // El botón "Buscar" ahora recarga los datos de la BD según las fechas
            CargarReporte();
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // El TextBox solo filtra la lista que ya está en memoria
            AplicarFiltroDeTexto();
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            cbobusqueda.SelectedIndex = 0;
            // Al limpiar, solo aplicamos el filtro de texto (que estará vacío)
            AplicarFiltroDeTexto();
        }

        // Estos eventos ya no son necesarios si usamos el botón "Buscar"
        private void dtpInicio_ValueChanged(object sender, EventArgs e) { /* No hacer nada */ }
        private void dtpFin_ValueChanged(object sender, EventArgs e) { /* No hacer nada */ }


        private void exportarExelButton_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible)
                    dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            // ✅ IMPORTANTE: Exportar solo las filas visibles
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                // Solo añadimos la fila al Excel si está visible en la grilla
                if (fila.Visible)
                {
                    DataRow row = dt.NewRow();
                    int colIndex = 0;
                    foreach (DataGridViewColumn columna in dgvdata.Columns)
                    {
                        if (columna.Visible)
                        {
                            row[colIndex] = fila.Cells[columna.Index].Value?.ToString() ?? "";
                            colIndex++;
                        }
                    }
                    dt.Rows.Add(row);
                }
            }

            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss")),
                Filter = "Excel files | *.xlsx"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                    }
                    MessageBox.Show("Reporte generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo generar el reporte.\nError: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnResetFechas_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Now.AddYears(-1);
            dtpFin.Value = DateTime.Now;
            CargarReporte();
        }
    }
}