using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using Microsoft.ML;
using BeanDesktop.CapaDeEntidades;
using OxyPlot.Legends;
using System.IO;

namespace BeanDesktop
{
    public partial class frmIAML : Form
    {
        private List<ClienteData> _datosOriginales;
        private List<ClientePrediction> _predicciones;

        public frmIAML()
        {
            InitializeComponent();
        }

        private async void btnSegmentar_Click(object sender, EventArgs e)
        {
            int numeroDeClusters = (int)numClusters.Value;
            if (numeroDeClusters <= 1)
            {
                MessageBox.Show("Debe seleccionar al menos 2 clusters.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStatusML.Text = "Entrenando modelo y segmentando clientes...";
            lblStatusML.Visible = true;
            btnSegmentar.Enabled = false;
            pltGraficoClusters.Model = null; 
            dgvResultados.Rows.Clear();
            try
            {
                await Task.Run(() =>
                {
                    var clusteringService = new CN_Clustering();
                    var (modelo, datosOriginales) = clusteringService.EntrenarModelo(numeroDeClusters);

                    var mlContext = new MLContext();
                    var dataView = mlContext.Data.LoadFromEnumerable(datosOriginales);
                    var predicciones = modelo.Transform(dataView);

                    _datosOriginales = datosOriginales;
                    _predicciones = mlContext.Data.CreateEnumerable<ClientePrediction>(predicciones, reuseRowObject: false).ToList();
                });

                MostrarResultadosEnGrafico();
                MostrarResultadosEnTabla();
                MostrarAnalisisEnTexto();

                lblStatusML.Text = $"Segmentación completada en {numeroDeClusters} grupos.";
            }
            catch (Exception ex)
            {
                lblStatusML.Text = "Error durante la segmentación.";
                MessageBox.Show($"Error: {ex.Message}", "Error de ML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSegmentar.Enabled = true;
            }
        }

        private void MostrarResultadosEnGrafico()
        {
            var model = new PlotModel { Title = "Clusters de Clientes (Gasto vs. Frecuencia)" };
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Frecuencia de Compra",
                MajorGridlineStyle = LineStyle.Dot
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Gasto Total ($)",
                StringFormat = "C0", // Formato de moneda
                MajorGridlineStyle = LineStyle.Dot
            });

            // Paleta de colores para los clusters
            var colores = new[] { OxyColors.Blue, OxyColors.Green, OxyColors.Red, OxyColors.Orange, OxyColors.Purple, OxyColors.Brown, OxyColors.Teal, OxyColors.Magenta };

            // 2. Juntar los datos originales con sus predicciones y agruparlos por Cluster ID
            var resultadosAgrupados = _datosOriginales
                .Zip(_predicciones, (data, pred) => new { Data = data, Pred = pred })
                .GroupBy(x => x.Pred.PredictedClusterId)
                .ToList();

            // 3. Crear una serie de puntos (ScatterSeries) para cada cluster
            foreach (var grupo in resultadosAgrupados)
            {
                uint clusterId = grupo.Key;
                var scatterSeries = new ScatterSeries
                {
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 5,
                    Title = $"Cluster {clusterId}",
                    MarkerFill = colores[(int)(clusterId - 1) % colores.Length]
                };

                foreach (var item in grupo)
                {
                    scatterSeries.Points.Add(new ScatterPoint(item.Data.Frequency, item.Data.Monetary));
                }

                model.Series.Add(scatterSeries);
            }

            // 4. Añadir la leyenda al gráfico
            model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendPosition = LegendPosition.TopRight,
                LegendPlacement = LegendPlacement.Inside
            });

            pltGraficoClusters.Model = model;
        }

        private void MostrarResultadosEnTabla()
        {
            dgvResultados.Rows.Clear();
            dgvResultados.Columns.Clear();
            dgvResultados.Columns.Add("IdCliente", "ID");
            dgvResultados.Columns.Add("Nombre", "Nombre Completo");
            dgvResultados.Columns.Add("Cluster", "Segmento (Cluster)");
            dgvResultados.Columns.Add("Recency", "Últ. Compra (días)");
            dgvResultados.Columns.Add("Frequency", "Frecuencia");
            dgvResultados.Columns.Add("Monetary", "Gasto Total");
            dgvResultados.Columns.Add("AverageTicket", "Ticket Promedio");
            dgvResultados.Columns.Add("ProductVariety", "Variedad Prod.");

            dgvResultados.Columns["Monetary"].DefaultCellStyle.Format = "C2";
            dgvResultados.Columns["AverageTicket"].DefaultCellStyle.Format = "C2";

            var resultados = _datosOriginales.Zip(_predicciones, (data, pred) => new { Data = data, Pred = pred }).ToList();

            foreach (var item in resultados)
            {
                dgvResultados.Rows.Add(
                    item.Data.IdCliente,
                    item.Data.NombreCompleto,
                    $"Cluster {item.Pred.PredictedClusterId}",
                    item.Data.Recency,
                    item.Data.Frequency,
                    item.Data.Monetary.ToString("C"),
                    item.Data.AverageTicket,
                    item.Data.ProductVariety
                );
            }
        }

        private void frmIAML_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 246, 250);
        }

        private void MostrarAnalisisEnTexto()
        {
            if (_datosOriginales == null || !_datosOriginales.Any()) return;

            var resultados = _datosOriginales.Zip(_predicciones, (data, pred) => new { Data = data, Pred = pred }).ToList();

            var promedioGeneralRecency = resultados.Average(r => r.Data.Recency);
            var promedioGeneralFrequency = resultados.Average(r => r.Data.Frequency);
            var promedioGeneralMonetary = resultados.Average(r => r.Data.Monetary);

            var insights = resultados
                .GroupBy(r => r.Pred.PredictedClusterId)
                .Select(g => new
                {
                    ClusterId = g.Key,
                    CantidadClientes = g.Count(),
                    PromedioRecency = g.Average(x => x.Data.Recency),
                    PromedioFrequency = g.Average(x => x.Data.Frequency),
                    PromedioMonetary = g.Average(x => x.Data.Monetary)
                })
                .OrderBy(g => g.ClusterId).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- ANÁLISIS DE CLUSTERS ---");

            foreach (var cluster in insights)
            {
                sb.AppendLine();
                sb.AppendLine($"CLUSTER {cluster.ClusterId}: ({cluster.CantidadClientes} clientes)");

                string personalidad = "Cliente Promedio";
                if (cluster.PromedioFrequency > promedioGeneralFrequency * 1.5 && cluster.PromedioMonetary > promedioGeneralMonetary * 1.5 && cluster.PromedioRecency < promedioGeneralRecency * 0.75)
                    personalidad = "⭐⭐⭐ Cliente Estrella / VIP";
                else if (cluster.PromedioRecency > promedioGeneralRecency * 1.5 && cluster.PromedioFrequency < promedioGeneralFrequency)
                    personalidad = "⚠️ Cliente Dormido / En Riesgo";
                else if (cluster.PromedioFrequency <= 2 && cluster.PromedioRecency < promedioGeneralRecency * 0.5)
                    personalidad = "🌱 Cliente Nuevo / Prometedor";
                else if (cluster.PromedioMonetary > promedioGeneralMonetary * 2.0 && cluster.PromedioFrequency < promedioGeneralFrequency)
                    personalidad = "💰 Comprador Ocasional de Alto Valor";

                sb.AppendLine($"  ▶ Personalidad: {personalidad}");
                sb.AppendLine($"  ▶ Gasto Promedio: {cluster.PromedioMonetary:C}");
                sb.AppendLine($"  ▶ Frecuencia Promedio: {cluster.PromedioFrequency:N1} compras");
                sb.AppendLine($"  ▶ Última Compra (Promedio): Hace {cluster.PromedioRecency:N0} días");
            }

            txtInsights.Text = sb.ToString();
        }

        private void btnDescargarCsv_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya datos para exportar
            if (_datosOriginales == null || _predicciones == null || !_datosOriginales.Any())
            {
                MessageBox.Show("No hay datos de segmentación para exportar. Por favor, ejecute la segmentación primero.", "Datos no encontrados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Preguntar al usuario dónde guardar
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"Segmentacion_Clientes_{DateTime.Now:yyyyMMdd}.csv";
            saveFile.Filter = "Archivo CSV (*.csv)|*.csv";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();

                    // 3. Crear los encabezados del CSV
                    sb.AppendLine("IdCliente,NombreCompleto,ClusterId,Recency(dias),Frequency(compras),Monetary(gasto),AverageTicket,ProductVariety");

                    // 4. Juntar los datos originales con sus predicciones
                    var resultados = _datosOriginales.Zip(_predicciones, (data, pred) => new { Data = data, Pred = pred });

                    // 5. Escribir cada fila de datos
                    foreach (var item in resultados)
                    {
                        sb.AppendLine(
                            $"{item.Data.IdCliente}," +
                            $"\"{item.Data.NombreCompleto}\"," + // Usar comillas por si el nombre tiene comas
                            $"{item.Pred.PredictedClusterId}," +
                            $"{item.Data.Recency}," +
                            $"{item.Data.Frequency}," +
                            $"{item.Data.Monetary}," +
                            $"{item.Data.AverageTicket}," +
                            $"{item.Data.ProductVariety}"
                        );
                    }

                    // 6. Guardar el archivo
                    File.WriteAllText(saveFile.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Archivo CSV exportado con éxito.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}