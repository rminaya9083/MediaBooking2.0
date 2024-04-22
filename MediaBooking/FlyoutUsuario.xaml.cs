namespace MediaBooking;

public partial class FlyoutUsuario : Shell
{
	public FlyoutUsuario()
	{
		InitializeComponent();
	}
    private async void Button_CerrarSeccion(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Screens.Acceso());
    }
}