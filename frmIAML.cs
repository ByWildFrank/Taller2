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

namespace BeanDesktop
{
    public partial class frmIAML : Form
    {
        public frmIAML()
        {
            InitializeComponent();
        }

        private void frmIAML_Load(object sender, EventArgs e)
        {
            MostrarSegmentacionClientes();
            MostrarTopProductos();

            this.BackColor = Color.LightGray;
            this.Refresh(); // fuerza el redibujado
        }

        private void MostrarSegmentacionClientes()
        {
            var model = new PlotModel { Title = "Segmentación de Clientes" };

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            // Datos simulados
            pieSeries.Slices.Add(new PieSlice("Segmento A", 40) { Fill = OxyColors.SkyBlue });
            pieSeries.Slices.Add(new PieSlice("Segmento B", 25) { Fill = OxyColors.Orange });
            pieSeries.Slices.Add(new PieSlice("Segmento C", 20) { Fill = OxyColors.LightGreen });
            pieSeries.Slices.Add(new PieSlice("Segmento D", 15) { Fill = OxyColors.MediumPurple });

            model.Series.Add(pieSeries);
            plotViewSegmentacion.Model = model;
        }

        private void MostrarTopProductos()
        {
            var model = new PlotModel { Title = "Top 5 Productos de Cafetería" };

            // Eje Y (categorías)
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "ProductosAxis"
            };
            categoryAxis.Labels.Add("Café Latte");
            categoryAxis.Labels.Add("Capuccino");
            categoryAxis.Labels.Add("Tostado");
            categoryAxis.Labels.Add("Medialunas");
            categoryAxis.Labels.Add("Frapuccino");

            // Eje X (valores)
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MinimumPadding = 0,
                AbsoluteMinimum = 0,
                Title = "Cantidad Vendida"
            };

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            // Serie de barras
            var barSeries = new BarSeries
            {
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };

            // Valores simulados
            barSeries.Items.Add(new BarItem { Value = 120 });
            barSeries.Items.Add(new BarItem { Value = 95 });
            barSeries.Items.Add(new BarItem { Value = 80 });
            barSeries.Items.Add(new BarItem { Value = 75 });
            barSeries.Items.Add(new BarItem { Value = 60 });

            model.Series.Add(barSeries);
            plotViewRecomendacion.Model = model;
        }
    }
}