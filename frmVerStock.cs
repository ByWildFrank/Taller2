using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using CapaDeDatos;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using ClosedXML.Excel;

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

        private void exportarExelButton_Click(object sender, EventArgs e)
        {
            // 1. Comprobar si hay datos para exportar
            if (dgvStock.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Crear un DataTable en memoria
            DataTable dt = new DataTable();

            // 3. Crear las columnas en el DataTable basadas en la grilla
            foreach (DataGridViewColumn columna in dgvStock.Columns)
            {
                if (columna.Visible && columna.HeaderText != "") // Solo columnas visibles
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
            }

            // 4. Copiar las filas de la grilla al DataTable
            foreach (DataGridViewRow fila in dgvStock.Rows)
            {
                if (fila.Visible) // Solo exportar filas que están visibles (respeta el filtro)
                {
                    DataRow row = dt.NewRow();
                    int colIndex = 0;
                    foreach (DataGridViewColumn columna in dgvStock.Columns)
                    {
                        if (columna.Visible && columna.HeaderText != "")
                        {
                            // Obtener el valor, formatearlo si es necesario (ej. Precio)
                            string valorCelda = fila.Cells[columna.Name].Value?.ToString() ?? "";

                            if (columna.Name == "PrecioVenta")
                            {
                                valorCelda = Convert.ToDecimal(fila.Cells[columna.Name].Value).ToString("0.00");
                            }

                            row[colIndex] = valorCelda;
                            colIndex++;
                        }
                    }
                    dt.Rows.Add(row);
                }
            }

            // 5. Pedir al usuario dónde guardar el archivo
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = string.Format("ReporteStock_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss")),
                Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 6. Usar ClosedXML para crear el archivo
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var hoja = wb.Worksheets.Add(dt, "Stock");
                        hoja.ColumnsUsed().AdjustToContents(); // Ajustar ancho de columnas
                        wb.SaveAs(saveFile.FileName);
                    }
                    MessageBox.Show("Reporte de stock generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}