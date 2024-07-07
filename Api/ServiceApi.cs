// ApiService.cs
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Api { 
public class ApiService
{
    public static async Task<List<Character>> ObtenerPersonajesDesdeAPI(string apiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Character> personajes = JsonSerializer.Deserialize<List<Character>>(responseBody);
                return personajes ;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al obtener personajes desde la API: {e.Message}");
                return new List<Character>();
            }
        }
    }

  }
}