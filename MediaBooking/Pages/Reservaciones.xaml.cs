using System.Net.Mail;
using System.Net;
using MediaBooking.API;
using MediaBooking.Models;
using Microsoft.Maui.Graphics;

namespace MediaBooking.Pages;

public partial class Reservaciones : ContentPage
{
    ProductoService _productoService = new ProductoService();

    MateriaService _materiaService = new MateriaService();

    ReservacionesService _reservacionService = new ReservacionesService();


    public List<MateriaClass> listaMaterias;

    public List<ProductoClass> listaProductos;
    public Reservaciones()
	{
		InitializeComponent();
	}


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMateriasEquipos();
    }



    private async Task LoadMateriasEquipos()
    {
        try
        {
            listaProductos = await _productoService.GetProductoAsync();
            listaMaterias = await _materiaService.GetMateriasAsync();

            if (listaMaterias != null && listaMaterias.Any())
            {

                Console.WriteLine("Conteo: " + listaMaterias.Count);
                Console.WriteLine(listaMaterias[0].nombre);
                materia.ItemsSource = listaMaterias;
                materia.ItemDisplayBinding = new Binding("CodigoYDia");
                

            }
            
            if(listaProductos != null && listaProductos.Any())
            {
                Console.WriteLine(listaProductos[0].Nombre);
                producto.ItemsSource = listaProductos;

                producto.ItemDisplayBinding = new Binding("Nombre");



            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al cargar usuarios: " + ex.Message, "Ok");
        }



    }

    async void OnButtonClicked(object senders, EventArgs args)
    {

        ProductoClass Producto = producto.SelectedItem as ProductoClass;

        MateriaClass Materia = materia.SelectedItem as MateriaClass;

        int idSolicitante = 3;


        DateOnly fecha_fin = DateOnly.FromDateTime( fecha_pic.Date);


        ReservacionClass reservacion = new()
        {
            
            idsolicitante = idSolicitante,
            idmateria = Materia.id,
            idproducto = Producto.Id,
            estatus = "En proceso",
            idauxiliar = null,
            fechareserva = fecha_fin,
            Usuario = UserDataService.CurrentUser,
            Materias = Materia,
            Producto = Producto,
            Auxiliar = UserDataService.CurrentUser

            
        };

        bool isAdded = await _reservacionService.AddReservacionAsync(reservacion);

        if (isAdded)
        {
            await DisplayAlert("Producto agregado correctamente", "Proceso completado", "Ok");
            
        }

        else
        {
            await DisplayAlert("Klk, no se pudo na", "Proceso fallido", "Na, pa lante");
        }







        /*string mail = correo.Text;
        string estudiante = matricula.Text, fecha="", aula2 = aula.Text, articulo2 = "";

        string cuerpo = @"<style>
                            h1{color:#1E8449;}
                            h2{color:#45B39D;}
                            </style>
                            <h1>Confirmaci&oacute;n de Reservaci&oacute;n Realizada</h1></br>
                            <h2>Le confirmamos que fue ejecutada correctamente la reservaci&oacute;n realizada por la matr&iacute;cula: " + estudiante + ", en fecha: " + fecha + " a utilizarse" +
                        " en el aula: " + aula2 + ".<br><br>Art&iacute;culo reservado: " + articulo2 + "</h2>";
        sendMail(mail, "Reservación de Recurso Audiovisual - MediaBooking", cuerpo);
        */
    }

    //public void sendMail(string correo, string asunto, string cuerpo)
    //{
    //    string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
    //    string origen = "yojannyvp@outlook.es";
    //    string displayName = "MediaBooking - MasterMail";
    //    try
    //    {
    //        MailMessage mail = new MailMessage();
    //        mail.From = new MailAddress(origen, displayName);
    //        mail.To.Add(correo);
    //        mail.Bcc.Add("yojannyvp@gmail.com");

    //        mail.Subject = asunto;
    //        mail.Body = cuerpo;
    //        mail.IsBodyHtml = true;


    //        SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
    //        client.Credentials = new NetworkCredential(origen, "TechFun27112015");
    //        client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


    //        client.Send(mail);
    //        msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

        }
        catch (Exception ex)
        {
            msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            

        }
    }

    private void materia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (materia.SelectedIndex == -1)
        {
            return;

        }

        MateriaClass materia_seleccionada = materia.SelectedItem as MateriaClass;

        aula.Text = materia_seleccionada.curso;






    }
}