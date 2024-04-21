using MediaBooking.API;
using MediaBooking.Models;

namespace MediaBooking.Screens;

public partial class Inventario : ContentPage
{

    InventarioService _InventarioService = new InventarioService();

    public List<InventarioClass> listaInventario;

    public Inventario()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadInventario();

        inventarioList.ItemsSource = listaInventario;
    }

    private async Task LoadInventario()
    {
        try
        {
            listaInventario = await _InventarioService.GetInventarioAsync();

            if (listaInventario != null && listaInventario.Any())
            {

                Console.WriteLine("Conteo: " + listaInventario.Count);
                Console.WriteLine("Primer inventario" + listaInventario[0].id);
            }
            else
            {
                Console.WriteLine(listaInventario);
                await DisplayAlert("Error", "No se encontraron inventario", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar inventario: " + ex.Message, "Ok");
        }


    }
}