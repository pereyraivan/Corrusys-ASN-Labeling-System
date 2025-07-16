using System;
using System.Collections.Generic;
using System.Linq;
using CEntidades;

namespace CDatos
{
    public class RepositorioASN
    {
        public List<ASN> ObtenerTodos()
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.ASN.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de ASN de la base de datos.", ex);
            }
        }

        public ASN ObtenerPorId(int id)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    return db.ASN.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ASN por ID de la base de datos.", ex);
            }
        }

        public void Insertar(ASN asn)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    db.ASN.Add(asn);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el ASN en la base de datos.", ex);
            }
        }

        public void Actualizar(ASN asn)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    db.Entry(asn).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el ASN en la base de datos.", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var db = new corrusys_asnEntities())
                {
                    var asn = db.ASN.Find(id);
                    if (asn != null)
                    {
                        db.ASN.Remove(asn);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el ASN de la base de datos.", ex);
            }
        }
    }
}
