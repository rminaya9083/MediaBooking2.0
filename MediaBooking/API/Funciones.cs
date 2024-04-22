using MediaBooking.Models;

namespace MediaBooking.API
{

    public class Funciones
    {
        private UsuarioController _apiService = new UsuarioController();
        private TipoProductoService _tipoproducto = new TipoProductoService();
        private ProductoService _productoService = new ProductoService();

        public async Task<bool> AgregarUsuario(UsuarioClass usuario)
        {
            return(await _apiService.AddUsuarioAsync(usuario));

        }

        public async Task<bool> AgregarTipoProducto(TipoProductoClass tipoproducto)
        {
            return (await _tipoproducto.AddTipoProductoAsync(tipoproducto));
        }

        public async Task<bool> AgregarProducto(ProductoClass producto)
        {
            return (await _productoService.AddProductoAsync(producto));
        }
    }
}
