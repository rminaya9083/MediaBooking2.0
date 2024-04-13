
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
            await DisplayAlert("¡Advertencia!","Debe llenar todos los campos","OK");
        } 
        else if (NombreUsuario.Text == "admin" && ClaveUsuario.Text == "123")
        {
            Application.Current.MainPage = new FlyoutMenu();
        }
        else
        {
            await DisplayAlert("¡Error!", "Usuario o contraseña incorrecta", "OK");
        }
    }
}