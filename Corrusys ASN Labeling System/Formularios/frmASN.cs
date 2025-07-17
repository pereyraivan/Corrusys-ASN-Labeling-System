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
    public partial class frmASN : Form
    {
        private GestorASN gestor = new GestorASN();
        private ASN ASNEnEdicion = null;
        private Action actualizarGrilla;
        public frmASN(Action actualizarGrilla)
        {
            InitializeComponent();
            this.actualizarGrilla = actualizarGrilla;
        }

        private void lblFechaEstimada_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            int radius = Math.Min(label.Width, label.Height) - 2;
            var rect = new Rectangle(1, 1, label.Width - 2, label.Height - 2);

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(rect);
                // Fondo blanco
                using (var brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, path);
                }
                // Borde negro
                using (var pen = new Pen(Color.Black, 3))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Texto centrado
            TextRenderer.DrawText(
                e.Graphics,
                label.Text,
                label.Font,
                rect,
                label.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void lblFechaEnvio_Paint(object sender, PaintEventArgs e)
        {
            var label = sender as Label;
            int radius = Math.Min(label.Width, label.Height) - 2;
            var rect = new Rectangle(1, 1, label.Width - 2, label.Height - 2);

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(rect);
                // Fondo blanco
                using (var brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, path);
                }
                // Borde negro
                using (var pen = new Pen(Color.Black, 3))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // Texto centrado
            TextRenderer.DrawText(
                e.Graphics,
                label.Text,
                label.Font,
                rect,
                label.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void frmASN_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ASNEnEdicion != null)
                {
                    //EditarASN();
                }
                else
                {
                    GuardarASN();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarASN()
        {
            try
            {
                var gestor = new CLogica.GestorASN();
                var asn = new CEntidades.ASN
                {
                    // Asigna aquí los valores desde los controles del formulario
                    // Ejemplo:
                    // Cantidad = int.Parse(txtCantidad.Text),
                    // Peso = decimal.Parse(txtPeso.Text),
                    // Lote = txtLote.Text.Trim(),
                    // FechaEnvio = dtpFechaEnvio.Value,
                    // NumeroSerie = txtNumeroSerie.Text.Trim(),
                    // NumeroFactura = txtNumeroFactura.Text.Trim(),
                    // DescripcionProducto = txtDescripcion.Text.Trim(),
                    // ClienteId = (int)cmbCliente.SelectedValue,
                    // EmpresaId = (int)cmbEmpresa.SelectedValue,
                    // UsuarioId = usuarioActual.Id
                };
                gestor.Guardar(asn);
                MessageBox.Show("ASN guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes limpiar el formulario o recargar la grilla si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el ASN: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

    }
}
