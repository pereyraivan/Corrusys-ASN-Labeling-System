using CEntidades;
using CEntidades.DTOs;
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
    public partial class frmCliente : Form
    {
        private GestorCliente gestor = new GestorCliente();
        private Cliente clienteEnEdicion = null;
        private Action actualizarGrilla;
        public frmCliente(Action actualizarGrilla)
        {
            InitializeComponent();
            this.actualizarGrilla = actualizarGrilla;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            
        }
      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteEnEdicion != null)
                {
                    EditarCliente();
                }
                else
                {
                    GuardarCliente();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GuardarCliente()
        {
            ClienteDTO cliente = new ClienteDTO
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Identificador = txtIdentificador.Text,
            };

            gestor.GuardarCliente(cliente);
            MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarGrilla?.Invoke();
        }
        private void EditarCliente()
        {
            var cliete = new ClienteDTO
            {
                IdCliente = clienteEnEdicion.Id,
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Identificador = txtIdentificador.Text,
            };

            gestor.EditarDesdeFormulario(cliete);
            MessageBox.Show("Cliente editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarGrilla?.Invoke();
        }
        public void CargarClientesParaEdicion(ClienteDTO cliente)
        {
            clienteEnEdicion = new Cliente
            {
                Id = cliente.IdCliente,
                Direccion = cliente.Direccion,
                Identificador = cliente.Identificador,

            };

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtDireccion.Text = cliente.Direccion;
                txtIdentificador.Text = cliente.Identificador;
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "Nombre:";
            txtDireccion.Text = "Direccion:";
            txtIdentificador.Text = "Identificados:";
            txtNombre.Focus();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
