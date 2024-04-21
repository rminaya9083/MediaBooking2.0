using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MediaBooking.Models
{
    public class TipoProductoClass
    {
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }
    }
}
