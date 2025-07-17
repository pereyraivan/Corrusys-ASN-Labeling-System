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
    public partial class frmGrillaASN : Form
    {
        private GestorASN gestor = new GestorASN();
        public frmGrillaASN()
        {
            InitializeComponent();
        }

        private void btnNuevoASN_Click(object sender, EventArgs e)
        {
            var frm = new frmASN(() => CargarASNs());
            frm.ShowDialog();
        }
        private void CargarASNs()
        {

            var lista = gestor.ObtenerTodos();
            dgvASN.DataSource = lista;
            if (dgvASN.Columns["Editar"] == null)
            {
                var btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.DefaultCellStyle.BackColor = Color.LightGreen;
                btnEditar.DefaultCellStyle.SelectionBackColor = Color.Green;
                btnEditar.DefaultCellStyle.ForeColor = Color.Black;
                dgvASN.Columns.Add(btnEditar);
            }
            if (dgvASN.Columns["Eliminar"] == null)
            {
                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.DefaultCellStyle.BackColor = Color.LightCoral;
                btnEliminar.DefaultCellStyle.SelectionBackColor = Color.Red;
                btnEliminar.DefaultCellStyle.ForeColor = Color.Black;
                dgvASN.Columns.Add(btnEliminar);
            }
        }

        private void frmGrillaASN_Load(object sender, EventArgs e)
        {

        }
    }
}
