using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MediaBooking.Models
{
    public class ProductoClass
    {
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("IdTipoProducto")]
        public int? IdTipoProducto { get; set; }

        [Column("FechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        

        //[ForeignKey("IdTipoProducto")] // Asegúrate de que esto corresponde al nombre de la columna de FK en la base de datos
        //public virtual TipoProducto TipoProducto { get; set; }
    }
}
