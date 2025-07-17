using System;
using System.Collections.Generic;
using System.Linq;
using CDatos;
using CEntidades;
using CEntidades.DTOs;

namespace CLogica
{
    public class GestorUsuario
    {
        private RepositorioUsuario repositorio;
        private const string MSG_NOMBRE_REQUERIDO = "Debe ingresar un nombre válido.";
        private const string MSG_PUESTO_REQUERIDO = "Debe ingresar un puesto válido.";
        private const string MSG_USUARIO_REQUERIDO = "Debe ingresar un nombre de usuario válido.";
        private const string MSG_CONTRASEÑA_REQUERIDA = "Debe ingresar una contraseña válida.";
        private const string MSG_USUARIO_EXISTENTE = "Ya existe un usuario con estos datos.";

        public GestorUsuario()
        {
            repositorio = new RepositorioUsuario();
        }

        public List<UsuarioDTO> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }

        public Usuario ObtenerPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void Eliminar(int id)
        {
            repositorio.Eliminar(id);
        }

        public Usuario BuscarPorUsername(string username)
        {
            return repositorio.ObtenerPorUsername(username);
        }

        public bool ExisteUsuario(string nombreCompleto, string rol, string username, int? idExcluir = null)
        {
            var usuarios = repositorio.ObtenerTodos();
            return usuarios.Any(u =>
                u.NombreCompleto.Equals(nombreCompleto, StringComparison.OrdinalIgnoreCase)
                && u.Puesto.Equals(rol, StringComparison.OrdinalIgnoreCase)
                && u.Usuario.Equals(username, StringComparison.OrdinalIgnoreCase)
                && (!idExcluir.HasValue || u.Id != idExcluir.Value)
            );
        }

        public void GuardarDesdeFormulario(UsuarioDTO dto)
        {
            ValidarUsuario(dto);
            var usuario = MapearDTOaEntidad(dto);
            repositorio.Insertar(usuario);
        }

        public void EditarDesdeFormulario(UsuarioDTO dto)
        {
            ValidarUsuario(dto);
            var usuario = MapearDTOaEntidad(dto);
            repositorio.Actualizar(usuario);
        }

        private void ValidarUsuario(UsuarioDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NombreCompleto) || dto.NombreCompleto.Trim() == "Nombre:")
                throw new ArgumentException(MSG_NOMBRE_REQUERIDO);
            if (string.IsNullOrWhiteSpace(dto.Puesto) || dto.Puesto.Trim() == "Puesto:")
                throw new ArgumentException(MSG_PUESTO_REQUERIDO);
            if (string.IsNullOrWhiteSpace(dto.Usuario) || dto.Usuario.Trim() == "Usuario:")
                throw new ArgumentException(MSG_USUARIO_REQUERIDO);
            if (string.IsNullOrWhiteSpace(dto.Contraseña) || dto.Contraseña.Trim() == "Contraseña:")
                throw new ArgumentException(MSG_CONTRASEÑA_REQUERIDA);
            
            if (ExisteUsuario(dto.NombreCompleto, dto.Puesto, dto.Usuario, dto.Id))
                throw new ArgumentException(MSG_USUARIO_EXISTENTE);
        }
        
        private Usuario MapearDTOaEntidad(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                NombreCompleto = dto.NombreCompleto.Trim(),
                Rol = dto.Puesto.Trim(),
                Username = dto.Usuario.Trim(),
                PasswordHash = dto.Contraseña.Trim(),
                Activo = true
            };
        }
    }
}
