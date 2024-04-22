using MediaBooking.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaBooking.Models
{
    public class UsuarioClass
    {
        [Key]
        public int id { get; set; }

        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string clave { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string rol { get; set; }

        [Column("FechaRegistro")]
        public DateTime registro { get; set; }

        
    }
}
