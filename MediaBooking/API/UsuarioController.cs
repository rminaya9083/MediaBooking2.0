using MediaBooking.Models;
using MediaBooking.Screens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaBooking.API
{
    public class UsuarioController
    {
        HttpClient _client;

        public UsuarioController()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _client = new HttpClient(handler);
            
        }

        public async Task<bool> AddUsuarioAsync(UsuarioClass usuario)
        {
            try
            {
                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("https://10.0.2.2:7113/api/Usuarios", content);
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

        public async Task<List<UsuarioClass>> GetUsuariosAsync()
        {
            try
            {
                var response = await _client.GetAsync("https://10.0.2.2:7113/api/Usuarios");
                if (response.IsSuccessStatusCode)
                {
                    
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    return JsonConvert.DeserializeObject<List<UsuarioClass>>(json);
                    
                }
                else
                {
                    // Puedes agregar un mensaje o una acción aquí si el código de estado no indica éxito
                    Console.WriteLine("Error: El servidor respondió con el código de estado " + response.StatusCode);
                    return new List<UsuarioClass>();
                }
            }
            catch (HttpRequestException e)
            {
                // Manejo de excepciones para errores en la solicitud HTTP
                Console.WriteLine("Error al realizar la solicitud HTTP: " + e.Message);
                return new List<UsuarioClass>();
            }
            catch (Exception e)
            {
                // Manejo de otras excepciones generales
                Console.WriteLine("Error genérico: " + e.Message);
                return new List<UsuarioClass>();
            }
            
        }

        public async Task<UsuarioClass> AuthenticateUsuarioAsync(string username, string password)
        {
            try
            {
                var loginModel = new { Username = username, Password = password };
                var json = JsonConvert.SerializeObject(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("https://10.0.2.2:7113/api/Usuarios/authenticate", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UsuarioClass>(jsonResponse);
                }
                else
                {
                    // Log o manejo de errores específicos
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error al autenticar usuario: {errorContent}");
                    return null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error genérico: {e.Message}");
                return null;
            }
        }
    }
}
