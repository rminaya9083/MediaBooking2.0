using MediaBooking.API;
namespace MediaBooking.Screens;

public partial class Acceso : ContentPage
{
	public Acceso()
	{
    InitializeComponent();
    }

    private async void Button_Huella(object sender, EventArgs e)
    {
       
       DisplayAlert("Error", "La autenticación mediante huella digital ha fallado", "OK");

    }

    private void Button_MostrarOcultar(object sender, EventArgs e)
    {
        ClaveUsuario.IsPassword = !ClaveUsuario.IsPassword;

        if (ClaveUsuario.IsPassword)
        {
            MostrarOjo.ImageSource = "ocultaracceso.png";
        }
        else
        {
            MostrarOjo.ImageSource = "mostraracceso.png";
        }
    }

    private async void Button_Entrar(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NombreUsuario.Text) || string.IsNullOrEmpty(ClaveUsuario.Text))
        {
            await DisplayAlert("¡Advertencia!", "Debe llenar todos los campos", "OK");
        }
        else
        {
            UsuarioController usuarioController = new UsuarioController();
            var usuarioAutenticado = await usuarioController.AuthenticateUsuarioAsync(NombreUsuario.Text, ClaveUsuario.Text);

            if (usuarioAutenticado != null)
            {

                if (usuarioAutenticado.rol == "Administrador")
                {
                    Application.Current.MainPage = new FlyoutMenu();
                }
                else if (usuarioAutenticado.rol == "Usuario")
                {
                    Application.Current.MainPage = new FlyoutUsuario();
                }
                else
                {
                    Application.Current.MainPage = new FlyoutEstudiante();
                }

                UserDataService.CurrentUser = usuarioAutenticado;
            }
            else
            {
                await DisplayAlert("¡Error!", "Usuario o contraseña incorrecta", "OK");
            }
        }
    }
}