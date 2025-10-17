using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BeanDesktop.CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace BeanDesktop
{
    public partial class FrmReportes : Form
    {
        // Colores para los bordes de las cards
        private readonly Color _colorBordePositivo = Color.FromArgb(223, 240, 216); // Verde claro
        private readonly Color _colorBordeNegativo = Color.FromArgb(242, 222, 222); // Rojo claro
        private readonly Color _colorBordeNeutro = Color.WhiteSmoke;

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // Configurar ComboBox
            cboTipoGrafico.Items.AddRange(new string[] { "Clientes por Segmento", "Ganancias Mensuales", "Ventas por Producto" });
            cboTipoGrafico.SelectedIndexChanged += CboTipoGrafico_SelectedIndexChanged;
            cboTipoGrafico.SelectedIndex = 0; // Esto disparará el evento y cargará el primer gráfico

            this.BackColor = Color.FromArgb(245, 246, 250);

            // Carga inicial de KPIs
            CargarDatosKPIs();
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
            }
        }

        private void CargarDatosKPIs()
        {
            var cnReporte = new CN_Reporte();
            DashboardKPIs kpis;

            try
            {
                kpis = cnReporte.ObtenerDatosDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los indicadores: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Card 1: Ganancias del Mes ---
            lblTituloGanancias.Text = "Ganancias (Mes Actual)";
            lblValorGanancias.Text = kpis.GananciasMesActual.ToString("C");
            ConfigurarIndicador(lblPorcentajeGanancias, pnlGanancias, kpis.GananciasMesActual, kpis.GananciasMesAnterior, "vs mes anterior");

            // --- Card 2: Nuevos Clientes ---
            lblTituloNuevosClientes.Text = "Nuevos Clientes (Mes Actual)";
            lblValorNuevosClientes.Text = kpis.NuevosClientesActual.ToString();
            ConfigurarIndicador(lblPorcentajeNuevosClientes, pnlNuevosClientes, kpis.NuevosClientesActual, kpis.NuevosClientesAnterior, "vs mes anterior");

            // --- Card 3: Ticket Promedio ---
            lblTituloTicketPromedio.Text = "Ticket Promedio (Mes Actual)";
            lblValorTicketPromedio.Text = kpis.TicketPromedioActual.ToString("C");
            ConfigurarIndicador(lblPorcentajeTicket, pnlTicketPromedio, kpis.TicketPromedioActual, kpis.TicketPromedioAnterior, "vs mes anterior");

            // --- Card 4: Segmento Dominante ---
            lblTituloSegmento.Text = "Segmento Dominante";
            lblValorSegmento.Text = "Grupo de clientes más común"; 
            lblValorSegmento.Text = kpis.SegmentoDominante; // Asigna el valor (ej: "AltoValor")
            lblValorSegmento.ForeColor = Color.Gray;
            pnlSegmento.BackColor = Color.FromArgb(232, 243, 255);

            // --- Alerta especial para Bajo Stock (puedes tener un panel dedicado para esto) ---
            lblTituloBajoStock.Text = "Productos en Bajo Stock (<20)";
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
                if (cambio > 0.1m) // Un pequeño umbral para no mostrar verde por cambios mínimos
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
                var datos = new CN_Reporte().ObtenerClientesPorSegmento();
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de segmentos para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var model = new PlotModel
                {
                    Title = "Distribución de Clientes por Segmento",
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

        // ------------------- GRAFICO 2: GANANCIAS MENSUALES (Columnas Verticales) -------------------
        private void CargarGraficoGanancias_Oxy()
        {
            try
            {
                var datos = new CN_Reporte().ObtenerGananciasMensuales();
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de ganancias mensuales para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var model = new PlotModel
                {
                    Title = "Ganancias Mensuales",
                    TitleFontSize = 18,
                    Background = OxyColors.White,
                    Padding = new OxyThickness(60, 10, 20, 60)
                };

                // Eje Y: Categorías (Meses) - Lo ponemos vertical para simular columnas
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

                // Eje X: Valores (Ganancias) - Lo ponemos horizontal
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
                    FontSize = 12,
                    Angle = -45
                };
                model.Axes.Add(valueAxis);

                // Usamos BarSeries horizontal (compatible con todas las versiones)
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

        // ------------------- GRAFICO 3: VENTAS POR PRODUCTO (Barras Horizontales, Top 5) -------------------
        private void CargarGraficoVentasProducto_Oxy()
        {
            try
            {
                var datos = new CN_Reporte().ObtenerVentasPorProducto();
                if (datos == null || datos.Count == 0)
                {
                    MessageBox.Show("No hay datos de ventas por producto para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Top 5 ordenado descendente
                var top5 = datos.OrderByDescending(d => d.Value).Take(5).ToList();

                var model = new PlotModel
                {
                    Title = "Ventas por Producto (Top 5)",
                    TitleFontSize = 18,
                    Background = OxyColors.White,
                    Padding = new OxyThickness(120, 10, 60, 40)
                };

                // Eje Y: Categorías (Productos)
                var categoryAxis = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Producto",
                    TitleFontSize = 14,
                    FontSize = 12
                };

                // Invertir orden para que el mayor quede arriba
                foreach (var item in top5.AsEnumerable().Reverse())
                {
                    categoryAxis.Labels.Add(item.Key);
                }
                model.Axes.Add(categoryAxis);

                // Eje X: Valores (Total Vendido)
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

                // Serie de Barras Horizontales - Usando sintaxis compatible
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

                // Agregar items usando solo el valor (compatible con todas las versiones)
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
    }
}