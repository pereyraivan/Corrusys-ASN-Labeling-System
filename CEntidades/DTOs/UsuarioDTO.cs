using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Puesto { get; set; }
        public string Contraseña { get; set; }
    }
}
