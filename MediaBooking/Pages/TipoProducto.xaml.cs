using MediaBooking.API;
using MediaBooking.Models;

namespace MediaBooking.Pages;

public partial class TipoProducto : ContentPage
{
    Funciones fun = new Funciones();

	public TipoProducto()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

    }


    private bool Validar()
	{
		if(string.IsNullOrWhiteSpace(Nombre.Text) || string.IsNullOrWhiteSpace(Descripcion.Text))
		{
			return false;
		}

		return true;
	}


    private async void Agregar(object sender, EventArgs e)
    {
        await DisplayAlert("Funcionando", "Proceso completado", "Ok");
        Console.WriteLine("Funcionando");
        if (Validar()==false)
        {
            Console.WriteLine("Invaluido");
            return;
        }

        Console.WriteLine("Valido");


        TipoProductoClass tipoProducoto = new TipoProductoClass()
        {
            nombre = Nombre.Text.Trim(),
            descripcion = Descripcion.Text.Trim(),


        };

        bool isAdded = await fun.AgregarTipoProducto(tipoProducoto);

        if (isAdded)
        {
            await DisplayAlert("Usuario agregado correctamente", "Proceso completado", "Ok");
            Limpiar(parent);
        }

        else
        {
            await DisplayAlert("Klk, no se pudo na", "Proceso fallido", "Na, pa lante");
        }
    }

    private void Limpiar(IView root)
    {
        if (root is Layout layout)
        {
            foreach (var child in layout.Children)
            {
                Limpiar(child);
            }
        }
        else if (root is Entry entry)
        {
            entry.Text = string.Empty;
        }
    }
}