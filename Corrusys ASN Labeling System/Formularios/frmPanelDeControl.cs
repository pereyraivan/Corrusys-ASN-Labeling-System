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
    public partial class frmPanelDeControl : Form
    {
        public frmPanelDeControl()
        {
            InitializeComponent();
        }

        private void frmPanelDeControl_Load_1(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Cerrar y limpiar formularios previos
            foreach (Control ctrl in panelContenedor.Controls)
            {
                if (ctrl is Form f)
                {
                    f.Close();
                }
            }
            panelContenedor.Controls.Clear();

            // Crear e incrustar el formulario de usuario
            var frm = new frmGrillaUsuario();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            // Cerrar y limpiar formularios previos
            foreach (Control ctrl in panelContenedor.Controls)
            {
                if (ctrl is Form f)
                {
                    f.Close();
                }
            }
            panelContenedor.Controls.Clear();

            // Crear e incrustar el formulario de usuario
            var frm = new frmGrillaPanel();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void btnASN_Click(object sender, EventArgs e)
        {
            // Cerrar y limpiar formularios previos
            foreach (Control ctrl in panelContenedor.Controls)
            {
                if (ctrl is Form f)
                {
                    f.Close();
                }
            }
            panelContenedor.Controls.Clear();

            // Crear e incrustar el formulario de usuario
            var frm = new frmASNEnviados();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            // Cerrar y limpiar formularios previos
            foreach (Control ctrl in panelContenedor.Controls)
            {
                if (ctrl is Form f)
                {
                    f.Close();
                }
            }
            panelContenedor.Controls.Clear();

            // Crear e incrustar el formulario de usuario
            var frm = new frmConfigurarEmpresa();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {

        }
    }
}

