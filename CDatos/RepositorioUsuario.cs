using System;
using System.Collections.Generic;
using System.Linq;
using CEntidades;

namespace CDatos
{
    public class RepositorioUsuario
    {
        public List<Usuario> ObtenerTodos()
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Usuario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios de la base de datos.", ex);
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Usuario.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por ID de la base de datos.", ex);
            }
        }

        public Usuario ObtenerPorUsername(string username)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Usuario.FirstOrDefault(u => u.Username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por nombre de usuario de la base de datos.", ex);
            }
        }

        public void Insertar(Usuario usuario)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario en la base de datos.", ex);
            }
        }

        public void Actualizar(Usuario usuario)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario en la base de datos.", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    var usuario = db.Usuario.Find(id);
                    if (usuario != null)
                    {
                        db.Usuario.Remove(usuario);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario de la base de datos.", ex);
            }
        }
    }
}
