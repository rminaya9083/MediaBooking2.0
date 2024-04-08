namespace MediaBooking.Screens;

public partial class Usuario : ContentPage
{
	public Usuario()
	{
		InitializeComponent();
	}

    private async void Button_AgregarUsuario(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Pages.Usuario());
    }
}