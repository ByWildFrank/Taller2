using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmReporteVentas : Form
    {
        private List<ReporteVenta> listaCompleta = new List<ReporteVenta>();

        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            dtpInicio.Value = DateTime.Now.AddYears(-1);
            dtpFin.Value = DateTime.Now;

            CargarReporte();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void CargarReporte()
        {
            string fechaInicio = dtpInicio.Value.ToString("dd/MM/yyyy");
            string fechaFin = dtpFin.Value.ToString("dd/MM/yyyy");

            listaCompleta = new CN_Reporte().Venta(fechaInicio, fechaFin);

            MostrarDatos(listaCompleta);
        }

        private void MostrarDatos(List<ReporteVenta> lista)
        {
            dgvdata.Rows.Clear();

            foreach (ReporteVenta rv in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    rv.FechaRegistro,
                    rv.HoraRegistro,
                    rv.TipoDocumento,
                    rv.NumeroDocumento,
                    rv.DocumentoCliente,
                    rv.NombreCliente,
                    rv.MontoTotal,
                    rv.MontoPago,
                    rv.MontoCambio,
                    rv.DescuentoAplicado,
                    rv.UsuarioRegistro,
                    rv.CodigoProducto,
                    rv.NombreProducto,
                    rv.Categoria,
                    rv.PrecioVenta,
                    rv.Cantidad,
                    rv.Subtotal,
                    rv.GananciaBruta,
                    rv.CostoUnitario
                });
            }
        }

        private void AplicarFiltros()
        {
            if (listaCompleta == null || listaCompleta.Count == 0)
                return;

            // Fechas desde los DateTimePickers
            DateTime inicio = dtpInicio.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            // Intentamos filtrar las fechas correctamente
            var listaFiltrada = listaCompleta
                .Where(rv =>
                {
                    // Intentamos convertir la cadena a DateTime con formato exacto
                    if (DateTime.TryParseExact(rv.FechaRegistro,
                                               "dd/MM/yyyy",
                                               System.Globalization.CultureInfo.InvariantCulture,
                                               System.Globalization.DateTimeStyles.None,
                                               out DateTime fechaVenta)
                        ||
                        DateTime.TryParseExact(rv.FechaRegistro,
                                               "dd/MM/yyyy HH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture,
                                               System.Globalization.DateTimeStyles.None,
                                               out fechaVenta))
                    {
                        // Comparamos solo las fechas (sin horas)
                        return fechaVenta.Date >= inicio && fechaVenta.Date <= fin;
                    }

                    // Si no se puede convertir, se excluye el registro
                    return false;
                })
                .ToList();

            // Búsqueda por columna (si hay texto)
            if (!string.IsNullOrWhiteSpace(txtbusqueda.Text))
            {
                string columna = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
                string valor = txtbusqueda.Text.Trim().ToLower();

                listaFiltrada = listaFiltrada
                    .Where(rv =>
                    {
                        var prop = typeof(ReporteVenta).GetProperty(columna);
                        if (prop == null) return false;
                        var propValue = prop.GetValue(rv)?.ToString()?.ToLower();
                        return propValue != null && propValue.Contains(valor);
                    })
                    .ToList();
            }

            MostrarDatos(listaFiltrada);
        }


        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            cbobusqueda.SelectedIndex = 0;
            AplicarFiltros();
        }


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

            foreach (DataGridViewRow fila in dgvdata.Rows)
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
                catch
                {
                    MessageBox.Show("No se pudo generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
