using MediaBooking.Models;
using MediaBooking.API;


namespace MediaBooking.Screens;

public partial class ReservacionesUsuario : ContentPage
{
    ReservacionesService _ReservacionesService = new ReservacionesService();

    public List<ReservacionesClass> listaReservaciones;

    public ReservacionesUsuario()
	{
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadReservaciones();

        reservacionesList.ItemsSource = listaReservaciones;
    }

    private async Task LoadReservaciones()
    {
        try
        {
            listaReservaciones = await _ReservacionesService.GetReservacionesAsync();

            if (listaReservaciones != null && listaReservaciones.Any())
            {

                Console.WriteLine("Conteo: " + listaReservaciones.Count);
                Console.WriteLine("Primer reservaciones" + listaReservaciones[0].id);
            }
            else
            {
                Console.WriteLine(listaReservaciones);
                await DisplayAlert("Error", "No se encontraron reservaciones", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar reservaciones: " + ex.Message, "Ok");
        }
    }
}