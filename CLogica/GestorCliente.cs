using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos;
using CEntidades;
using CEntidades.DTOs;

namespace CLogica
{
    public class GestorCliente
    {

        private const string MSG_NOMBRE_REQUERIDO = "Debe ingresar un nombre válido.";
        private const string MSG_DIRECCION_REQUERIDO = "Debe ingresar una direccion válida.";
        private const string MSG_IDENTIFICADOR_REQUERIDO = "Debe ingresar un identificador de usuario válido.";
        private const string MSG_CLIENTE_EXISTENTE = "Ya existe un usuario con estos datos.";
        private RepositorioCliente repositorio;

        public GestorCliente()
        {
            repositorio = new RepositorioCliente();
        }

        public List<ClienteDTO> ObtenerTodosLosClientes()
        {
            return repositorio.ObtenerTodos();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void EliminarCliente(int id)
        {
            repositorio.Eliminar(id);
        }

        public void GuardarCliente(ClienteDTO cliente)
        {
            ValidarUsuario(cliente);
            var usuario = MapearDTOaEntidad(cliente);
            repositorio.Insertar(usuario);
        }

        public void EditarDesdeFormulario(ClienteDTO cliente)
        {
            ValidarUsuario(cliente);
            var usuario = MapearDTOaEntidad(cliente);
            repositorio.Actualizar(usuario);
        }

        public Cliente BuscarPorIdentificador(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                throw new ArgumentException("El identificador es requerido para la búsqueda.");

            return repositorio.ObtenerPorIdentificador(identificador);
        }

        private Cliente MapearDTOaEntidad(ClienteDTO dto)
        {
            return new Cliente
            {
                Id = dto.IdCliente,
                Nombre = dto.Nombre.Trim(),
                Direccion = dto.Direccion.Trim(),
                Identificador = dto.Identificador.Trim(),
                
            };
        }
        private void ValidarUsuario(ClienteDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre) || dto.Nombre.Trim() == "Nombre:")
                throw new ArgumentException(MSG_NOMBRE_REQUERIDO);
            if (string.IsNullOrWhiteSpace(dto.Direccion) || dto.Direccion.Trim() == "Dirección:")
                throw new ArgumentException(MSG_DIRECCION_REQUERIDO);
            if (string.IsNullOrWhiteSpace(dto.Identificador) || dto.Identificador.Trim() == "Identificador:")
                throw new ArgumentException(MSG_IDENTIFICADOR_REQUERIDO);
            

            if (ExisteCliente(dto.Nombre, dto.Direccion, dto.Identificador, dto.IdCliente))
                throw new ArgumentException(MSG_CLIENTE_EXISTENTE);
        }

        public bool ExisteCliente(string nombre, string direccion, string identificador, int? idExcluir = null)
        {
            var cliente = repositorio.ObtenerTodos();
            return cliente.Any(u =>
                u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
                && u.Direccion.Equals(direccion, StringComparison.OrdinalIgnoreCase)
                && u.Identificador.Equals(identificador, StringComparison.OrdinalIgnoreCase)
                && (!idExcluir.HasValue || u.IdCliente != idExcluir.Value)
            );
        }

    }
}
