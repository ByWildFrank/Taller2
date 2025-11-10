using BeanDesktop.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeEntidades;
using BeanDesktop.CapaDeNegocio;
using System.Drawing.Text;
using CapaDeNegocio;
using System.Text.RegularExpressions;


namespace BeanDesktop
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (Rol item in listaRol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;


            // --- Carga de Datos ---
            dgvdata.Rows.Clear(); // Limpiamos por si acaso
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            foreach (Usuario item in listaUsuarios)
            {
                dgvdata.Rows.Add(new object[]
                {
            "",
            item.IdUsuario,
            item.Documento,
            item.NombreCompleto,
            item.Correo,
            item.Clave,
            item.oRol.IdRol,
            item.oRol.Descripcion,
            item.Estado, // Esta es la columna 'EstadoValor'
            item.Estado == true ? "Activo" : "No Activo" // Esta es la columna 'Estado'
                });
            }

            // ✅ CAMBIO CLAVE: Ocultar los 'No Activos' por defecto
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                // Asumimos que la columna "EstadoValor" (la que tiene el 0 o 1) se llama 'EstadoValor'
                // Si se llama 'Estado' en la grilla, usa row.Cells["Estado"].Value
                if (row.Cells["EstadoValor"].Value != null && Convert.ToBoolean(row.Cells["EstadoValor"].Value) == false)
                {
                    row.Visible = false;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            // --- VALIDACIONES DEL FORMULARIO ---

            // 1. Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que las contraseñas coincidan
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarClave.Focus();
                return;
            }

            // 3. Validar formato de Email
            if (!IsValidEmail(txtCorreo.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido. (ej: usuario@dominio.com)", "Error de Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return;
            }
            int idUsuario = Convert.ToInt32(txtid.Text);
            if (idUsuario != 0 && string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña para el nuevo usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si estamos CREANDO (IdUsuario == 0) el campo clave NO puede estar vacío
            if (idUsuario == 0 && string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña para el nuevo usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Si todas las validaciones pasan, creamos el objeto ---
            bool estadoSeleccionado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1;

            Usuario objUsusario = new Usuario()
            {
                IdUsuario = idUsuario,
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                Estado = estadoSeleccionado // Asignamos el bool
            };

            if (objUsusario.IdUsuario == 0) // --- REGISTRAR ---
            {
                int idUsuarioGenerado = new CN_Usuario().Registrar(objUsusario, out mensaje);

                if (idUsuarioGenerado != 0)
                {
                    // ✅ CORRECCIÓN: Pasamos el booleano 'estadoSeleccionado' a la grilla
                    dgvdata.Rows.Add(new object[]
                    {
                "",
                idUsuarioGenerado,
                txtDocumento.Text,
                txtNombreCompleto.Text,
                txtCorreo.Text,
                txtClave.Text,
                ((OpcionCombo)cboRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(),
                estadoSeleccionado, // <-- AQUÍ (en lugar de .Valor.ToString())
                ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString()
                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error al Registrar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else // --- EDITAR ---
            {
                bool resultado = new CN_Usuario().Editar(objUsusario, out mensaje);
                if (resultado)
                {
                    int indice = Convert.ToInt32(txtindice.Text);
                    dgvdata.Rows[indice].Cells["Documento"].Value = txtDocumento.Text;
                    dgvdata.Rows[indice].Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    dgvdata.Rows[indice].Cells["Correo"].Value = txtCorreo.Text;
                    dgvdata.Rows[indice].Cells["Clave"].Value = txtClave.Text;
                    dgvdata.Rows[indice].Cells["IdRol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                    dgvdata.Rows[indice].Cells["Rol"].Value = ((OpcionCombo)cboRol.SelectedItem).Texto.ToString();

                    // ✅ CORRECCIÓN: Pasamos el booleano 'estadoSeleccionado' a la grilla
                    dgvdata.Rows[indice].Cells["EstadoValor"].Value = estadoSeleccionado; // <-- AQUÍ
                    dgvdata.Rows[indice].Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    // ✅ CAMBIO: Dejar los campos de clave vacíos
                    txtClave.Text = "";
                    txtConfirmarClave.Text = "";

                    foreach (OpcionCombo oc in cboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea desactivar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objUsuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new CN_Usuario().Eliminar(objUsuario, out mensaje);

                    if (respuesta)
                    {
                        int indice = Convert.ToInt32(txtindice.Text);
                        if (indice >= 0)
                        {
                            dgvdata.Rows[indice].Cells["EstadoValor"].Value = 0;
                            dgvdata.Rows[indice].Cells["Estado"].Value = "No Activo";
                        }
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value == null) continue;

                    bool estaActivo = false;
                    if (row.Cells["EstadoValor"].Value is bool)
                    {
                        estaActivo = (bool)row.Cells["EstadoValor"].Value;
                    }
                    else if (row.Cells["EstadoValor"].Value != null)
                    {
                        // Intenta convertir desde un string "1" o "0" (por si acaso)
                        estaActivo = row.Cells["EstadoValor"].Value.ToString() == "1" ||
                                     row.Cells["EstadoValor"].Value.ToString().ToUpper() == "TRUE";
                    }

                    bool coincideTexto = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textoBusqueda);

                    if (string.IsNullOrEmpty(textoBusqueda))
                    {
                        // Si la búsqueda está vacía, solo mostrar activos
                        row.Visible = estaActivo;
                    }
                    else
                    {
                        // Si hay búsqueda, mostrar si coincide
                        row.Visible = coincideTexto;
                    }
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
