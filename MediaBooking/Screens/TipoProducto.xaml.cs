using MediaBooking.API;
using MediaBooking.Models;
namespace MediaBooking.Screens;

public partial class TipoProducto : ContentPage
{
    TipoProductoService _tipoProductoService = new TipoProductoService();

    public List<TipoProductoClass> listaTipoProducto;

    public TipoProducto()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTipoProducto();

        tipoproductoList.ItemsSource = listaTipoProducto;
    }

    private async Task LoadTipoProducto()
    {
        try
        {
            listaTipoProducto = await _tipoProductoService.GetTipoProductoAsync();

            if (listaTipoProducto != null && listaTipoProducto.Any())
            {

                Console.WriteLine("Conteo: " + listaTipoProducto.Count);
                Console.WriteLine("Primer producto" + listaTipoProducto[0].nombre);
            }
            else
            {
                Console.WriteLine(listaTipoProducto);
                await DisplayAlert("Error", "No se encontraron tipo de proudcto", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar tipo produto: " + ex.Message, "Ok");
        }


    }

    private async void Button_TipoProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.TipoProducto());
    }
}
