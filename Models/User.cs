using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Models
{
    public class User
    {
        [Key]
        public int usuario_id { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public string? contraseña { get; set; }
        public string? telefono { get; set; }
        public DateOnly? fecha_registro { get; set; }
        public string? estado { get; set; }
    }
}
