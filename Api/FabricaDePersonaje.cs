
using System;
using System.Collections.Generic;
namespace Api
{
    

public class FabricaDePersonajes
{
   
    private static readonly List<string> Nombres = new List<string> { "Jon", "Daenerys", "Tyrion", "Arya", "Theon" };
      private static readonly Random Random = new Random();

    public Character CrearPersonajeAleatorio(string familia)
    {
     
        var nombre = Nombres[Random.Next(Nombres.Count)];
      
     

        return new Character
        {
           
            FirstName = nombre,
            Family = familia,
            Velocidad1 = Random.Next(1, 11),
            Destreza1 = Random.Next(1, 6),
            Fuerza1 = Random.Next(1, 11),
            Nivel1 = Random.Next(1, 11),
            Armadura1 = Random.Next(1, 11),
           
        };
    }
}
}
