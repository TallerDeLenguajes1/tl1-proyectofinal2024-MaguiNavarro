using System.Text.Json.Serialization;
using System;
using Api;
using JuegoP;
using Historial;
public class Program 
{  
     static async Task Main(string[] args)
    {
        // Mostrar la presentación
    
    
        
        JuegoPrincipal.MostrarBienvenida();

            while (true)
            {
                JuegoPrincipal.MostrarMenuInicial();
                string eleccion = Console.ReadLine();

                if (eleccion == "1")
                {
                  JuegoPrincipal.MostrarPresentacion();
                    // URL de la API que deseas consumir
                    string apiUrl = "https://thronesapi.com/api/v2/Characters";

                    // Obtener personajes desde la API
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

                    // Inicializar y comenzar el juego
                    JuegoPrincipal juego = new JuegoPrincipal(personajesLeidos);
                    juego.IniciarJuego();
                }
                else if (eleccion == "2")
                {    
                      Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("GRACIAS POR JUGAR. ¡HASTA LA PROXIMA!");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, elige una opción válida.");
                }
            }
        }

    
 
 
 
 }
 
