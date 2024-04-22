namespace MediaBooking;

public partial class FlyoutEstudiante : Shell
{ 

    public FlyoutEstudiante()
	{
        InitializeComponent();
    }

    private async void Button_CerrarSeccion(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Screens.Acceso());
    }
}