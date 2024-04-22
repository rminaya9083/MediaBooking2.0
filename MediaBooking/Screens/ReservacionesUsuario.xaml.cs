using MediaBooking.Models;
using MediaBooking.API;
namespace MediaBooking.Screens;

public partial class ReservacionesUsuario : ContentPage
{
    ReservacionesService _ReservacionesService = new ReservacionesService();

    public List<ReservacionesClass> listaReservacionesUsuario;

    public ReservacionesUsuario()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadReservacionesUsuario();

        reservacionesUsuarioList.ItemsSource = listaReservacionesUsuario;
    }

    private async Task LoadReservacionesUsuario()
    {
        try
        {
            listaReservacionesUsuario = await _ReservacionesService.GetReservacionesAsync();

            if (listaReservacionesUsuario != null && listaReservacionesUsuario.Any())
            {

                Console.WriteLine("Conteo: " + listaReservacionesUsuario.Count);
                Console.WriteLine("Primer reservaciones" + listaReservacionesUsuario[0].id);
            }
            else
            {
                Console.WriteLine(listaReservacionesUsuario);
                await DisplayAlert("Error", "No se encontraron reservaciones", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar reservaciones: " + ex.Message, "Ok");
        }
    }
}