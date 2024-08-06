using System;
using System.Collections.Generic;
using  Api;
using Historial;

namespace JuegoP
{
    
 
    public class JuegoPrincipal
{
    private Character jugador;
    private Character oponente;
    private int turnosRestantes;
    private Random random;
    private List<Character> personajes;

    public JuegoPrincipal(List<Character> personajes)
    {
        this.personajes = personajes;
        random = new Random();
        turnosRestantes = 5; // Defino que se necesitan 5 turnos consecutivos para ganar
       
    }

    public void IniciarJuego()
    {
        Console.WriteLine("Bienvenido al juego del Trono de Hierro.");

        // Mostrar menú para seleccionar la casa
         string familiaElegida = MostrarMenuYCapturarEleccion();

        // Seleccionar personaje basado en la casa elegida
        jugador = CrearPersonajeAleatorio(familiaElegida);
        if (jugador == null)
            { 
                Console.WriteLine($"No se encontraron personajes para la familia {familiaElegida}. Saliendo del juego.");
                return;
            }
           jugador.Salud1=100;
            // Seleccionar un oponente aleatorio
            oponente = CrearPersonajeAleatorio(familiaElegida);
            if (oponente == null)
            {     Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No se pudo seleccionar un oponente. Saliendo del juego.");
                return;
            }
            oponente.Salud1= 100;
            MostrarDatosPersonaje(jugador);

       


        while (turnosRestantes > 0 && jugador.Salud1 > 0 && oponente.Salud1 > 0)
        {
              Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nTurnos restantes para ganar: {turnosRestantes}");

            TomarDecision();
            EjecutarEventoAleatorio();
            RealizarAtaque(jugador, oponente);

            // Verificar si se ha alcanzado el objetivo de ganar
            if (turnosRestantes == 0 || oponente.Salud1 <= 0)
            {    
                Console.ForegroundColor = ConsoleColor.Magenta;
               Console.WriteLine("Has mantenido el Trono de Hierro durante cinco turnos consecutivos." ) ;
               MostrarAsciiGanador("TronoAscii.txt");
                  RegistrarGanador(jugador);
           
                break;

            }
              Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nPresiona cualquier tecla para continuar al siguiente turno...");
            Console.ReadKey();
       
            turnosRestantes--;
        }
          Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nFin del juego.");

   
    }

       //Funciones de Bienvenida
         public static void MostrarBienvenida()
        {
  
            string bienvenida = "Bienvenido al Juego de Tronos.\n" +
                                "El juego se sitúa en el continente de Westeros, en el periodo inmediatamente posterior a la muerte de un rey.\n " +
                                "El Trono de Hierro está vacante y varios pretendientes de diferentes casas nobiliarias luchan por reclamarlo.\n";
            Console.ForegroundColor = ConsoleColor.Magenta;
             MostrarTextoLento(bienvenida, 50);
        
            Console.ResetColor();
        }
        public static void MostrarPresentacion()
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
          public static void MostrarTextoLento(string texto, int delay)
        {
            foreach (char c in texto)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine(); // Agrega una nueva línea al final del texto
        }

        public static void MostrarMenuInicial()
        {
            string menu = "  # ------------------------------- #\n" +
                          "  |  # - #                  # - #   |\n" +
                          "  |         MENU PRINCIPAL          |\n" +
                          "  |                                 |\n" +
                          "  |       1. Nueva Partida          |\n" +
                          "  |                                 |\n" +
                          "  |       2. Salir                  |\n" +
                          "  |                                 |\n" +
                          "  |  # - #                  # - #   |\n" +
                          "  # ------------------------------- #\n" +
                          "            Elija una opción:         ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(menu);
            Console.ResetColor();
        }
     
     
      //funcion que crea el ARchivo para registrar el ganador
        private void RegistrarGanador(Character ganador)
        {
            string nombreArchivo = "historial.json";
            List<Character> historial = HistorialJson.Existe(nombreArchivo) ? HistorialJson.LeerDatos<List<Character>>(nombreArchivo) : new List<Character>();
            historial.Add(ganador);
            HistorialJson.GuardarDatos(historial, nombreArchivo);
        }
   public static Character CrearPersonajeAleatorio(string familia)
        {
            // Aquí utilizamos la fábrica de personajes para crear un personaje aleatorio
            FabricaDePersonajes fabrica = new();  
            return fabrica.CrearPersonajeAleatorio(familia);
        }


    public Character SeleccionarPersonajeAleatorio()
    {
        int indiceAleatorio = random.Next(personajes.Count);
        return personajes[indiceAleatorio];
    }

    private void TomarDecision()
    {
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\nEs tu turno. ¿Qué decisión tomarás?");
        Console.WriteLine("1. Formar alianza");
        Console.WriteLine("2. Movimiento militar");
        Console.WriteLine("3. Gestión de recursos");
        Console.WriteLine("4. Intriga");

        string decision = Console.ReadLine();

          Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Has elegido la opción {decision}.");
    }

    private void EjecutarEventoAleatorio()
    {
        // Generar un evento aleatorio y mostrarlo al jugador
        string[] eventos = {
            "Un aliado poderoso se une a tu causa.",
            "Un ataque sorpresa por una de las casas Enemigas",
            "Una disputa interna debilita tus recursos.",
            "Recibes un mensaje enigmático de un rival.",
            "Una plaga afecta a tus tierras, disminuyendo tus recursos."
        };

        int indiceEvento = random.Next(eventos.Length);
        string eventoAleatorio = eventos[indiceEvento];
           Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\nEvento aleatorio: {eventoAleatorio}");
    }

    private void RealizarAtaque(Character atacante, Character defensor)
    {   
     
        int ataque = atacante.Destreza1 * atacante.Fuerza1 * atacante.Nivel1;
        int efectividad = random.Next(20, 100);
        int defensa = defensor.Armadura1 * defensor.Velocidad1;
        int constanteAjuste = 50;

        int danioProvocado = ((ataque * efectividad) - defensa) / constanteAjuste;

       

        defensor.Salud1 -= danioProvocado;
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"\n{atacante.FirstName} ataca a {defensor.FirstName}");
        Console.WriteLine($"Daño provocado: {danioProvocado}");
        Console.WriteLine($"{defensor.FirstName} tiene {defensor.Salud1} de salud restante");

        if (defensor.Salud1 <= 0)
        {      Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n{defensor.FirstName} ha sido derrotado.");
              Console.WriteLine("FELICIDADES GANASTE EL TRONO DE HIERRO!.");

        }
    }

 
   private static string MostrarMenuYCapturarEleccion()
    {
  
       
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("**************************************");
        Console.WriteLine("*   Juego de Tronos - Selección de Casa   *");
        Console.WriteLine("**************************************\n");

   
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Seleccione la casa a la que le gustaría pertenecer:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Stark");
        Console.WriteLine("2. Targaryen");
        Console.WriteLine("3. Lannister");
        Console.WriteLine("4. Baratheon");
        Console.WriteLine("5. Greyjoy");

        // Capturar la elección del usuario
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nIngrese su elección (1-5): ");
        string eleccion = Console.ReadLine();
        string familia = eleccion switch
        {
            "1" => "Stark",
            "2" => "Targaryen",
            "3" => "Lannister",
            "4" => "Baratheon",
            "5" => "Greyjoy",
            _ => "Stark", // Valor predeterminado
             };
             return familia;
        }
 
   public static void MostrarDatosPersonaje(Character personaje)
        {
            if (personaje == null)
            {
                Console.WriteLine("Personaje no encontrado.");
                return;
            }

            Console.WriteLine($"Nombre: {personaje.FirstName}");
            Console.WriteLine($"Familia: {personaje.Family}");
            Console.WriteLine($"Velocidad: {personaje.Velocidad1}");
            Console.WriteLine($"Destreza: {personaje.Destreza1}");
            Console.WriteLine($"Fuerza: {personaje.Fuerza1}");
            Console.WriteLine($"Nivel de defensa: {personaje.Nivel1}");
            Console.WriteLine($"Armadura: {personaje.Armadura1}");
            Console.WriteLine($"Salud: {personaje.Salud1}%");
        }
         private static void  MostrarAsciiGanador(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                string asciiArte = File.ReadAllText(rutaArchivo);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(asciiArte);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Archivo de arte ASCII no encontrado.");
            }
        }
   }
    
   
}