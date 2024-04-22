using MediaBooking.API;
using MediaBooking.Models;


namespace MediaBooking.Pages;

public partial class Producto : ContentPage
{
	TipoProductoService _tipoService = new TipoProductoService();

    ProductoService _productoService = new ProductoService();

	public List<TipoProductoClass> listaTipos;
	public Producto()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTipos();
    }

    private async Task LoadTipos()
    {
        try
        {
            listaTipos = await _tipoService.GetTipoProductoAsync();

            if (listaTipos != null && listaTipos.Any())
            {

                Console.WriteLine("Conteo: " + listaTipos.Count);
                Console.WriteLine(listaTipos[0].nombre);
                tipo.ItemsSource = listaTipos;
                tipo.ItemDisplayBinding = new Binding("nombre");

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar los tipos de productos: " + ex.Message, "Ok");
        }


    }

    private async void OnSubmit(object sender, EventArgs e)
    {

        if (!Validar(parent))
        {
            return;
        }
        TipoProductoClass elegido = tipo.SelectedItem as TipoProductoClass;
        ProductoClass producto = new (){
            Nombre = nombre_producto.Text.Trim(),
            IdTipoProducto = elegido.id,
            Descripcion = descripcion.Text.Trim()
        };


        bool isAdded = await _productoService.AddProductoAsync(producto);

        if (isAdded)
        {
            await DisplayAlert("Producto agregado correctamente", "Proceso completado", "Ok");
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

    private bool Validar(IView root)
    {
        // Esta variable asume que todo es válido, y cambiará si encuentra algún problema
        bool isValid = true;

        if (root is Layout layout)
        {
            // Recorre todos los hijos de este layout
            foreach (var child in layout.Children)
            {
                // Utiliza el operador &= para combinar los resultados: si alguna llamada retorna false, isValid será false
                isValid &= Validar(child);
            }
        }
        else if (root is Entry entry)
        {
            // Revisa si el texto del Entry está vacío y actualiza isValid
            if (entry.Text == string.Empty)
            {
                isValid = false;
            }
        }
        else if (root is Picker picker)
        {
            // Revisa si el Picker no tiene una selección válida y actualiza isValid
            if (picker.SelectedIndex == -1)
            {
                isValid = false;
            }
        }

        // Retorna el resultado acumulado de todas las validaciones
        return isValid;
    }
}