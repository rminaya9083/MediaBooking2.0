using System.Net.Mail;
using System.Net;
namespace MediaBooking.Pages;

public partial class Reservaciones : ContentPage
{
	public Reservaciones()
	{
		InitializeComponent();
	}

    //async void OnButtonClicked(object senders, EventArgs args)
    //{
    //    string mail = correo.text;
    //    string estudiante = matricula.text, fecha=horario.text , aula2 = aula.text, articulo2 = articulo.text;

    //    string cuerpo = @"<style>
    //                        h1{color:#1E8449;}
    //                        h2{color:#45B39D;}
    //                        </style>
    //                        <h1>Confirmaci&oacute;n de Reservaci&oacute;n Realizada</h1></br>
    //                        <h2>Le confirmamos que fue ejecutada correctamente la reservaci&oacute;n realizada por la matr&iacute;cula: " + estudiante + ", en fecha: " + fecha + " a utilizarse" +
    //                    " en el aula: " + aula2 + ".<br><br>Art&iacute;culo reservado: " + articulo2 + "</h2>";
    //    sendMail(mail, "Reservación de Recurso Audiovisual - MediaBooking", cuerpo);
    //}

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

    //    }
    //    catch (Exception ex)
    //    {
    //        msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
    //        MessageBox.Show(ex.Message);

    //    }
    //}

}