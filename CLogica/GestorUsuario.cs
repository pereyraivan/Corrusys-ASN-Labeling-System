using System;
using System.Collections.Generic;
using System.Linq;
using CDatos;
using CEntidades;

namespace CLogica
{
    public class GestorUsuario
    {
        private RepositorioUsuario repositorio;

        public GestorUsuario()
        {
            repositorio = new RepositorioUsuario();
        }

        public List<Usuario> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }

        public Usuario ObtenerPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void Guardar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Username))
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.PasswordHash))
                throw new ArgumentException("La contraseña es obligatoria.");
            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
                throw new ArgumentException("El nombre completo es obligatorio.");
            if (string.IsNullOrWhiteSpace(usuario.Rol))
                usuario.Rol = "Administrador";
            if (usuario.Id == 0)
                repositorio.Insertar(usuario);
            else
                repositorio.Actualizar(usuario);
        }

        public void Eliminar(int id)
        {
            repositorio.Eliminar(id);
        }

        public Usuario BuscarPorUsername(string username)
        {
            return repositorio.ObtenerPorUsername(username);
        }

        // Nuevo método para validar existencia por nombre, puesto y nombre de usuario
        public bool ExisteUsuario(string nombreCompleto, string rol, string username, int? idExcluir = null)
        {
            var usuarios = repositorio.ObtenerTodos();
            return usuarios.Any(u =>
                u.NombreCompleto.Equals(nombreCompleto, StringComparison.OrdinalIgnoreCase)
                && u.Rol.Equals(rol, StringComparison.OrdinalIgnoreCase)
                && u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                && (!idExcluir.HasValue || u.Id != idExcluir.Value)
            );
        }

        public void GuardarDesdeFormulario(string nombre, string puesto, string usuario, string contrasena)
        {
            // Validar que los campos no tengan los textos por defecto ni estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim() == "Nombre:")
                throw new ArgumentException("Debe ingresar un nombre válido.");
            if (string.IsNullOrWhiteSpace(puesto) || puesto.Trim() == "Puesto:")
                throw new ArgumentException("Debe ingresar un puesto válido.");
            if (string.IsNullOrWhiteSpace(usuario) || usuario.Trim() == "Usuario:")
                throw new ArgumentException("Debe ingresar un nombre de usuario válido.");
            if (string.IsNullOrWhiteSpace(contrasena) || contrasena.Trim() == "Contraseña:")
                throw new ArgumentException("Debe ingresar una contraseña válida.");

            var nuevoUsuario = new Usuario
            {
                NombreCompleto = nombre.Trim(),
                Rol = puesto.Trim(),
                Username = usuario.Trim(),
                PasswordHash = contrasena.Trim(),
                Activo = true
            };

            Guardar(nuevoUsuario);
        }
    }
}
