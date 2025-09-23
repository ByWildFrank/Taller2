using BeanDesktop.CapaDeNegocio;
using BeanDesktop.Utilidades;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BeanDesktop
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            // Cargar combo Estado
            cboEstado.Items.Clear();
            cboEstado.Items.Add(new OpcionCombo() { Valor = true, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = false, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            // Cargar columnas para búsqueda
            foreach (DataGridViewColumn columna in dgvClientes.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            // Cargar clientes
            List<Cliente> listaClientes = new CN_Cliente().Listar();
            foreach (Cliente item in listaClientes)
            {
                dgvClientes.Rows.Add(new object[]
                {
            "",
            item.IdCliente,
            item.Documento,
            item.NombreCompleto,
            item.Correo,
            item.Telefono,
            item.Estado,
            item.Estado == true ? "Activo" : "No Activo"
                });
            }
            this.BackColor = Color.LightGray;
            this.Refresh(); // fuerza el redibujado
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Cliente objCliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtid.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1
            };

            if (objCliente.IdCliente == 0)
            {
                int idClienteGenerado = new CN_Cliente().Registrar(objCliente, out mensaje);

                if (idClienteGenerado != 0)
                {
                    dgvClientes.Rows.Add(new object[]
                    {
                        "",
                        idClienteGenerado,
                        objCliente.Documento,
                        objCliente.NombreCompleto,
                        objCliente.Correo,
                        objCliente.Telefono,
                        objCliente.Estado,
                        objCliente.Estado ? "Activo" : "No Activo"
                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                bool resultado = new CN_Cliente().Editar(objCliente, out mensaje);
                if (resultado)
                {
                    int indice = Convert.ToInt32(txtindice.Text);
                    dgvClientes.Rows[indice].Cells["Documento"].Value = objCliente.Documento;
                    dgvClientes.Rows[indice].Cells["NombreCompleto"].Value = objCliente.NombreCompleto;
                    dgvClientes.Rows[indice].Cells["Correo"].Value = objCliente.Correo;
                    dgvClientes.Rows[indice].Cells["Telefono"].Value = objCliente.Telefono;
                    dgvClientes.Rows[indice].Cells["EstadoValor"].Value = objCliente.Estado;
                    dgvClientes.Rows[indice].Cells["Estado"].Value = objCliente.Estado ? "Activo" : "No Activo";
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente objCliente = new Cliente() { IdCliente = Convert.ToInt32(txtid.Text) };
                    bool respuesta = new CN_Cliente().Eliminar(objCliente, out mensaje);

                    if (respuesta)
                    {
                        dgvClientes.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvClientes.Rows[indice].Cells["IdCliente"].Value.ToString();
                    txtDocumento.Text = dgvClientes.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvClientes.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvClientes.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvClientes.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToBoolean(oc.Valor) == Convert.ToBoolean(dgvClientes.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            cboEstado.SelectedIndex = cboEstado.Items.IndexOf(oc);
                            break;
                        }
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvClientes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    row.Visible = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper());
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.Visible = true;
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cboEstado.SelectedIndex = 0; // Seguro porque ya tiene items
        }

    }
}
