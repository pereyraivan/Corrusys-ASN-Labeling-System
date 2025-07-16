using CEntidades;
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
    public partial class frmCliente : Form
    {
        private CLogica.GestorCliente gestor = new CLogica.GestorCliente();
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void GuardarCliente()
        {
            // Validar que los campos no tengan los textos por defecto ni estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text.Trim() == "Nombre:")
            {
                MessageBox.Show("Debe ingresar un nombre válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text) || txtDireccion.Text.Trim() == "Direccion:")
            {
                MessageBox.Show("Debe ingresar una dirección válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtIdentificador.Text) || txtIdentificador.Text.Trim() == "Identificados:")
            {
                MessageBox.Show("Debe ingresar un identificador válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cliente = new CEntidades.Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Identificador = txtIdentificador.Text.Trim()
                };
                gestor.GuardarCliente(cliente);
                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "Nombre:";
            txtDireccion.Text = "Direccion:";
            txtIdentificador.Text = "Identificados:";
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCliente();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
