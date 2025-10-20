using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanDesktop.CapaDeDatos;
using BeanDesktop.CapaDeEntidades;
using CapaDeEntidades;
using Microsoft.ML;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Clustering
    {
        private CD_Reporte objCD_Reporte = new CD_Reporte();

        public (ITransformer model, List<ClienteData> data) EntrenarModelo(int numeroDeClusters)
        {
            var mlContext = new MLContext(seed: 0);

            List<ClienteData> datosClientesOriginales = objCD_Reporte.ObtenerDatosParaClustering();

            // ✅ CAMBIO CLAVE: Filtramos los clientes que no tienen compras.
            // Un cliente sin compras tiene Frecuencia = 0.
            List<ClienteData> datosClientesActivos = datosClientesOriginales
                .Where(cliente => cliente.Frequency > 0)
                .ToList();

            // Si después de filtrar no quedan suficientes clientes para formar los clusters, avisamos.
            if (datosClientesActivos.Count < numeroDeClusters)
            {
                // Lanzamos una excepción con un mensaje claro que podemos capturar en el formulario.
                throw new Exception($"No hay suficientes clientes con compras ({datosClientesActivos.Count}) para formar {numeroDeClusters} clusters.");
            }

            var dataView = mlContext.Data.LoadFromEnumerable(datosClientesActivos);

            var pipeline = mlContext.Transforms
                .Concatenate("Features", "Recency", "Frequency", "Monetary", "AverageTicket", "ProductVariety")
                .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(mlContext.Clustering.Trainers.KMeans(
                    featureColumnName: "Features",
                    numberOfClusters: numeroDeClusters));

            var model = pipeline.Fit(dataView);

            // Devolvemos el modelo entrenado y la lista de datos que SÍ se usaron para entrenar.
            return (model, datosClientesActivos);
        }
    }
}