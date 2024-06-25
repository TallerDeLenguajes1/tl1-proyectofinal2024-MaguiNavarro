using System.Text.Json.Serialization;
using PersonajeApi;


class Program
{
  static void Main(string[] args)
    {
        // Crear algunos personajes de ejemplo
        List<Character> personajes = new List<Character>
        {
            new Character { Id = 1, FirstName = "Jon", LastName = "Snow", FullName = "Jon Snow", Title = "King in the North", Family = "Stark" },
            new Character { Id = 2, FirstName = "Daenerys", LastName = "Targaryen", FullName = "Daenerys Targaryen", Title = "Mother of Dragons", Family = "Targaryen" }
        };

        // Guardar personajes en un archivo JSON
        string nombreArchivo = "personajes.json";
        PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

        // Verificar si el archivo existe y tiene datos
        bool existe = PersonajesJson.Existe(nombreArchivo);
        Console.WriteLine($"El archivo {nombreArchivo} existe y tiene datos: {existe}");

        // Leer personajes desde el archivo JSON
        List<Character> personajesLeidos = PersonajesJson.LeerPersonajes(nombreArchivo);
        Console.WriteLine($"Se leyeron {personajesLeidos.Count} personajes del archivo {nombreArchivo}");
    }
}
