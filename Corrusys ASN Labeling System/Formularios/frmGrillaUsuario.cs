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
    public partial class frmGrillaUsuario : Form
    {
        GestorUsuario gestor = new GestorUsuario();
        public frmGrillaUsuario()
        {
            InitializeComponent();
            // Estilos para el DataGridView
            EstiloGrilla();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el click sea en una celda de botón
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = dgvUsuarios;
                if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    var usuarioSeleccionado = dgv.Rows[e.RowIndex].DataBoundItem as UsuarioDTO;
                    if (dgv.Columns[e.ColumnIndex].Name == "Editar")
                    {
                        // Abrir frmUsuario en modo edición
                        var frm = new frmUsuario(() => CargarUsuarios());
                        frm.CargarUsuarioParaEdicion(usuarioSeleccionado);
                        frm.ShowDialog();
                        // Recargar la grilla después de editar
                        CargarUsuarios();
                    }
                    else if (dgv.Columns[e.ColumnIndex].Name == "Eliminar")
                    {
                        var confirm = MessageBox.Show($"¿Está seguro que desea eliminar el usuario '{usuarioSeleccionado.NombreCompleto}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirm == DialogResult.Yes)
                        {             
                            gestor.Eliminar(usuarioSeleccionado.Id);
                            MessageBox.Show("Usuario eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarUsuarios();
                        }
                    }
                }
            }
        }

        private void frmGrillaUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {

            var lista = gestor.ObtenerTodos();
            dgvUsuarios.DataSource = lista;
            if (dgvUsuarios.Columns["Editar"] == null)
            {
                var btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.DefaultCellStyle.BackColor = Color.LightGreen;
                btnEditar.DefaultCellStyle.SelectionBackColor = Color.Green;
                btnEditar.DefaultCellStyle.ForeColor = Color.Black;
                dgvUsuarios.Columns.Add(btnEditar);
            }
            if (dgvUsuarios.Columns["Eliminar"] == null)
            {
                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.DefaultCellStyle.BackColor = Color.LightCoral;
                btnEliminar.DefaultCellStyle.SelectionBackColor = Color.Red;
                btnEliminar.DefaultCellStyle.ForeColor = Color.Black;
                dgvUsuarios.Columns.Add(btnEliminar);
            }
        }

        private void frmGrillaUsuario_Load_1(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var frm = new frmUsuario(() => CargarUsuarios());
            frm.ShowDialog();
        }
        private void EstiloGrilla()
        {

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ScrollBars = ScrollBars.Both;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Berlin Sans FB", 13F);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Berlin Sans FB", 11F, FontStyle.Regular);
            dgvUsuarios.ColumnHeadersHeight = 35;
            dgvUsuarios.RowTemplate.Height = 28;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
    }
}

