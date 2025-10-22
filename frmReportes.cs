using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Legends;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Legends;

namespace BeanDesktop
{
    public partial class FrmReportes : Form
    {
        private readonly Color _colorBordePositivo = Color.FromArgb(223, 240, 216);
        private readonly Color _colorBordeNegativo = Color.FromArgb(242, 222, 222);
        private readonly Color _colorBordeNeutro = Color.WhiteSmoke;

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // Configurar selectores de fecha
            ConfigurarSelectoresFecha();

            // Configurar ComboBox
            cboTipoGrafico.Items.AddRange(new string[] {
                "Clientes por Segmento",
                "Ganancias Mensuales",
                "Ventas por Producto",
                "Ventas por Vendedor"
            });
            cboTipoGrafico.SelectedIndexChanged += CboTipoGrafico_SelectedIndexChanged;
            cboTipoGrafico.SelectedIndex = 0;

            this.BackColor = Color.FromArgb(245, 246, 250);

            // Carga inicial
            CargarDatosKPIs();
        }

        private void ConfigurarSelectoresFecha()
        {
            // Fecha inicio: primer día del mes actual
            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;

            // Fecha fin: hoy
            dtpFechaFin.Value = DateTime.Now;
            dtpFechaFin.Format = DateTimePickerFormat.Short;

            // Eventos de botones
            btnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            btnMesActual.Click += BtnMesActual_Click;
        }

        private void BtnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.",
                    "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarDatosKPIs();
            CargarGraficoSeleccionado();
        }

        private void BtnMesActual_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFin.Value = DateTime.Now;
            CargarDatosKPIs();
            CargarGraficoSeleccionado();
        }

        private void CboTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGraficoSeleccionado();
        }

        private void CargarGraficoSeleccionado()
        {
            string opcion = cboTipoGrafico.SelectedItem?.ToString() ?? "";
            switch (opcion)
            {
                case "Clientes por Segmento": CargarGraficoSegmentos_Oxy(); break;
                case "Ganancias Mensuales": CargarGraficoGanancias_Oxy(); break;
                case "Ventas por Producto": CargarGraficoVentasProducto_Oxy(); break;
                case "Ventas por Vendedor": CargarGraficoVentasVendedor_Oxy(); break;
            }
        }

        private void CargarDatosKPIs()
        {
            var cnReporte = new CN_Reporte();
            DashboardKPIs kpis;

            try
            {
                // Pasar las fechas seleccionadas
                kpis = cnReporte.ObtenerDatosDashboard(dtpFechaInicio.Value, dtpFechaFin.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los indicadores: {ex.Message}",
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Formatear período para mostrar en las tarjetas
            string periodo = "";
            if (dtpFechaInicio.Value.Month == DateTime.Now.Month &&
                dtpFechaInicio.Value.Year == DateTime.Now.Year &&
                dtpFechaFin.Value.Date == DateTime.Now.Date)
            {
                periodo = "(Mes Actual)";
            }
            else
            {
                periodo = $"({dtpFechaInicio.Value:dd/MM} - {dtpFechaFin.Value:dd/MM})";
            }

            // Card 1: Ganancias (SIEMPRE del mes actual)
            lblTituloGanancias.Text = "Ganancias (Mes Actual)";
            lblValorGanancias.Text = kpis.GananciasMesActual.ToString("C");
            ConfigurarIndicador(lblPorcentajeGanancias, pnlGanancias,
                kpis.GananciasMesActual, kpis.GananciasMesAnterior, "vs mes anterior");

            // Card 2: Nuevos Clientes (del período seleccionado)
            lblTituloNuevosClientes.Text = $"Nuevos Clientes {periodo}";
            lblValorNuevosClientes.Text = kpis.NuevosClientesActual.ToString();
            ConfigurarIndicador(lblPorcentajeNuevosClientes, pnlNuevosClientes,
                kpis.NuevosClientesActual, kpis.NuevosClientesAnterior, "vs período anterior");

            // Card 3: Ticket Promedio (del período seleccionado)
            lblTituloTicketPromedio.Text = $"Ticket Promedio {periodo}";
            lblValorTicketPromedio.Text = kpis.TicketPromedioActual.ToString("C");
            ConfigurarIndicador(lblPorcentajeTicket, pnlTicketPromedio,
                kpis.TicketPromedioActual, kpis.TicketPromedioAnterior, "vs período anterior");

            // Card 4: Segmento Dominante (hasta la fecha fin)
            lblTituloSegmento.Text = "Segmento Dominante";
            lblValorSegmento.Text = kpis.SegmentoDominante;
            lblValorSegmento.ForeColor = Color.Gray;
            pnlSegmento.BackColor = Color.FromArgb(232, 243, 255);

            // Card 5: Bajo Stock (SIEMPRE actual)
            lblTituloBajoStock.Text = "Productos en Bajo Stock (<10)";
            lblValorBajoStock.Text = kpis.ProductosBajoStock.ToString();
            if (kpis.ProductosBajoStock > 0)
            {
                lblAlertaStock.Text = "⚠️ ¡Revisar!";
                pnlBajoStock.BackColor = _colorBordeNegativo;
            }
            else
            {
                lblAlertaStock.Text = "✓ Stock OK";
                pnlBajoStock.BackColor = _colorBordePositivo;
            }
        }

        private void ConfigurarIndicador(Label label, Panel panelBorde, decimal valorActual, decimal valorAnterior, string textoComparacion)
        {
            Color colorBorde = _colorBordeNeutro;
            Color colorTexto = Color.Gray;
            string texto = $"s/d {textoComparacion}";

            if (valorAnterior != 0)
            {
                decimal cambio = ((valorActual - valorAnterior) / valorAnterior) * 100;
                if (cambio > 0.1m)
                {
                    texto = $"▲ {cambio:F1}% {textoComparacion}";
                    colorTexto = Color.DarkGreen;
                    colorBorde = _colorBordePositivo;
                }
                else if (cambio < -0.1m)
                {
                    texto = $"▼ {Math.Abs(cambio):F1}% {textoComparacion}";
                    colorTexto = Color.Red;
                    colorBorde = _colorBordeNegativo;
                }
                else
                {
                    texto = $"▬ ~0% {textoComparacion}";
                }
            }

            label.Text = texto;
            label.ForeColor = colorTexto;
            panelBorde.BackColor = colorBorde;
        }

        // ------------------- GRAFICO 1: SEGMENTOS -------------------
        private void CargarGraficoSegmentos_Oxy()
        {
            try
            {
                // Pasar fecha fin para filtrar clientes registrados hasta esa fecha
                var datos = new CN_Reporte().ObtenerClientesPorSegmento(dtpFechaFin.Value);
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de segmentos para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrafico();
                    return;
                }

                var model = new PlotModel
                {
                    Title = $"Distribución de Clientes por Segmento (hasta {dtpFechaFin.Value:dd/MM/yyyy})",
                    TitleFontSize = 18,
                    Background = OxyColors.White
                };

                var pie = new PieSeries
                {
                    StrokeThickness = 2,
                    Stroke = OxyColors.White,
                    InsideLabelPosition = 0.8,
                    AngleSpan = 360,
                    StartAngle = 0,
                    FontSize = 14,
                    OutsideLabelFormat = "{1}: {2:0}%",
                    InsideLabelFormat = "{0}",
                    InsideLabelColor = OxyColors.White
                };

                foreach (var kv in datos)
                {
                    pie.Slices.Add(new PieSlice(kv.Key, Convert.ToDouble(kv.Value))
                    {
                        IsExploded = false,
                        Fill = OxyColor.FromRgb((byte)(50 + pie.Slices.Count * 40),
                                                 (byte)(100 + pie.Slices.Count * 30),
                                                 (byte)(200 - pie.Slices.Count * 20))
                    });
                }

                model.Series.Add(pie);
                pltGraficos.Model = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico de segmentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------- GRAFICO 2: GANANCIAS MENSUALES -------------------
        private void CargarGraficoGanancias_Oxy()
        {
            try
            {
                // Pasar rango de fechas
                var datos = new CN_Reporte().ObtenerGananciasMensuales(dtpFechaInicio.Value, dtpFechaFin.Value);
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de ganancias mensuales para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrafico();
                    return;
                }

                var model = new PlotModel
                {
                    Title = $"Ganancias Mensuales ({dtpFechaInicio.Value:MMM yyyy} - {dtpFechaFin.Value:MMM yyyy})",
                    TitleFontSize = 18,
                    Background = OxyColors.White,
                    Padding = new OxyThickness(60, 10, 20, 60)
                };

                var categoryAxis = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Mes",
                    TitleFontSize = 14,
                    FontSize = 11
                };

                foreach (var item in datos)
                {
                    categoryAxis.Labels.Add(item.Key);
                }
                model.Axes.Add(categoryAxis);

                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Ganancia ($)",
                    TitleFontSize = 14,
                    StringFormat = "C0",
                    MajorGridlineStyle = LineStyle.Solid,
                    MajorGridlineColor = OxyColor.FromRgb(220, 220, 220),
                    MinorGridlineStyle = LineStyle.Dot,
                    MinorGridlineColor = OxyColor.FromRgb(240, 240, 240),
                    FontSize = 12
                };
                model.Axes.Add(valueAxis);

                var barSeries = new BarSeries
                {
                    Title = "Ganancias",
                    FillColor = OxyColor.FromRgb(79, 129, 189),
                    StrokeThickness = 1,
                    StrokeColor = OxyColors.Black,
                    LabelFormatString = "{0:C0}",
                    LabelPlacement = LabelPlacement.Outside,
                    FontSize = 10
                };

                foreach (var item in datos)
                {
                    barSeries.Items.Add(new BarItem(Convert.ToDouble(item.Value)));
                }

                model.Series.Add(barSeries);
                pltGraficos.Model = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico de ganancias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------- GRAFICO 3: VENTAS POR PRODUCTO -------------------
        private void CargarGraficoVentasProducto_Oxy()
        {
            try
            {
                // Pasar rango de fechas
                var datos = new CN_Reporte().ObtenerVentasPorProducto(dtpFechaInicio.Value, dtpFechaFin.Value);
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de ventas por producto para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrafico();
                    return;
                }

                var top5 = datos.OrderByDescending(d => d.Value).Take(5).ToList();

                var model = new PlotModel
                {
                    Title = $"Ventas por Producto - Top 5 ({dtpFechaInicio.Value:dd/MM} - {dtpFechaFin.Value:dd/MM})",
                    TitleFontSize = 18,
                    Background = OxyColors.White,
                    Padding = new OxyThickness(120, 10, 60, 40)
                };

                var categoryAxis = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Producto",
                    TitleFontSize = 14,
                    FontSize = 12
                };

                foreach (var item in top5.AsEnumerable().Reverse())
                {
                    categoryAxis.Labels.Add(item.Key);
                }
                model.Axes.Add(categoryAxis);

                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Total Vendido ($)",
                    TitleFontSize = 14,
                    StringFormat = "C0",
                    FontSize = 12,
                    MajorGridlineStyle = LineStyle.Solid,
                    MajorGridlineColor = OxyColor.FromRgb(220, 220, 220)
                };
                model.Axes.Add(valueAxis);

                var barSeries = new BarSeries
                {
                    Title = "Ventas",
                    FillColor = OxyColor.FromRgb(155, 187, 89),
                    StrokeThickness = 1,
                    StrokeColor = OxyColors.Black,
                    LabelFormatString = "{0:C0}",
                    LabelPlacement = LabelPlacement.Outside,
                    FontSize = 10
                };

                foreach (var item in top5.AsEnumerable().Reverse())
                {
                    barSeries.Items.Add(new BarItem(Convert.ToDouble(item.Value)));
                }

                model.Series.Add(barSeries);
                pltGraficos.Model = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------- GRAFICO 4: VENTAS POR VENDEDOR -------------------
        private void CargarGraficoVentasVendedor_Oxy()
        {
            try
            {
                // Usar las fechas del selector
                var datos = new CN_Reporte().ObtenerVentasPorVendedor(dtpFechaInicio.Value, dtpFechaFin.Value);

                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de ventas por vendedor en el período seleccionado.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrafico();
                    return;
                }

                ResetearGrafico();

                var model = new PlotModel
                {
                    Title = $"Ventas por Vendedor ({dtpFechaInicio.Value:dd/MM} - {dtpFechaFin.Value:dd/MM})",
                    TitleFontSize = 18,
                    Background = OxyColors.White,
                    Padding = new OxyThickness(150, 10, 60, 40)
                };

                var categoryAxis = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Vendedor",
                    TitleFontSize = 14,
                    FontSize = 11
                };

                foreach (var item in datos)
                {
                    categoryAxis.Labels.Add(item.Key);
                }
                model.Axes.Add(categoryAxis);

                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "Total Vendido ($)",
                    TitleFontSize = 14,
                    StringFormat = "C0",
                    MajorGridlineStyle = LineStyle.Solid,
                    MajorGridlineColor = OxyColor.FromRgb(220, 220, 220),
                    FontSize = 12
                };
                model.Axes.Add(valueAxis);

                var barSeries = new BarSeries
                {
                    Title = "Ventas",
                    FillColor = OxyColor.FromRgb(91, 155, 213),
                    StrokeThickness = 1,
                    StrokeColor = OxyColors.Black,
                    LabelFormatString = "{0:C0}",
                    LabelPlacement = LabelPlacement.Outside,
                    FontSize = 10
                };

                foreach (var item in datos)
                {
                    barSeries.Items.Add(new BarItem(Convert.ToDouble(item.Value)));
                }

                model.Series.Add(barSeries);
                pltGraficos.Model = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gráfico de vendedores: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetearGrafico()
        {
            pltGraficos.Model = new PlotModel();
            pltGraficos.InvalidatePlot(true);
        }
    }
}