using BeanDesktop.CapaDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmDescuentos : Form
    {
        private CN_Utilidades cnUtilidades = new CN_Utilidades();

        public frmDescuentos()
        {
            InitializeComponent();
        }

        private void frmDescuentos_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 246, 250);
            txtSegmento.ReadOnly = true;

            // Configurar NumericUpDown
            numDescuento.Minimum = 0;
            numDescuento.Maximum = 50;
            numDescuento.DecimalPlaces = 2;

            dgvSegmentos.AutoGenerateColumns = true;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                dgvSegmentos.DataSource = cnUtilidades.ListarSegmentosConfig();
                dgvSegmentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSegmentos.ReadOnly = true;
                dgvSegmentos.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSegmentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvSegmentos.Rows[e.RowIndex];

                // --- Verificación de Nulos ---

                // 1. Validar la celda "Segmento"
                if (fila.Cells["Segmento"].Value != null)
                {
                    txtSegmento.Text = fila.Cells["Segmento"].Value.ToString();
                }
                else
                {
                    txtSegmento.Text = ""; // Poner en blanco si es nulo
                }

                // 2. Validar la celda "DescuentoPorcent"
                if (fila.Cells["DescuentoPorcent"].Value != null && fila.Cells["DescuentoPorcent"].Value != DBNull.Value)
                {
                    numDescuento.Value = Convert.ToDecimal(fila.Cells["DescuentoPorcent"].Value);
                }
                else
                {
                    numDescuento.Value = 0; // Poner 0 si es nulo
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSegmento.Text))
            {
                MessageBox.Show("Seleccione un segmento de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string segmento = txtSegmento.Text;
            decimal descuento = numDescuento.Value;

            // --- INICIO DE LA CORRECCIÓN ---

            string mensaje = string.Empty; // 1. Definimos la variable para el mensaje

            // 2. Llamamos al método actualizado que devuelve un 'out string mensaje'
            bool resultado = cnUtilidades.ActualizarSegmentoConfig(segmento, descuento, out mensaje);

            if (resultado)
            {
                MessageBox.Show("Descuento actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
            }
            else
            {
                // 3. Mostramos el mensaje de error específico que vino de la BD o la Capa de Negocio
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // --- FIN DE LA CORRECCIÓN ---
        }
    }
}
