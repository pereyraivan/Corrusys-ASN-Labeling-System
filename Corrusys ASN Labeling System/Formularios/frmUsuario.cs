using CEntidades;
using CEntidades.DTOs;
using CLogica;
using System;
using System.Windows.Forms;

namespace Corrusys_ASN_Labeling_System.Formularios
{
    public partial class frmUsuario : Form
    {
        private GestorUsuario gestorUsuario = new GestorUsuario();
        private Usuario usuarioEnEdicion = null;
        private Action actualizarGrilla;

        public frmUsuario(Action actualizarGrilla)
        {
            InitializeComponent();
            this.actualizarGrilla = actualizarGrilla;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioEnEdicion != null)
                {
                    EditarUsuario();
                }
                else
                {
                    GuardarUsuario();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarUsuario()
        {
            UsuarioDTO usuario = new UsuarioDTO
            {
                NombreCompleto = txtNombre.Text,
                Puesto = txtPuesto.Text,
                Usuario = txtUsuario.Text,
                Contraseña = txtContraseña.Text
            };

            gestorUsuario.GuardarDesdeFormulario(usuario);
            MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarGrilla?.Invoke();
        }

        private void Limpiar()
        {
            txtNombre.Text = "Nombre:";
            txtPuesto.Text = "Puesto:";
            txtUsuario.Text = "Usuario:";
            txtContraseña.Text = "Contraseña:";
            txtNombre.Focus();
            usuarioEnEdicion = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        public void CargarUsuarioParaEdicion(UsuarioDTO usuario)
        {
            usuarioEnEdicion = new Usuario
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                Rol = usuario.Puesto,
                Username = usuario.Usuario,
                PasswordHash = usuario.Contraseña
            };

            if (usuario != null)
            {
                txtNombre.Text = usuario.NombreCompleto;
                txtPuesto.Text = usuario.Puesto;
                txtUsuario.Text = usuario.Usuario;
                txtContraseña.Text = usuario.Contraseña;
            }
        }

        private void EditarUsuario()
        {
            var usuario = new UsuarioDTO
            {
                Id = usuarioEnEdicion.Id,
                NombreCompleto = txtNombre.Text,
                Puesto = txtPuesto.Text,
                Usuario = txtUsuario.Text,
                Contraseña = txtContraseña.Text
            };
          
            gestorUsuario.EditarDesdeFormulario(usuario);
            MessageBox.Show("Usuario editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarGrilla?.Invoke();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
