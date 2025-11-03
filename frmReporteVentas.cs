using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace BeanDesktop
{
    public partial class frmReporteVentas : Form
    {
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
                cbobusqueda.DisplayMember = "Texto";
                cbobusqueda.ValueMember = "Valor";
                cbobusqueda.SelectedIndex = 0;
            }
            // Fecha de inicio: un año antes de la fecha actual
            dtpInicio.Value = DateTime.Now.AddYears(-1);

            // Fecha de fin: fecha actual
            dtpFin.Value = DateTime.Now;
            CargarReporte();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
        private void CargarReporte()
        {
            // Convertimos las fechas al formato que espera el SP (dd/MM/yyyy)
            string fechaInicio = dtpInicio.Value.ToString("dd/MM/yyyy");
            string fechaFin = dtpFin.Value.ToString("dd/MM/yyyy");

            List<ReporteVenta> lista = new CN_Reporte().Venta(fechaInicio, fechaFin);

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
                    rv.CostoUnitario,
                });
            }
        }
        private void exportarExelButton_Click(object sender, EventArgs e)
        {
            if(dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
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

            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            saveFile.Filter = "Exel files | *.xslx";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook wb = new XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Informe");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(saveFile.FileName);
                    MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("No se pudo generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
