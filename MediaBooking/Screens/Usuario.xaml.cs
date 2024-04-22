using MediaBooking.API;
using MediaBooking.Models;
namespace MediaBooking.Screens;

public partial class Usuario : ContentPage
{
    UsuarioController _apiService = new UsuarioController();

    public List<UsuarioClass> listaUsuarios;

    public Usuario()
    {
        InitializeComponent();
    }


    private async void Button_AgregarUsuario(object sender, EventArgs e)
    {
        var addUserPage = new Pages.Usuario();
        addUserPage.Disappearing += (sender, e) => OnAppearing();
        await Navigation.PushAsync(new Pages.Usuario());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadUsuarios();

        userList.ItemsSource = listaUsuarios;
    }


    private async Task LoadUsuarios()
    {
        try
        {
            var todosLosUsuarios = await _apiService.GetUsuariosAsync();
            listaUsuarios = await _apiService.GetUsuariosAsync();

            if (listaUsuarios != null && listaUsuarios.Any())
            {

                listaUsuarios = todosLosUsuarios
                    .Where(u => u.rol == "Usuario" || u.rol == "Administrador")
                    .ToList();

                Console.WriteLine("Conteo: " + listaUsuarios.Count);
                Console.WriteLine(listaUsuarios[0].nombre);
            }
            else
            {
                Console.WriteLine(listaUsuarios);
                await DisplayAlert("Error", "No se encontraron usuarios", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar usuarios: " + ex.Message, "Ok");
        }


    }


}