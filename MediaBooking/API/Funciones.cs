using MediaBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.API
{

    public class Funciones
    {
        private UsuarioController _apiService = new UsuarioController();

        public async Task<bool> AgregarUsuario(UsuarioClass usuario)
        {
            return(await _apiService.AddUsuarioAsync(usuario));

        }
    }
}
