namespace MediaBooking.Screens;

public partial class TipoProducto : ContentPage
{
	public TipoProducto()
	{
		InitializeComponent();
	}

    private async void Button_TipoProducto(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Pages.TipoProducto());
    }
}