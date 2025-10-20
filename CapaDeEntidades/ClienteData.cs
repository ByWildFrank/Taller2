using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeEntidades
{
    public class ClienteData
    {
        [LoadColumn(0)] public float IdCliente { get; set; }
        [LoadColumn(1)] public string NombreCompleto { get; set; }
        [LoadColumn(2)] public float Recency { get; set; }
        [LoadColumn(3)] public float Frequency { get; set; }
        [LoadColumn(4)] public float Monetary { get; set; }
        [LoadColumn(5)] public float AverageTicket { get; set; }
        [LoadColumn(6)] public float ProductVariety { get; set; }
    }
}
