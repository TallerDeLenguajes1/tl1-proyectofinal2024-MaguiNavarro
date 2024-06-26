using System.Text.Json.Serialization;
using PersonajeApi;
using ServicioApi;

class Program
{
  static void Main(string[] args)
    {
       
          // Crear una instancia de la fábrica de personajes
        FabricaDePersonajes fabrica = new FabricaDePersonajes();

        // Mostrar el menú y capturar la elección del usuario
        string familiaElegida = MostrarMenuYCapturarEleccion();

        // Crear un personaje aleatorio basado en la elección del usuario
        Character personajeAleatorio = fabrica.CrearPersonajeAleatorio(familiaElegida);

        // Mostrar los datos del personaje creado
        MostrarDatosPersonaje(personajeAleatorio);
       
        // Guardar personajes en un archivo JSON
        string nombreArchivo = "personajes.json";
        PersonajesJson.GuardarPersonajes(new List<Character> { personajeAleatorio }, nombreArchivo);

        // Verificar si el archivo existe y tiene datos
        bool existe = PersonajesJson.Existe(nombreArchivo);
        Console.WriteLine($"El archivo {nombreArchivo} existe y tiene datos: {existe}");

        // Leer personajes desde el archivo JSON
        List<Character> personajesLeidos = PersonajesJson.LeerPersonajes(nombreArchivo);
        Console.WriteLine($"Se leyeron {personajesLeidos.Count} personajes del archivo {nombreArchivo}");
    }
    static string MostrarMenuYCapturarEleccion()
    {
        Console.WriteLine("Seleccione la casa a la que le gustaría pertenecer:");
        Console.WriteLine("1. Stark");
        Console.WriteLine("2. Targaryen");
        Console.WriteLine("3. Lannister");
        Console.WriteLine("4. Baratheon");
        Console.WriteLine("5. Greyjoy");

        string eleccion = Console.ReadLine();
        string familia = eleccion switch
        {
            "1" => "Stark",
            "2" => "Targaryen",
            "3" => "Lannister",
            "4" => "Baratheon",
            "5" => "Greyjoy",
            _ => "Stark" // Valor predeterminado
        };

        return familia;
    }

    static void MostrarDatosPersonaje(Character personaje)
    {
        Console.WriteLine($"Nombre: {personaje.FirstName}");
        Console.WriteLine($"Familia: {personaje.Family}");
        Console.WriteLine($"Velocidad: {personaje.Velocidad1}");
        Console.WriteLine($"Destreza: {personaje.Destreza1}");
        Console.WriteLine($"Fuerza: {personaje.Fuerza1}");
        Console.WriteLine($"Nivel: {personaje.Nivel1}");
        Console.WriteLine($"Armadura: {personaje.Armadura1}");
        Console.WriteLine($"Salud: {personaje.Salud1}");
    }
}

