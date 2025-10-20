using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeEntidades
{
    public class ClientePrediction
    {
        // ML.NET genera estas columnas por defecto.
        // PredictedLabel es el ID del cluster al que pertenece el cliente.
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId { get; set; }

        // Distances contiene las distancias del punto a cada centro de cluster.
        [ColumnName("Score")]
        public float[] Distances { get; set; }
    }
}
