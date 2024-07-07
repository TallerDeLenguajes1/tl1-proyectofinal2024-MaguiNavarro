using System;
using System.Collections.Generic;

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
        turnosRestantes = 5; // Definimos que se necesitan 5 turnos consecutivos para ganar
    }

    public void IniciarJuego()
    {
        Console.WriteLine("Bienvenido al juego del Trono de Hierro.");
        jugador = SeleccionarPersonaje();
        oponente = SeleccionarPersonajeAleatorio(); // Selecciona un oponente aleatorio

        Console.WriteLine($"Has elegido a {jugador.FirstName} de la casa {jugador.Family}.");

        while (turnosRestantes > 0 && jugador.Salud > 0 && oponente.Salud > 0)
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
            Console.Clear();

            turnosRestantes--;
        }

        Console.WriteLine("\nFin del juego.");
    }