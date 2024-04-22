using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.Models
{
    public class ReservacionClass
    {
        [Key]
        public int id_reservacion { get; set; }
        [ForeignKey("Usuario")]
        public int id_usuario { get; set; }
        public virtual UsuarioClass Usuario { get; set; }
        public string nombre_materia { get; set; }
        [ForeignKey("Producto")]
        public int id_producto { get; set; }
        public virtual ProductoClass Producto { get; set; }
        public string telefono_reservacion { get; set; }
        public DateTime hora_inicio_reservacion { get; set; }
        public DateTime hora_final_reservacion { get; set; }
        public string correo_reservacion { get; set; }

    }
}
