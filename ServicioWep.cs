using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Servicio
{
    static async Task Main(string[] args)
    {
        // URL de la API que deseo consumir
        string apiUrl = "https://thronesapi.com/api/v2/Characters";
        
        using (HttpClient client = new HttpClient())
        {
            try
            {
              
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); 

                // Leer el contenido de la respuesta como una cadena
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON a una lista de objetos Character
                List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(responseBody);

                // Usar los objetos Character deserializados
                foreach (var character in characters)
                {
                    Console.WriteLine($"Full Name: {character.FullName}\nTitle: {character.Title}\nFamily: {character.Family}\n");
                }
            }
            catch (HttpRequestException e)
            {
                // Manejar posibles errores de la solicitud HTTP
                Console.WriteLine($"Error al realizar la solicitud HTTP: {e.Message}");
            }
        }
    }
}
