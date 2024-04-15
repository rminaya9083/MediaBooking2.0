using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.Models
{
    public class UsuarioClass
    {
        [Key]
        public int id_usuario { get; set; }

        public string usuario { get; set; }
        public string nombre_usuario { get; set; }

        public string apellido_usuario { get; set; }

        public string correo_usuario { get; set; }

        public string telefono_usuario { get; set; }

        public string direccion_usuario { get; set; }

        public string clave_usuario { get; set; }

        public string tipo_usuario { get; set; }
    }
}
