using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopSoftNetCore.Models
{
    public class UsuarioEntity
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string NombreUsuario { get; set; }
    }
}
