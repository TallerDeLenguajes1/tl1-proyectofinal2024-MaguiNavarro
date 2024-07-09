using System.Text.Json.Serialization;
using System;
using System.Text.Json;
using Api;
using JuegoP;
using Historial;


class Juego
{
    static async Task Main(string[] args)
    {
        // Mostrar la presentación
        MostrarPresentacion();

        // URL de la API que deseas consumir
        string apiUrl = "https://thronesapi.com/api/v2/Characters";

        // Obtener personajes desde la API utilizando ApiService
        List<Character> personajes = await ApiService.ObtenerPersonajesDesdeAPI(apiUrl);
         // Verificar si se obtuvieron personajes
        if (personajes == null || personajes.Count == 0)
        {
            Console.WriteLine("No se pudieron obtener personajes de la API. Saliendo del juego.");
            return;
        }

        // Guardar personajes en un archivo JSON
        string nombreArchivo = "personajes.json";
        PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

        // Verificar si el archivo existe y tiene datos
        bool existe = PersonajesJson.Existe(nombreArchivo);
        Console.WriteLine($"El archivo {nombreArchivo} existe y tiene datos: {existe}");

            // Leer personajes desde el archivo JSON
        List<Character> personajesLeidos = PersonajesJson.LeerPersonajes(nombreArchivo);
        Console.WriteLine($"Se leyeron {personajesLeidos.Count} personajes del archivo {nombreArchivo}");

        // Inicializar y comenzar el juego
        JuegoP.JuegoPrincipal juego = new(personajesLeidos);
        juego.IniciarJuego();
    }

    static void MostrarPresentacion()
    {
        string rutaArchivo = "Presentacion.txt";
        if (File.Exists(rutaArchivo))
        {
            string presentacion = File.ReadAllText(rutaArchivo);
            Console.ForegroundColor = ConsoleColor.Cyan; // Color de presentación
            Console.WriteLine(presentacion);
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Archivo de presentación no encontrado.");
        }
    }
}