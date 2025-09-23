using BeanDesktop.CapaDeNegocio;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmCategoria : Form
    {
        private CN_Categoria cnCategoria = new CN_Categoria();
        private int idCategoriaSeleccionada = 0;

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            this.BackColor = Color.LightGray;
            this.Refresh(); // fuerza el redibujado
        }

        private void ListarCategorias()
        {
            dgvCategorias.DataSource = cnCategoria.Listar().Select(c => new
            {
                c.IdCategoria,
                c.Descripcion,
                Estado = c.Estado ? "Activo" : "Inactivo",
                c.FechaRegistro
            }).ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria oCategoria = new Categoria
            {
                IdCategoria = idCategoriaSeleccionada,
                Descripcion = txtDescripcion.Text.Trim(),
                Estado = chkEstado.Checked,
                FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            string mensaje = cnCategoria.Guardar(oCategoria);
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            ListarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una categoría para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string mensaje = cnCategoria.Eliminar(idCategoriaSeleccionada);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                ListarCategorias();
            }
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idCategoriaSeleccionada = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["IdCategoria"].Value);
                txtDescripcion.Text = dgvCategorias.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                chkEstado.Checked = dgvCategorias.Rows[e.RowIndex].Cells["Estado"].Value.ToString() == "Activo";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idCategoriaSeleccionada = 0;
            txtDescripcion.Clear();
            chkEstado.Checked = true;
        }
    }
}
