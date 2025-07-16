using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos;
using CEntidades;

namespace CLogica
{
    public class GestorCliente
    {
        private RepositorioCliente repositorio;

        public GestorCliente()
        {
            repositorio = new RepositorioCliente();
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return repositorio.ObtenerTodos();
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void GuardarCliente(Cliente cliente)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es requerido.");

            if (string.IsNullOrWhiteSpace(cliente.Identificador))
                throw new ArgumentException("El identificador del cliente es requerido.");

            // Validar que el identificador no esté duplicado
            if (repositorio.ExisteIdentificador(cliente.Identificador, cliente.Id))
                throw new ArgumentException("Ya existe un cliente con el mismo identificador.");

            if (cliente.Id == 0)
                repositorio.Insertar(cliente);
            else
                repositorio.Actualizar(cliente);
        }

        public void EliminarCliente(int id)
        {
            var cliente = repositorio.ObtenerPorId(id);
            if (cliente == null)
                throw new ArgumentException("Cliente no encontrado.");

            // Verificar si el cliente tiene ASNs asociados
            if (cliente.ASN.Any())
                throw new InvalidOperationException("No se puede eliminar el cliente porque tiene ASNs asociados.");

            repositorio.Eliminar(id);
        }

        public Cliente BuscarPorIdentificador(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                throw new ArgumentException("El identificador es requerido para la búsqueda.");

            return repositorio.ObtenerPorIdentificador(identificador);
        }
    }
}
