using MediaBooking.API;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
namespace MediaBooking.Screens;

public partial class Acceso : ContentPage
{
	public Acceso()
	{
    InitializeComponent();
    }

    private async void Button_Huella(object sender, EventArgs e)
    {
        var request = new AuthenticationRequestConfiguration("Demo de Autenticaci�n", "Toque el sensor de huella digital")
        {
            CancelTitle = "Cancelar",
            FallbackTitle = "Usar Contrase�a",
            AllowAlternativeAuthentication = true
        };

        var availability = await CrossFingerprint.Current.IsAvailableAsync(true);
        if (!availability)
        {
            await DisplayAlert("No disponible", "La autenticaci�n biom�trica no est� disponible o no est� configurada.", "OK");
            return;
        }

        var result = await CrossFingerprint.Current.AuthenticateAsync(request);
        if (result.Authenticated)
        {
            // Recuperar el nombre de usuario y la contrase�a (o token) de forma segura
            var username = await SecureStorage.GetAsync("username");
            var password = await SecureStorage.GetAsync("password");  // Considera cambiar esto por un token si es posible

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                await AuthenticateWithCredentials(username, password);
            }
            else
            {
                await DisplayAlert("Error", "No hay credenciales almacenadas.", "OK");
            }
        }
        else
        {
            if (result.Status == FingerprintAuthenticationResultStatus.Canceled)
            {
                await DisplayAlert("Cancelado", "Autenticaci�n cancelada por el usuario.", "OK");
            }
            else
            {
                await DisplayAlert("No autenticado", "No se pudo autenticar usando la huella digital.", "OK");
            }
        }
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
        await AuthenticateWithCredentials(NombreUsuario.Text, ClaveUsuario.Text);
    }

    public async Task AuthenticateWithCredentials(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("�Advertencia!", "Debe llenar todos los campos", "OK");
        }
        else
        {
            UsuarioController usuarioController = new UsuarioController();
            var usuarioAutenticado = await usuarioController.AuthenticateUsuarioAsync(username, password);

            if (usuarioAutenticado != null)
            {
                // Almacenar las credenciales de forma segura si el inicio de sesi�n es exitoso
                await SecureStorage.SetAsync("username", username);
                await SecureStorage.SetAsync("password", password);  // Aunque es mejor guardar un token de acceso en lugar de la contrase�a

                MediaBooking.Secciones.Usuario.NombreUsuario = usuarioAutenticado.nombre;

                switch (usuarioAutenticado.rol)
                {
                    case "Administrador":
                        Application.Current.MainPage = new FlyoutMenu();
                        break;
                    case "Usuario":
                        Application.Current.MainPage = new FlyoutUsuario();
                        break;
                    default:
                        Application.Current.MainPage = new FlyoutEstudiante();
                        break;
                }

                UserDataService.CurrentUser = usuarioAutenticado;
            }
            else
            {
                await DisplayAlert("�Error!", "Usuario o contrase�a incorrecta", "OK");
            }
        }
    }


}