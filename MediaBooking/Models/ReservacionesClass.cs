using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MediaBooking.Models
{
    public class ReservacionesClass
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

        [Column("Codigo")]
        public string codigo { get; set; }

        [Column("FechaReserva")]
        public DateOnly fechareserva { get; set; }

        public string nombreestudiante { get; set; }
        public string nombreproducto { get; set; }
        public string codigos { get; set; }
        public string nombremateria { get; set; }
        public string curso { get; set; }
        public DateOnly fehcaregistro { get; set; }
        public TimeOnly horainicial { get; set; }
        public TimeOnly horafin {  get; set; }
        public string estatuse { get; set; }
        public string nombreauxiliar { get; set; }
        public string matricula { get; set; }
    }
}
