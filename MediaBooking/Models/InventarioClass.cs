using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.Models
{
    public class InventarioClass
    {
        [Key]
        public int id { get; set; }

        [Column("Cantidad")]
        public int cantidad { get; set; }

        [Column("IdProducto")]
        public int? idproducto { get; set; }  
        
        public string nombreproducto { get; set; }
    }
}
