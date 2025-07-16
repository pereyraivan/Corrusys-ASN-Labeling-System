using CEntidades;
using CLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corrusys_ASN_Labeling_System.Formularios
{
    public partial class frmUsuario : Form
    {
        private GestorUsuario gestorUsuario = new GestorUsuario();
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
        }

        private void GuardarUsuario()
        {
            try
            {            
                gestorUsuario.GuardarDesdeFormulario(
                    txtNombre.Text,
                    txtPuesto.Text,
                    txtUsuario.Text,
                    txtContraseña.Text
                );

                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "Nombre:";
            txtPuesto.Text = "Puesto:";
            txtUsuario.Text = "Usuario:";
            txtContraseña.Text = "Contraseña:";
            txtNombre.Focus();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
