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
    public partial class frmBackUp : Form
    {
        public frmBackUp()
        {
            InitializeComponent();
        }

        private void frmBackUp_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 246, 250);
        }

        // --- SECCIÓN 1: BACKUP NATIVO (.BAK) ---

        private async void btnCrearBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Archivos de Backup (*.bak)|*.bak",
                Title = "Guardar Copia de Seguridad Nativa",
                FileName = $"DB_BEAN03_{DateTime.Now:yyyyMMdd_HHmm}.bak"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveDialog.FileName;

                // Prepara la UI para la operación de backup
                PrepararUI(true, false); // Deshabilita el botón de script
                lblStatus.Text = "Creando copia de seguridad .bak...";
                progressBar.Value = 30; // Progreso inicial

                bool exito = false;
                string mensaje = "Ocurrió un error inesperado.";

                try
                {
                    // Ejecuta la tarea pesada en un hilo secundario
                    (exito, mensaje) = await Task.Run(() =>
                    {
                        var cnUtilidades = new CN_Utilidades();
                        bool resultado = cnUtilidades.CrearBackup(rutaArchivo, out string msg);
                        return (resultado, msg);
                    });
                }
                finally
                {
                    // Finaliza la operación y actualiza la UI
                    FinalizarOperacionBackup(exito, mensaje);
                }
            }
        }

        private void FinalizarOperacionBackup(bool exito, string mensaje)
        {
            progressBar.Value = 100;
            if (exito)
            {
                lblStatus.Text = "¡Copia .bak completada!";
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblStatus.Text = "Error al crear la copia .bak.";
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RestaurarUI();
        }


        // --- SECCIÓN 2: GENERACIÓN DE SCRIPT (.SQL) ---

        private async void btnGenerarScript_Click(object sender, EventArgs e)
        {
            // Prepara la UI para la generación del script
            PrepararUI(false, true); // Deshabilita el botón de backup
            lblStatus2.Text = "Generando script, por favor espere...";
            progressBar2.Value = 10; // Progreso inicial

            bool incluirDatos = radSchemaYDatos.Checked;
            string scriptGenerado = string.Empty;

            try
            {
                // Ejecuta la tarea pesada en un hilo secundario
                scriptGenerado = await Task.Run(() => new CN_Utilidades().GenerarScript(incluirDatos));
            }
            finally
            {
                // Finaliza la operación y actualiza la UI
                FinalizarOperacionScript(scriptGenerado);
            }
        }

        private void FinalizarOperacionScript(string script)
        {
            txtScriptSQL.Text = script;
            progressBar2.Value = 100;

            if (script.StartsWith("-- ERROR"))
            {
                lblStatus2.Text = "Error al generar el script.";
            }
            else
            {
                lblStatus2.Text = "Script generado con éxito.";
            }
            RestaurarUI();
        }

        private void btnCopiarScript_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtScriptSQL.Text) && !txtScriptSQL.Text.StartsWith("-- ERROR"))
            {
                Clipboard.SetText(txtScriptSQL.Text);
                lblStatus2.Text = "¡Script copiado al portapapeles!";
                lblStatus2.Visible = true; // Asegurarse de que sea visible
            }
        }


        // --- MÉTODOS AUXILIARES DE UI ---

        private void PrepararUI(bool deshabilitarBackup, bool deshabilitarScript)
        {
            // Limpia estados anteriores
            lblStatus.Visible = false;
            lblStatus2.Visible = false;
            progressBar.Visible = false;
            progressBar2.Visible = false;
            txtScriptSQL.Clear(); // Limpia el TextBox antes de una nueva generación

            // Configura para la operación actual
            if (deshabilitarBackup)
            {
                lblStatus.Visible = true;
                progressBar.Visible = true;
                progressBar.Value = 0;
            }
            if (deshabilitarScript)
            {
                lblStatus2.Visible = true;
                progressBar2.Visible = true;
                progressBar2.Value = 0;
            }

            btnCrearBackup.Enabled = !deshabilitarBackup;
            btnGenerarScript.Enabled = !deshabilitarScript;
        }

        private void RestaurarUI()
        {
            btnCrearBackup.Enabled = true;
            btnGenerarScript.Enabled = true;
        }
    }
}