using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Api;
public class HistorialDeGanadores
{
    
    public static void MostrarHistorial()
    {
        // Nombre del archivo JSON donde se almacenan los ganadores
        string nombreArchivo = "historial.json";

        // Verificar si el archivo existe
        if (!File.Exists(nombreArchivo))
        {
            Console.WriteLine("No hay un historial de ganadores disponible.");
            return;
        }

        try
        {
            // Leer el contenido del archivo JSON
            string json = File.ReadAllText(nombreArchivo);
            
            // Deserializar la lista de ganadores
            List<Character> ganadores = JsonSerializer.Deserialize<List<Character>>(json);

            // Verificar si la lista de ganadores está vacía
            if (ganadores == null || ganadores.Count == 0)
            {
                Console.WriteLine("No hay ganadores registrados en el historial.");
                return;
            }

            // Mostrar el historial de ganadores
            Console.WriteLine("=== Historial de Ganadores ===");
            foreach (var ganador in ganadores)
            {
                Console.WriteLine($"Nombre: {ganador.FirstName} {ganador.LastName}, Casa: {ganador.Family}");
            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones si ocurre un error al leer o deserializar el archivo
            Console.WriteLine($"Error al mostrar el historial de ganadores: {ex.Message}");
        }
    }
}
