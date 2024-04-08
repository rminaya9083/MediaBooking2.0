namespace MediaBooking;

public partial class FlyoutMenu : Shell
{
	public FlyoutMenu()
	{
		InitializeComponent();
	}

    private async void Button_CerrarSeccion(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new Screens.Acceso());
    }
}