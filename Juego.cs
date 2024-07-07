using System.Text.Json.Serialization;
using System;
using System.Text.Json;
using Api;

public class Juego
{
    public async Task IniciarAsync()
    
    {  MostrarPresentacion();
        // Crear una instancia de la fábrica de personajes
        FabricaDePersonajes fabrica = new FabricaDePersonajes();

        // Mostrar el menú y capturar la elección del usuario
        string familiaElegida = MostrarMenuYCapturarEleccion();

        // Crear un personaje aleatorio basado en la elección del usuario
        Character personajeAleatorio = fabrica.CrearPersonajeAleatorio(familiaElegida);

        // Mostrar los datos del personaje creado
        MostrarDatosPersonaje(personajeAleatorio);

        // Guardar el personaje aleatorio en un archivo JSON
        string nombreArchivoAleatorio = "Historial_pers.json";
        PersonajesJson.GuardarPersonajes(new List<Character> { personajeAleatorio }, nombreArchivoAleatorio);

        // Verificar si el archivo del personaje aleatorio existe y tiene datos
        bool existeAleatorio = PersonajesJson.Existe(nombreArchivoAleatorio);
        Console.WriteLine($"El archivo {nombreArchivoAleatorio} existe y tiene datos: {existeAleatorio}");

        // Leer el personaje aleatorio desde el archivo JSON
        List<Character> personajeAleatorioLeido = PersonajesJson.LeerPersonajes(nombreArchivoAleatorio);
        Console.WriteLine($"Se leyó el personaje del archivo {nombreArchivoAleatorio}");

        // URL de la API que deseas consumir
        string apiUrl = "https://thronesapi.com/api/v2/Characters";

        // Obtener personajes desde la API utilizando ApiService
        List<Character> personajes = await ApiService.ObtenerPersonajesDesdeAPI(apiUrl);

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
    static void MostrarPresentacion()
    {
        string rutaArchivo = "Presentacion.txt";
        if (File.Exists(rutaArchivo))
        {
            string presentacion = File.ReadAllText(rutaArchivo);
            // Cambiar el color del texto a un solo color para todo el contenido
            Console.ForegroundColor = ConsoleColor.Cyan; // Elige el color que prefieras
            Console.WriteLine(presentacion);
            // Restablecer el color de la consola al color predeterminado
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Archivo de presentación no encontrado.");
        }
    }
   

    static string MostrarMenuYCapturarEleccion()
    {   Console.WriteLine("Bienvenido al juego de personajes de Juego de Tronos.");
    
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