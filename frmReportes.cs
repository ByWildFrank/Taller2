using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;

namespace BeanDesktop
{
    public partial class FrmReportes : Form
    {
        string connectionString = Config.GetConnectionString();
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            CargarVentasPorProducto();
            CargarGananciasMes();
            CargarCantidadClientes();
            CargarUsuariosPorRol();
        }

        private void CargarVentasPorProducto()
        {
            string query = @"SELECT p.Nombre, SUM(dv.Cantidad) AS TotalVendido
                             FROM DETALLE_VENTA dv
                             INNER JOIN PRODUCTO p ON dv.IdProducto = p.IdProducto
                             GROUP BY p.Nombre";

            var nombres = new List<string>();
            var valores = new List<double>();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nombres.Add(dr["Nombre"].ToString());
                    valores.Add(Convert.ToDouble(dr["TotalVendido"]));
                }
            }

            var model = new PlotModel { Title = "Ventas por producto" };

            var series = new BarSeries
            {
                ItemsSource = valores.ConvertAll(v => new BarItem { Value = v }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };
            model.Series.Add(series);

            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = nombres
            });

            chartVentas.Model = model;
        }

        private void CargarGananciasMes()
        {
            string query = @"SELECT SUM((dv.PrecioVenta - p.PrecioFabricacion) * dv.Cantidad) AS GananciaMes
                             FROM DETALLE_VENTA dv
                             INNER JOIN PRODUCTO p ON dv.IdProducto = p.IdProducto
                             INNER JOIN VENTA v ON dv.IdVenta = v.IdVenta
                             WHERE MONTH(v.FechaRegistro) = MONTH(GETDATE())
                               AND YEAR(v.FechaRegistro) = YEAR(GETDATE())";

            double ganancia = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value) ganancia = Convert.ToDouble(result);
            }

            var model = new PlotModel { Title = "Ganancias del Mes" };
            var pie = new PieSeries();
            pie.Slices.Add(new PieSlice("Ganancia", ganancia));
            model.Series.Add(pie);

            chartGanancias.Model = model;
        }

        private void CargarCantidadClientes()
        {
            int total = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CLIENTE", con))
            {
                con.Open();
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }

            var model = new PlotModel { Title = "Cantidad de Clientes" };
            var pie = new PieSeries();
            pie.Slices.Add(new PieSlice("Clientes", total));
            model.Series.Add(pie);

            chartClientes.Model = model;
        }

        private void CargarUsuariosPorRol()
        {
            var roles = new List<string>();
            var valores = new List<double>();

            string query = @"SELECT r.Descripcion, COUNT(u.IdUsuario) AS Cantidad
                             FROM USUARIO u
                             INNER JOIN ROL r ON u.IdRol = r.IdRol
                             GROUP BY r.Descripcion";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    roles.Add(dr["Descripcion"].ToString());
                    valores.Add(Convert.ToDouble(dr["Cantidad"]));
                }
            }

            var model = new PlotModel { Title = "Usuarios por Rol" };

            var series = new BarSeries
            {
                ItemsSource = valores.ConvertAll(v => new BarItem { Value = v }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };
            model.Series.Add(series);

            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = roles
            });

            chartUsuarios.Model = model;
        }
    }
}
