using System.Text.Json.Serialization;
using System;
using System.Text.Json;

class Program
{
  static async Task Main(string[] args)

    {
         Juego juego = new Juego();
        await juego.IniciarAsync();
     }
}

