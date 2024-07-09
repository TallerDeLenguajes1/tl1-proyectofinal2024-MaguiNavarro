using System;
using System.Collections.Generic;
using  Api;

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
        jugador = CrearPersonajeAleatorio();
        if (jugador == null)
            { 
                Console.WriteLine($"No se encontraron personajes para la familia {familiaElegida}. Saliendo del juego.");
                return;
            }

            // Seleccionar un oponente aleatorio
            oponente = SeleccionarPersonajeAleatorio();
            if (oponente == null)
            {
                Console.WriteLine("No se pudo seleccionar un oponente. Saliendo del juego.");
                return;
            }

            MostrarDatosPersonaje(jugador);

       


        while (turnosRestantes > 0 && jugador.Salud1 > 0 && oponente.Salud1 > 0)
        {
            Console.WriteLine($"\nTurnos restantes para ganar: {turnosRestantes}");

            TomarDecision();
            EjecutarEventoAleatorio();
            RealizarAtaque(jugador, oponente);

            // Verificar si se ha alcanzado el objetivo de ganar
            if (turnosRestantes == 0)
            {
                Console.WriteLine("\n¡Felicidades! Has mantenido el Trono de Hierro durante cinco turnos consecutivos. ¡Has ganado el juego!");
                break;
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar al siguiente turno...");
            Console.ReadKey();
       

            turnosRestantes--;
        }

        Console.WriteLine("\nFin del juego.");
    }
   public static Character CrearPersonajeAleatorio()
        {
            // Aquí utilizamos la fábrica de personajes para crear un personaje aleatorio
            FabricaDePersonajes fabrica = new();
            string familiaElegida = MostrarMenuYCapturarEleccion(); // Puedes implementar tu propia lógica para elegir la familia
            return fabrica.CrearPersonajeAleatorio(familiaElegida);
        }
    //    public Character SeleccionarPersonaje(string familia)
        // {
        //     List<Character> personajesFamilia = personajes.FindAll(p => p.Family == familia);
        //     if (personajesFamilia.Count == 0)
        //     {
        //         return null;
        //     }
        //     int indiceAleatorio = random.Next(personajesFamilia.Count);
        //     return personajesFamilia[indiceAleatorio];
        // }

    public Character SeleccionarPersonajeAleatorio()
    {
        int indiceAleatorio = random.Next(personajes.Count);
        return personajes[indiceAleatorio];
    }

    private void TomarDecision()
    {
        Console.WriteLine("\nEs tu turno. ¿Qué decisión tomarás?");
        Console.WriteLine("1. Formar alianza");
        Console.WriteLine("2. Movimiento militar");
        Console.WriteLine("3. Gestión de recursos");
        Console.WriteLine("4. Intriga");

        string decision = Console.ReadLine();

    
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

        Console.WriteLine($"\nEvento aleatorio: {eventoAleatorio}");
    }

    private void RealizarAtaque(Character atacante, Character defensor)
    {
        int ataque = atacante.Destreza1 * atacante.Fuerza1 * atacante.Nivel1;
        int efectividad = random.Next(1, 101);
        int defensa = defensor.Armadura1 * defensor.Velocidad1;
        int constanteAjuste = 500;

        int danioProvocado = ((ataque * efectividad) - defensa) / constanteAjuste;

        if (danioProvocado < 0) {
            danioProvocado = 0;
         }

        defensor.Salud1 -= danioProvocado;

        Console.WriteLine($"\n{atacante.FirstName} ataca a {defensor.FirstName}");
        Console.WriteLine($"Daño provocado: {danioProvocado}");
        Console.WriteLine($"{defensor.FirstName} tiene {defensor.Salud1} de salud restante");

        if (defensor.Salud1 <= 0)
        {
            Console.WriteLine($"\n{defensor.FirstName} ha sido derrotado.");
        }
    }

    private static string MostrarMenuYCapturarEleccion()
    {
        Console.WriteLine("Bienvenido al juego de personajes de Juego de Tronos.");
        
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
            Console.WriteLine($"Nivel: {personaje.Nivel1}");
            Console.WriteLine($"Armadura: {personaje.Armadura1}");
            Console.WriteLine($"Salud: {personaje.Salud1}");
        }
   }
}