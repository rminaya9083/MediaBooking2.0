using MediaBooking.API;
using MediaBooking.Models;
using System.Text.RegularExpressions;

namespace MediaBooking.Pages;

public partial class Usuario : ContentPage
{
	Funciones fun = new Funciones();


	public Usuario()
	{
		InitializeComponent();




	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();



	}



	private bool Validar()
	{
		if (string.IsNullOrWhiteSpace(user.Text) || string.IsNullOrWhiteSpace(nombre_usuario.Text) || string.IsNullOrWhiteSpace(apellido_usuario.Text) || string.IsNullOrWhiteSpace(password.Text)
			|| string.IsNullOrWhiteSpace(confirm_password.Text) || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(telefono.Text) || string.IsNullOrWhiteSpace(direccion.Text))
		{

			return false;
		}
		else if (!usuario.IsChecked && !admin.IsChecked)
		{
			return false;
		}

		else if (password.Text.Trim() != confirm_password.Text.Trim())
		{
			return false;
		}

		else if (!IsValidEmail(email.Text))
		{
			return false;
		}

		else
		{
			return true;
		}


	}

	private async void OnSubmit(object sender, EventArgs e)
	{
		await DisplayAlert("Funcionando", "Proceso completado", "Ok");
		Console.WriteLine("Funcionando");
		if (!Validar())
		{
			Console.WriteLine("Invaluido");
			return;
		}

		Console.WriteLine("Valido");

		string tipoUsuario = usuario.IsChecked ? "Usuario" : "Administrador";



		UsuarioClass Usuario = new()
		{
			usuario = user.Text.Trim(),
			nombre = nombre_usuario.Text.Trim(),
			apellido = apellido_usuario.Text.Trim(),
			correo = email.Text.Trim(),
			telefono = telefono.Text.Trim(),
			direccion = direccion.Text.Trim(),
			rol = tipoUsuario,
			clave = password.Text.Trim(),

			registro = DateTime.Now,


		};

		bool isAdded = await fun.AgregarUsuario(Usuario);

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

	private bool IsValidEmail(string email)
	{
		try
		{
			// Patrón para la validación básica de un email
			Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
			return regex.IsMatch(email);
		}
		catch (RegexMatchTimeoutException)
		{
			return false;
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
