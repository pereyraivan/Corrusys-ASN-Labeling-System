using System;
using System.Windows.Forms;
using CLogica;
using CEntidades;

namespace Corrusys_ASN_Labeling_System.Formularios
{
    public partial class frmClientes : Form
    {
        private GestorCliente gestor;
        private Cliente clienteActual;

        public frmClientes()
        {
            InitializeComponent();
            gestor = new GestorCliente();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = gestor.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            clienteActual = null;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtIdentificador.Text = string.Empty;
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtIdentificador.Text))
                {
                    MessageBox.Show("Nombre e Identificador son campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cliente = clienteActual ?? new Cliente();
                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Direccion = txtDireccion.Text.Trim();
                cliente.Identificador = txtIdentificador.Text.Trim();

                gestor.GuardarCliente(cliente);
                MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarGrilla();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar eliminación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    gestor.EliminarCliente(clienteActual.Id);
                    MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clienteActual = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                txtNombre.Text = clienteActual.Nombre;
                txtDireccion.Text = clienteActual.Direccion;
                txtIdentificador.Text = clienteActual.Identificador;
            }
        }
    }
}
