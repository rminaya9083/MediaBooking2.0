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
        public int id { get; set; }

        [Column("IdSolicitante")]
        public int? idsolicitante { get; set; }

        [Column("IdMateria")]
        public int? idmateria { get; set; }

        [Column("IdProducto")]
        public int? idproducto { get; set; }

        [Column("Estatus")]
        public string estatus { get; set; }

        [Column("IdAuxiliar")]
        public int? idauxiliar { get; set; }

    

        [Column("FechaReserva")]
        public DateOnly fechareserva { get; set; }


        //Llaves foraneas para poder utilizar los campos de tipoproducto, Esto crea una instancia para crear las relaciones.
        [ForeignKey("IdSolicitante")]
        public UsuarioClass Usuario { get; set; }
        [ForeignKey("IdMateria")]
        public MateriaClass Materias { get; set; }
        [ForeignKey("IdProducto")]
        public ProductoClass Producto { get; set; }
        [ForeignKey("IdAuxiliar")]
        public UsuarioClass Auxiliar { get; set; }

    }
}
