using MediaBooking.API;
using MediaBooking.Models;

namespace MediaBooking.Screens;

public partial class Producto : ContentPage
{
    ProductoService _ProductoService = new ProductoService();

    public List<ProductoClass> listaProducto;

    public Producto()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadProducto();

        productoList.ItemsSource = listaProducto;
    }

    private async void Button_AgregarProducto(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Pages.Producto());
    }

    private async Task LoadProducto()
    {
        try
        {
            listaProducto = await _ProductoService.GetProductoAsync();

            if (listaProducto != null && listaProducto.Any())
            {

                Console.WriteLine("Conteo: " + listaProducto.Count);
                Console.WriteLine("Primer producto" + listaProducto[0].Nombre);
            }
            else
            {
                Console.WriteLine(listaProducto);
                await DisplayAlert("Error", "No se encontraron tipo de proudcto", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar tipo produto: " + ex.Message, "Ok");
        }


    }
}