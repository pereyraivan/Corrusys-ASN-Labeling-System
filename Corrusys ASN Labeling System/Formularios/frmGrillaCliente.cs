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
    public partial class frmGrillaCliente : Form
    {
        private GestorCliente gestor = new GestorCliente();
        public frmGrillaCliente()
        {
            InitializeComponent();
            EstiloGrilla();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var frm = new frmCliente(() => CargarClientes());
            frm.ShowDialog();
        }

        private void frmGrillaCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void EstiloGrilla()
        {

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ScrollBars = ScrollBars.Both;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Berlin Sans FB", 13F);
            dgvClientes.DefaultCellStyle.Font = new Font("Berlin Sans FB", 11F, FontStyle.Regular);
            dgvClientes.ColumnHeadersHeight = 35;
            dgvClientes.RowTemplate.Height = 28;
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        private void CargarClientes()
        {

            var lista = gestor.ObtenerTodosLosClientes();
            dgvClientes.DataSource = lista;
            if (dgvClientes.Columns["Editar"] == null)
            {
                var btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.DefaultCellStyle.BackColor = Color.LightGreen;
                btnEditar.DefaultCellStyle.SelectionBackColor = Color.Green;
                btnEditar.DefaultCellStyle.ForeColor = Color.Black;
                dgvClientes.Columns.Add(btnEditar);
            }
            if (dgvClientes.Columns["Eliminar"] == null)
            {
                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.DefaultCellStyle.BackColor = Color.LightCoral;
                btnEliminar.DefaultCellStyle.SelectionBackColor = Color.Red;
                btnEliminar.DefaultCellStyle.ForeColor = Color.Black;
                dgvClientes.Columns.Add(btnEliminar);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el click sea en una celda de botón
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = dgvClientes;
                if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    var clienteSeleccionado = dgv.Rows[e.RowIndex].DataBoundItem as ClienteDTO;
                    if (dgv.Columns[e.ColumnIndex].Name == "Editar")
                    {
                        // Abrir frmUsuario en modo edición
                        var frm = new frmCliente(() => CargarClientes());
                        frm.CargarClientesParaEdicion(clienteSeleccionado);
                        frm.ShowDialog();
                        // Recargar la grilla después de editar
                        CargarClientes();
                    }
                    else if (dgv.Columns[e.ColumnIndex].Name == "Eliminar")
                    {
                        var confirm = MessageBox.Show($"¿Está seguro que desea eliminar el cliente '{clienteSeleccionado.Nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm == DialogResult.Yes)
                        {
                            gestor.EliminarCliente(clienteSeleccionado.IdCliente);
                            MessageBox.Show("Usuario eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes();
                        }
                    }
                }
            }
        }
    }
}
