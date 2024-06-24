using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;



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
        List<Personajes> personajes = JsonConverter.DeserializeObject<List<Personajes>>(responseBody);

        // Usar los objetos Character deserializados
        foreach (var personaje in personajes)
        {
            Console.WriteLine($"Full Name: {personaje.FullName}\nTitle: {personaje.Title}\nFamily: {personaje.Family}\n");
        }
    }
    catch (HttpRequestException e)
    {
        // Manejar posibles errores de la solicitud HTTP
        Console.WriteLine($"Error al realizar la solicitud HTTP: {e.Message}");
    }
}
