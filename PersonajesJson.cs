using System.Text.Json.Serialization;
using System;
using System.Text.Json;
using System.IO;
using PersonajeApi;

public class PersonajesJson{
     public static void GuardarPersonajes(List<Character> personajes, string nombreArchivo)
    {
        try
        {
            var opcionesJson = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(personajes, opcionesJson);
            File.WriteAllText(nombreArchivo, json);
            Console.WriteLine($"Personajes guardados en {nombreArchivo}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar personajes: {ex.Message}");
        }
    }

    public static List<Character> LeerPersonajes(string nombreArchivo)
    {
        try
        {
            if (!File.Exists(nombreArchivo))
            {
                Console.WriteLine($"El archivo {nombreArchivo} no existe.");
                return new List<Character>();
            }

            string json = File.ReadAllText(nombreArchivo);
            List<Character> personajes = JsonSerializer.Deserialize<List<Character>>(json);
            return personajes ;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer personajes: {ex.Message}");
            return new List<Character>();
        }
    }

    public static bool Existe(string nombreArchivo)
    {
        try
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar la existencia del archivo: {ex.Message}");
            return false;
        }
    }
}
