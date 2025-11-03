using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDeDatos;
using CapaDeNegocio;
using CapaDeEntidades;


namespace BeanDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // 1. Validar entradas vacías primero
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Debe ingresar su documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar su contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            // 2. Llamar al NUEVO método de validación
            // Ya no traemos la lista, solo enviamos los datos para que SQL compare.
            CN_Usuario cnUsuario = new CN_Usuario();
            Usuario ousuario = cnUsuario.ValidarUsuario(txtDocumento.Text, txtClave.Text);

            // 3. Comprobar el resultado
            if (ousuario != null)
            {
                // 4. (¡IMPORTANTE!) Verificar si el usuario está activo
                if (!ousuario.Estado)
                {
                    MessageBox.Show("Este usuario se encuentra desactivado. Contacte al administrador.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // 5. Si todo está bien, abrir el formulario principal
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();
                form.FormClosing += frm_clossing;
            }
            else
            {
                // Si ousuario es null, significa que el DNI o la clave (hasheada) no coincidieron
                MessageBox.Show("Documento o Contraseña Incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void frm_clossing(object? sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}