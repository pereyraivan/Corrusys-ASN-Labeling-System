using System;
using System.Collections.Generic;
using System.Linq;
using CEntidades;
using CEntidades.DTOs;

namespace CDatos
{
    public class RepositorioUsuario
    {
        public List<UsuarioDTO> ObtenerTodos()
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.Usuario
                        .Select(u => new UsuarioDTO
                        {
                            Id = u.Id,
                            NombreCompleto = u.NombreCompleto,
                            Usuario = u.Username,
                            Puesto = u.Rol,
                            Contraseña = u.PasswordHash
                        })
                        .ToList();
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
                    var usuario = db.Usuario.Find(id);
                    if (usuario == null)
                        throw new InvalidOperationException($"No se encontró el usuario con ID {id}");
                    return usuario;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el usuario con ID {id} de la base de datos.", ex);
            }
        }

        public Usuario ObtenerPorUsername(string username)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    var usuario = db.Usuario.FirstOrDefault(u => u.Username == username);
                    if (usuario == null)
                        throw new InvalidOperationException($"No se encontró el usuario con nombre de usuario {username}");
                    return usuario;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el usuario por nombre de usuario de la base de datos.", ex);
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
                    var usuarioDb = db.Usuario.Find(usuario.Id);
                    if (usuarioDb == null)
                        throw new InvalidOperationException($"No se encontró el usuario con ID {usuario.Id} para actualizar");

                    usuarioDb.NombreCompleto = usuario.NombreCompleto;
                    usuarioDb.Rol = usuario.Rol;
                    usuarioDb.Username = usuario.Username;
                    usuarioDb.PasswordHash = usuario.PasswordHash;
                    usuarioDb.Activo = usuario.Activo;

                    db.SaveChanges();
                }
            }
            catch (InvalidOperationException)
            {
                throw;
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
                    if (usuario == null)
                        throw new InvalidOperationException($"No se encontró el usuario con ID {id} para eliminar");

                    db.Usuario.Remove(usuario);
                    db.SaveChanges();
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario de la base de datos.", ex);
            }
        }
    }
}
