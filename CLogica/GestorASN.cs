using System;
using System.Collections.Generic;
using CDatos;
using CEntidades;

namespace CLogica
{
    public class GestorASN
    {
        private RepositorioASN repositorio;

        public GestorASN()
        {
            repositorio = new RepositorioASN();
        }

        public List<ASN> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }

        public ASN ObtenerPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void Guardar(ASN asn)
        {
            // Validaciones básicas
            if (asn.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(asn.Lote))
                throw new ArgumentException("El lote es obligatorio.");
            if (string.IsNullOrWhiteSpace(asn.NumeroSerie))
                throw new ArgumentException("El número de serie es obligatorio.");
            if (string.IsNullOrWhiteSpace(asn.NumeroFactura))
                throw new ArgumentException("El número de factura es obligatorio.");
            if (string.IsNullOrWhiteSpace(asn.DescripcionProducto))
                throw new ArgumentException("La descripción del producto es obligatoria.");
            if (asn.Id == 0)
                repositorio.Insertar(asn);
            else
                repositorio.Actualizar(asn);
        }

        public void Eliminar(int id)
        {
            repositorio.Eliminar(id);
        }
    }
}
