
using MediaBooking.Models;
using Newtonsoft.Json;
using System.Text;

namespace MediaBooking.API
{
    public class ReservacionesService
    {
        HttpClient _client;

        public ReservacionesService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _client = new HttpClient(handler);
        }

        public async Task<List<ReservacionesClass>> GetReservacionesAsync()
        {
            try
            {
                var response = await _client.GetAsync("https://10.0.2.2:7113/api/Reservaciones");
                if (response.IsSuccessStatusCode)
                {

                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    return JsonConvert.DeserializeObject<List<ReservacionesClass>>(json);

                }
                else
                {
                    // Puedes agregar un mensaje o una acción aquí si el código de estado no indica éxito
                    Console.WriteLine("Error: El servidor respondió con el código de estado " + response.StatusCode);
                    return new List<ReservacionesClass>();
                }
            }
            catch (HttpRequestException e)
            {
                // Manejo de excepciones para errores en la solicitud HTTP
                Console.WriteLine("Error al realizar la solicitud HTTP: " + e.Message);
                return new List<ReservacionesClass>(); ;
            }
            catch (Exception e)
            {
                // Manejo de otras excepciones generales
                Console.WriteLine("Error genérico: " + e.Message);
                return new List<ReservacionesClass>();
            }

        }


        public async Task<bool> AddReservacionAsync(ReservacionClass reservacion)
        {
            try
            {
                var json = JsonConvert.SerializeObject(reservacion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("https://10.0.2.2:7113/api/Reservaciones", content);
                Console.WriteLine(response);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Aquí puedes manejar respuestas que no son de éxito, por ejemplo, 
                    // leyendo el contenido de la respuesta para obtener más detalles del error
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al añadir usuario: {errorContent}");
                    return false;
                }
            }
            catch (HttpRequestException e)
            {
                // Manejo de excepciones de solicitudes HTTP
                Console.WriteLine($"Error en la solicitud HTTP: {e.Message}");
                return false;
            }
            catch (Exception e)
            {
                // Manejo de otras excepciones generales
                Console.WriteLine($"Error genérico: {e.Message}");
                return false;
            }
        }


    }
}
