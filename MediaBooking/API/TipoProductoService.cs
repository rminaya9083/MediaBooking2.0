﻿using MediaBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.API
{
    class TipoProductoService
    {
        HttpClient _client;

        public TipoProductoService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _client = new HttpClient(handler);

        }

        public async Task<List<TipoProductoClass>>GetTipoProductoAsync()
        {
            try
            {
                var response = await _client.GetAsync("https://10.0.2.2:7113/api/TipoProducto");
                if (response.IsSuccessStatusCode)
                {

                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                    return JsonConvert.DeserializeObject<List<TipoProductoClass>>(json);

                }
                else
                {
                    // Puedes agregar un mensaje o una acción aquí si el código de estado no indica éxito
                    Console.WriteLine("Error: El servidor respondió con el código de estado " + response.StatusCode);
                    return new List<TipoProductoClass>();
                }
            }
            catch (HttpRequestException e)
            {
                // Manejo de excepciones para errores en la solicitud HTTP
                Console.WriteLine("Error al realizar la solicitud HTTP: " + e.Message);
                return new List<TipoProductoClass>(); ;
            }
            catch (Exception e)
            {
                // Manejo de otras excepciones generales
                Console.WriteLine("Error genérico: " + e.Message);
                return new List<TipoProductoClass>();
            }
        }
    }
}