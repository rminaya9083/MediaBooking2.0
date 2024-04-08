namespace MediaBooking.Screens;

public partial class Producto : ContentPage
{
	public Producto()
	{
		InitializeComponent();
	}

    private async void Button_AgregarProducto(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Pages.Producto());
    }
}