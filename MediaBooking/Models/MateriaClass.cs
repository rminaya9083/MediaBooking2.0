using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace MediaBooking.Models
{
    public class MateriaClass
    {
        [Key]
        public int id { get; set; }

        [Column("Codigo")]
        public string codigo { get; set; }

        [Column("Nombre")]
        public string nombre { get; set; }

        [Column("Dia")]
        public string dia { get; set; }

        [Column("HoraInicio")]
        public TimeOnly horainicio { get; set; }

        [Column("HoraFin")]
        public TimeOnly horafin { get; set; }

        [Column("IdProfesor")]
        public int idprofesor { get; set; }

        [Column("IdEstudiante")]
        public int idestudiante { get; set; }
        [Column("Curso")]
        public string curso { get; set; }

        public string CodigoYDia => $"{codigo} - {dia} - {horainicio} - {horafin}";
    }
}
