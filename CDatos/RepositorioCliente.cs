using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidades;
using System.Data.Entity;

namespace CDatos
{
    public class RepositorioCliente
    {
        public List<Cliente> ObtenerTodos()
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes de la base de datos.", ex);
            }
        }

        public Cliente ObtenerPorId(int id)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Cliente.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por ID de la base de datos.", ex);
            }
        }

        public Cliente ObtenerPorIdentificador(string identificador)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Cliente.FirstOrDefault(c => c.Identificador == identificador);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por identificador de la base de datos.", ex);
            }
        }

        public void Insertar(Cliente cliente)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el cliente en la base de datos.", ex);
            }
        }

        public void Actualizar(Cliente cliente)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente en la base de datos.", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    var cliente = db.Cliente.Find(id);
                    if (cliente != null)
                    {
                        db.Cliente.Remove(cliente);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente de la base de datos.", ex);
            }
        }

        public bool ExisteIdentificador(string identificador, int? idExcluir = null)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    if (idExcluir.HasValue)
                        return db.Cliente.Any(c => c.Identificador == identificador && c.Id != idExcluir.Value);
                    return db.Cliente.Any(c => c.Identificador == identificador);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del identificador en la base de datos.", ex);
            }
        }
    }
}
