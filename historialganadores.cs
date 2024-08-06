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
        string nombreArchivo = "historial.json";
    
        if (!File.Exists(nombreArchivo))
        {
            Console.WriteLine("No hay un historial de ganadores disponible.");
            return;
        }

        try
        {
            string json = File.ReadAllText(nombreArchivo);
            List<Character> ganadores = JsonSerializer.Deserialize<List<Character>>(json);

            if (ganadores == null || ganadores.Count == 0)
            {
                Console.WriteLine("No hay ganadores registrados en el historial.");
                return;
            }
            Console.WriteLine("*** Historial de Ganadores ***");
            foreach (var ganador in ganadores)
            {
                Console.WriteLine($"Nombre: {ganador.FirstName} {ganador.LastName}, Casa: {ganador.Family}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mostrar el historial de ganadores: {ex.Message}");
        }
    }
}
