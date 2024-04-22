using MediaBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.API
{
    public static class UserDataService
    {
        public static UsuarioClass CurrentUser { get; set; }
    }
}
