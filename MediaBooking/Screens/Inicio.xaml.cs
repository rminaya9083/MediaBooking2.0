namespace MediaBooking.Screens;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    private async void Button_AgregarUsuario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.Usuario());
    }

    private async void Button_AgregarProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.Producto());
    }

    private async void Button_AgregarTipoProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.TipoProducto());
    }

    private void Button_Inventario(object sender, EventArgs e)
    {
        DisplayAlert("¡Advertencia!","En proceso de implementación...","OK");
    }
}